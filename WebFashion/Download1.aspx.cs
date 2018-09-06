using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common;
using System.IO;
using DBBusiness;

public partial class Download1 : System.Web.UI.Page
{
    getList db = new getList();
    protected void Page_Load(object sender, EventArgs e)
    {
        string filename = common.ToString(Request.QueryString["name"]);
        if(filename!="")
        {
            string filePath = common.GetVirtualPath() + "\\Products\\" + common.ToString(Request.QueryString["id"]) + "\\FileAttach\\" + filename;

            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);

                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(filePath);
                Response.End();
            }			
        }
        
    }
    private string getName(string id)
    {
        if (id == "") return "";
        string sql = "Select ID,FileAttach from Products where Status=0 and ID=" + id;
        IList listMenu = db.getlist(sql);
        if (listMenu != null && listMenu.Count > 0)
        {
            object[] o = (object[])listMenu[0];
            return common.ToString(o[1]) + "$" + common.ToString(o[2]);
        }
        return "";
    }
}
