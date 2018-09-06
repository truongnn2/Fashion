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

public partial class Admins_Album_AddNew : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private GalleryImageDB db1 = new GalleryImageDB();
    public string listphoto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             Showdata();
        }
    }
    private void Showdata()
    {
        IList list1 = db1.getList("Select ID, Photo,Description from GalleryImage  order by ID desc");
        if(list1!=null&&list1.Count>0)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                object[] o1 = (object[])list1[i];
                listphoto += String.Format(common.GetTemplate("AlbumListImage.tpl")
                    , pathClient + "/FileUpload/Album/" + common.ToString(o1[1])
                    , "img" + i.ToString()
                    , common.ToString(o1[1])
                    ,common.ToString(o1[2])
                    );//+ ConfigurationManager.AppSettings["imageSizeAlbum"] + "/"
            }
        }
    }
   
    protected void Addnew_ServerClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string pathUpload = common.GetVirtualPath() + "\\Album";
            common.CreateDirectory(pathUpload);
            string filename1 = "";
            string filename2 = "";
            filename1 = common.Uploadfile(FileUpload1, pathUpload, ConfigurationManager.AppSettings["imageSizeAlbum"]) ;
            filename2 = common.Uploadfile(FileUpload2, pathUpload, ConfigurationManager.AppSettings["imageSizeAlbum"]) ;
            bool t;
            string err = "";
            if (filename1 != "")
            {

                GalleryImage GT = new GalleryImage();
                GT.Photo = filename1 ;
                GT.Description = txtDescription.Value;
                t = db1.insert(ref err, GT);
            }
            if (filename2 != "")
            {

                GalleryImage GT = new GalleryImage();
                GT.Photo = filename2;
                GT.Description = txtDescription1.Value;
                t = db1.insert(ref err, GT);
            }
           
            Response.Redirect(pathAdmin + "/Album/AddNew.aspx");
        }

    }
}
