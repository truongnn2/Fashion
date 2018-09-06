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
    protected void Page_Load(object sender, EventArgs e)
    {
        Titlesptt = Global.Resource.GetString("lblNewProduct", Global.ci);
        GetHotNews();
        GetBoxqc();
    }
    private void GetHotNews()
    {
        NewsDB db = new NewsDB();
        string SQL = "select top 10  ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE from Products where Photo is not null and Photo <>'' and Status=0 order by DateCreate desc,Location desc,ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string url = pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[6]) + "&catdetail=" + common.ToString(o[7]);
                string img = "";
                if (common.ToString(o[2]) != "")
                {
                    string[] listimg = common.ToString(o[2]).Split(',');
                    img = pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts"] + "/" + listimg[0];
                }
                string price = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    price = String.Format("<span>{1}: <font>{0}</font></span>", common.ToString(o[3]), Global.Resource.GetString("lblPrice", Global.ci));
                hotnews += String.Format(common.GetTemplate("NewsHot.tpl")
                    , common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[1]) : common.ToString(o[9])
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
        string SQL = "select ID,Photo,Url from BoxAd where Photo is not null and Photo <>'' and Status=0 and Category=0 order by Location desc";
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
                if (listimg[0].ToLower().IndexOf("swf") != -1)
                    boxqc += String.Format(common.GetTemplate("FlashRightClient.tpl"), pathClient + "/FileUpload/BoxAd/" + common.ToString(o[0]) + "/" + listimg[0], url);
                else
                    boxqc += String.Format("<div class=\"Banner_R {2}\"><a href=\"javascript:void(0);\"  onclick=\"window.open('{1}');\"><img src=\"{0}\" alt=\"{1}\" /></a></div>"
                        , pathClient + "/FileUpload/BoxAd/" + common.ToString(o[0]) + "/" + listimg[0]
                        , url
                        , (i != list.Count-1)? "mar_b10" : ""
                        );
            }
            boxqc = String.Format("<div class=\"R_BoxAdv mar_t10\"><h4><span>{0}</span></h4>{1}</div>"
                , Global.Resource.GetString("lblAdvertising", Global.ci)
                , boxqc
                );
        }
    }
   
}
