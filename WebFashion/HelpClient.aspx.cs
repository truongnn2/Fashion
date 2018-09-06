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

public partial class HelpClient : System.Web.UI.Page
{
    public string cont = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GiamgiaDB db = new GiamgiaDB();
        string SQL = "select Content from Giamgia where ID = 1";
        IList list = db.getList(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            string temp=common.ToString(o[0]);
            cont = common.replaceWidthImage(HttpUtility.HtmlDecode(temp), 540);
        }
    }
}
