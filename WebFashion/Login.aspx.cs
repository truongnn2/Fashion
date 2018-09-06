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

public partial class Login : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtnLogin_Click(object sender, EventArgs e)
    {
        if (CheckLogin()) Response.Redirect(pathClient + "/Default.aspx" + Global.l + "&pg=1&cat=3");
        else
            lbErrorMsg.Text = "Username hoặc password chưa đúng.<br>Vui lòng nhập lại!";
    }
    private bool CheckLogin()
    {
        if (txtUserName.Text == "truong" && txtPsw.Text == "123")
        {
            Session["UsernameClient"] = txtUserName.Text;
            return true;
        }
        else
        {
            Session.RemoveAll();
            return false;
        }
    }
}
