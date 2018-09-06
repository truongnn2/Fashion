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
public partial class Admins_AboutUs_Edit : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private GiamgiaDB db = new GiamgiaDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (common.ToString(Request.QueryString["id"]) != "")
                Showdata();
        }
//         common.CreateDirectory(common.GetVirtualPath() + "\\Giamgia\\ImageEditor");
//         Session["FCKeditor:UserFilesPath"] = ConfigurationManager.AppSettings["FCKeditorUserFilesPath"] + "Giamgia/ImageEditor/";
    }
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Giamgia TD = new Giamgia();
            TD.Content = HttpUtility.HtmlEncode(txtNoidung.Value);
            String err = "";
            bool t;
            if (common.ToString(Request.QueryString["id"]) == "")
            {
                t = db.insert(ref err, TD);
            }
            else
            {
                TD.ID = Convert.ToInt32(common.ToString(Request.QueryString["id"]));
                t = db.update(ref err, TD);
            }

            Response.Redirect(pathAdmin + "/Huongdan/Huongdan.aspx");
        }
    }
    private void Showdata()
    {
        string SQL = "select Content from Giamgia where ID =" + common.ToString(Request.QueryString["id"]);
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtNoidung.Value = HttpUtility.HtmlDecode(common.ToString(o[0]));
        }
    }
}
