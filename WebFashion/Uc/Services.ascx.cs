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

public partial class Uc_Services : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    string PathTemp = ConfigurationManager.AppSettings["WebTemplate"];
    public string service = "";
    public string serviceList = "";
    public string TitleService = "text_home_service_vn.gif";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetService();
    }
    private void GetService()
    {
        IList listMenu = db.getlist("Select top 4 ID, Title, TitleE, Content, ContentE, Photo, Status, DateCreate, Location from Solution where Photo is not null and Photo <>'' and Status=0 order by Location desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 1; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = pathClient + "/SolutionDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]);
                string title = common.ToString(o[1]);

                if (common.ToString(Request.QueryString["l"]) == "1")
                {
                    title = common.ToString(o[2]);
                }
                serviceList += String.Format(common.GetTemplate("ServiceDefaultItem.tpl"),
                    /*0*/title,
                    /*1*/link,
                    /*2*/pathClient
                    );
               
            }
            if (serviceList != "")
                serviceList = String.Format(common.GetTemplate("ServiceDefaultListItem.tpl"),
                    /*0*/serviceList
                 );
            object[] o1 = (object[])listMenu[0];
            string link1 = pathClient + "/SolutionDetail.aspx" + Global.l + "&id=" + common.ToString(o1[0]);
            string[] listimg = common.ToString(o1[5]).Split(',');
            string temp = common.ToString(o1[3]);
            string title1 = common.ToString(o1[1]);
            if (common.ToString(Request.QueryString["l"]) == "1")
            {
                TitleService = "text_home_service_en.gif";
                temp = common.ToString(o1[4]);
                title1 = common.ToString(o1[2]);
            }
            string content = Regex.Replace(common.RemoveTag(common.RemoveTag(common.RemoveTag(HttpUtility.HtmlDecode(temp), "<style", "</style>"), "<script", "</script>"), "<w:WordDocument>", "</w:WordDocument>"), @"<[\s\S]*?>", "");
            service += String.Format(common.GetTemplate("ServiceDefault.tpl"),
                /*0*/title1,
                /*1*/link1,
                /*2*/pathClient + "/FileUpload/Solution/" + common.ToString(o1[0]) + "/" + ConfigurationManager.AppSettings["imageSizeSolution"] + "/" + listimg[0],
                /*3*/common.LaySoKyTuCuaChuoi(content, 200),
                /*4*/Global.Resource.GetString("lblViewAll", Global.ci),
                /*5*/pathClient + "/ListSolution.aspx" + Global.l,
                /*6*/TitleService,
                /*7*/serviceList
                );
           
        }
        else
        {
            service = "<table><tr><td>" + Global.Resource.GetString("lblNodata1", Global.ci) + "</td></tr></table>";
        }
    }
}
