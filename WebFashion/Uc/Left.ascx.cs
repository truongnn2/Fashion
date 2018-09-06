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

public partial class Uc_Left : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    string PathTemp = ConfigurationManager.AppSettings["WebTemplate"];
    public string ml = "";
    public string menu_services = "";
    public string TitleCategory = "";
    public string Titleqc = "";
    public string Listsupport = "";
    public string TitleSupportOnline = "";
    public string boxqc = "";
    public string DiscountProducts = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        TitleCategory = Global.Resource.GetString("lblTitleCategory", Global.ci);
        TitleSupportOnline = Global.Resource.GetString("lblTitlesupport", Global.ci);
        IList listMenu = db.getlist("Select ID,Name,NameE from Menu where Status=0 order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string menusub = "";
                menusub = GetSubMenu(common.ToString(o[0]));
                ml += String.Format("<h2>{0}</h2><ul class=\"categories_list\">{1}</ul>",
                    /*0*/common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[2]) : common.ToString(o[1]),
                    /*1*/menusub,
                    /*2*/common.ToString(Request.QueryString["cat"]) == common.ToString(o[0]) ? "current" : ""
                );
            }
        }
        GetOnlineSupport();
        GetDiscountsProducts();
        GetBoxqc();
    }
    private void GetDiscountsProducts()
    {
        ProductsDB db = new ProductsDB();
        string SQL = "select top " + ConfigurationManager.AppSettings["numDiscountsProducts"] + "  ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE,CategoryDetailSub,PromotionPrice,(select Name from Menu where ID=Category) as NameCat,(select Name from MenuSub where ID=CategoryDetail) as NameCatSub from Products where Photo is not null and Photo <>'' and Status=0 and IsShowDefault =1 order by ViewCount desc,Location desc,ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            int count = 0;
            string listtemp = "";
            string tempItem = common.GetTemplate("ProductsDiscountsItem.tpl");
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
                    price = common.ToString(o[3]);
                listtemp += String.Format(tempItem
                    /*0*/ , url
                    /*1*/ , img
                    /*2*/ , price
                    /*3*/ , i == list.Count - 1 ? "" : "lineleft"
                    );
            }

            if (listtemp != "")
            {
                DiscountProducts = String.Format(common.GetTemplate("ProductsDiscounts.tpl")
                    , listtemp
                    , Global.Resource.GetString("lblTitleDiscountsProducts", Global.ci)
                    );
            }
        }
    }
    private string GetCatSubServices(string idMenu)
    {
        string result = "";
        IList listMenu = db.getlist("Select a.ID,a.Name,a.NameE,b.Name from CatSubServices a,CatServices b where a.Status=0 and a.IDCatServices=" + idMenu + " and a.IDCatServices=b.ID order by a.Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = common.GetUrlCatServicesSub(common.ToString(o[3]), idMenu, common.ToString(o[1]), common.ToString(o[0]), Global.l, "1");//pathClient + "/ListServices.aspx" + Global.l + "&pg=1&cats=" + idMenu + "&catdetails=" + common.ToString(o[0]);
                string cl = "";

                if (common.ToString(Request.QueryString["catdetails"]) == common.ToString(o[0]))
                {
                    cl = "current1";
                }

                result += String.Format("<tr><td class=\"left_menu_td\"><a class=\"left_menu {2}\" href=\"{1}\">{0}</a></td></tr>",
                common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[2]) : common.ToString(o[1]),
                link,
                cl
                );
            }
        }
        return result;
    }
    private void GetBoxqc()
    {
        BoxAdDB db = new BoxAdDB();
        string SQL = "select ID,Photo,Url from BoxAd where Status=0 and Category=1 order by Location desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string[] listimg = common.ToString(o[1]).Split(',');
                string url = "";
                if (common.ToString(o[2]) != "")
                    url = "http://" + common.ToString(o[2]).Replace("http://", "");
                boxqc += String.Format("<div class=\"left_banner\"><a href=\"javascript:void(0);\"  onclick=\"window.open('{1}');\"><img class=\"image_style\" src=\"{0}\" alt=\"{1}\" /></a></div>", pathClient + "/FileUpload/BoxAd/" + common.ToString(o[0]) + "/" + listimg[0], url);
            }
            boxqc = String.Format(common.GetTemplate("QuangCao.tpl"), boxqc, Global.Resource.GetString("lblAdvertising", Global.ci));
        }
    }
    private string GetSubMenu(string idMenu)
    {
        string result = "";
        IList listMenu = db.getlist("Select a.ID,a.Name,a.NameE,b.Name from MenuSub a,Menu b where a.Status=0 and a.IDMenu=" + idMenu + " and a.IDMenu=b.ID order by a.Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = common.GetUrlCatSub(common.ToString(o[3]), idMenu, common.ToString(o[1]), common.ToString(o[0]), Global.l, "1");//pathClient + "/products.aspx" + Global.l + "&pg=1&cat=" + idMenu + "&catdetail=" + common.ToString(o[0]);
                string cl = "";
                if (common.ToString(Request.QueryString["catdetail"]) == common.ToString(o[0]))
                {
                    cl = "current";
                }
                result += String.Format("<li><a class=\"{2}\" href=\"{1}\">{0}</a></li>",
                    common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[2]) : common.ToString(o[1]),
                    link,
                    cl
                    );
            }
        }
        return result;
    }
    private string GetSubMenuSub(string idMenu, string idMenuSub)
    {
        string result = "";
        IList listMenu = db.getlist("Select a.ID,a.Name,a.NameE,b.Name,c.Name from MenuSubSub a,MenuSub b,Menu c where a.Status=0 and a.IDMenuSub=" + idMenuSub + " and a.IDMenuSub=b.ID and b.IDMenu=c.ID order by a.Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = common.GetUrlCatSubSub(common.ToString(o[4]), idMenu, common.ToString(o[3]), idMenuSub, common.ToString(o[1]), common.ToString(o[0]), Global.l, "1");// pathClient + "/products.aspx" + Global.l + "&pg=1&cat=" + idMenu + "&catdetail=" + idMenuSub + "&catdetailsub=" + common.ToString(o[0]);
                string cl = "";
                if (common.ToString(Request.QueryString["catdetailsub"]) == common.ToString(o[0]))
                {
                    cl = "current1";
                }

                result += String.Format("<li><a href=\"{1}\" class=\"menusubsub {2}\"><span>{0}</span></a></li>",
                    common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[2]) : common.ToString(o[1]),
                    link,
                    cl
                    );
            }
            result = "<tr class=\"menusubsubmain\"><td style=\"border-left: 1px solid inactivecaption;border-right: 1px solid inactivecaption;\"><ul class=\"menucontentssub\">" + result + "</ul></td></tr>";
        }
        return result;
    }
    private void GetOnlineSupport()
    {
        SupportOnlineDB db = new SupportOnlineDB();
        string SQL = "select ID, Name, NickName, NickSkype, Phone, Status from SupportOnline where Status=0 order by ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            bool t = true;
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string listyahoo = "";
                string listskype = "";
                if (common.ToString(o[2]) != "")
                {
                    string[] tempyh = common.ToString(o[2]).Split(',');
                    for (int j = 0; j < tempyh.Length; j++)
                    {
                        listyahoo += String.Format("<a href=\"ymsgr:sendim?{0}&amp;m=\"><img border=\"0\" src=\"http://opi.yahoo.com/online?u={0}&amp;m=g&amp;t=2\" alt=\"{0}\" style=\"padding-top:5px;padding-left:5px;\"></a>"
                            , tempyh[j].Trim()
                            );
                    }
                }
                if (common.ToString(o[3]) != "")
                {
                    string[] tempsp = common.ToString(o[3]).Split(',');
                    for (int j = 0; j < tempsp.Length; j++)
                    {
                        listskype += String.Format("<a href=\"skype:{0}?chat\"><img src=\"http://mystatus.skype.com/bigclassic/{0}\" style=\"border: none;\" width=\"150\" height=\"35\" alt=\"My status\" /></a>"
                            , tempsp[j].Trim()
                            );
                    }
                    if (t)
                    {
                        listskype = "<script type=\"text/javascript\" src=\"http://download.skype.com/share/skypebuttons/js/skypeCheck.js\"></script>" + listskype;
                        t = false;
                    }
                }
                Listsupport += String.Format("<div class=\"Contents\"><span style=\"color: #000;font-size:14px;\">{0}</span> <br />{1}<br /><h4><span style=\"color: red;font-size:16px;\">{2}</span></h4></a></div>"
                , common.ToString(o[1])
                , listskype + listyahoo
                , common.ToString(o[4])
                );
            }
        }
    }
    private string GetProject()
    {
        string result = "";
        IList listMenu = db.getlist("Select ID,Name,NameE from Menu where Status=0 order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = pathClient + "/products.aspx" + Global.l + "&pg=1&cat=" + common.ToString(o[0]);
                result += String.Format("<li><a class=\"{2}\" href=\"{1}\">{0}</a></li>", 
                    common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[1]) : common.ToString(o[2]), 
                    link,
                    common.ToString(o[0]) == common.ToString(Request.QueryString["cat"]) ? "current" : ""
                    );
            }
            if (result != "")
                result = String.Format("<div class=\"box-title\"><h1> {0}</h1></div><div style=\"padding-left:6px;\"><div class=\"box-content\"><div class=\"box_category\"><ul>{1}</ul></div></div></div>"
                    , common.ToString(Request.QueryString["l"]) == "0" ? "Dự án" : "Project"
                    , result
                    );
        }
        return result;
    }
    private string GetDichVu() 
    {
        string result = "";
        IList listMenu = db.getlist("Select ID,Title,TitleE from Solution where Status=0 order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = pathClient + "/SolutionDetail.aspx" + Global.l + "&pg=1&id=" + common.ToString(o[0]);

                result += String.Format("<li><a class=\"{2}\" href=\"{1}\">{0}</a></li>",
                    common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[1]) : common.ToString(o[2]),
                    link,
                    ((common.ToString(o[0]) == common.ToString(Request.QueryString["id"])) && (common.ToString(Request.Url).ToLower().IndexOf("solution")!=0)) ? "current" : ""
                    );
            }
            if (result != "")
                result = String.Format("<div class=\"box-title\"><h1> {0}</h1></div><div style=\"padding-left:6px;\"><div class=\"box-content\"><div class=\"box_category\"><ul>{1}</ul></div></div></div>"
                    , common.ToString(Request.QueryString["l"]) == "0" ? "Dịch vụ" : "Services"
                    , result
                    );
        }
        return result;
    }
    
}
