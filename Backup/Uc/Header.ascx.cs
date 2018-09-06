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
public partial class Uc_Header : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string about = "";
    public string find = "";
    public string find1 = "";
    public string language = "";
    public string listImage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        mt.InnerHtml = String.Format(common.GetTemplate("MenuHead.tpl"),
             Global.Resource.GetString("lblTrangchu", Global.ci), //0
             Global.Resource.GetString("lblGioithieu", Global.ci), //1
             Global.Resource.GetString("lblServices", Global.ci), //2
             Global.Resource.GetString("lblLienhe", Global.ci),//3
             pathClient + "/Default.aspx" + Global.l,//4
             pathClient + "/About.aspx" + Global.l,//5
             pathClient + "/Services.aspx" + Global.l,//6
             pathClient + "/ContactUs.aspx" + Global.l,//7
             Global.Resource.GetString("lblProduct", Global.ci), //8
             pathClient + "/Products.aspx" + Global.l+"&pg=1"//9
             );
        if(common.ToString(Request.QueryString["l"])!="1")
        {
            about = String.Format(common.GetTemplate("GioiThieuCty_V.tpl"), pathClient + "/About.aspx" + Global.l);
            
        }
        else about = String.Format(common.GetTemplate("GioiThieuCty_E.tpl"), pathClient + "/About.aspx" + Global.l);
        find = Global.Resource.GetString("lblSearch", Global.ci);
        find1 = Global.Resource.GetString("lblFind", Global.ci);
        language = common.ToString(Request.QueryString["l"]);
        GetListImage();
    }
    private void GetListImage()
    {
        GalleryImageDB db1 = new GalleryImageDB();
        IList list1 = db1.getList("Select ID, Photo from GalleryImage  order by ID desc");
        if (list1 != null && list1.Count > 0)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                object[] o1 = (object[])list1[i];
                string cl = "";
                if (i == 0) cl = "active";
                int t = i + 1;
                listImage += String.Format("<img src=\"{0}\" alt=\"Slideshow Image {2}\" class=\"{1}\" />", pathClient + "/FileUpload/Album/" + ConfigurationManager.AppSettings["imageSizeAlbum"] + "/" + common.ToString(o1[1]), cl, t.ToString());
            }
        }
    }
}
