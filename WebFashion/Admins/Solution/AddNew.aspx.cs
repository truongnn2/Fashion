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

public partial class Admins_Products_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private SolutionDB db = new SolutionDB();
    public string listphoto = "";
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
        common.CreateDirectory(common.GetVirtualPath() + "\\Solution\\ImageEditor");
        Session["FCKeditor:UserFilesPath"] = ConfigurationManager.AppSettings["FCKeditorUserFilesPath"] + "Solution/ImageEditor/";
        Session["FCKeditor:UserFilesAbsolutePath"] = "Solution/ImageEditor/";
    }
    private void Showdata()
    {
        string SQL = "select Title,Content,Photo,Location,TitleE,ContentE from Solution where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtTitle.Value = common.ToString(o[0]);
            txtTitleE.Value = common.ToString(o[4]);
            txtContent.Value = HttpUtility.HtmlDecode(common.ToString(o[1]));
            txtContentE.Value = HttpUtility.HtmlDecode(common.ToString(o[5]));
            sltLocation.Value = common.ToString(o[3]);
            if (common.ToString(o[2]) != "")
            {
                string[] listimg = common.ToString(o[2]).Split(',');
                for (int i = 0; i < listimg.Length; i++)
                {
                    listphoto += String.Format(common.GetTemplate("SolutionListImage.tpl"), pathClient + "/FileUpload/Solution/" + Request.QueryString["id"] + "/" + ConfigurationManager.AppSettings["imageSizeSolution"] + "/" + listimg[i], "img" + i.ToString(), listimg[i], Request.QueryString["id"]);
                }
            }
            
        }
    }
   
    private string getID()
    {
        string SQL = "select Top 1 ID from Solution order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[0]);
        }
        return "";
    }
    private string getphoto(string id)
    {
        string SQL = "select ID,Photo from Products where ID=" + id;
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[1]);
        }
        return "";
    }
    private string getfile(string id)
    {
        string SQL = "select ID,FileAttach from Products where ID=" + id;
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[1]);
        }
        return "";
    }
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Solution TD = new Solution();
            TD.Title = txtTitle.Value;
            TD.TitleE = txtTitleE.Value;
            TD.Content = txtContent.Value;
            TD.ContentE = txtContentE.Value;
            TD.Status = 0;
            if (sltLocation.Value=="")
                TD.Location = 0;
            else
                TD.Location = Convert.ToInt32(sltLocation.Value);
            String err = "";
            bool t;
            string id = "";
            if (common.ToString(Request.QueryString["id"]) == "")
            {
                TD.DateCreate = DateTime.Now;
                t = db.insert(ref err, TD);
                id = getID();
            }
            else
            {
                TD.ID = Convert.ToInt32(common.ToString(Request.QueryString["id"]));
                t = db.update(ref err, TD);
                id = common.ToString(Request.QueryString["id"]);
            }
            if (id != "")
            {
                string pathUpload = common.GetVirtualPath() + "\\Solution";
                common.CreateDirectory(pathUpload);
                pathUpload = common.GetVirtualPath() + "\\Solution\\" + id;
                common.CreateDirectory(pathUpload);
              
                string filename = "";
                if (FileUpload1 != null && FileUpload1.PostedFile.FileName != "")
                    filename = common.Uploadfile(FileUpload1, pathUpload, ConfigurationManager.AppSettings["imageSizeSolution"]);// ";" + ConfigurationManager.AppSettings["imageSizeProducts260x260"]) + ",";
               
                filename.Trim().Trim(',');

                if (filename != "")
                {
                    string fileold = getphoto(id).Trim().Trim(',').Replace(",,", ",");
                    string temp = filename;
                    if (fileold.Trim() != "")
                        temp = temp + "," + fileold;
                    Solution GT = new Solution();
                    GT.Photo = temp.Trim(',').Replace(",,", ",");

                    GT.ID = Convert.ToInt32(id);
                    t = db.updatePhoto(ref err, GT);

                }
            }

            Response.Redirect(pathAdmin + "/Solution/ListSolution.aspx");
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
