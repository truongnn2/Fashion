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

public partial class About : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string cont = "";
    public string diachi = "";
    public string Titlesptt = "";
    public string Titlepage = "";
    public string aboutus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        favicon.Attributes.Add("href", pathClient + "/favicon.ico");
        StyleTag1.Attributes.Add("href", pathClient + "/Css/templatemo_style.css");
        StyleTag.Attributes.Add("href", pathClient + "/Css/styles.css");
        Titlepage = Global.Resource.GetString("lblTitlepage", Global.ci);
        Titlesptt = Global.Resource.GetString("lblAboutUs", Global.ci);
        aboutus = GetAboutUs();
    }
    private string GetAboutUs()
    {
        GioiThieuDB db1 = new GioiThieuDB();
        IList list1 = db1.getList("select Content,ContentE from AboutUs where ID = 1");
        string tempCont = "";
        if (list1 != null && list1.Count > 0)
        {
            object[] o = (object[])list1[0];
            string temp = common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[0]) : common.ToString(o[1]);
            tempCont = String.Format(common.GetTemplate("AboutUs1.tpl")
            , temp
            , common.ToString(Request.QueryString["l"]) == "0" ? "Giới thiệu" : "About us"
            );
        }
        return tempCont;
    }
    
}
