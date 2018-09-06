using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;
using System.Resources;
using Common;
/// <summary>
/// Summary description for Global
/// </summary>
public partial class Global : System.Web.HttpApplication
{
    public static ResourceManager Resource = new ResourceManager("Resources.Default.aspx", System.Reflection.Assembly.Load("App_GlobalResources"));
    public static CultureInfo ci;
    public static string l;
    public Global()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    void Application_Start(object sender, EventArgs e)
    {

    }
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {

        if (common.ToString(HttpContext.Current.Request.QueryString["l"]) == "1")
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            ci = Thread.CurrentThread.CurrentCulture;
            l = "?l=1";
        }
        else
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            ci = Thread.CurrentThread.CurrentCulture;
            l = "?l=";
        }
    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends.
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer
        // or SQLServer, the event is not raised.

    }
    void Application_OnStart(Object Sender, EventArgs E)
    {
        Application["ActiveUsers"] = 0;
    }
    void Session_OnStart(object Sender, EventArgs E)
    {
        Session.Timeout = 20;
        Session["Start"] = "Now";
        Application.Lock();
        Application["ActiveUsers"] = System.Convert.ToInt32(Application["ActiveUsers"]) + 1;
        Application.UnLock();
    }
    void Session_OnEnd(object Sender, EventArgs E)
    {
        Application.Lock();
        Application["ActiveUsers"] = System.Convert.ToInt32(Application["ActiveUsers"]) - 1;
        Application.UnLock();
    }
}
