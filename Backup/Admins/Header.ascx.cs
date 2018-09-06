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

public partial class Admin_Header : System.Web.UI.UserControl
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string PathClient = ConfigurationManager.AppSettings["PathClient"];
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
