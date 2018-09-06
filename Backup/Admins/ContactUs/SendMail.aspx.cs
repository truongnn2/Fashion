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

public partial class Admins_ContactUs_SendMail : System.Web.UI.Page
{
    public string success = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ContactusDB db = new ContactusDB();
            string SQL = "select Name,Email from Contactus where ID = " + common.ToString(Request.QueryString["id"]);
            IList list = db.getList(SQL);
            if (list != null && list.Count > 0)
            {
                object[] o = (object[])list[0];
                txtEmailTo.Value = common.ToString(o[1]);
            }
        }
    }
    
    private void SendAccount(string body, string subject, string from, string to)
    {
        SendMail sm = new SendMail();
        sm.mBody = body;
        sm.mFrom = from;
        sm.mSubject = subject;
        sm.mTo = to;
        sm.SendEmail();
    }

    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string subject = "www.theulogo.vn - Chào bạn!";
            string body = txtMessage.Value;
            string to = txtEmailTo.Value;
            string from = ConfigurationManager.AppSettings["MailServer"];
            SendAccount(body, subject, from, to);
            success = "Gửi email thành công!";
            ContactusDB db = new ContactusDB();
            Contactus CT = new Contactus();
            CT.Status = 1;
            CT.ID = Convert.ToInt32(common.ToString(Request.QueryString["id"]));
            String err = "";
            bool t;
            t = db.updateStatus(ref err, CT);
        }
    }
}
