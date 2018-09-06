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
using System.Net.Mail;
using System.Net;

public partial class ContactUs : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string contactUs = "";
    public string img = "";
    public string Titlesptt = "";
    public string hoten = "";
    public string diachi = "";
    public string dienthoai = "";
    public string noidung = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Titlesptt = Global.Resource.GetString("lblLienhe1", Global.ci);
        hoten = Global.Resource.GetString("lblhoten", Global.ci);
        diachi = Global.Resource.GetString("lbldiachi", Global.ci);
        dienthoai = Global.Resource.GetString("lbldienthoai", Global.ci);
        noidung = Global.Resource.GetString("lblnoidung", Global.ci);
        button.Value = Global.Resource.GetString("lblGuiLienHe", Global.ci);
        hdLanguage.Value = common.ToString(Request.QueryString["l"]);
    }
   
    
    protected void button_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Contactus TD = new Contactus();
            TD.Name = txtHoten.Value;
            TD.Phone = txtSodienthoai.Value;
            TD.Email = txtEmail.Value;
            TD.Content = txtNoidung.Value;
            TD.Address = txtDiachi.Value;
            TD.DatePost = DateTime.Now;
            TD.Status = 0;
            TD.Donhang = "";
            String err = "";
            ContactusDB db = new ContactusDB();
            bool t = db.insert(ref err, TD);

            #region SendMail
             string subject = "Khách hàng liên hệ";
             string to = ConfigurationManager.AppSettings["emailadmin"];
             string body = string.Format(common.GetTemplate("SendMailAdmin.tpl"),
                 /*0*/txtHoten.Value,
                 /*1*/txtSodienthoai.Value,
                 /*2*/txtEmail.Value,
                 /*3*/txtDiachi.Value,
                 /*4*/txtNoidung.Value,
                 /*5*/pathClient
                 );
             SendAccount(body, subject, txtEmail.Value, to);
//              string szServer = "112.78.7.50";
//              int iPort = 25;
// 
//              SmtpClient client = new SmtpClient(szServer, iPort);
//              client.Credentials = new NetworkCredential(to, "anhyeuemnhieu");
//              using (MailMessage message = new MailMessage())
//              {
//                  message.From = new MailAddress(txtEmail.Value);
//                  message.To.Add(to);
//                  message.Subject = subject;
//                  message.Body = "Send successfully !";
// 
//                  client.Send(message);
//              } 
            #endregion
             string scr = @"<script>alert('" + Global.Resource.GetString("lblSendSuccess", Global.ci) + "');window.location='" + pathClient + "/ContactUs.aspx';</script>;";
            Page.RegisterClientScriptBlock("done", scr);
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
}
