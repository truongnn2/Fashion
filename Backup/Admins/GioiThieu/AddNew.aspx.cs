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

public partial class Admins_Gioithieu_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private GioiThieuDB db = new GioiThieuDB();
    public string listphoto = "";
    public string listfile = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            common.ShowCombobox(sltLocation, typeof(eLocationMenu), "", "Chọn");
            if (common.ToString(Request.QueryString["id"]) != "")
            {
                Showdata();
                Addnew.Value = "Hiệu chỉnh";
            }
        }
        common.CreateDirectory(common.GetVirtualPath() + "\\GioiThieu\\ImageEditor");
        Session["FCKeditor:UserFilesPath"] = ConfigurationManager.AppSettings["FCKeditorUserFilesPath"] + "GioiThieu/ImageEditor/";
        Session["FCKeditor:UserFilesAbsolutePath"] = "GioiThieu/ImageEditor/";
    }
    private void Showdata()
    {
        string SQL = "select Title,Content,Location from GioiThieu where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtTitle.Value = common.ToString(o[0]);
            txtContent.Value = HttpUtility.HtmlDecode(common.ToString(o[1]));
            sltLocation.Value = common.ToString(o[2]);
        }
    }
   
    private string getID()
    {
        string SQL = "select Top 1 ID from GioiThieu order by ID desc";
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
            GioiThieu TD = new GioiThieu();
            TD.Title = txtTitle.Value;
            TD.Content = txtContent.Value;
            TD.Status = 0;
            if (sltLocation.Value=="")
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
            Response.Redirect(pathAdmin + "/GioiThieu/ListGioithieu.aspx");
        }
    }
   

    private string getname(FileUpload f, HtmlInputText inputtext)
    {
        if (inputtext.Value != "") return inputtext.Value;
        if (f != null && f.PostedFile.FileName != "")
        {
            string[] Ext = f.PostedFile.FileName.ToString().Split('\\');
            return Ext[Ext.Length-1].Split('.')[0];
        }
        return "";
    }
    private string getnamefile(FileUpload f)
    {
        if (f != null && f.PostedFile.FileName != "")
        {
            string[] Ext = f.PostedFile.FileName.ToString().Split('.');
            return common.ChangeName() + "." + Ext[Ext.Length - 1].ToString();
        }
        return "";
    }
    private void UploadFile(FileUpload f, string pathUpload, string filename)
    {
        if (f != null && f.PostedFile.FileName != "")
        {
            f.PostedFile.SaveAs(pathUpload + "\\" + filename);
        }
    }
}
