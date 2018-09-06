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

public partial class MenuGioiThieu : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string ml = "";//<h2 class=\"menuc1\">Danh mục sản phẩm</h2>
    public string productsnew = "";
    public string productshot = "";
    string PathTemp = ConfigurationManager.AppSettings["WebTemplate"];
    public string boxqc = "";
    public string thongkesp = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        IList listMenu = db.getlist("Select ID,Title from GioiThieu where Status=0 order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = pathClient + "/About.aspx?id=" + common.ToString(o[0]);
                string cl = "";
                ml += String.Format("<li><a href=\"{1}\" class=\"{2}\">{0}</a></li>", common.ToString(o[1]), link, "");
            }
            ml = String.Format("<h3 class=\"headerbar at\">{0}</h3><ul class=\"submenu\">{1}</ul>", "Giới thiệu", ml);
        }
        LinkWebsiteDB db1 = new LinkWebsiteDB();
        IList list = db1.getList("Select Url,Website from LinkWebsite where Status=0");
        common.ShowCombobox(linkwebsite, list, "", "");
        GetBoxqc();
        if (ConfigurationManager.AppSettings["IsShowTKe"] != "ON")
        {
            boxtk.Attributes.Add("style", "display:none");
        }
        else
            ThongKeSP();
       GetProductsNew();
       
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
        IList listMenu = db.getlist("Select ID,Name from MenuSub where Status=0 and IDMenu=" + idMenu + " order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = pathClient + "/products.aspx?pg=1&cat=" + idMenu + "&catdetail=" + common.ToString(o[0]);
                string cl = "";
                if (common.ToString(Request.QueryString["catdetail"]) == common.ToString(o[0]))
                    cl = "atx";
                result += String.Format("<li><a href=\"{1}\" class=\"{2}\">{0}</a></li>", common.ToString(o[1]), link, cl);
            }
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
