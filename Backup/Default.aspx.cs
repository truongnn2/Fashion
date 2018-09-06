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


public partial class _Default : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string listImage = "";
    public string sp = "";
    getList db = new getList();
    public string img = "";
    public string img1 = "";
    public int countimg = 0;
    public string listkh= "";
    public string listdoitac = "";
    public string Titlesptt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Titlesptt = Global.Resource.GetString("lblSpTieubieu", Global.ci);
        //if (Request.Cookies["defaultpage"] != null && common.ToString(Request.Cookies["defaultpage"].Value) != "")
        //{
        //    string temp = common.ToString(Request.Cookies["defaultpage"].Value);
        //    setCookie("defaultpage", "");
        //    Response.Redirect(temp);
        //}
        //GetListImage();
        GetProducts();
        setCookie("url",common.ToString(Request.Url));
        
    }
    private void GetCustomer()
    {
        IList list = db.getlist("Select ID, Name,Address from Customer where status=0 and type=0 order by Location desc");
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string name = common.ToString(o[1]);
                if (common.ToString(o[2]) != "")
                    name = name + " - " + common.ToString(o[2]);
                listkh += String.Format("<div class=\"IcoCustomer\"></div><div class=\"khachhang {1}\">{0}</div><div style=\"Clear:both\"></div>", name, i == list.Count - 1 ? "noline" : "");
            }
        }
    }
    private void GetDoitac()
    {
        IList list = db.getlist("Select ID, Name,Address from Customer where status=0 and type=1 order by Location desc");
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = (object[])list[i];
                string name = common.ToString(o[1]);
                if (common.ToString(o[2]) != "")
                    name = name + " - " + common.ToString(o[2]);
                listdoitac += String.Format("<div class=\"IcoDoitac\"></div><div class=\"d_tac {1}\">{0}</div><div style=\"Clear:both\"></div>", name, i == list.Count - 1 ? "noline" : "");
            }
        }
    }
    private void setCookie(string name, string value)
    {
        HttpCookie Cookie = new HttpCookie(name);
        DateTime now = DateTime.Now;
        Cookie.Value = value;
        Cookie.Expires = now.AddDays(1);
        Response.Cookies.Add(Cookie);
    }
    private void GetListImage()
    {
        GalleryImageDB db1 = new GalleryImageDB();
        IList list1 = db1.getList("Select ID, Photo from GalleryImage  order by ID desc");
        countimg = list1.Count;
        if (list1 != null && list1.Count > 0)
        {
            string page = "";
            for (int i = 0; i < list1.Count; i++)
            {
                object[] o1 = (object[])list1[i];
                int t = i + 1;
                page += "<li>"+t+"</li>";
                listImage += String.Format("<li><img src=\"{0}\" /><li>", pathClient + "/FileUpload/Album/" + ConfigurationManager.AppSettings["imageSizeAlbum"] + "/" + common.ToString(o1[1]));
            }
            listImage = String.Format("<ul class=\"slider\" id=\"idSlider\">{0}</ul><ul class=\"num\" id=\"idNum\">{1}</ul>",
                listImage,
                page
                );
        }
    }
    private void GetProducts()
    {
        IList listMenu = db.getlist("Select top " + ConfigurationManager.AppSettings["numProDefault"] + " ID,Title,Photo,Price,IsShowPrice,intro,Category,CategoryDetail,DateCreate,TitleE from Products where Photo is not null and Photo <>'' and Status=0 order by IsShowDefault desc,Location desc,ID desc");
        if (listMenu != null && listMenu.Count > 0)
        {
            int c = 0;
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = pathClient + "/ProductsDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cat=" + common.ToString(o[6]) + "&catdetail=" + common.ToString(o[7]);
                string[] listimg = common.ToString(o[2]).Split(',');
                c++;
                string price = "";
                if (common.ToString(o[3]) != "" && common.ToString(o[4]) == "1")
                    price = String.Format("<span>{1}: <font>{0}</font></span>", common.ToString(o[3]), Global.Resource.GetString("lblPrice", Global.ci));
                sp += String.Format(common.GetTemplate("SanphamClient.tpl"),
                    /*0*/common.ToString(Request.QueryString["l"]) == "" ? common.ToString(o[1]) : common.ToString(o[9]),
                    /*1*/link,
                    /*2*/pathClient + "/FileUpload/Products/" + common.ToString(o[0]) + "/" + ConfigurationManager.AppSettings["imageSizeProducts"] + "/" + listimg[0],
                    /*3*/price,
                    /*4*/common.ToString(o[0]),
                    /*5*/Global.Resource.GetString("lblOrder", Global.ci),
                    /*6*/common.ToString(Request.QueryString["l"])
                    );
                if (c == 3)
                {
                    sp += "<li style=\"width: 520px; padding: 0pt 10px 0px;\"></li>";
                    c = 0;
                }
            }
            
        }
        else
        {
            sp = "<li style=\"width:300px;\">" + Global.Resource.GetString("lblNodata1", Global.ci) + "</li>";
        }
    }
}
