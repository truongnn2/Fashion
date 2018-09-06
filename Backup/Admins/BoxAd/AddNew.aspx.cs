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

public partial class Admins_BoxAd_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private BoxAdDB db = new BoxAdDB();
    public string listphoto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            common.ShowCombobox(sltCategory, typeof(eCategoryBoxAd), "", "Chọn");
            common.ShowCombobox(sltLocation, typeof(eLocationMenu), "", "Chọn");
            //common.ShowCombobox(sltPage, typeof(ePage), "10", "Chọn");
            if (common.ToString(Request.QueryString["id"]) != "")
            {
                Showdata();
                Addnew.Value = "Hiệu chỉnh";
            }
        }
    }
    private void Showdata()
    {
        string SQL = "select Photo,Url,Category,Location from BoxAd where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtUrl.Value = common.ToString(o[1]);
            sltCategory.Value = common.ToString(o[2]);
            sltLocation.Value = common.ToString(o[3]);
            if (common.ToString(o[0]) != "")
            {
                string[] listimg = common.ToString(o[0]).Split(',');
                for (int i = 0; i < listimg.Length; i++)
                {
                    if (listimg[i].ToLower().IndexOf("flv")!=-1)
                        listphoto += String.Format(common.GetTemplate("VideoClipAdmin.tpl"), pathClient + "/FileUpload/BoxAd/" + Request.QueryString["id"] + "/" + listimg[i], "img" + i.ToString(), listimg[i], Request.QueryString["id"], pathClient);
                    else if (listimg[i].ToLower().IndexOf("swf") != -1)
                        listphoto += String.Format(common.GetTemplate("FlashAdmin.tpl"), pathClient + "/FileUpload/BoxAd/" + Request.QueryString["id"] + "/" + listimg[i], "img" + i.ToString(), listimg[i], Request.QueryString["id"], pathClient);
                    else
                        listphoto += String.Format(common.GetTemplate("BoxAdListImage.tpl"), pathClient + "/FileUpload/BoxAd/" +Request.QueryString["id"] + "/"+ listimg[i], "img" + i.ToString(), listimg[i], Request.QueryString["id"]);
                }
            }
        }
    }
    private string getID()
    {
        string SQL = "select Top 1 ID from BoxAd order by ID desc";
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
        string SQL = "select ID,Photo from BoxAd where ID=" + id;
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
            BoxAd TD = new BoxAd();
            TD.Url = txtUrl.Value;
            TD.Status = 0;
            TD.Category = Convert.ToInt16(sltCategory.Value);
            //TD.Page = Convert.ToInt16(sltPage.Value);
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
            if (id != "")
            {
                string pathUpload = common.GetVirtualPath() + "\\BoxAd";
                common.CreateDirectory(pathUpload);
                pathUpload = common.GetVirtualPath() + "\\BoxAd\\" + id;
                common.CreateDirectory(pathUpload);
                string filename = "";
                if (FileUpload1.PostedFile.FileName.ToLower().IndexOf("flv") != -1 || FileUpload1.PostedFile.FileName.ToLower().IndexOf("swf") != -1)
                    filename = Uploadfile(FileUpload1, pathUpload);
                else
                    filename = common.Uploadfile(FileUpload1, pathUpload, ConfigurationManager.AppSettings["imageSizeBoxAd"]);
                if (filename != "")
                {
                    string fileold = getphoto(id);
                    string temp = filename + "," + fileold;
                    BoxAd GT = new BoxAd();
                    GT.Photo = temp.Trim(',').Replace(",,", ",");
                    GT.ID = Convert.ToInt32(id);
                    t = db.updatePhoto(ref err, GT);
                }

            }
            Response.Redirect(pathAdmin + "/BoxAd/ListBoxAd.aspx");
        }
    }
    public string Uploadfile(FileUpload f, string pathUpload)
    {
        if (f != null && f.PostedFile.FileName != "")
        {
            string[] Ext = f.PostedFile.FileName.ToString().Split('.');
            string filename = common.ChangeName() + "." + Ext[Ext.Length - 1].ToString();
            f.PostedFile.SaveAs(pathUpload + "\\" + filename);
            return filename;
        }
        return "";
    }
}
