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

public partial class Admins_CatSubServices_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private CatSubServicesDB db = new CatSubServicesDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            common.ShowCombobox(sltStatus, typeof(eStatusMenuSub), "", "Chọn");
            common.ShowCombobox(sltLocation, typeof(eLocationMenu), "", "Chọn");
            CatServicesDB db1 = new CatServicesDB();
            IList list = db1.getList("Select ID,Name from CatServices");
            common.ShowCombobox(sltCategory, list, "", "");
            if (common.ToString(Request.QueryString["id"]) != "")
            {
                Showdata();
                Addnew.Value = "Hiệu chỉnh";
            }
        }
      
    }
    private void Showdata()
    {
        string SQL = "select Name,IDCatServices,Status,Location,NameE from CatSubServices where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtName.Value = common.ToString(o[0]);
            txtNameE.Value = common.ToString(o[4]);
            sltStatus.Value = common.ToString(o[2]);
            sltLocation.Value = common.ToString(o[3]);
            sltCategory.Value = common.ToString(o[1]);
        }
    }
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            CatSubServices TD = new CatSubServices();
            TD.Name = txtName.Value;
            TD.NameE = txtNameE.Value;
            TD.Status = Convert.ToInt16(sltStatus.Value);
            TD.IDCatServices = Convert.ToInt32(sltCategory.Value);
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
            Response.Redirect(pathAdmin + "/CatSubServices/ListCatSubServices.aspx");
        }
    }
    private string getID()
    {
        string SQL = "select Top 1 ID from CatSubServices order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[0]);
        }
        return "";
    }
}
