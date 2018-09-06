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
    public string cont = "";
    public string diachi = "";
    public string Titlesptt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Titlesptt = Global.Resource.GetString("lblAboutUs", Global.ci);
        GioiThieuDB db = new GioiThieuDB();
        string SQL = "select Content,ContentE from AboutUs where ID = 1";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            string temp = common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[0]) : common.ToString(o[1]);
            //diachi = string.Format("<p><span class=\"siteto dott\"><strong>{0}<br />{1}</strong></span></p>", common.ToString(o[1]), common.ToString(o[2]));
            cont = common.replaceWidthImage(HttpUtility.HtmlDecode(temp), 540);
        }
    }
}
