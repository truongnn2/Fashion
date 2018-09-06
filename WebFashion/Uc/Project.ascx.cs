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

public partial class Uc_Project : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    string PathTemp = ConfigurationManager.AppSettings["WebTemplate"];
    public string sp = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetProducts();
    }
    private void GetProducts()
    {
        IList listMenu = db.getlist("select top " + ConfigurationManager.AppSettings["numNewProducts"] + "  ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE,CategoryDetailSub,PromotionPrice,(select Name from Menu where ID=Category) as NameCat,(select Name from MenuSub where ID=CategoryDetail) as NameCatSub from Products where Photo is not null and Photo <>'' and Status=0 and IsNew=1 order by ViewCount desc,Location desc,ID desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            string tempItem = common.GetTemplate("ProductsNewItem.tpl");
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string url = common.GetUrlProductDetail(common.ToString(o[1]), common.ToString(o[0]), common.ToString(o[12]), common.ToString(o[6]), common.ToString(o[13]), common.ToString(o[7]), "", "", Global.l);
                string img = "";
                if (common.ToString(o[2]) != "")
                {
                    string[] listimg = common.ToString(o[2]).Split(',');
                    img = pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts190x120"] + "/" + listimg[0];
                }
                sp += String.Format(tempItem
                   /*0*/ , common.LaySoKyTuCuaChuoi(common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[9]) : common.ToString(o[1]),17)
                   /*1*/ , url
                   /*2*/ , img
                   ///*3*/ , price
                   ///*4*/ , img400
                   ///*5*/ , ""//count == 3 ? "onmouseover='EditLeft();'" : ""
                   ///*6*/ , count == 3 ? "" : "margin_r35"
                   ///*7*/ , Global.Resource.GetString("lblChitiet", Global.ci)
                   ///*8*/ , Global.Resource.GetString("lblBuyNow", Global.ci)
                   ///*9*/ , common.ToString(Request.QueryString["l"])
                   ///*10*/, common.ToString(o[0])
                    );

            }
            if (sp != "")
            {
                sp = String.Format(common.GetTemplate("ProductsNewList.tpl")
                    /*0*/ , sp
                    /*1*/ , Global.Resource.GetString("lblProductNew", Global.ci)
                   );
            }
        }
       
    }
}
