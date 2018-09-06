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

public partial class Handler_handler : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    private getList db = new getList();
    protected void Page_Load(object sender, EventArgs e)
    {
        string act=Request.Form["act"];
        switch (act)
        {
            case "dathang":
                dathang();
                break;
            case "deletesp":
                deletesp();
                break;
            case "updatedathang":
                updatedathang();
                break;
            case "setdefault":
                setdefault();
                break;
          
        }
    }
   
    private void setdefault()
    {
        setCookie("defaultpage", Request.Form["url"]);
        Response.Write("success");
        Response.End();
    }
    private void updatedathang()
    {
        setCookie("sp", Request.Form["sp"]);
        Response.Write("success");
        Response.End();
    }
    private void deletesp()
    {
        string sp = "";
        if (common.ToString(Request.Cookies["sp"].Value).IndexOf(Request.Form["id"] + "-") != -1)
        {
            int cout = Convert.ToInt32(getCount(common.ToString(Request.Cookies["sp"].Value), Request.Form["id"]));
            int cout1 = cout + 1;
            sp = common.ToString(Request.Cookies["sp"].Value).Replace("#" + Request.Form["id"] + "-" + cout.ToString() + "#", "#");
            if (sp == "#") sp = "";
            setCookie("sp", sp);
        }
        Response.Write("success");
        Response.End();
    }
    private void dathang()
    {
        string sp = "";
        if (Request.Cookies["sp"] != null && common.ToString(Request.Cookies["sp"].Value) != "")
        {
            if (common.ToString(Request.Cookies["sp"].Value).IndexOf(Request.Form["id"] + "-") != -1)
            {
                int cout = Convert.ToInt32(getCount(common.ToString(Request.Cookies["sp"].Value), Request.Form["id"]));
                int cout1 = cout + 1;
                sp = common.ToString(Request.Cookies["sp"].Value).Replace("#" + Request.Form["id"] + "-" + cout.ToString() + "#", "#" + Request.Form["id"] + "-" + cout1.ToString() + "#");
                setCookie("sp", sp);
            }
            else
            {
                sp = common.ToString(Request.Cookies["sp"].Value) + Request.Form["id"] + "-1#";
                setCookie("sp", sp);
            }
        }
        else
        {
            sp = "#" + Request.Form["id"] + "-1#";
            setCookie("sp",sp);
        }
        
        Response.Write("success");
        Response.End();
    }
    private void setCookie(string name, string value)
    {
        HttpCookie Cookie = new HttpCookie(name);
        DateTime now = DateTime.Now;
        Cookie.Value = value;
        Cookie.Expires = now.AddDays(1);
        Response.Cookies.Add(Cookie);
    }
    private string getCount(string s, string s1)
    {
        string[] temp = s.Trim('#').Split('#');
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].IndexOf(s1 + "-") != -1)
            {
                return temp[i].Split('-')[1];
            }
        }
        return "0";
    }

}
