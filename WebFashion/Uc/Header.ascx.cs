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
    public string project = "";
    public string listImage = "";
    public string listjs = "";
    public string flash = "";
    public string menutop = "";
    public string language = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        flash = common.ToString(Request.QueryString["l"]) == "1" ? "banner_top_en.swf" : "banner_top.swf";
        menutop = String.Format(common.GetTemplate("MenuHead.tpl"),
             Global.Resource.GetString("lblTrangchu", Global.ci), //0
             Global.Resource.GetString("lblGioithieu", Global.ci), //1
             Global.Resource.GetString("lblProduct", Global.ci), //2
             Global.Resource.GetString("lblNews", Global.ci),//3
             Global.Resource.GetString("lblPromotion", Global.ci), //4
             Global.Resource.GetString("lblLienhe", Global.ci), //5 
             pathClient +"/"+ Global.l + "/trang-chu.aspx",//6
             pathClient + "/" + Global.l + "/gioi-thieu.aspx" ,//7
             pathClient + "/" + Global.l + "/trang-1/danh-sach-san-pham.aspx",//8
             pathClient + "/" + Global.l + "/trang-1/tin-tuc.aspx",//9
             pathClient + "/" + Global.l + "/trang-1/khuyen-mai.aspx",//10
             pathClient + "/" + Global.l + "/lien-he.aspx",//11
             pathClient //12
            );
        language = common.ToString(Request.QueryString["l"])==""?"0":"1";
        GetProducts();
    }

    private void GetProducts()
    {
        getList db = new getList();
        IList listMenu = db.getlist("Select top " + ConfigurationManager.AppSettings["numProHot"] + " ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE,CategoryDetailSub,PromotionPrice,(select Name from Menu where ID=Category) as NameCat,(select Name from MenuSub where ID=CategoryDetail) as NameCatSub,(select Name from MenuSubSub where ID=CategoryDetailSub) as NameCatSubSub from Products where Photo is not null and Photo <>'' and Status=0 and IsHot=1 order by IsShowDefault desc,Location desc,ID desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = common.GetUrlProductDetail(common.ToString(o[1]), common.ToString(o[0]), common.ToString(o[12]), common.ToString(o[6]), common.ToString(o[13]), common.ToString(o[7]), common.ToString(o[14]), common.ToString(o[10]), Global.l);//pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[6]) + "&catdetail=" + common.ToString(o[7]) + "&catdetailsub=" + common.ToString(o[10]);
                string[] listimg = common.ToString(o[2]).Split(',');
                string title = common.ToString(o[1]);
                if (common.ToString(Request.QueryString["l"]) == "1")
                {
                    title = common.ToString(o[9]);
                }
                project += String.Format(common.GetTemplate("ProjectDefault.tpl"),
                    /*0*/common.LaySoKyTuCuaChuoi(title, 25),
                    /*1*/link,
                    /*2*/pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts190x120"] + "/" + listimg[0]
                    );

            }
        }
        IList listMenu1 = db.getlist("Select top " + ConfigurationManager.AppSettings["numProHot"] + " ID, Category, CategorySub, Title, TitleE, Content, ContentE, Photo, Status, DateCreate, Location, FileAttach, IsHot from Services where Photo is not null and Photo <>'' and Status=0 and IsHot=1 order by Location desc,ID desc");
        if (listMenu1 != null && listMenu1.Count > 0)
        {
            for (int i = 0; i < listMenu1.Count; i++)
            {
                object[] o = (object[])listMenu1[i];
                string link = pathClient + "/ServicesDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cats=" + common.ToString(o[1]) + "&catdetails=" + common.ToString(o[2]);
                string[] listimg = common.ToString(o[7]).Split(',');
                string title = common.ToString(o[3]);
                if (common.ToString(Request.QueryString["l"]) == "1")
                {
                    title = common.ToString(o[4]);
                }
                project += String.Format(common.GetTemplate("ProjectDefault.tpl"),
                    /*0*/common.LaySoKyTuCuaChuoi(title, 25),
                    /*1*/link,
                    /*2*/pathClient + "/FileUpload/Services/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeServices190x120"] + "/" + listimg[0]
                    );

            }

        }
        
    }
    private void GetListImage()
    {
        GalleryImageDB db1 = new GalleryImageDB();
        IList list1 = db1.getList("Select ID, Photo,Description from GalleryImage  order by ID desc");
        if (list1 != null && list1.Count > 0)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                object[] o1 = (object[])list1[i];
                listImage += String.Format("<img id=\"slide-img-{1}\" src=\"{0}\" alt=\"\" class=\"slide\" />", pathClient + "/FileUpload/Album/" + ConfigurationManager.AppSettings["imageSizeAlbum"] + "/" + common.ToString(o1[1]), i);
                listjs += "{" + String.Format("'id': 'slide-img-{1}', 'client': '', 'desc': '{0}' ", common.ToString(o1[2]), i) + "},";
            }
            listjs = listjs.Trim(',');
        }
        else
        {
            listImage += String.Format("<img id=\"slide-img-{1}\" src=\"{0}\" alt=\"\" class=\"slide\" />", pathClient + "/images/banner.jpg","1");
            listjs += "{" + String.Format("'id': 'slide-img-{1}', 'client': '', 'desc': '{0}' ", "","1") + "},";
        }
    }
}
