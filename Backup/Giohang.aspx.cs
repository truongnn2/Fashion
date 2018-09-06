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

public partial class TTgiamgia : System.Web.UI.Page
{
    public string listsp = "";
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string Titlesptt = "";
    public string hoten = "";
    public string diachi = "";
    public string dienthoai = "";
    public string noidung = "";
    public string language = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Titlesptt = Global.Resource.GetString("lblGiohang", Global.ci);
        hoten = Global.Resource.GetString("lblhoten", Global.ci);
        diachi = Global.Resource.GetString("lbldiachi", Global.ci);
        dienthoai = Global.Resource.GetString("lbldienthoai", Global.ci);
        noidung = Global.Resource.GetString("lblnoidung", Global.ci);
        hdLanguage.Value = common.ToString(Request.QueryString["l"]);
        Cont.Value = Global.Resource.GetString("lblContinueShopping", Global.ci);
        btexit.Value = Global.Resource.GetString("lblUpdate", Global.ci);
        Button1.Value = Global.Resource.GetString("lblSendOrder", Global.ci);
        button.Value = Global.Resource.GetString("lblGuiLienHe", Global.ci);
        language = common.ToString(Request.QueryString["l"]);
        if (Request.Cookies["sp"] != null && common.ToString(Request.Cookies["sp"].Value) != "")
        {

            string listID = "";
            string[] temp = common.ToString(Request.Cookies["sp"].Value).Trim('#').Split('#');
            for (int i = 0; i < temp.Length; i++)
            {
                listID += temp[i].Split('-')[0] + ",";
            }
            hdListID.Value = listID.Trim(',');
            getList db = new getList();
            string SQL = "select ID,Title,Price,Category,CategoryDetail,TitleE from Products where ID in(" + listID.Trim(',') + ")";
            IList list = db.getlist(SQL);
            if (list != null && list.Count > 0)
            {
                string func = "<a href=\"javascript:void(0);\" onclick=\"Deletesp({0},'{1}');\" class=\"delete\">" + Global.Resource.GetString("lblDelete", Global.ci) + "</a>";
                for (int j = 0; j < list.Count; j++)
                {
                    object[] o = (object[])list[j];
                    string link = pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[3]) + "&catdetail=" + common.ToString(o[4]);
                    string cl = "odd";
                    if (j % 2 == 0)
                        cl = "";
                    listsp += String.Format(common.GetTemplate("GiohangList.tpl")
                        , cl
                        , common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[1]) : common.ToString(o[5])
                        , common.ToString(o[0])
                        , getCount(common.ToString(Request.Cookies["sp"].Value), common.ToString(o[0]))
                        , common.ToString(o[2])
                        , String.Format(func, common.ToString(o[0]), common.ToString(Request.QueryString["l"]))
                        , link
                        );
                }
                listsp = String.Format(common.GetTemplate("Giohang.tpl")
                    , listsp
                    , Global.Resource.GetString("lblProductSelected", Global.ci)
                    , Global.Resource.GetString("lblNumber", Global.ci)
                    , Global.Resource.GetString("lblPriceProduct", Global.ci)
                    , Global.Resource.GetString("lblFunction", Global.ci)
                    );
            }
            else listsp = Global.Resource.GetString("lblNoProductCart", Global.ci) + "<br><br> ";
        }
        else listsp = Global.Resource.GetString("lblNoProductCart", Global.ci)+"<br><br> ";
    }
    private string getCount(string s, string s1)
    {
        string[] temp = s.Trim('#').Split('#');
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].IndexOf(s1 + "-") != -1)
            {
                return temp[i].Split('-')[1];
            }
        }
        return "0";
    }
    protected void Cont_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (Request.Cookies["url"] != null && common.ToString(Request.Cookies["url"].Value) != "")
            {
                Response.Redirect(common.ToString(Request.Cookies["url"].Value));
            }
            else
                Response.Redirect(pathClient + "/products.aspx?pg=1");
        }
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
            TD.Donhang = Request.Cookies["sp"]!=null?common.ToString(Request.Cookies["sp"].Value):"";
            String err = "";
            ContactusDB db = new ContactusDB();
            bool t = db.insert(ref err, TD);

            #region SendMail
            string donhang="";
            if (Request.Cookies["sp"] != null)
                donhang = "<br/>Đơn hàng: " + common.ToString(Request.Cookies["sp"].Value);
            string subject = "Khách hàng liên hệ";
            string to = ConfigurationManager.AppSettings["emailadmin"];
            string body = string.Format(common.GetTemplate("SendMailAdmin.tpl"),
                /*0*/txtHoten.Value,
                /*1*/txtSodienthoai.Value,
                /*2*/txtEmail.Value,
                /*3*/txtDiachi.Value,
                /*4*/txtNoidung.Value + donhang,
                /*5*/pathClient
                );
            SendAccount(body, subject, txtEmail.Value, to);
            #endregion
            string scr = @"<script>alert('" + Global.Resource.GetString("lblSendOrderSuccess", Global.ci) + "');window.location='" + pathClient + "/Giohang.aspx" + Global.l + "';</script>;";
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
