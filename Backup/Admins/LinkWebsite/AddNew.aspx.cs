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

public partial class Admins_Download_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private LinkWebsiteDB db = new LinkWebsiteDB();
    public string listphoto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    private void Showdata()
    {
        string SQL = "select Website,Url from LinkWebsite where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtName.Value = common.ToString(o[0]);
            txtUrl.Value = common.ToString(o[1]);
        }
    }
    private string getID()
    {
        string SQL = "select Top 1 ID from LinkWebsite order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[0]);
        }
        return "";
    }
   
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            LinkWebsite TD = new LinkWebsite();
            TD.Website = txtName.Value;
            TD.Url = "http://"+txtUrl.Value.Replace("http://","");
            TD.Status = 0;
            String err = "";
            bool t;
            string id = "";
            if (common.ToString(Request.QueryString["id"]) == "")
            {
                t = db.insert(ref err, TD);
                id = getID();
            }
            Response.Redirect(pathAdmin + "/LinkWebsite/ListLinkWebsite.aspx");
        }

    }
}
