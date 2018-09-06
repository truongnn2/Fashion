using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DBBusiness;
using System.IO;
using System.Collections;
using Common;

public partial class ProductsDetail : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string proDetail = "";
    public string sptt = "";
    public string menuname = "";
    public string title = "";
    public string checkimages = "";
    public string listimages = "";
    public string content = "";
    public string Titlesptt = "";
    public string TitleSimilarproduct = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Titlesptt = Global.Resource.GetString("lblChitietSp", Global.ci);
        TitleSimilarproduct = Global.Resource.GetString("lblSimilarProduct", Global.ci);
        string SQL = "Select ID,Title,(select Name from Menu where ID=Category)as Categoryname ,";
        SQL += "(select Name from MenuSub where ID=CategoryDetail)as CategoryDetailname ,Content,Photo,";
        SQL += "Price,IsShowPrice,Category,DateCreate,intro,TitleE,ContentE";
        SQL+=" from Products a where Status=0 and ID=" + common.ToString(Request.QueryString["id"]);
        IList listProducts = db.getlist(SQL);
        if (listProducts != null && listProducts.Count > 0)
        {
            object[] o = (object[])listProducts[0];
            if (common.ToString(Request.QueryString["l"]) == "")
                title = common.ToString(o[1]);
            else
                title = common.ToString(o[11]);
            string tempcat = common.ToString(o[2]);
            string tempcatdetail = common.ToString(o[3]);
            if (tempcat != "")
                menuname += tempcat;
            if (tempcatdetail != "")
                menuname += " - " + tempcatdetail;
            string img = "";
            string ListImageThum = "";
            if(common.ToString(o[5])!="")
            {
                checkimages = "1";
                
                string[] temp = common.ToString(o[5]).Split(',');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == 0)
                    {
                        img += String.Format("<a href=\"{1}\" id=\"main_href\" class=\"lightbox-2\" rel=\"flowers\"><img src=\"{0}\" width=\"260\" height=\"260\" /></a>"
                            , pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts260x260"] + "/" + temp[0]
                            ,pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + temp[i]
                            );
                    }
//                     else if (i < 5)
//                     {
//                         ListImageThum += String.Format("<a rel=\"flowers\" class=\"lightbox-2\" href=\"{0}\"><img style=\"border-left: 1px solid #CCCCCC;border-top: 1px solid #CCCCCC;border-bottom: 1px solid #CCCCCC;{2}\"  height=\"100px\" border=\"0\" width=\"100px\" src=\"{1}\"></a>",
//                             pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + temp[i],
//                             pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts"] + "/" + temp[i],
//                             (i == 4||i==temp.Length-1) ? "border-right: 1px solid #CCCCCC;" : ""
//                             );
//                     }
                    else
                    {
                        ListImageThum += String.Format("<a rel=\"flowers\" class=\"lightbox-2\" href=\"{0}\"></a>",
                               pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + temp[i]
                               );
                    }

                }
//                 listimages = String.Format(common.GetTemplate("ProductsDetail_Images.tpl"),
//                     PathImageMain,
//                     ListImageThum
//                     );
            }
            string price = "";
            if (common.ToString(o[6]) != "" && common.ToString(o[7]) == "1")
                price = String.Format("<tr><td width=\"26%\"><label>{1}:</label></td><td width=\"74%\"><span>{0}</span></td></tr>", common.ToString(o[6]), Global.Resource.GetString("lblPrice", Global.ci));
            proDetail = String.Format(common.GetTemplate("ProductsDetail.tpl"),
                /*0*/common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[1]) : common.ToString(o[11]),
                /*1*/common.ToString(Request.QueryString["l"]) == "" ? HttpUtility.HtmlDecode(common.ToString(o[4])) : HttpUtility.HtmlDecode(common.ToString(o[12])),
                /*2*/img,
                /*3*/Global.Resource.GetString("lblDescription", Global.ci),
                /*4*/price,
                /*5*/common.ToString(Request.QueryString["l"]),
                /*6*/common.ToString(o[0]),
                /*7*/Global.Resource.GetString("lblAddtoCart", Global.ci),
                /*8*/pathClient + "/Giohang.aspx" + Global.l,
                /*9*/Global.Resource.GetString("lblViewDetailCart", Global.ci),
                /*10*/ListImageThum
                );
        }
        sptt = GetProducts(common.ToString(Request.QueryString["cat"]));
    }
    private string GetProducts(string cat)
    {
        string sp = "";
        string condi = "";
        if (cat != "")
            condi += " and Category=" + cat;
        if(common.ToString(Request.QueryString["id"])!="")
            condi += " and ID<>" + common.ToString(Request.QueryString["id"]);

        IList listMenu = db.getlist("Select top 15 ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE from Products where Photo is not null and Photo <>'' and Status=0 " + condi + " order by ID desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            int c = 0;
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[6]) + "&catdetail=" + common.ToString(o[7]);
                string[] listimg = common.ToString(o[2]).Split(',');
                c++;
                string price = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    price = String.Format("<span>{1}: <font>{0}</font></span>", common.ToString(o[3]), Global.Resource.GetString("lblPrice", Global.ci));
                sp += String.Format(common.GetTemplate("SanphamClient.tpl"),
                    /*0*/common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[1]) : common.ToString(o[9]),
                    /*1*/link,
                    /*2*/pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts"] + "/" + listimg[0],
                    /*3*/price,
                    /*4*/common.ToString(o[0]),
                    /*5*/Global.Resource.GetString("lblOrder", Global.ci),
                    /*6*/common.ToString(Request.QueryString["l"])
                    );
                if (c == 3)
                {
                    sp += "<li style=\"width: 520px; padding: 0pt 10px 0px;\"></li>";
                    c = 0;
                }
            }

        }
        else
        {
            sp = "<li style=\"width:300px;\">" + Global.Resource.GetString("lblNodata1", Global.ci) + "</li>";
        }
        return sp;
    }
    private string getnameCat()
    {
        IList listProducts = db.getlist("select Name from Menu where ID=" + common.ToString(Request.QueryString["cat"]));
        if (listProducts != null && listProducts.Count > 0)
        {
            object[] o = (object[])listProducts[0];
            return common.ToString(o[0]);
        }
        return "";
    }
    private string getnameCatDetail()
    {
        IList listProducts = db.getlist("select Name from MenuSub where ID=" + common.ToString(Request.QueryString["catdetail"]));
        if (listProducts != null && listProducts.Count > 0)
        {
            object[] o = (object[])listProducts[0];
            return common.ToString(o[0]);
        }
        return "";
    }
}
