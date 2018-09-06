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

public partial class ListServices : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string sptt = "";
    public string title = "";
    public string title1 = "";
    public string proDetail = "";
    public string b = "1";
    public string link1 = "";
    public string Titlepage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        favicon.Attributes.Add("href", pathClient + "/favicon.ico");
        StyleTag.Attributes.Add("href", pathClient + "/Css/FSportal.css");
        Titlepage = Global.Resource.GetString("lblTitlepage", Global.ci);
        sptt = GetServices(common.ToString(Request.QueryString["catdetails"]), common.ToString(Request.QueryString["cats"]));
        hdfRecordCount.Value = ConfigurationManager.AppSettings["DisplayPage"];
       
    }
    private string GetServices(string catdetail, string cat)
    {
        string ttt = "";
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
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
            condi += " and CategorySub=" + catdetail;
        count = getCountRecord("select count(ID) from Services where Status=0 " + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.QueryString["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string sql = "Select top " + rowsOnPage.ToString() + " ID,Title,Photo,DateCreate,TitleE,Content,ContentE,Category,CategorySub,(select Name from CatServices where ID=Category) as NameCat,(select Name from CatSubServices where ID=CategorySub) as NameCatSub from Services where ID in ( select top " + plFirstPage.ToString() + " ID  from Services where Photo is not null and Photo <>'' and Status=0" + condi + " order by ID desc)  order by ID asc";
        string tempcat = getnameCat();
        string tempcatdetail = getnameCatDetail();
        IList listMenu = db.getlist(sql);
        if (listMenu != null && listMenu.Count > 0)
        {
            int c = 0;
            for (int i = listMenu.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])listMenu[i];
                c++;
                string link = common.GetUrlServicesDetail(common.ToString(o[1]), common.ToString(o[0]), common.ToString(o[9]), common.ToString(o[7]), common.ToString(o[10]), common.ToString(o[8]), Global.l);//pathClient + "/ServicesDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cats=" + common.ToString(o[7]) + "&catdetails=" + common.ToString(o[8]);
                string[] listimg = common.ToString(o[2]).Split(',');
                string tempcont = common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[5]) : common.ToString(o[6]);
                string content = Regex.Replace(common.RemoveTag(common.RemoveTag(common.RemoveTag(HttpUtility.HtmlDecode(tempcont), "<style", "</style>"), "<script", "</script>"), "<w:WordDocument>", "</w:WordDocument>"), @"<[\s\S]*?>", "");
                content = common.LaySoKyTuCuaChuoi(content, 250);
                ttt += String.Format(common.GetTemplate("SolutionListClient1.tpl"),
                    /*0*/common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[1]) : common.ToString(o[4]),
                    /*1*/link,
                    /*2*/pathClient + "/FileUpload/Services/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeServices"] + "/" + listimg[0],
                    /*3*/common.ToString(Request.QueryString["l"]) == "0" ? "Chi tiết" : "Details",
                    /*4*/content,
                    /*5*/i == 0 ? "display:none" : "",
                    /*6*/i != 0 ? "border-bottom: 1px solid #DDDDDD;" : ""
                    );

            }

            ttt = "<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + ttt;
            link1 = common.GetUrlServices(Global.l, "###");
            if (cat != "")
                link1 = common.GetUrlCatServices(tempcat, common.ToString(Request.QueryString["cats"]), Global.l, "###");//"&cats=" + cat;
            if (catdetail != "")
                link1 = common.GetUrlCatServicesSub(tempcat, common.ToString(Request.QueryString["cat"]), tempcatdetail, common.ToString(Request.QueryString["catdetails"]), Global.l, "###");//"&catdetails=" + catdetail;
        }
        if (ttt == "")
        {
            b = "0";
            ttt = "<tr><td>" + Global.Resource.GetString("lblCapnhadulieu", Global.ci) + "</td></tr>";
        }
        string link2 = common.GetUrlServices(Global.l, "1");// pathClient + "/ListServices.aspx" + Global.l + "&pg=1";
        
        title1 = string.Format("<a style=\"text-decoration: none;\" href=\"{0}\">{1}</a>", link2, Global.Resource.GetString("lblTitleMenuService", Global.ci));
        if (tempcat != "")
        {
            title += tempcat;
            link2 = common.GetUrlCatServices(tempcat, common.ToString(Request.QueryString["cats"]), Global.l, "1");//"&cats=" + cat;
            title1 += string.Format(" » <a style=\"text-decoration: none;\" href=\"{0}\">{1}</a>", link2, tempcat);
        }
        if (tempcatdetail != "")
        {
            title += " - " + tempcatdetail;
            link2 = common.GetUrlCatServicesSub(tempcat, common.ToString(Request.QueryString["cat"]), tempcatdetail, common.ToString(Request.QueryString["catdetails"]), Global.l, "1");//"&catdetails=" + catdetail;
            title1 += string.Format(" » <a style=\"text-decoration: none;\" href=\"{0}\">{1}</a>", link2, tempcatdetail);
        }
        if (title == "")
            title = Global.Resource.GetString("lblTitleMenuService", Global.ci);
        return ttt;
    }
    private string getnameCat()
    {
        IList listProducts = db.getlist("select Name,NameE from CatServices where ID=" + common.ToString(Request.QueryString["cats"]));
        if (listProducts != null && listProducts.Count > 0)
        {
            object[] o = (object[])listProducts[0];
            return common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[0]) : common.ToString(o[1]);
        }
        return "";
    }
    private string getnameCatDetail()
    {
        IList listProducts = db.getlist("select Name,NameE from CatSubServices where ID=" + common.ToString(Request.QueryString["catdetails"]));
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
