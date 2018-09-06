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

public partial class Uc_Bottom : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string bottom = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (common.ToString(Request.QueryString["l"]) != "1")
            bottom = String.Format(common.GetTemplate("Bottom.tpl"), pathClient);
        else
            bottom = String.Format(common.GetTemplate("Bottom_E.tpl"),pathClient);
    }
}
