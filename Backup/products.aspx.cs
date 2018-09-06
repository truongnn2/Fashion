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

public partial class products : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string proDetail = "";
    public string sptt = "";
    public string b = "1";
    public string link1 = "";
    public string title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        hdfRecordCount.Value = ConfigurationManager.AppSettings["numProducts"];
        setCookie("url", common.ToString(Request.Url));
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
        if (cat != "")
            condi += " and Category=" + cat;
        if (catdetail != "")
            condi += " and CategoryDetail=" + catdetail;
        if (common.ToString(Request.QueryString["kw"]) != "")
            condi += " and (Title like N'%" + common.ToString(Request.QueryString["kw"]) + "%' or Content like N'%" + common.ToString(Request.QueryString["kw"]) + "%' or TitleE like N'%" + common.ToString(Request.QueryString["kw"]) + "%' or ContentE like N'%" + common.ToString(Request.QueryString["kw"]) + "%')";

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
        string sql = "Select top " + rowsOnPage.ToString() + " ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE from Products where ID in ( select top " + plFirstPage.ToString() + " ID  from Products where Photo is not null and Photo <>'' and Status=0 " + condi + " order by ID desc)  order by ID asc";
        
        IList listMenu = db.getlist(sql);
        if (listMenu != null && listMenu.Count > 0)
        {
            int c = 0;
            for (int i = listMenu.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])listMenu[i];
                c++;
                string link = pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[6]) + "&catdetail=" + common.ToString(o[7]);
                string[] listimg = common.ToString(o[2]).Split(',');
                string price = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    price = String.Format("<span>{1}: <font>{0}</font></span>", common.ToString(o[3]), Global.Resource.GetString("lblPrice", Global.ci));
                ttt += String.Format(common.GetTemplate("SanphamClient.tpl"),
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
                    ttt += "<li style=\"width: 520px; padding: 0pt 10px 0px;\"></li>";
                    c = 0;
                }
            }
          
            ttt = "<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + ttt;
            string temp1 = "";
            if (common.ToString(Request.QueryString["cat"]) != "")
                temp1 = "cat=" + common.ToString(Request.QueryString["cat"]);
            if (common.ToString(Request.QueryString["catdetail"]) != "")
                temp1 +="&catdetail=" + Request.QueryString["catdetail"];
            if (common.ToString(Request.QueryString["kw"]) != "")
                temp1 = "kw=" + common.ToString(Request.QueryString["kw"]);
            else if (common.ToString(Request.QueryString["loai"]) == "spmoi")
                temp1 = "loai=spmoi";
            link1 = pathClient + "/products.aspx" + Global.l + "&" + temp1 + "&pg=";
        }
        if (ttt == "")
        {
            b = "0";
            ttt = "<li style=\"width:300px;\">" + Global.Resource.GetString("lblNodata1", Global.ci) + "</li>";
        }
        
        
        string tempcat=getnameCat();
        string tempcatdetail = getnameCatDetail();
        if (tempcat != "")
            title += tempcat;
        if (tempcatdetail != "")
            title += " - "+tempcatdetail;
        if (title == "")
            title = Global.Resource.GetString("lblProduct", Global.ci);
        if (common.ToString(Request.QueryString["kw"]) != "")
            title = Global.Resource.GetString("lblResultSearch", Global.ci) +": "+ common.ToString(Request.QueryString["kw"]);
//         if (common.ToString(Request.QueryString["loai"]) == "spmoi")
//             title = "Sản phẩm mới";
        return ttt;
    }
    private string getnameCat()
    {
        IList listProducts = db.getlist("select Name,NameE from Menu where ID=" + common.ToString(Request.QueryString["cat"]));
         if (listProducts != null && listProducts.Count > 0)
         {
             object[] o = (object[])listProducts[0];
             return common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[0]) : common.ToString(o[1]);
         }
         return "";
    }
    private string getnameCatDetail()
    {
        IList listProducts = db.getlist("select Name,NameE from MenuSub where ID=" + common.ToString(Request.QueryString["catdetail"]));
        if (listProducts != null && listProducts.Count > 0)
        {
            object[] o = (object[])listProducts[0];
            return common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[0]) : common.ToString(o[1]);
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
