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

public partial class Uc_Right : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string hotnews = "";
    public string boxqc = "";
    public string Titlesptt = "";
    public string TitleSupportOnline = "";
    public string Listsupport = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        TitleSupportOnline = Global.Resource.GetString("lblTitlesupport", Global.ci);
        Titlesptt = Global.Resource.GetString("lblNewProduct", Global.ci);
        GetHotNews();
        GetBoxqc();
        GetOnlineSupport();
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
                Listsupport += String.Format("<div class=\"Contents\"><span style=\"color: red;\">{0}</span> <br />{1}<br /><span>{2}</span></a></div>"
                , common.ToString(o[1])
                , listskype + listyahoo
                , common.ToString(o[4])
                );
            }
        }
    }
    private void GetHotNews()
    {
        NewsDB db = new NewsDB();
        string SQL = "select top 30  ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE,CategoryDetailSub,PromotionPrice,(select Name from Menu where ID=Category) as NameCat,(select Name from MenuSub where ID=CategoryDetail) as NameCatSub,(select Name from MenuSubSub where ID=CategoryDetailSub) as NameCatSubSub from Products where Photo is not null and Photo <>'' and Status=0 order by DateCreate desc,Location desc,ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string url = common.GetUrlProductDetail(common.ToString(o[1]), common.ToString(o[0]), common.ToString(o[12]), common.ToString(o[6]), common.ToString(o[13]), common.ToString(o[7]), common.ToString(o[14]), common.ToString(o[10]), Global.l);//pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[6]) + "&catdetail=" + common.ToString(o[7]) + "&catdetailsub=" + common.ToString(o[10]);
                string img = "";
                if (common.ToString(o[2]) != "")
                {
                    string[] listimg = common.ToString(o[2]).Split(',');
                    img = pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts"] + "/" + listimg[0];
                }
                string price = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    price = String.Format("<span style=\"color:red;\">{1}: <font>{0}</font></span>", common.ToString(o[3]), Global.Resource.GetString("lblPrice", Global.ci));
                hotnews += String.Format(common.GetTemplate("NewsHot.tpl")
                    , common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[9]) : common.ToString(o[1])
                    , url
                    , img
                    , price
                    );
            }
        }
    }

    private void GetBoxqc()
    {
        BoxAdDB db = new BoxAdDB();
        string SQL = "select ID,Photo,Url from BoxAd where Status=0 and Category=0 order by Location desc";
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
            boxqc = String.Format(common.GetTemplate("QuangCao_Right.tpl"), boxqc, Global.Resource.GetString("lblAdvertising", Global.ci));
        }
    }
   
}
