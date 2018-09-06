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
    public string Titlepage = "";
    public string TitleSimilarproduct = "";
    public string otherSolution = "";
    public string ProductsSimilar = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        favicon.Attributes.Add("href", pathClient + "/favicon.ico");
        StyleTag2.Attributes.Add("href", pathClient + "/Css/templatemo_style.css");
        StyleTag.Attributes.Add("href", pathClient + "/Css/styles.css");
        StyleTag1.Attributes.Add("href", pathClient + "/Css/lightbox_Product_detail.css");
        Titlepage = Global.Resource.GetString("lblTitlepage", Global.ci);
        Titlesptt = Global.Resource.GetString("lblChitietSp", Global.ci);
        TitleSimilarproduct = Global.Resource.GetString("lblSimilarProduct", Global.ci);
        string SQL = "Select ID,Title,(select Name from Menu where ID=Category)as Categoryname ,";
        SQL += "(select Name from MenuSub where ID=CategoryDetail)as CategoryDetailname ,Content,Photo,";
        SQL += "Price,IsShowPrice,Category,DateCreate,intro,TitleE,ContentE,FileAttach,ViewCount,PromotionPrice,IdInput";
        SQL += " from Products a where Status=0 and ID=" + common.ToString(Request.QueryString["id"]);
        IList listProducts = db.getlist(SQL);
        if (listProducts != null && listProducts.Count > 0)
        {
            object[] o = (object[])listProducts[0];
            if (common.ToString(Request.QueryString["l"]) == "0")
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
            if (common.ToString(o[5]) != "")
            {
                checkimages = "1";

                string[] temp = common.ToString(o[5]).Split(',');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == 0)
                    {
                        img += String.Format("<a href=\"{1}\" id=\"main_href\" class=\"lightbox-2\" rel=\"flowers\"><img src=\"{0}\" width=\"280\" height=\"280\" /></a>"
                            , pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts400x400"] + "/" + temp[0]
                            , pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + temp[i]
                            );
                    }
                    else
                    {
                        ListImageThum += String.Format("<a rel=\"flowers\" class=\"lightbox-2\" href=\"{0}\"></a>",
                               pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + temp[i]
                               );
                    }

                }
            }
            string price = "";
            if (common.ToString(o[6]) != "" && common.ToString(o[7]) == "1")
                price = String.Format("<tr><td colspan=\"2\" width=\"100%\"><label>{1}: </label><span>{0}</span></td></tr>", common.ToString(o[6]), Global.Resource.GetString("lblPrice", Global.ci));
            string Promotionprice = "";
            if (common.ToString(o[15]) != "" )
                Promotionprice = String.Format("<tr><td colspan=\"2\" width=\"100%\"><label>{1}: </label><span>{0}</span></td></tr>", common.ToString(o[15]), "Size");
            string listfi = "";
            if (common.ToString(o[13]) != "")
            {
                string[] listfile = common.ToString(o[13]).Split(';');
                for (int i = 0; i < listfile.Length; i++)
                {
                    listfi += String.Format("<p><a style=\"color:red\" href=\"{0}\">{1}</a></p>", pathClient + "/Download1.aspx?id=" + common.ToString(o[0]) + "&name=" + listfile[i], listfile[i]);
                }
            }
            if (listfi != "")
                listfi = "<p><b>Download: </b></p>" + listfi;
            proDetail = String.Format(common.GetTemplate("ProductsDetail.tpl"),
                /*0*/common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[1]) : common.ToString(o[11]),
                /*1*/common.ToString(Request.QueryString["l"]) == "0" ? HttpUtility.HtmlDecode(common.ToString(o[4])) : HttpUtility.HtmlDecode(common.ToString(o[12])),
                /*2*/img,
                /*3*/Global.Resource.GetString("lblDescription", Global.ci),
                /*4*/price,
                /*5*/common.ToString(Request.QueryString["l"]),
                /*6*/common.ToString(o[0]),
                /*7*/Global.Resource.GetString("lblAddtoCart", Global.ci),
                /*8*/pathClient + "/" + Global.l + "/Gio-hang.aspx",
                /*9*/Global.Resource.GetString("lblViewDetailCart", Global.ci),
                /*10*/ListImageThum,
                /*11*/listfi,
                /*12*/Promotionprice,
                /*13*/Global.Resource.GetString("lblId", Global.ci),
                /*14*/common.ToString(o[16])
                );
            String err = "";
            ProductsDB db1 = new ProductsDB();
            int count=1;
            if(common.ToString(o[14])!="")
                count=Convert.ToInt32(common.ToString(o[14]))+1;
            bool t = db1.updateViewCount(ref err, common.ToString(o[0]), count);
        }
        GetProductsSimilar();
    }
    private void GetProductsSimilar()
    {
        ProductsDB db = new ProductsDB();
        string condi = "";
        if (common.ToString(Request.QueryString["cat"]) != "")
            condi += " and Category=" + common.ToString(Request.QueryString["cat"]);
        if (common.ToString(Request.QueryString["id"]) != "")
            condi += " and ID<>" + common.ToString(Request.QueryString["id"]);
        string SQL = "select top " + ConfigurationManager.AppSettings["numFeaturedProducts"] + "  ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE,CategoryDetailSub,PromotionPrice,(select Name from Menu where ID=Category) as NameCat,(select Name from MenuSub where ID=CategoryDetail) as NameCatSub from Products where Photo is not null and Photo <>'' and Status=0 " + condi + " order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            int count = 0;
            string listtemp = "";
            string tempItem = common.GetTemplate("ProductsDefault.tpl");
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                count++;
                string url = common.GetUrlProductDetail(common.ToString(o[1]), common.ToString(o[0]), common.ToString(o[12]), common.ToString(o[6]), common.ToString(o[13]), common.ToString(o[7]), "", "", Global.l);
                string img = "";
                string img400 = "";
                if (common.ToString(o[2]) != "")
                {
                    string[] listimg = common.ToString(o[2]).Split(',');
                    img = pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts190x120"] + "/" + listimg[0];
                    img400 = pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts400x400"] + "/" + listimg[0];
                }
                string price = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    price = String.Format("<p class=\"price\">{1}: {0}</p>", common.ToString(o[3]), Global.Resource.GetString("lblPrice", Global.ci));
                else price = "<p class=\"price\">&nbsp;</p>";
                listtemp += String.Format(tempItem
                    /*0*/ , common.LaySoKyTuCuaChuoi(common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[9]) : common.ToString(o[1]), 15)
                    /*1*/ , url
                    /*2*/ , img
                    /*3*/ , price
                    /*4*/ , img400
                    /*5*/ , ""//count == 3 ? "onmouseover='EditLeft();'" : ""
                    /*6*/ , count == 3 ? "" : "margin_r35"
                    /*7*/ , Global.Resource.GetString("lblChitiet", Global.ci)
                    /*8*/ , Global.Resource.GetString("lblBuyNow", Global.ci)
                    /*9*/ , common.ToString(Request.QueryString["l"])
                    /*10*/, common.ToString(o[0])
                    );

                if (count == 3)
                {
                    listtemp += "<div class=\"cleaner\"></div>";
                    count = 0;
                }
            }
            if (listtemp != "")
            {
                ProductsSimilar = String.Format(common.GetTemplate("ProductsPromotion.tpl")
                        , listtemp
                        , Global.Resource.GetString("lblSimilarProduct", Global.ci)
                        );
            }
        }
       
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
