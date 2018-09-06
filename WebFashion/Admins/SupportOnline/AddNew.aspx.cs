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

public partial class Admins_SupportOnline_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private SupportOnlineDB db = new SupportOnlineDB();
    public string listphoto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            common.ShowCombobox(sltStatus, typeof(eStatusMenu), "", "Chọn");
            if (common.ToString(Request.QueryString["id"]) != "")
            {
                Showdata();
                Addnew.Value = "Hiệu chỉnh";
            }
        }
    }
    private void Showdata()
    {
        string SQL = "select Name,Status,NickName,Phone,NickSkype from SupportOnline where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtName.Value = common.ToString(o[0]);
            txtNickName.Value = common.ToString(o[2]);
            txtSkype.Value = common.ToString(o[4]);
            sltStatus.Value = common.ToString(o[1]);
            txtPhone.Value = common.ToString(o[3]);
        }
    }
   
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            SupportOnline TD = new SupportOnline();
            TD.Name = txtName.Value; 
            TD.NickName = txtNickName.Value;
            TD.NickSkype = txtSkype.Value;
            TD.Status = Convert.ToInt16(sltStatus.Value);
            TD.Phone = txtPhone.Value;
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
            Response.Redirect(pathAdmin + "/SupportOnline/ListSupportOnline.aspx");
        }
    }
    private string getID()
    {
        string SQL = "select Top 1 ID from SupportOnline order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[0]);
        }
        return "";
    }
}
