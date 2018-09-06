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

public partial class Uc_ucSolution : System.Web.UI.UserControl
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string listSolution = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetSolution();
    }
    private void GetSolution()
    {
        NewsDB db = new NewsDB();
        string SQL = "select top 2 ID,Title,Photo,DateCreate,TitleE,Content,ContentE from Solution where Photo is not null and Photo <>'' and Status=0 order by DateCreate desc,Location desc,ID desc";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string url = pathClient + "/SolutionDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) ;
                string img = "";
                if (common.ToString(o[2]) != "")
                {
                    string[] listimg = common.ToString(o[2]).Split(',');
                    img = pathClient + "/FileUpload/Solution/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeSolution"] + "/" + listimg[0];
                }
                string tempcont = common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[5]) : common.ToString(o[6]);
                string content = Regex.Replace(common.RemoveTag(common.RemoveTag(common.RemoveTag(HttpUtility.HtmlDecode(tempcont), "<style", "</style>"), "<script", "</script>"), "<w:WordDocument>", "</w:WordDocument>"), @"<[\s\S]*?>", "");
                content = common.LaySoKyTuCuaChuoi(content, 190);
                listSolution += String.Format(common.GetTemplate("SolutionListClient.tpl")
                   /*0*/, common.ToString(Request.QueryString["l"]) == "0" ? common.ToString(o[1]) : common.ToString(o[4])
                   /*1*/, url
                   /*2*/, img
                   /*3*/, common.ToString(Request.QueryString["l"]) == "0" ? "Xem thêm" : "Details"
                   /*4*/, content
                    );
            }
        }
    }
}
