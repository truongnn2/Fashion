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

public partial class Uc_Left : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string ml = "";//<h2 class=\"menuc1\">Danh mục sản phẩm</h2>
    public string productsnew = "";
    public string productshot = "";
    string PathTemp = ConfigurationManager.AppSettings["WebTemplate"];
    public string boxqc = "";
    public string thongkesp = "";
    public string title = "";
    public string Titlesupport = "";
    public string Listsupport = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        title = Global.Resource.GetString("lblTitleCategory", Global.ci);
        Titlesupport = Global.Resource.GetString("lblTitlesupport", Global.ci);
        IList listMenu = db.getlist("Select ID,Name,NameE from Menu where Status=0 order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string menusub = "";
                if (common.ToString(Request.QueryString["cat"]) == common.ToString(o[0]))
                {
                    menusub = GetSubMenu(common.ToString(o[0]));
                }
                ml += String.Format("<li class=\"menuheaders\"><a href=\"{2}\" class=\"{3}\"><span>{0}</span></a>{1}</li>",
                    /*0*/common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[1]) : common.ToString(o[2]),
                    /*1*/menusub,
                    /*2*/pathClient + "/products.aspx"+Global.l+"&pg=1&cat=" + common.ToString(o[0]),
                    /*3*/common.ToString(Request.QueryString["cat"]) == common.ToString(o[0]) ? "current" : ""
                );
            }
        }
        GetOnlineSupport();
       
    }
    private void GetBoxqc()
    {
        BoxAdDB db = new BoxAdDB();
        string SQL = "select ID,Photo,Url from BoxAd where Status=0 and Category=0 order by Location desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string[] listimg = common.ToString(o[1]).Split(',');
                string url = "";
                if (common.ToString(o[2]) != "")
                    url = "http://" + common.ToString(o[2]).Replace("http://", "");
                boxqc += String.Format("<div class=\"box\"><a href=\"javascript:void(0);\"  onclick=\"window.open('{1}');\"><img src=\"{0}\" alt=\"{1}\" /></a></div>", pathClient + "/FileUpload/BoxAd/" + common.ToString(o[0]) + "/" + listimg[0], url);
            }
        }
    }
    private string GetSubMenu(string idMenu)
    {
        string result = "";
        IList listMenu = db.getlist("Select ID,Name,NameE from MenuSub where Status=0 and IDMenu=" + idMenu + " order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = pathClient + "/products.aspx" + Global.l + "&pg=1&cat=" + idMenu + "&catdetail=" + common.ToString(o[0]);
                string cl = "";
                if (common.ToString(Request.QueryString["catdetail"]) == common.ToString(o[0]))
                    cl = "current";
                result += String.Format("<li><a href=\"{1}\" class=\"{2}\"><span>{0}</span></a></li>", 
                    common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[1]) : common.ToString(o[2]), 
                    link, 
                    cl
                    );
            }
            result = "<ul class=\"menucontents\">" + result + "</ul>";
        }
        return result;
    }
    private void GetProductsNew()
    {
        if (ConfigurationManager.AppSettings["IsShowNewProducts"] == "ON")
        {
            ProductsDB db = new ProductsDB();
            string SQL = "select top 10 ID,Photo,Title,Price,IsShowPrice,Category,CategoryDetail from Products where Photo is not null and Photo <>'' and Status=0 order by ID desc";
            IList list = db.getList(SQL);
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    object[] o = (object[])list[i];
                    string[] listimg = common.ToString(o[1]).Split(',');
                    string price = "";
                    if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                        price += String.Format("Giá bán lẻ: <strong class=\"red\">{0} vnđ</strong>", common.ToString(o[3]));
                    else price = String.Format("Giá bán lẻ: <a href=\"{0}\"><strong class=\"red\">Liên hệ</strong></a>", pathClient + "/ContactUs.aspx");
                    productsnew += String.Format(common.GetTemplate("spmoinhat.tpl"),
                        pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts"] + "/" + listimg[0],
                        common.ToString(o[2]),
                        pathClient + "/ProductsDetail.aspx?id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[5]) + "&catdetail=" + common.ToString(o[6]),
                        price
                        );//ConfigurationManager.AppSettings["imageSizeProducts"] + "/" +
                }
                productsnew = "<table> " + productsnew + "</table>";
            }
        }
    }
    private void GetOnlineSupport()
    {
        SupportOnlineDB db = new SupportOnlineDB();
        string SQL = "select ID, Name, NickName, NickSkype, Phone, Status from SupportOnline where Status=0 order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            bool t = true;
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string listyahoo = "";
                string listskype = "";
                if(common.ToString(o[2])!="")
                {
                    string[] tempyh = common.ToString(o[2]).Split(',');
                    for (int j = 0; j < tempyh.Length;j++ )
                    {
                        listyahoo+=String.Format("<a href=\"ymsgr:sendim?{0}&amp;m=\"><img border=\"0\" src=\"http://opi.yahoo.com/online?u={0}&amp;m=g&amp;t=2\" alt=\"{0}\" style=\"padding-top:5px;padding-left:5px;\"></a>"
                            , tempyh[j].Trim()
                            );
                    }
                }
                if (common.ToString(o[3]) != "")
                {
                    string[] tempsp = common.ToString(o[3]).Split(',');
                    for (int j = 0; j < tempsp.Length; j++)
                    {
                        listskype += String.Format("<a href=\"skype:{0}?chat\"><img src=\"http://mystatus.skype.com/bigclassic/{0}\" style=\"border: none;\" width=\"150\" height=\"35\" alt=\"My status\" /></a>"
                            , tempsp[j].Trim()
                            );
                    }
                    if (t)
                    {
                        listskype = "<script type=\"text/javascript\" src=\"http://download.skype.com/share/skypebuttons/js/skypeCheck.js\"></script>" + listskype;
                        t = false;
                    }
                }
                Listsupport += String.Format("<div class=\"YM\">{0} <br />{1}<br /><span>{2}</span></a></div>"
                , common.ToString(o[1])
                , listskype + listyahoo
                , common.ToString(o[4])
                );
            }
        }
    }
    private void GetProductsHot()
    {
        ProductsDB db = new ProductsDB();
        string SQL = "select top 2 ID,Photo,Title,Price,IsShowPrice,Category,CategoryDetail from Products where Photo is not null and Photo <>'' and Status=0 and IsHot=1 order by NewID() desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string[] listimg = common.ToString(o[1]).Split(',');
                string gia = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    gia = "Giá: <span class=\"den bold\">" + common.ToString(o[3]) + "</span>";
                productshot += String.Format(common.GetTemplate("spmoinhat.tpl"), pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts"] + "/" + listimg[0], common.ToString(o[2]), pathClient + "/ProductsDetail.aspx?id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[5]) + "&catdetail=" + common.ToString(o[6]), gia);//ConfigurationManager.AppSettings["imageSizeProducts"] + "/" +
            }
            productshot = "<div class=\"ttLeft\">SẢN PHẨM BÁN CHẠY</div><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" + productshot + "</table>";
        }
    }
    private void ThongKeSP()
    {
        ProductsDB db = new ProductsDB();
        string condi = "";
        if (common.ToString(Request.QueryString["cat"]) != "")
            condi = " and Category=" + common.ToString(Request.QueryString["cat"]);
        else condi = " and Category=0";
        string SQL = "select  top 1 (select count(ID) from Products where Status=0)as countAll,(select count(ID) from Products where Status=0 " + condi + " )as countCat from Products ";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            string cat = "";
            if (common.ToString(Request.QueryString["cat"]) != "")
                cat = String.Format(" Có <strong>{0}</strong> sản phẩm cùng loại<br/>",common.ToString(o[1]));
            thongkesp = String.Format(" Có <strong>{0}</strong> sản phẩm<br />{1}", common.ToString(o[0]),cat);
        }
    }
}
