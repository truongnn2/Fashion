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

public partial class Admins_CatServices_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private CatServicesDB db = new CatServicesDB();
    public string listphoto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            common.ShowCombobox(sltStatus, typeof(eStatusMenu), "", "Chọn");
            common.ShowCombobox(sltLocation, typeof(eLocationMenu), "", "Chọn");
            if (common.ToString(Request.QueryString["id"]) != "")
            {
                Showdata();
                Addnew.Value = "Hiệu chỉnh";
            }
        }
    }
    private void Showdata()
    {
        string SQL = "select Name,Status,Location,NameE from CatServices where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtName.Value = common.ToString(o[0]);
            txtNameE.Value = common.ToString(o[3]);
            sltStatus.Value = common.ToString(o[1]);
            sltLocation.Value = common.ToString(o[2]);
        }
    }
   
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            CatServices TD = new CatServices();
            TD.Name = txtName.Value; 
            TD.NameE = txtNameE.Value;
            TD.Status = Convert.ToInt16(sltStatus.Value);
            if (sltLocation.Value == "")
                TD.Location = 0;
            else
                TD.Location = Convert.ToInt16(sltLocation.Value);
            String err = "";
            bool t;
            string id = "";
            if (common.ToString(Request.QueryString["id"]) == "")
            {
                t = db.insert(ref err, TD);
                id = getID();
            }
            else
            {
                TD.ID = Convert.ToInt32(common.ToString(Request.QueryString["id"]));
                t = db.update(ref err, TD);
                id = common.ToString(Request.QueryString["id"]);
            }
            Response.Redirect(pathAdmin + "/CatServices/ListCatServices.aspx");
        }
    }
    private string getID()
    {
        string SQL = "select Top 1 ID from CatServices order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[0]);
        }
        return "";
    }
}
