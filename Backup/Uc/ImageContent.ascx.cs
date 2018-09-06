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
public partial class ImageContent : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string listImage = "";
    public int countimg = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetListImage();
    }
    private void GetListImage()
    {
        GalleryImageDB db1 = new GalleryImageDB();
        IList list1 = db1.getList("Select ID, Photo from GalleryImage  order by ID desc");
        if (list1 != null && list1.Count > 0)
        {
            string page = "";
            ImageBanner.Attributes.Add("style", "display:");
            for (int i = 0; i < list1.Count; i++)
            {
                object[] o1 = (object[])list1[i];
                listImage += String.Format("<img src=\"{0}\" />", pathClient + "/FileUpload/Album/" + common.ToString(o1[1])); //ConfigurationManager.AppSettings["imageSizeAlbum"] + "/" +
            }
           
        }
    }
}
