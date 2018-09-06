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
using System.Text.RegularExpressions;
public partial class products : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string proDetail = "";
    public string sptt = "";
    public string b = "1";
    public string link1 = "";
    public string title = "";
    public string title1 = "";
    public string Titlepage = "";
    public string titleProject = "Products";
    protected void Page_Load(object sender, EventArgs e)
    {
        favicon.Attributes.Add("href", pathClient + "/favicon.ico");
        Titlepage = Global.Resource.GetString("lblTitlepage", Global.ci);
        hdfRecordCount.Value = ConfigurationManager.AppSettings["numProducts"];
        StyleTag1.Attributes.Add("href", pathClient + "/Css/templatemo_style.css");
        StyleTag.Attributes.Add("href", pathClient + "/Css/styles.css");
        if (common.ToString(Request.QueryString["l"]) == "0")
        {
            titleProject = "Sản phẩm";
        }
        sptt = GetProducts(common.ToString(Request.QueryString["catdetail"]), common.ToString(Request.QueryString["cat"]));
    }
    private void setCookie(string name, string value)
    {
        HttpCookie Cookie = new HttpCookie(name);
        DateTime now = DateTime.Now;
        Cookie.Value = value;
        Cookie.Expires = now.AddDays(1);
        Response.Cookies.Add(Cookie);
    }
    private string GetProducts(string catdetail, string cat)
    {
        string ttt = "";
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["numProducts"]);
        int plFirstPage;
        if (Request.QueryString["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.QueryString["pg"]);
        }
        plFirstPage = common.ToString(Request.QueryString["pg"]) != "" ? (int.Parse(common.ToString(Request.QueryString["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        string kw = common.ToString(Request.QueryString["kw"]).Replace("-"," ");
        if (cat != "")
            condi += " and Category=" + cat;
        if (catdetail != "")
            condi += " and CategoryDetail=" + catdetail;
        if (kw != "")
            condi += " and (Title like N'%" + kw + "%' or Content like N'%" + kw + "%' or TitleE like N'%" + kw + "%' or ContentE like N'%" + kw + "%')";

        count = getCountRecord("select count(ID) from Products where Status=0 " + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.QueryString["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }
        if (common.ToString(Request.QueryString["loai"]) == "spmoi")
        {
            rowsOnPage = 10;
            count=10;
            plFirstPage = 10;
        }
        string sql = "Select top " + rowsOnPage.ToString() + " ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE,CategoryDetailSub,PromotionPrice,(select Name from Menu where ID=Category) as NameCat,(select Name from MenuSub where ID=CategoryDetail) as NameCatSub from Products where ID in ( select top " + plFirstPage.ToString() + " ID  from Products where Photo is not null and Photo <>'' and Status=0 " + condi + " order by ID desc)  order by ID asc";
        
        IList listMenu = db.getlist(sql);
        string tempcat = getnameCat();
        string tempcatdetail = getnameCatDetail();
        string tempcatdetailsub = getnameCatDetailSub();
        if (listMenu != null && listMenu.Count > 0)
        {
            int c = 0;
            string listtemp = "";
            string tempItem = common.GetTemplate("ProductsDefault.tpl");
            for (int i = listMenu.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])listMenu[i];
                c++;
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
                    /*6*/ , c == 3 ? "" : "margin_r35"
                    /*7*/ , Global.Resource.GetString("lblChitiet", Global.ci)
                    /*8*/ , Global.Resource.GetString("lblBuyNow", Global.ci)
                    /*9*/ , common.ToString(Request.QueryString["l"])
                    /*10*/, common.ToString(o[0])
                    );

                if (c == 3)
                {
                    listtemp += "<div class=\"cleaner\"></div>";
                    c = 0;
                }
            }

            ttt = "<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + listtemp;
            link1 = common.GetUrlProducts(Global.l, "###");
            if (common.ToString(Request.QueryString["cat"]) != "")
                link1=common.GetUrlCat(tempcat, common.ToString(Request.QueryString["cat"]), Global.l, "###");//temp1 = "cat=" + common.ToString(Request.QueryString["cat"]);
            if (common.ToString(Request.QueryString["catdetail"]) != "")
                link1 = common.GetUrlCatSub(tempcat, common.ToString(Request.QueryString["cat"]), tempcatdetail, common.ToString(Request.QueryString["catdetail"]), Global.l, "###");//"&catdetail=" + Request.QueryString["catdetail"];
            if (common.ToString(Request.QueryString["kw"]) != "")
                link1 = common.GetUrlKeyword(common.ToString(Request.QueryString["kw"]), Global.l, "###"); //"kw=" + common.ToString(Request.QueryString["kw"]);

        }
        if (ttt == "")
        {
            b = "0";
            ttt = Global.Resource.GetString("lblCapnhadulieu", Global.ci) ;
        }

        string link2 = common.GetUrlProducts(Global.l, "1");// pathClient + "/products.aspx" + Global.l + "&pg=1";
      
        title1 = string.Format("<a style=\"text-decoration: none;\" href=\"{0}\">{1}</a>", link2, Global.Resource.GetString("lblProduct1", Global.ci));
        if (tempcat != "")
        {
            title += tempcat;
            link2 = common.GetUrlCat(tempcat, common.ToString(Request.QueryString["cat"]), Global.l, "1");//"&cat=" + common.ToString(Request.QueryString["cat"]);
            title1 += string.Format(" » <a style=\"text-decoration: none;\" href=\"{0}\">{1}</a>", link2, tempcat);
        }
        if (tempcatdetail != "")
        {
            title += " - " + tempcatdetail;
            link2 = common.GetUrlCatSub(tempcat, common.ToString(Request.QueryString["cat"]), tempcatdetail, common.ToString(Request.QueryString["catdetail"]), Global.l, "1");//"&catdetail=" + common.ToString(Request.QueryString["catdetail"]);
            title1 += string.Format(" » <a style=\"text-decoration: none;\" href=\"{0}\">{1}</a>", link2, tempcatdetail);
        }
        
        if (title == "")
            title = Global.Resource.GetString("lblProduct", Global.ci);
        if (common.ToString(Request.QueryString["kw"]) != "")
            title = Global.Resource.GetString("lblResultSearch", Global.ci) +": "+ common.ToString(Request.QueryString["kw"]);
        return ttt;
    }
    private string getnameCat()
    {
        IList listProducts = db.getlist("select Name,NameE from Menu where ID=" + common.ToString(Request.QueryString["cat"]));
         if (listProducts != null && listProducts.Count > 0)
         {
             object[] o = (object[])listProducts[0];
             return common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[0]) : common.ToString(o[1]);
         }
         return "";
    }
    private string getnameCatDetail()
    {
        IList listProducts = db.getlist("select Name,NameE from MenuSub where ID=" + common.ToString(Request.QueryString["catdetail"]));
        if (listProducts != null && listProducts.Count > 0)
        {
            object[] o = (object[])listProducts[0];
            return common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[0]) : common.ToString(o[1]);
        }
        return "";
    }
    private string getnameCatDetailSub()
    {
        IList listProducts = db.getlist("select Name,NameE from MenuSubSub where ID=" + common.ToString(Request.QueryString["catdetailsub"]));
        if (listProducts != null && listProducts.Count > 0)
        {
            object[] o = (object[])listProducts[0];
            return common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[0]) : common.ToString(o[1]);
        }
        return "";
    }
    private int getCountRecord(string sql)
    {
        IList list = db.getlist(sql);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return Convert.ToInt32(o[0]);
        }
        else return 0;
    }
}
