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

public partial class Huongdan : System.Web.UI.Page
{
    private GiamgiaDB db = new GiamgiaDB();
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Showdata();
        }
    }
    private void Showdata()
    {
        string SQL = "select Content,photo from Giamgia where ID = 1";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            lblNoidung.Text = HttpUtility.HtmlDecode(common.ToString(o[0]));
        }
    }
}
