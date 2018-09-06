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

public partial class Admins_AboutUs_AboutUs : System.Web.UI.Page
{
    private AboutUsDB db = new AboutUsDB();
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string tt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Showdata();
            tt = common.ToString(Request.QueryString["id"]) == "1" ? "Giới thiệu Công ty" : "Dịch vụ";
        }
    }
    private void Showdata()
    {
        string SQL = "select Content,ContentE from AboutUs where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            lblNoidung.Text = HttpUtility.HtmlDecode(common.ToString(o[0]));
            lblContent.Text = HttpUtility.HtmlDecode(common.ToString(o[1]));
        }
        else
        {
            lblNoidung.Text = "Chưa có dữ liệu!";
            lblContent.Text = "No data!";
        }
    }
}
