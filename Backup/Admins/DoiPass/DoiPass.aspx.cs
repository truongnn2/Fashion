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

public partial class Admin_DoiPass_DoiPass : System.Web.UI.Page
{
    private AdminDB db = new AdminDB();
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (Session["adminID"] != null)
            {
                Admin TD = new Admin();
                TD.Password = txtPass.Value;
                TD.AdminID = Convert.ToInt32(Session["adminID"]);
                String err = "";
                bool t;
                t = db.update(ref err, TD);
                string scr = @"<script>alert('Thay đổi password thành công!');</script>;";
                Page.RegisterClientScriptBlock("done", scr);
            }
        }
    }
   
}
