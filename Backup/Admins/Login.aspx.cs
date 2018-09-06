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

public partial class Admin_Login : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private getList db = new getList();
    protected void Page_Load(object sender, EventArgs e)
    {
   
    }
 
    private bool CheckLogin()
    {
        string SQL = "select AdminID,Username from Admin where Username = '" + txtUserName.Value + "' and Password = '" + txtPsw.Value + "'";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            object[]o=(object[])list[0];
            Session["UsernameAdmin"] = common.ToString(o[1]);
            Session["adminID"] = common.ToString(o[0]);
            return true;
        }
        else
        {
            Session.RemoveAll();
            return false;
        }
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (CheckLogin()) Response.Redirect(pathAdmin + "/Products/ListProducts.aspx");
            else
            {
                string scr = @"<script>alert('Username hoặc password chưa đúng. Vui lòng nhập lại!');</script>";
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "MyKey", scr);
            }
        }
    }
}
