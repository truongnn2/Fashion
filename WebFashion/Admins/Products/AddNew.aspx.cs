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
    private ProductsDB db = new ProductsDB();
    public string listphoto = "";
    public string listfile = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MenuDB db1 = new MenuDB();
            IList list = db1.getList("Select ID,Name from Menu ");
            common.ShowCombobox(sltCategory, list, "", "");
            common.ShowCombobox(sltLocation, typeof(eLocationMenu), "", "Chọn");
            if (common.ToString(Request.QueryString["id"]) != "")
            {
                Showdata();
                Addnew.Value = "Hiệu chỉnh";
            }
        }
        common.CreateDirectory(common.GetVirtualPath() + "\\Products\\ImageEditor");
        Session["FCKeditor:UserFilesPath"] = ConfigurationManager.AppSettings["FCKeditorUserFilesPath"] + "Products/ImageEditor/";
        Session["FCKeditor:UserFilesAbsolutePath"] = "Products/ImageEditor/";
    }
    private void Showdata()
    {
        string SQL = "select Title,Content,Photo,Category,CategoryDetail,isHot,Price,IsShowPrice,Location,Intro,IsShowDefault,TitleE,ContentE,FileAttach,CategoryDetailSub,PromotionPrice,IsNew,IsMostView,IdInput from Products where ID = " + Request.QueryString["id"];
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            txtTitle.Value = common.ToString(o[0]);
            txtTitleE.Value = common.ToString(o[11]);
            txtPrice.Value = common.ToString(o[6]);
            txtPromotionPrice.Value = common.ToString(o[15]);
            txtContent.Value = HttpUtility.HtmlDecode(common.ToString(o[1]));
            txtContentE.Value = HttpUtility.HtmlDecode(common.ToString(o[12]));
            sltCategory.Value = common.ToString(o[3]);
            chkisHot.Checked = common.ToString(o[5]) == "1" ? true : false;
            chkIsShowPrice.Checked = common.ToString(o[7]) == "1" ? true : false;
            chkIsShowDefault.Checked = common.ToString(o[10]) == "1" ? true : false;
            chkIsMostView.Checked = common.ToString(o[17]) == "1" ? true : false;
            chkIsNew.Checked = common.ToString(o[16]) == "1" ? true : false;
            IList listMenuSub = db.getList("Select ID,Name from MenuSub where IDMenu="+common.ToString(o[3]));
            common.ShowCombobox(sltCategoryDetail, listMenuSub, "", "");
            sltCategoryDetail.Value=common.ToString(o[4]);
            hdCategoryDetail.Value = common.ToString(o[4]);

            //IList listMenuSubSub = db.getList("Select ID,Name from MenuSubSub where IDMenuSub=" + common.ToString(o[4]));
            //common.ShowCombobox(sltCategoryDetailSub, listMenuSubSub, "", "");
            //sltCategoryDetailSub.Value = common.ToString(o[14]);
            //hdCategoryDetailSub.Value = common.ToString(o[14]);
            sltLocation.Value = common.ToString(o[8]);
            txtIntro.Value = common.ToString(o[9]);
            txtIdInput.Value = common.ToString(o[18]);
            if (common.ToString(o[2]) != "")
            {
                string[] listimg = common.ToString(o[2]).Split(',');
                for (int i = 0; i < listimg.Length; i++)
                {
                    listphoto += String.Format(common.GetTemplate("ProductsListImage.tpl"), pathClient + "/FileUpload/Products/" + Request.QueryString["id"] + "/" + ConfigurationManager.AppSettings["imageSizeProducts190x120"] + "/" + listimg[i], "img" + i.ToString(), listimg[i], Request.QueryString["id"]);
                }
            }
            if (common.ToString(o[13]) != "")
            {
                string[] listimg1 = common.ToString(o[13]).Split(';');
                for (int i = 0; i < listimg1.Length; i++)
                {
                    listfile += String.Format(common.GetTemplate("ProductsListFile.tpl"), listimg1[i], "file" + i.ToString(), listimg1[i], Request.QueryString["id"]);
                }
            }
           
        }
    }
   
    private string getID()
    {
        string SQL = "select Top 1 ID from Products order by ID desc";
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
            Products TD = new Products();
            TD.Title = txtTitle.Value;
            TD.TitleE = txtTitleE.Value;
            TD.Price = txtPrice.Value;
            TD.PromotionPrice = txtPromotionPrice.Value;
            TD.Content = txtContent.Value;
            TD.ContentE = txtContentE.Value;
            TD.Intro = txtIntro.Value;
            TD.Status = 0;
            TD.Category = Convert.ToInt16(sltCategory.Value);
            TD.IdInput = txtIdInput.Value;
            if (hdCategoryDetail.Value != "")
                TD.CategoryDetail = Convert.ToInt16(hdCategoryDetail.Value);
            else TD.CategoryDetail = 0;
            if (hdCategoryDetailSub.Value != "")
                TD.CategoryDetailSub = Convert.ToInt16(hdCategoryDetailSub.Value);
            else TD.CategoryDetailSub = 0;
            if (chkisHot.Checked == true)
                TD.IsHot = 1;
            else TD.IsHot = 0;
            if (chkIsMostView.Checked == true)
                TD.IsMostView = 1;
            else TD.IsMostView = 0;
            if (chkIsNew.Checked == true)
                TD.IsNew = 1;
            else TD.IsNew = 0;
            if (chkIsShowPrice.Checked == true)
                TD.IsShowPrice = 1;
            else TD.IsShowPrice = 0;
            if (chkIsShowDefault.Checked == true)
                TD.IsShowDefault = 1;
            else TD.IsShowDefault = 0;
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
                string pathUpload = common.GetVirtualPath() + "\\Products";
                common.CreateDirectory(pathUpload);
                pathUpload = common.GetVirtualPath() + "\\Products\\" + id;
                common.CreateDirectory(pathUpload);
                //tao thu muc file dinh kem
                string pathUpload1 = common.GetVirtualPath() + "\\Products\\" + id+"\\FileAttach";
                common.CreateDirectory(pathUpload1);
                string filename = "";
                string filename1 = "";
                if (FileUpload1 != null && FileUpload1.PostedFile.FileName != "")
                    filename = common.Uploadfile(FileUpload1, pathUpload,  ConfigurationManager.AppSettings["imageSizeProducts400x400"] + ";" + ConfigurationManager.AppSettings["imageSizeProducts190x120"]) + ",";
                if (FileUpload2 != null && FileUpload2.PostedFile.FileName != "")
                    filename += common.Uploadfile(FileUpload2, pathUpload, ConfigurationManager.AppSettings["imageSizeProducts400x400"] + ";" + ConfigurationManager.AppSettings["imageSizeProducts190x120"]) + ",";
                if (FileUpload3 != null && FileUpload3.PostedFile.FileName != "")
                    filename += common.Uploadfile(FileUpload3, pathUpload, ConfigurationManager.AppSettings["imageSizeProducts400x400"] + ";" + ConfigurationManager.AppSettings["imageSizeProducts190x120"]) + ",";
                if (FileUpload4 != null && FileUpload4.PostedFile.FileName != "")
                    filename += common.Uploadfile(FileUpload4, pathUpload, ConfigurationManager.AppSettings["imageSizeProducts400x400"] + ";" + ConfigurationManager.AppSettings["imageSizeProducts190x120"]) + ",";
                if (FileUpload5 != null && FileUpload5.PostedFile.FileName != "")
                    filename += common.Uploadfile(FileUpload5, pathUpload, ConfigurationManager.AppSettings["imageSizeProducts400x400"] + ";" + ConfigurationManager.AppSettings["imageSizeProducts190x120"]);
                filename.Trim().Trim(',');

                if (FileUpload6 != null && FileUpload6.PostedFile.FileName != "")
                    filename1 = common.Uploadfile1(FileUpload6, pathUpload1, FileUpload6.PostedFile.FileName) + ";";
                if (FileUpload7 != null && FileUpload7.PostedFile.FileName != "")
                    filename1 += common.Uploadfile1(FileUpload7, pathUpload1, FileUpload7.PostedFile.FileName) + ";";
                if (FileUpload8 != null && FileUpload8.PostedFile.FileName != "")
                    filename1 += common.Uploadfile1(FileUpload8, pathUpload1, FileUpload8.PostedFile.FileName);
                filename1.Trim().Trim(',');
                if (filename != "")
                {
                    string fileold = getphoto(id).Trim().Trim(',').Replace(",,", ",");
                    string temp = filename;
                    if (fileold.Trim() != "")
                        temp = temp + "," + fileold;
                    Products GT = new Products();
                    GT.Photo = temp.Trim(',').Replace(",,", ",");

                    GT.ID = Convert.ToInt32(id);
                    t = db.updatePhoto(ref err, GT);

                }
                if (filename1 != "")
                {
                    string fileold = getfile(id).Trim().Trim(';').Replace(";;", ";");
                    string temp = filename1;
                    if (fileold.Trim() != "")
                        temp = temp + ";" + fileold;
                    Products GT = new Products();
                    GT.FileAttach = temp.Trim(';').Replace(";;", ";");

                    GT.ID = Convert.ToInt32(id);
                    t = db.updateFile(ref err, GT);

                }
            }

            Response.Redirect(pathAdmin + "/Products/ListProducts.aspx");
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
