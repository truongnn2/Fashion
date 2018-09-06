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

public partial class employment : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string img = "";
    public string diachi = "";
    public string cont = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AboutUsDB db = new AboutUsDB();
        string SQL = "select photo,Address,Phone from AboutUs where ID = 1";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            string temp=common.ToString(o[0]);
            diachi = string.Format("<p><span class=\"siteto dott\"><strong>{0}<br />{1}</strong></span></p>", common.ToString(o[1]), common.ToString(o[2]));
            img = "<img src='" + pathClient + "/FileUpload/AboutUs/" + common.ToString(o[0]) + "'/>";//ConfigurationManager.AppSettings["imageSizeAboutUs"] + "/" + 
        }

        EmploymentDB db1 = new EmploymentDB();
        string SQL1 = "select Content from Employment where ID=1";
        IList list1 = db1.getList(SQL1);
        if (list1 != null && list1.Count > 0)
        {
            object[] o = (object[])list1[0];
            cont = common.replaceWidthImage(HttpUtility.HtmlDecode(common.ToString(o[0])), 540);
        }
    }
}
