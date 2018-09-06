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
    private AboutUsDB db = new AboutUsDB();
    public string tt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (common.ToString(Request.QueryString["id"]) != "")
                Showdata();
            tt = "Tin hot";
        }
        //common.CreateDirectory(common.GetVirtualPath() + "\\AboutUs\\ImageEditor");
        //Session["FCKeditor:UserFilesPath"] = ConfigurationManager.AppSettings["FCKeditorUserFilesPath"] + "AboutUs/ImageEditor/";
        //Session["FCKeditor:UserFilesAbsolutePath"] = "AboutUs/ImageEditor/";
    }
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        
        if (IsPostBack)
        {
            
            AboutUs TD = new AboutUs();
            TD.Content = txtNoidung.Value;
            TD.ContentE = txtContent.Value;
            String err = "";
            bool t;
            
            if (common.ToString(Request.QueryString["id"]) != "")
            {
                TD.ID = Convert.ToInt32(common.ToString(Request.QueryString["id"]));
                t = db.update(ref err, TD);
                Response.Redirect(pathAdmin + "/HotNews/HotNews.aspx?id=" + common.ToString(Request.QueryString["id"]));
            }
        }
    }
    private void Showdata()
    {
        string SQL = "select Content,ContentE from AboutUs where ID =" + common.ToString(Request.QueryString["id"]);
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtNoidung.Value = HttpUtility.HtmlDecode(common.ToString(o[0]));
            txtContent.Value = HttpUtility.HtmlDecode(common.ToString(o[1]));
        }
    }
}
