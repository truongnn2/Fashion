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

public partial class ListSolution : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string sptt = "";
    public string title = "Promotion";
    public string proDetail = "";
    public string link1 = "";
    public string b = "1";
    public string Titlepage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        StyleTag1.Attributes.Add("href", pathClient + "/Css/templatemo_style.css");
        StyleTag.Attributes.Add("href", pathClient + "/Css/styles.css");
        Titlepage = Global.Resource.GetString("lblTitlepage", Global.ci);
        sptt=GetSolution();
        hdfRecordCount.Value = ConfigurationManager.AppSettings["DisplayPage"];
        if (common.ToString(Request.QueryString["l"]) == "0")
        {
            title = "Khuyến mãi";
        }
    }
    private string GetSolution()
    {

        string ttt = "";
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.QueryString["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.QueryString["pg"]);
        }
        plFirstPage = common.ToString(Request.QueryString["pg"]) != "" ? (int.Parse(common.ToString(Request.QueryString["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        count = getCountRecord("select count(ID) from Solution where Status=0 ");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.QueryString["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string sql = "Select top " + rowsOnPage.ToString() + " ID,Title,Photo,DateCreate,TitleE,Content,ContentE from Solution where ID in ( select top " + plFirstPage.ToString() + " ID  from Solution where Photo is not null and Photo <>'' and Status=0 order by ID desc)  order by ID asc";

        IList listMenu = db.getlist(sql);
        if (listMenu != null && listMenu.Count > 0)
        {
            int c = 0;
            for (int i = listMenu.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])listMenu[i];
                c++;
                string link = common.GetUrlPromotionDetail(common.ToString(o[1]), common.ToString(o[0]), Global.l);//pathClient + "/SolutionDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]);
                string[] listimg = common.ToString(o[2]).Split(',');
                string tempcont = common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[5]) : common.ToString(o[6]);
                string content = Regex.Replace(common.RemoveTag(common.RemoveTag(common.RemoveTag(HttpUtility.HtmlDecode(tempcont), "<style", "</style>"), "<script", "</script>"), "<w:WordDocument>", "</w:WordDocument>"), @"<[\s\S]*?>", "");
                content = common.LaySoKyTuCuaChuoi(content, 250);
                ttt += String.Format(common.GetTemplate("SolutionListClient1.tpl"),
                    /*0*/common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[1]) : common.ToString(o[4]),
                    /*1*/link,
                    /*2*/pathClient + "/FileUpload/Solution/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeSolution"] + "/" + listimg[0],
                    /*3*/common.ToString(Request.QueryString["l"]) == "0" ? "Chi tiết" : "Details",
                    /*4*/content,
                    /*5*/i == 0 ? "display:none" : "",
                    /*6*/i != 0 ? "border-bottom: 1px dotted #000;" : ""
                    );

            }

            ttt = "<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + ttt;
            link1 = common.GetUrlPromotion(Global.l, "###");//pathClient + "/ListSolution.aspx" + Global.l + "&pg=";
        }
        if (ttt == "")
        {
            b = "0";
            ttt = Global.Resource.GetString("lblCapnhadulieu", Global.ci) ;
        }
        return ttt;
    }
    private int getCountRecord(string sql)
    {
        IList list = db.getlist(sql);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return Convert.ToInt32(o[0]);
        }
        else return 0;
    }
}
