using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_CheckLogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UsernameAdmin"] == null)
        {
            //if (Session["Logout"] == null || (bool)Session["Logout"] != true)
            //    Global.pLinkAfterLoginAdmin = HttpContext.Current.Request.Url.ToString();
            HttpContext.Current.Response.Redirect(ConfigurationManager.AppSettings["PathAdmin"]+"/login.aspx");
        }
    }
}
