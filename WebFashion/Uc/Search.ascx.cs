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

public partial class Uc_Search : System.Web.UI.UserControl
{
    public string find1 = "";
    public string hotnews = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        find1 = Global.Resource.GetString("lblFind", Global.ci);
        AboutUsDB db = new AboutUsDB();
        string SQL = "select Content,ContentE from AboutUs where ID =3";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            string tempcont = common.ToString(Request.QueryString["l"]) == "1" ? common.ToString(o[1]) : common.ToString(o[0]);
            if(tempcont.Trim()!="")
                hotnews = String.Format(common.GetTemplate("HotNews.tpl"),
                /*0*/tempcont
                    );
        }
        
    }
}
