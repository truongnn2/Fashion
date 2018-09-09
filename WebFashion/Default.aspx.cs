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
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string listImage = "";
    
    
    getList db = new getList();
    public string img = "";
    public string img1 = "";
    public int countimg = 0;
    public string listkh= "";
    public string listdoitac = "";
    public string aboutus = "";
    public string Titlepage = "";
    public string TitleProductsViewCount = "";
    public string TitleProductsNew = "";
    public string service = "";
    public string ProductsViewCount = "";
    public string MostViewProducts = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        favicon.Attributes.Add("href", pathClient + "/favicon.ico");
        StyleTag00.Attributes.Add("href", pathClient + "/Css/stylesheetweb.css");
        StyleTag01.Attributes.Add("href", pathClient + "/Css/simple-sidebar.css");
        StyleTag.Attributes.Add("href", pathClient + "/Css/style.css");
        StyleTag1.Attributes.Add("href", pathClient + "/Css/owl.carousel.css");
        StyleTag2.Attributes.Add("href", pathClient + "/Css/owl.carousel.partner.css");
        StyleTag3.Attributes.Add("href", pathClient + "/Css/animate.min.css");
        Titlepage = Global.Resource.GetString("lblTitlepage", Global.ci);
        //TitleProductsViewCount = Global.Resource.GetString("lblTitleProductsViewCount", Global.ci);
        //TitleProductsNew = Global.Resource.GetString("lblNewProduct", Global.ci);
        GetFeaturedProducts();
        GetMostViewProducts();
        //GetProductsPromotion();
    }
    private void GetFeaturedProducts()
    {
        ProductsDB db = new ProductsDB();
        string SQL = "select top " + ConfigurationManager.AppSettings["numFeaturedProducts"] + "  ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE,CategoryDetailSub,PromotionPrice,(select Name from Menu where ID=Category) as NameCat,(select Name from MenuSub where ID=CategoryDetail) as NameCatSub from Products where Photo is not null and Photo <>'' and Status=0 and isHot=1 order by ViewCount desc,Location desc,ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            int count = 0;
            string listtemp="";
            string tempItem = common.GetTemplate("ProductsDefault.tpl");
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                count++;
                string url = common.GetUrlProductDetail(common.ToString(o[1]), common.ToString(o[0]), common.ToString(o[12]), common.ToString(o[6]), common.ToString(o[13]), common.ToString(o[7]), "", "", Global.l);//pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[6]) + "&catdetail=" + common.ToString(o[7]) + "&catdetailsub=" + common.ToString(o[10]);
                string img = "";
                string img400 = "";
                if (common.ToString(o[2]) != "")
                {
                    string[] listimg = common.ToString(o[2]).Split(',');
                    img = pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts190x120"] + "/" + listimg[0];
                    img400 =pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts400x400"] + "/" + listimg[0];
                }
                string price = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    price = String.Format("<p class=\"price\">{1}: {0}</p>", common.ToString(o[3]), Global.Resource.GetString("lblPrice", Global.ci));
                else price = "<p class=\"price\">&nbsp;</p>";
                listtemp += String.Format(tempItem
                   /*0*/ , common.LaySoKyTuCuaChuoi(common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[9]) : common.ToString(o[1]),15)
                   /*1*/ , url
                   /*2*/ , img
                   /*3*/ , price
                   /*4*/ , img400
                   /*5*/ , ""//count == 3 ? "onmouseover='EditLeft();'" : ""
                   /*6*/ , count == 3 ? "" : "margin_r35"
                   /*7*/ , Global.Resource.GetString("lblChitiet", Global.ci)
                   /*8*/ , Global.Resource.GetString("lblBuyNow", Global.ci)
                   /*9*/ , common.ToString(Request.QueryString["l"])
                   /*10*/, common.ToString(o[0])
                    );
                
                if (count == 3)
                {
                    listtemp += "<div class=\"cleaner\"></div>";
                    count = 0;
                }
            }

            if (listtemp != "")
            {
                ProductsViewCount = String.Format(common.GetTemplate("ProductsPromotion.tpl")
                    , listtemp
                    , Global.Resource.GetString("lblbFeaturedProducts", Global.ci)
                    );
            }
        }
    }
    private void GetMostViewProducts()
    {
        ProductsDB db = new ProductsDB();
        string SQL = "select top " + ConfigurationManager.AppSettings["numFeaturedProducts"] + "  ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE,CategoryDetailSub,PromotionPrice,(select Name from Menu where ID=Category) as NameCat,(select Name from MenuSub where ID=CategoryDetail) as NameCatSub from Products where Photo is not null and Photo <>'' and Status=0 and isHot=1 order by ViewCount desc,Location desc,ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            int count = 0;
            string listtemp = "";
            string tempItem = common.GetTemplate("ProductsDefault.tpl");
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                count++;
                string url = common.GetUrlProductDetail(common.ToString(o[1]), common.ToString(o[0]), common.ToString(o[12]), common.ToString(o[6]), common.ToString(o[13]), common.ToString(o[7]), "", "", Global.l);//pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[6]) + "&catdetail=" + common.ToString(o[7]) + "&catdetailsub=" + common.ToString(o[10]);
                string img = "";
                string img400 = "";
                if (common.ToString(o[2]) != "")
                {
                    string[] listimg = common.ToString(o[2]).Split(',');
                    img = pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts190x120"] + "/" + listimg[0];
                    img400 = pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts400x400"] + "/" + listimg[0];
                }
                string price = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    price = String.Format("<p class=\"price\">{1}: {0}</p>", common.ToString(o[3]), Global.Resource.GetString("lblPrice", Global.ci));
                else price = "<p class=\"price\">&nbsp;</p>";
                listtemp += String.Format(tempItem
                    /*0*/ , common.LaySoKyTuCuaChuoi(common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[9]) : common.ToString(o[1]), 15)
                    /*1*/ , url
                    /*2*/ , img
                    /*3*/ , price
                    /*4*/ , img400
                    /*5*/ , ""//count == 3 ? "onmouseover='EditLeft();'" : ""
                    /*6*/ , count == 3 ? "" : "margin_r35"
                    /*7*/ , Global.Resource.GetString("lblChitiet", Global.ci)
                    /*8*/ , Global.Resource.GetString("lblBuyNow", Global.ci)
                    /*9*/ , common.ToString(Request.QueryString["l"])
                    /*10*/, common.ToString(o[0])
                    );

                if (count == 3)
                {
                    listtemp += "<div class=\"cleaner\"></div>";
                    count = 0;
                }
            }

            if (listtemp != "")
            {
                MostViewProducts = String.Format(common.GetTemplate("ProductsPromotion.tpl")
                    , listtemp
                    , Global.Resource.GetString("lblTitleProductsViewCount", Global.ci)
                    );
            }
        }
    }
    private string GetAboutUs()
    {
        GioiThieuDB db1 = new GioiThieuDB();
        IList list1 = db1.getList("select Content,ContentE from AboutUs where ID = 1");
        string tempCont = "";
        if (list1 != null && list1.Count > 0)
        {
            object[] o = (object[])list1[0];
            string link = pathClient + "/About.aspx" + Global.l;
            string temp = common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[0]) : common.ToString(o[1]);
            string content = Regex.Replace(common.RemoveTag(common.RemoveTag(common.RemoveTag(HttpUtility.HtmlDecode(temp), "<style", "</style>"), "<script", "</script>"), "<w:WordDocument>", "</w:WordDocument>"), @"<[\s\S]*?>", "");
            tempCont=String.Format(common.GetTemplate("AboutUs.tpl")
            ,common.LaySoKyTuCuaChuoi(content, 450)
            , link
            , common.ToString(Request.QueryString["l"]) == "0" ? "Chi tiết" : "Detail"
            , common.ToString(Request.QueryString["l"]) == "0" ? "GIỚI THIỆU" : "ABOUT US"
            );
        }
        return tempCont;
    }
    private void GetService()
    {
        IList listMenu = db.getlist("Select ID, Title, TitleE, Content, ContentE, Photo, Status, DateCreate, Location from Solution where Photo is not null and Photo <>'' and Status=0 order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link1 = pathClient + "/SolutionDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]);
                string[] listimg = common.ToString(o[5]).Split(',');
                string temp = common.ToString(o[3]);
                string title1 = common.ToString(o[1]);
                string viewdetail = "Chi tiết";
                if (common.ToString(Request.QueryString["l"]) == "1")
                {
                    temp = common.ToString(o[4]);
                    title1 = common.ToString(o[2]);
                    viewdetail = "Detail";
                }
                string content = Regex.Replace(common.RemoveTag(common.RemoveTag(common.RemoveTag(HttpUtility.HtmlDecode(temp), "<style", "</style>"), "<script", "</script>"), "<w:WordDocument>", "</w:WordDocument>"), @"<[\s\S]*?>", "");
                service += String.Format(common.GetTemplate("ServiceDefault.tpl"),
                    /*0*/title1,
                    /*1*/link1,
                    /*2*/pathClient + "/FileUpload/Solution/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeSolution"] + "/" + listimg[0],
                    /*3*/common.LaySoKyTuCuaChuoi(content, 200),
                    /*4*/viewdetail,
                    /*5*/i==listMenu.Count-1?"": "hr_footer1"
                    );
            }
            service = String.Format("<div class=\"TitleBox_M1\"><h2><span class=\"titlebox\">{0}</span></h2></div>", common.ToString(Request.QueryString["l"]) == "0" ? "DỊCH VỤ" : "SERVICES") + service;
        }
        
    }
    
   
}
