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

public partial class Admins_Menu_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private CustomerDB db = new CustomerDB();
    public string nametitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            common.ShowCombobox(sltStatus, typeof(eStatusMenuSub), "", "Chọn");
            common.ShowCombobox(sltLocation, typeof(eLocationMenu), "", "Chọn");
            
            if (common.ToString(Request.QueryString["id"]) != "")
            {
                Showdata();
                Addnew.Value = "Hiệu chỉnh";
            }
        }
        nametitle = common.ToString(Request.QueryString["cat"]) == "0" ? "Khách hàng" : "Đối tác";
    }
    private void Showdata()
    {
        string SQL = "select Name, Phone, Email, Address, Status, Location from Customer where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtName.Value = common.ToString(o[0]);
            txtPhone.Value = common.ToString(o[1]);
            txtEmail.Value = common.ToString(o[2]);
            txtAddress.Value = common.ToString(o[3]);
            sltStatus.Value = common.ToString(o[4]);
            sltLocation.Value = common.ToString(o[5]);
        }
    }
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Customer TD = new Customer();
            TD.Name = txtName.Value;
            TD.Phone = txtPhone.Value;
            TD.Email = txtEmail.Value;
            TD.Address = txtAddress.Value;
            TD.Status = Convert.ToInt16(sltStatus.Value);
            TD.Type = Convert.ToInt16(common.ToString(Request.QueryString["cat"]));
            if (sltLocation.Value == "")
                TD.Location = 0;
            else
                TD.Location = Convert.ToInt16(sltLocation.Value);
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
            Response.Redirect(pathAdmin + "/Customer/ListCustomer.aspx?cat=" + common.ToString(Request.QueryString["cat"]));
        }
    }
    private string getID()
    {
        string SQL = "select Top 1 ID from Customer order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[0]);
        }
        return "";
    }
}
