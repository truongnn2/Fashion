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

public partial class SolutionDetail : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string sptt = "";
    public string title = "";
    public string proDetail = "";
    public string b = "1";
    public string link1 = "";
    public string otherSolution = "";
    public string Titlepage = "";
    public string titleService = "News";
    protected void Page_Load(object sender, EventArgs e)
    {
        favicon.Attributes.Add("href", pathClient + "/favicon.ico");
        StyleTag1.Attributes.Add("href", pathClient + "/Css/templatemo_style.css");
        StyleTag.Attributes.Add("href", pathClient + "/Css/styles.css");
        Titlepage = Global.Resource.GetString("lblTitlepage", Global.ci);
        sptt=GetNews();
    }
    private string GetNews()
    {
        string ttt = "";
        string sql = "Select ID,Title,Photo,DateCreate,TitleE,Content,ContentE from News where ID =" + common.ToString(Request.QueryString["id"]);
        IList listMenu = db.getlist(sql);
        if (listMenu != null && listMenu.Count > 0)
        {
            object[] o = (object[])listMenu[0];
            string tempTitle = common.ToString(o[4]);
            string tempContent = common.ToString(o[6]);
            if (common.ToString(Request.QueryString["l"]) == "0")
            {
                titleService = "Tin tức";
                tempTitle = common.ToString(o[1]);
                tempContent = common.ToString(o[5]);
            }
            title = tempTitle;
            ttt = String.Format(common.GetTemplate("NewsDetail.tpl"),
                /*0*/tempTitle,
                /*1*/tempContent,
                /*2*/GetNewsOther()
                );
        }
        return ttt;
    }
    private string GetNewsOther()
    {
        string serviceList = "";
        string sql = "Select top 10 ID,Title,Photo,DateCreate,TitleE,Content,ContentE from News where status=0 and ID <>" + common.ToString(Request.QueryString["id"])+" Order by ID desc";
        IList listMenu = db.getlist(sql);
        if (listMenu != null && listMenu.Count > 0)
        {
            string temp = "";
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = common.GetUrlNewsDetail(common.ToString(o[1]), common.ToString(o[0]), Global.l);
                string title = common.ToString(o[1]);
                if (common.ToString(Request.QueryString["l"]) == "1")
                {
                    title = common.ToString(o[4]);
                }
                temp += String.Format("<li><a href=\"{1}\" title=\"{0}\">{0}<span></span></a></li>",
                    /*0*/title,
                    /*1*/link
                    );
            }
            if (temp != "")
                serviceList = String.Format(common.GetTemplate("ServiceDefaultListItem.tpl"),
                    /*0*/temp,
                    /*1*/common.ToString(Request.QueryString["l"]) == "1" ? "Others News" : "Các tin khác"
                 );
        }
        return serviceList;
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
