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
using System.Text;
using System.Drawing.Text;

public partial class Admin_handler_Logout : System.Web.UI.Page
{
    private getList db = new getList();
    string PathTemp = ConfigurationManager.AppSettings["WebTemplate"];
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    string pathUpload = "";
    public string ImageUpload = common.GetVirtualPath();
    protected void Page_Load(object sender, EventArgs e)
    {
        pathUpload = common.GetVirtualPath();
        string act = common.ToString(Request.Form["act"]);
        switch (act)
        {
            case "logout":
                Logout();
                break;
            case "listContactUs":
                ListContactUs();
                break;
            case "deleteLH":
                DeleteLH();
                break;
            case "ChStatusContactUs":
                ChangeStatusContactUs();
                break;
            case "listNews":
                ListNews();
                break;
            case "ChStatusNews":
                ChangeStatusNews();
                break;
            case "deleteNews":
                DeleteNews();
                break;
            case "deleteImgNews":
                DeleteImgNews();
                break;
            case "listMenu":
                ListMenu();
                break;
            case "ChStatusMenu":
                ChStatusMenu();
                break;
            case "listMenuSub":
                ListMenuSub();
                break;
            case "ChStatusMenuSub":
                ChStatusMenuSub();
                break;
            case "DeleteCatSub":
                DeleteCatSub();
                break;
            case "getListCatDetail":
                GetListCatDetail();
                break;
            case "listQA":
                ListQA();
                break;
            case "ChStatusQA":
                ChStatusQA();
                break;
            case "deleteQA":
                DeleteQA();
                break;
            case "deleteImgAlbum":
                DeleteImgAlbum();
                break;
            case "listBoxAd":
                ListBoxAd();
                break;
            case "deleteImgBoxAd":
                DeleteImgBoxAd();
                break;
            case "ChStatusBoxAd":
                ChStatusBoxAd();
                break;
            case "deletefile":
                DeleteFileNews();
                break;

                //font
            case "listSolution":
                listSolution();
                break;
            case "ChStatusSolution":
                ChStatusSolution();
                break;
            case "deleteSolution":
                deleteSolution();
                break;
            case "deleteImgSolution":
                deleteImgSolution();
                break;
            case "listProducts":
                ListProducts();
                break;
            case "deleteImgProducts":
                DeleteImgProducts();
                break;
            case "ChStatusProducts":
                ChangeStatusProducts();
                break;
           
            case "deleteProducts":
                DeleteProducts();
                break;
            case "listFileDownload":
                ListFileDownload();
                break;
            case "ChStatusFileDownload":
                ChangeStatusFileDownload();
                break;
            case "deleteFileDownload":
                DeleteFileDownload();
                break;
            case "listLinkWebsite":
                listLinkWebsite();
                break;
            case "ChStatusLinkWebsite":
                ChStatusLinkWebsite();
                break;
            case "deleteLinkWebsite":
                deleteLinkWebsite();
                break;
           
            case "deleteImgBlog":
                DeleteImgBlog();
                break;
            case "listBlog":
                ListBlog();
                break;
            case "ChStatusBlog":
                ChStatusBlog();
                break;
            case "ChangeDefaultBlog":
                ChangeDefaultBlog();
                break;
            case "deleteBlog":
                deleteBlog();
                break;
            case "listcomment":
                listcomment();
                break;
            case "ChStatusComment":
                ChStatusComment();
                break;
            case "deleteComment":
                deleteComment();
                break;
            case "listGuest":
                listGuest();
                break;
            case "ChStatusGuest":
                ChStatusGuest();
                break;
            case "deleteGuest":
                deleteGuest();
                break;
            case "listcommentfont":
                listcommentfont();
                break;
            case "ChStatusCommentFont":
                ChStatusCommentFont();
                break;
            case "deleteCommentFont":
                deleteCommentFont();
                break;
            case "listCustomer":
                listCustomer();
                break;
            case "ChStatusCustomer":
                ChStatusCustomer();
                break;
            case "deleteCustomer":
                deleteCustomer();
                break;
            case "listGioiThieu":
                listGioiThieu();
                break;
            case "ChStatusGioiThieu":
                ChStatusGioiThieu();
                break;
            case "listSupportOnline":
                listSupportOnline();
                break;
            case "ChStatusSupportOnline":
                ChStatusSupportOnline();
                break;
            case "DeleteSupportOnline":
                DeleteSupportOnline();
                break;
            case "ListMenuSubSub":
                ListMenuSubSub();
                break;
            case "ChStatusMenuSubSub":
                ChStatusMenuSubSub();
                break;
            case "DeleteCatSubSub":
                DeleteCatSubSub();
                break;
            case "getListCatDetailSub":
                getListCatDetailSub();
                break;
            case "listCatServices":
                listCatServices();
                break;
            case "ChStatusCatServices":
                ChStatusCatServices();
                break;
            case "listCatSubServices":
                listCatSubServices();
                break;
            case "ChStatusCatSubServices":
                ChStatusCatSubServices();
                break;
            case "DeleteCatSubServices":
                DeleteCatSubServices();
                break;
            case "listServices":
                listServices();
                break;
            case "ChStatusServices":
                ChStatusServices();
                break;
            case "deleteServices":
                deleteServices();
                break;
            case "deleteImgServices":
                deleteImgServices();
                break;
            case "deletefileServices":
                deletefileServices();
                break;
            case "GetListCatSubServices":
                GetListCatSubServices();
                break;
        }
    }
    private void GetListCatSubServices()
    {
        CatServicesDB db1 = new CatServicesDB();
        IList vList = db1.getList("Select ID,Name from CatSubServices where IDCatServices=" + common.ToString(Request.Form["cat"]));
        if (vList != null)
        {
            Response.ContentType = "text/xml";
            Response.Write("<?xml version='1.0' encoding='utf-8'?>");
            Response.Write("<options>");
            Response.Write("<option>");
            Response.Write("<value> </value>");
            Response.Write("<text>Chọn</text>");
            Response.Write("</option>");
            if (vList != null && vList.Count > 0)
            {
                IEnumerator ie = vList.GetEnumerator();
                while (ie.MoveNext())
                {
                    object[] vList_ = (object[])ie.Current;
                    Response.Write("<option>");
                    Response.Write("<value>" + vList_[0] + "</value>");
                    Response.Write("<text>" + vList_[1].ToString().Replace('&', '|') + "</text>");
                    Response.Write("</option>");
                }
            }
            Response.Write("</options>");
            Response.End();
        }
        Response.Write("");
        Response.End();
    }
    private void deleteImgServices()
    {

        string listimg = ListImage("select ID,photo from Services where ID=" + common.ToString(Request.Form["id"]));
        if (listimg != "")
        {
            string img1 = pathUpload + "\\Services\\" + common.ToString(Request.Form["id"]) + "\\" + common.ToString(Request.Form["img"]);
            string img2 = pathUpload + "\\Services\\" + common.ToString(Request.Form["id"]) + "\\" + ConfigurationManager.AppSettings["imageSizeServices"] + "\\" + common.ToString(Request.Form["img"]);
            if (File.Exists(img1))
                File.Delete(img1);
            if (File.Exists(img2))
                File.Delete(img2);
        }
        ServicesDB DA = new ServicesDB();
        Services GT = new Services();
        GT.Photo = listimg.Replace(common.ToString(Request.Form["img"]), "").Replace(",,", ",").Trim(',');
        GT.ID = Convert.ToInt32(common.ToString(Request.Form["id"]));
        String err = "";
        bool t = DA.updatePhoto(ref err, GT);
        Response.Write("");
        Response.End();
    }
    private void deleteServices()
    {
        ServicesDB td = new ServicesDB();
        common.DeleteFile(pathUpload + "\\Services\\" + common.ToString(Request.Form["cat"]) + "\\" + common.ToString(Request.Form["id"]));
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusServices()
    {
        ServicesDB td = new ServicesDB();
        Services TD = new Services();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listServices()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["kw"]) != "")
            condi = " and (Title like N'%" + common.ToString(Request.Form["kw"]) + "%' or Content like N'%" + common.ToString(Request.Form["kw"]) + "%')";
        if (common.ToString(Request.Form["type"]) != "")
            condi += " and Category =" + common.ToString(Request.Form["type"]);
        if (common.ToString(Request.Form["typeDetail"]) != "" && common.ToString(Request.Form["typeDetail"]) != "null")
            condi += " and CategoryDetail =" + common.ToString(Request.Form["typeDetail"]);

        count = getCountRecord("select count(ID) from Services where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Title,(select Name from CatServices where ID=Category) as CategoryName,Status,DateCreate,(select Name from CatSubServices where ID=CategorySub) as CategoryNameDetail,Location,TitleE from Services where ID in (select top " + plFirstPage.ToString() + " ID from Services where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/Services/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxServices.Delete({0});' class=\"delete\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("ServicesList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.ToString(o[7]),
                    /*4*/common.ToString(o[6]),
                    /*5*/common.ToString(o[2]),
                    /*6*/common.ToString(o[5]),
                    /*7*/common.GetEnumType(typeof(eStatusNews), common.ToString(o[3])),
                    /*8*/common.ToString(o[4]),
                    /*9*/String.Format(func, common.ToString(o[0]))
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Services.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void deletefileServices()
    {
        string listimg = ListImage("select ID,FileAttach from Services where ID=" + common.ToString(Request.Form["id"]));
        if (listimg != "")
        {
            string img1 = pathUpload + "\\Services\\" + common.ToString(Request.Form["id"]) + "\\FileAttach\\" + common.ToString(Request.Form["filename"]);
            if (File.Exists(img1))
                File.Delete(img1);
        }
        ServicesDB DA = new ServicesDB();
        Services GT = new Services();
        GT.FileAttach = listimg.Replace(common.ToString(Request.Form["filename"]), "").Replace(";;", ";").Trim(';');
        GT.ID = Convert.ToInt32(common.ToString(Request.Form["id"]));
        String err = "";
        bool t = DA.updateFile(ref err, GT);
        Response.Write("");
        Response.End();
    }
    private void DeleteCatSubServices()
    {
        CatSubServicesDB td = new CatSubServicesDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }

    private void ChStatusCatSubServices()
    {
        CatSubServicesDB td = new CatSubServicesDB();
        CatSubServices TD = new CatSubServices();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }

    private void listCatSubServices()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["category"]) != "")
            condi += " and IDMenu =" + common.ToString(Request.Form["category"]);
        count = getCountRecord("select count(ID) from CatSubServices where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Name,Status,Location,(select Name from CatServices b where a.IDCatServices=b.ID)as NameMenu,NameE  from CatSubServices a where ID in (select top " + plFirstPage.ToString() + " ID from CatSubServices where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/CatSubServices/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxCatSubServices.DeleteCatSubServices({0});'  class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("MenuSubList.tpl"),
                    cl,
                    common.ToString(o[0]),
                    common.ToString(o[1]),
                    common.GetEnumType(typeof(eStatusMenuSub), common.ToString(o[2])),
                    String.Format(func, common.ToString(o[0])),
                    common.ToString(o[3]),
                    common.ToString(o[4]),
                    common.ToString(o[5])
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("MenuSub.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void ChStatusCatServices()
    {
        CatServicesDB td = new CatServicesDB();
        CatServices TD = new CatServices();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listCatServices()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        count = getCountRecord("select count(ID) from CatServices");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Name,Status,Location,NameE from CatServices where ID in (select top " + plFirstPage.ToString() + " ID from CatServices where ID>0  order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/CatServices/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("MenuList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.GetEnumType(typeof(eStatusMenu), common.ToString(o[2])),
                    /*4*/String.Format(func, common.ToString(o[0])),
                    /*5*/common.ToString(o[3]),
                    /*6*/common.ToString(o[4])
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Menu.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void getListCatDetailSub()
    {
        MenuSubSubDB db1 = new MenuSubSubDB();
        IList vList = db1.getList("Select ID,Name from MenuSubSub where IDMenuSub=" + common.ToString(Request.Form["cat"]));
        if (vList != null)
        {
            Response.ContentType = "text/xml";
            Response.Write("<?xml version='1.0' encoding='utf-8'?>");
            Response.Write("<options>");
            Response.Write("<option>");
            Response.Write("<value> </value>");
            Response.Write("<text>Chọn</text>");
            Response.Write("</option>");
            if (vList != null && vList.Count > 0)
            {
                IEnumerator ie = vList.GetEnumerator();
                while (ie.MoveNext())
                {
                    object[] vList_ = (object[])ie.Current;
                    Response.Write("<option>");
                    Response.Write("<value>" + vList_[0] + "</value>");
                    Response.Write("<text>" + vList_[1].ToString().Replace('&', '|') + "</text>");
                    Response.Write("</option>");
                }
            }
            Response.Write("</options>");
            Response.End();
        }
        Response.Write("");
        Response.End();
    }
    private void DeleteCatSubSub()
    {
        MenuSubSubDB td = new MenuSubSubDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusMenuSubSub()
    {
        MenuSubSubDB td = new MenuSubSubDB();
        MenuSubSub TD = new MenuSubSub();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void ListMenuSubSub()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["category"]) != "")
            condi += " and IDMenu =" + common.ToString(Request.Form["category"]);
        count = getCountRecord("select count(ID) from MenuSubSub where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Name,Status,Location,(select Name from Menu b where a.IDMenu=b.ID)as NameMenu,NameE,(select Name from MenuSub c where a.IDMenuSub=c.ID)as NameMenuSub  from MenuSubSub a where ID in (select top " + plFirstPage.ToString() + " ID from MenuSubSub where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/MenuSubSub/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxMenuSubSub.DeleteCatSub({0});'  class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("MenuSubSubList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.GetEnumType(typeof(eStatusMenuSub), common.ToString(o[2])),
                    /*4*/String.Format(func, common.ToString(o[0])),
                    /*5*/common.ToString(o[3]),
                    /*6*/common.ToString(o[4]),
                    /*7*/common.ToString(o[5]),
                    /*8*/common.ToString(o[6])
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("MenuSubSub.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void DeleteSupportOnline()
    {
        SupportOnlineDB td = new SupportOnlineDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusSupportOnline()
    {
        SupportOnlineDB td = new SupportOnlineDB();
        SupportOnline TD = new SupportOnline();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listSupportOnline()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        count = getCountRecord("select count(ID) from SupportOnline");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Name,Status,Phone,NickName,NickSkype from SupportOnline where ID in (select top " + plFirstPage.ToString() + " ID from SupportOnline where ID>0  order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/SupportOnline/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxSupportOnline.DeleteSupportOnline({0});'  class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("SupportOnlineList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.GetEnumType(typeof(eStatusMenu), common.ToString(o[2])),
                    /*4*/String.Format(func, common.ToString(o[0])),
                    /*5*/common.ToString(o[4]),
                    /*6*/common.ToString(o[3]),
                    /*7*/common.ToString(o[5])
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("SupportOnline.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void ChStatusGioiThieu()
    {
        GioiThieuDB td = new GioiThieuDB();
        GioiThieu TD = new GioiThieu();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listGioiThieu()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;

        count = getCountRecord("select count(ID) from GioiThieu where ID>0");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID, Title, Status, Location  from GioiThieu a where ID in (select top " + plFirstPage.ToString() + " ID from GioiThieu where ID>0 order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/GioiThieu/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("GioiThieuList.tpl"),
                    cl,
                    common.ToString(o[0]),
                    common.ToString(o[1]),
                    common.GetEnumType(typeof(eStatusMenuSub), common.ToString(o[2])),
                    common.ToString(o[3]),
                    String.Format(func, common.ToString(o[0]))
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("GioiThieu.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void deleteCustomer()
    {
        CustomerDB td = new CustomerDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusCustomer()
    {
        CustomerDB td = new CustomerDB();
        Customer TD = new Customer();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listCustomer()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["cat"]) != "")
            condi += " and type =" + common.ToString(Request.Form["cat"]);
        count = getCountRecord("select count(ID) from Customer where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID, Name, Phone, Email, Address, Status, Location  from Customer a where ID in (select top " + plFirstPage.ToString() + " ID from Customer where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/Customer/AddNew.aspx?id={0}&cat={1}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxCustomer.Delete({0});'  class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("CustomerList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.ToString(o[2]),
                    /*4*/common.ToString(o[3]),
                    /*5*/common.ToString(o[4]),
                    /*6*/common.ToString(o[6]),
                    /*7*/common.GetEnumType(typeof(eStatusMenuSub), common.ToString(o[5])),
                    /*8*/String.Format(func, common.ToString(o[0]), common.ToString(Request.Form["cat"]))
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Customer.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void deleteCommentFont()
    {
        CommentFontDB td = new CommentFontDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusCommentFont()
    {
        CommentFontDB td = new CommentFontDB();
        CommentFont TD = new CommentFont();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listcommentfont()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["kw"]) != "")
            condi = " and (Title like N'%" + common.ToString(Request.Form["kw"]) + "%' or Content like N'%" + common.ToString(Request.Form["kw"]) + "%' )";
        count = getCountRecord("select count(ID) from CommentFont where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID, Title, Content, Status, DateCreate,(select b.Title from Products b where b.ID=a.FontID) as Title from CommentFont a where ID in (select top " + plFirstPage.ToString() + " ID from CommentFont where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\" style=\"width:40px;\"><ul><li><a href='javascript:void(0);' onclick='ajxComment.Delete({0});' class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";

                temptd += String.Format(common.GetTemplate("CommentFontList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.ToString(o[2]),
                    /*4*/common.ToString(o[5]),
                    /*5*/common.GetEnumType(typeof(eStatusNews), common.ToString(o[3])),
                    /*5*/common.ToString(o[4]),
                    /*6*/String.Format(func, common.ToString(o[0]))
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("CommentFont.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void deleteGuest()
    {
        GuestDB td = new GuestDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusGuest()
    {
        GuestDB td = new GuestDB();
        Guest TD = new Guest();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listGuest()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["kw"]) != "")
            condi = " and (Name like N'%" + common.ToString(Request.Form["kw"]) + "%' or Email like N'%" + common.ToString(Request.Form["kw"]) + "%' or MobilePhone like N'%" + common.ToString(Request.Form["kw"]) + "%' or Phone like N'%" + common.ToString(Request.Form["kw"]) + "%' )";
        count = getCountRecord("select count(ID) from Guest where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID, Name, Username, Password, Email, Phone, MobilePhone, Status, Date from Guest a where ID in (select top " + plFirstPage.ToString() + " ID from Guest where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\" style=\"width:40px;\"><ul><li><a href='javascript:void(0);' onclick='ajxGuest.Delete({0});' class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";

                temptd += String.Format(common.GetTemplate("GuestList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.ToString(o[4]),
                    /*4*/common.ToString(o[3]),
                    /*5*/common.ToString(o[5]),
                    /*6*/common.ToString(o[6]),
                    /*7*/common.GetEnumType(typeof(eStatusGuest), common.ToString(o[7])),
                    /*8*/common.ToString(o[8]),
                    /*9*/String.Format(func, common.ToString(o[0]))
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Guest.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void deleteComment()
    {
        CommentDB td = new CommentDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusComment()
    {
        CommentDB td = new CommentDB();
        Comment TD = new Comment();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listcomment()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["kw"]) != "")
            condi = " and (Title like N'%" + common.ToString(Request.Form["kw"]) + "%' or Content like N'%" + common.ToString(Request.Form["kw"]) + "%' )";
        count = getCountRecord("select count(ID) from Comment where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID, Title, Content, Status, DateCreate,(select b.Title from Blog b where b.ID=a.BlogID) as Title from Comment a where ID in (select top " + plFirstPage.ToString() + " ID from Comment where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\" style=\"width:40px;\"><ul><li><a href='javascript:void(0);' onclick='ajxComment.Delete({0});' class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";

                temptd += String.Format(common.GetTemplate("CommentList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.ToString(o[2]),
                    /*4*/common.ToString(o[5]),
                    /*5*/common.GetEnumType(typeof(eStatusNews), common.ToString(o[3])),
                    /*5*/common.ToString(o[4]),
                    /*6*/String.Format(func, common.ToString(o[0]))
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Comment.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void deleteBlog()
    {
        BlogDB td = new BlogDB();
        common.DeleteFile(pathUpload + "\\Blog\\" + common.ToString(Request.Form["id"]));
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChangeDefaultBlog()
    {
        BlogDB td = new BlogDB();
        Blog TD = new Blog();
        TD.DisplayDefault = Convert.ToInt16(common.ToString(Request.Form["sltDisplayDefault"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateChangeDefault(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void ChStatusBlog()
    {
        BlogDB td = new BlogDB();
        Blog TD = new Blog();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void ListBlog()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["kw"]) != "")
            condi = " and Title like N'%" + common.ToString(Request.Form["kw"]) + "%' ";
        if (common.ToString(Request.Form["cat"]) != "")
            condi = " and Category=" + common.ToString(Request.Form["cat"]);
        count = getCountRecord("select count(ID) from Blog where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID, Title, Content, Photo, Status, DateCreate, Location, DisplayDefault,Category from Blog where ID in (select top " + plFirstPage.ToString() + " ID from Blog where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\" style=\"width:100px;\"><ul><li><a href='" + pathAdmin + "/blog/AddNew.aspx?cat={1}&id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxBlog.Delete({0});' class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                
                temptd += String.Format(common.GetTemplate("BlogList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.GetEnumType(typeof(eStatusNews), common.ToString(o[4])),
                    /*4*/common.GetEnumType(typeof(eIsShowDefault), common.ToString(o[7])),
                    /*5*/common.ToString(o[5]),
                    /*6*/String.Format(func, common.ToString(o[0]), common.ToString(o[8])),
                    /*7*/common.ToString(o[6])
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Blog.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void DeleteImgBlog()
    {

        string listimg = ListImage("select ID,photo from Blog where ID=" + common.ToString(Request.Form["id"]));
        if (listimg != "")
        {
            common.DeleteFile(pathUpload + "\\Blog\\" + common.ToString(Request.Form["id"]));
        }
        BlogDB DA = new BlogDB();
        Blog GT = new Blog();
        GT.Photo = listimg.Replace(common.ToString(Request.Form["img"]), "").Replace(",,", ",").Trim(',');
        GT.ID = Convert.ToInt32(common.ToString(Request.Form["id"]));
        String err = "";
        bool t = DA.updatePhoto(ref err, GT);
        Response.Write("");
        Response.End();
    }
   
    private void deleteLinkWebsite()
    {
        LinkWebsiteDB td = new LinkWebsiteDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusLinkWebsite()
    {
        LinkWebsiteDB td = new LinkWebsiteDB();
        LinkWebsite TD = new LinkWebsite();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void listLinkWebsite()
    {
        string SQL = "select ID,Website,Url,Status from LinkWebsite order by ID desc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\" style=\"width:100px;\"><ul><li><a href='javascript:void(0);' onclick='ajxLinkWebsite.Delete({0});' class=\"delete\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("LinkWebsiteList.tpl"), cl, common.ToString(o[0]), common.ToString(o[1]), common.ToString(o[2]), common.GetEnumType(typeof(eStatusProducts), common.ToString(o[3])), String.Format(func, common.ToString(o[0])));
            }
            Response.Write(String.Format(common.GetTemplate("LinkWebsite.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void DeleteFileDownload()
    {
        DownloadDB td = new DownloadDB();
        string listimage = ListImage("select ID,Namefile from Download where ID=" + common.ToString(Request.Form["id"]));
        string img1 = pathUpload + "\\Download\\" + listimage;
        if (File.Exists(img1))
            File.Delete(img1);
        String err = "";
        bool t = td.delete(ref err, listimage);
        Response.Write("");
        Response.End();
    }
    private void ChangeStatusFileDownload()
    {
        DownloadDB td = new DownloadDB();
        Download TD = new Download();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void ListFileDownload()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        count = getCountRecord("select count(ID) from Download ");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Name, Status from Download where ID in (select top " + plFirstPage.ToString() + " ID from Download order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<a href='javascript:void(0);' onclick='ajxFileDownload.Delete({0});' class=\"delete\">Xóa</a>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("FileDownloadList.tpl"), cl, common.ToString(o[0]), common.ToString(o[1]), common.GetEnumType(typeof(eStatusNews), common.ToString(o[2])), String.Format(func, common.ToString(o[0])));
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("FileDownload.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void DeleteProducts()
    {
        ProductsDB td = new ProductsDB();
        common.DeleteFile(pathUpload + "\\Products\\" + common.ToString(Request.Form["cat"]) + "\\" + common.ToString(Request.Form["id"]));
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void deleteSolution()
    {
        SolutionDB td = new SolutionDB();
        //common.DeleteFile(pathUpload + "\\font\\" + common.ToString(Request.Form["cat"]) + "\\" + common.ToString(Request.Form["id"]));
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChangeStatusProducts()
    {
        ProductsDB td = new ProductsDB();
        Products TD = new Products();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void ChStatusSolution()
    {
        SolutionDB td = new SolutionDB();
        Solution TD = new Solution();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void DeleteImgProducts()
    {

        string listimg = ListImage("select ID,photo from Products where ID=" + common.ToString(Request.Form["id"]));
        if (listimg != "")
        {
            string img1 = pathUpload + "\\Products\\" + common.ToString(Request.Form["id"]) + "\\" + common.ToString(Request.Form["img"]);
            string img2 = pathUpload + "\\Products\\" + common.ToString(Request.Form["id"]) + "\\" + ConfigurationManager.AppSettings["imageSizeProducts"] + "\\" + common.ToString(Request.Form["img"]);
            string img3 = pathUpload + "\\Products\\" + common.ToString(Request.Form["id"]) + "\\" + ConfigurationManager.AppSettings["imageSizeProducts400x400"] + "\\" + common.ToString(Request.Form["img"]);
            if (File.Exists(img1))
                File.Delete(img1);
            if (File.Exists(img2))
                File.Delete(img2);
            if (File.Exists(img3))
                File.Delete(img3);
        }
        ProductsDB DA = new ProductsDB();
        Products GT = new Products();
        GT.Photo = listimg.Replace(common.ToString(Request.Form["img"]), "").Replace(",,", ",").Trim(',');
        GT.ID = Convert.ToInt32(common.ToString(Request.Form["id"]));
        String err = "";
        bool t = DA.updatePhoto(ref err, GT);
        Response.Write("");
        Response.End();
    }
    private void deleteImgSolution()
    {

        string listimg = ListImage("select ID,photo from Solution where ID=" + common.ToString(Request.Form["id"]));
        if (listimg != "")
        {
            string img1 = pathUpload + "\\Solution\\" + common.ToString(Request.Form["id"]) + "\\" + common.ToString(Request.Form["img"]);
            string img2 = pathUpload + "\\Solution\\" + common.ToString(Request.Form["id"]) + "\\" + ConfigurationManager.AppSettings["imageSizeSolution"] + "\\" + common.ToString(Request.Form["img"]);
            if (File.Exists(img1))
                File.Delete(img1);
            if (File.Exists(img2))
                File.Delete(img2);
          
        }
        SolutionDB DA = new SolutionDB();
        Solution GT = new Solution();
        GT.Photo = listimg.Replace(common.ToString(Request.Form["img"]), "").Replace(",,", ",").Trim(',');
        GT.ID = Convert.ToInt32(common.ToString(Request.Form["id"]));
        String err = "";
        bool t = DA.updatePhoto(ref err, GT);
        Response.Write("");
        Response.End();
    }
    private void listSolution()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["kw"]) != "")
            condi = " and (Title like N'%" + common.ToString(Request.Form["kw"]) + "%' or Content like N'%" + common.ToString(Request.Form["kw"]) + "%')";
       
        count = getCountRecord("select count(ID) from Solution where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Title,TitleE,Status,DateCreate,Location from Solution where ID in (select top " + plFirstPage.ToString() + " ID from Solution where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/Solution/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxSolution.Delete({0});' class=\"delete\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("SolutionList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.ToString(o[2]),
                    /*4*/common.ToString(o[5]),
                    /*5*/common.GetEnumType(typeof(eStatusNews), common.ToString(o[3])),
                    /*6*/common.ToString(o[4]),
                    /*7*/String.Format(func, common.ToString(o[0]))
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Solution.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void ListProducts()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["kw"]) != "")
            condi = " and (Title like N'%" + common.ToString(Request.Form["kw"]) + "%' or Content like N'%" + common.ToString(Request.Form["kw"]) + "%')";
        if (common.ToString(Request.Form["type"]) != "")
            condi += " and Category =" + common.ToString(Request.Form["type"]);
        if (common.ToString(Request.Form["typeDetail"]) != "" && common.ToString(Request.Form["typeDetail"]) != "null")
            condi += " and CategoryDetail =" + common.ToString(Request.Form["typeDetail"]);
        if (common.ToString(Request.Form["IsShowDefault"]) == "1")
            condi += " and IsShowDefault =" + common.ToString(Request.Form["IsShowDefault"]);
        else if (common.ToString(Request.Form["IsShowDefault"]) == "0")
            condi += " and (IsShowDefault =0 or IsShowDefault is null)";
        count = getCountRecord("select count(ID) from Products where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Title,(select Name from Menu where ID=Category) as CategoryName,Status,DateCreate,(select Name from MenuSub where ID=CategoryDetail) as CategoryNameDetail,Location,IsShowDefault,TitleE from Products where ID in (select top " + plFirstPage.ToString() + " ID from Products where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/Products/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxProducts.Delete({0});' class=\"delete\">Xóa</a></li></ul></div>";
            string tempItem = common.GetTemplate("ProductsList.tpl");
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(tempItem,
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.ToString(o[2]),
                    /*4*/common.GetEnumType(typeof(eStatusNews), common.ToString(o[3])),
                    /*5*/String.Format(func, common.ToString(o[0])),
                    /*6*/common.ToString(o[4]),
                    /*7*/"",//common.ToString(o[5]),
                    /*8*/common.ToString(o[6]),
                    /*9*/common.ToString(o[7]) == "1" ? "Có" : "Không",
                    /*10*/common.ToString(o[8]),
                    /*11*/common.ToString(o[0])
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Products.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void DeleteFileNews()
    {
        string listimg = ListImage("select ID,FileAttach from Products where ID=" + common.ToString(Request.Form["id"]));
        if (listimg != "")
        {
            string img1 = pathUpload + "\\Products\\" + common.ToString(Request.Form["id"]) + "\\FileAttach\\" + common.ToString(Request.Form["filename"]);
            if (File.Exists(img1))
                File.Delete(img1);
        }
        ProductsDB DA = new ProductsDB();
        Products GT = new Products();
        GT.FileAttach = listimg.Replace(common.ToString(Request.Form["filename"]), "").Replace(";;", ";").Trim(';');
        GT.ID = Convert.ToInt32(common.ToString(Request.Form["id"]));
        String err = "";
        bool t = DA.updateFile(ref err, GT);
        Response.Write("");
        Response.End();
    }
    private void ChStatusBoxAd()
    {
        BoxAdDB td = new BoxAdDB();
        BoxAd TD = new BoxAd();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void DeleteImgBoxAd()
    {
        string listimg = ListImage("select ID,photo from BoxAd where ID=" + common.ToString(Request.Form["id"]));
        if (listimg != "")
        {
            string img1 = pathUpload + "\\BoxAd\\" + common.ToString(Request.Form["id"]);
            common.DeleteFile(img1);
        }
        BoxAdDB DA = new BoxAdDB();
        BoxAd GT = new BoxAd();
        GT.Photo = listimg.Replace(common.ToString(Request.Form["img"]), "").Replace(",,", ",").Trim(',');
        GT.ID = Convert.ToInt32(common.ToString(Request.Form["id"]));
        String err = "";
        bool t = DA.updatePhoto(ref err, GT);
        Response.Write("");
        Response.End();
    }
    private void ListBoxAd()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        count = getCountRecord("select count(ID) from BoxAd");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }
        string SQL = "select top " + rowsOnPage.ToString() + " ID,Url,Category,Status,Location from BoxAd where ID in (select top " + plFirstPage.ToString() + " ID from BoxAd where ID>0  order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/BoxAd/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("BoxAdList.tpl"), cl, common.ToString(o[0]), common.ToString(o[1]), common.GetEnumType(typeof(eCategoryBoxAd), common.ToString(o[2])), common.GetEnumType(typeof(eStatusBoxAd), common.ToString(o[3])), String.Format(func, common.ToString(o[0])), common.ToString(o[4]));
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("BoxAd.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void DeleteImgAlbum()
    {
        GalleryImageDB DA = new GalleryImageDB();
        string img1 = pathUpload + "\\Album\\" + common.ToString(Request.Form["img"]);
        string img2 = pathUpload + "\\Album\\" + ConfigurationManager.AppSettings["imageSizeAlbum"] + "\\" + common.ToString(Request.Form["img"]);
        if (File.Exists(img1))
            File.Delete(img1);
        if (File.Exists(img2))
            File.Delete(img2);
        String err = "";
        bool t = DA.delete(ref err, common.ToString(Request.Form["img"]));
        Response.Write("");
        Response.End();
    }
    private void DeleteQA()
    {
        QADB td = new QADB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChStatusQA()
    {
        QADB td = new QADB();
        QA TD = new QA();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }

    private void ListQA()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        count = getCountRecord("select count(ID) from QA");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }
        string SQL = "select top " + rowsOnPage.ToString() + " ID,Title,Name,Status,DatePost from QA where ID in (select top " + plFirstPage.ToString() + " ID from QA where ID>0  order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<a href='" + pathAdmin + "/QA/Answer.aspx?id={0}'  class=\"edit\">Trả lời</a><a href='javascript:void(0);' onclick='ajxQA.Delete({0});' class=\"delete\">Xóa</a>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("QAList.tpl"), cl, common.ToString(o[0]), common.ToString(o[1]), common.ToString(o[2]), common.ToString(o[4]), common.GetEnumType(typeof(eStatusQA), common.ToString(o[3])), String.Format(func, common.ToString(o[0])));
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("QA.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void GetListCatDetail()
    {
        MenuDB db1 = new MenuDB();
        IList vList = db1.getList("Select ID,Name from MenuSub where IDMenu="+common.ToString(Request.Form["cat"]));
        if (vList != null)
        {
            Response.ContentType = "text/xml";
            Response.Write("<?xml version='1.0' encoding='utf-8'?>");
            Response.Write("<options>");
            Response.Write("<option>");
            Response.Write("<value> </value>");
            Response.Write("<text>Chọn</text>");
            Response.Write("</option>");
            if (vList != null && vList.Count > 0)
            {
                IEnumerator ie = vList.GetEnumerator();
                while (ie.MoveNext())
                {
                    object[] vList_ = (object[])ie.Current;
                    Response.Write("<option>");
                    Response.Write("<value>" + vList_[0] + "</value>");
                    Response.Write("<text>" + vList_[1].ToString().Replace('&', '|') + "</text>");
                    Response.Write("</option>");
                }
            }
            Response.Write("</options>");
            Response.End();
        }
        Response.Write("");
        Response.End();
    }
    private void DeleteCatSub()
    {
        MenuSubDB td = new MenuSubDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
   
    private void ChStatusMenuSub()
    {
        MenuSubDB td = new MenuSubDB();
        MenuSub TD = new MenuSub();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }

    private void ListMenuSub()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["category"]) != "")
            condi += " and IDMenu =" + common.ToString(Request.Form["category"]);
        count = getCountRecord("select count(ID) from MenuSub where ID>0"+condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Name,Status,Location,(select Name from Menu b where a.IDMenu=b.ID)as NameMenu,NameE  from MenuSub a where ID in (select top " + plFirstPage.ToString() + " ID from MenuSub where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/MenuSub/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxMenuSub.DeleteCatSub({0});'  class=\"action4\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("MenuSubList.tpl"), 
                    cl, 
                    common.ToString(o[0]), 
                    common.ToString(o[1]),  
                    common.GetEnumType(typeof(eStatusMenuSub), common.ToString(o[2])), 
                    String.Format(func, common.ToString(o[0])), 
                    common.ToString(o[3]),
                    common.ToString(o[4]),
                    common.ToString(o[5])
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("MenuSub.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void ChStatusMenu()
    {
        MenuDB td = new MenuDB();
        Menu TD = new Menu();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void ListMenu()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        count = getCountRecord("select count(ID) from Menu");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Name,Status,Location,NameE from Menu where ID in (select top " + plFirstPage.ToString() + " ID from Menu where ID>0  order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/Menu/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("MenuList.tpl"), 
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.GetEnumType(typeof(eStatusMenu), common.ToString(o[2])),
                    /*4*/String.Format(func, common.ToString(o[0])),
                    /*5*/common.ToString(o[3]),
                    /*6*/common.ToString(o[4])
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Menu.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    private void DeleteImgNews()
    {

        string listimg = ListImage("select ID,photo from News where ID=" + common.ToString(Request.Form["id"]));
        if (listimg != "")
        {
            string img1 = pathUpload + "\\News\\" + common.ToString(Request.Form["id"]) + "\\" + common.ToString(Request.Form["img"]);
            string img2 = pathUpload + "\\News\\" + common.ToString(Request.Form["id"]) + "\\" + ConfigurationManager.AppSettings["imageSizeNews"] + "\\" + common.ToString(Request.Form["img"]);
            if (File.Exists(img1))
                File.Delete(img1);
            if (File.Exists(img2))
                File.Delete(img2);
        }
        NewsDB DA = new NewsDB();
        News GT = new News();
        GT.Photo = listimg.Replace(common.ToString(Request.Form["img"]), "").Replace(",,", ",").Trim(',');
        GT.ID = Convert.ToInt32(common.ToString(Request.Form["id"]));
        String err = "";
        bool t = DA.updatePhoto(ref err, GT);
        Response.Write("");
        Response.End();
    }
    private void DeleteNews()
    {
        NewsDB td = new NewsDB();
        string[] listimage = ListImage("select ID,photo from News where ID=" + common.ToString(Request.Form["id"])).Split(',');
        for (int i = 0; i < listimage.Length; i++)
        {
            string img1 = pathUpload + "\\News\\" + common.ToString(Request.Form["id"]) + "\\" + listimage[i];
            string img2 = pathUpload + "\\News\\" + common.ToString(Request.Form["id"]) + "\\" + ConfigurationManager.AppSettings["imageSizeNews"] + "\\" + listimage[i];
            if (File.Exists(img1))
                File.Delete(img1);
            if (File.Exists(img2))
                File.Delete(img2);
        }
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChangeStatusNews()
    {
        NewsDB td = new NewsDB();
        News TD = new News();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void ListNews()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        string condi = "";
        if (common.ToString(Request.Form["kw"]) != "")
            condi = " and (Title like N'%" + common.ToString(Request.Form["kw"]) + "%' or Content like N'%" + common.ToString(Request.Form["kw"]) + "%')";

        count = getCountRecord("select count(ID) from News where ID>0" + condi);
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }

        string SQL = "select top " + rowsOnPage.ToString() + " ID,Title,TitleE,Status,DateCreate,Location from News where ID in (select top " + plFirstPage.ToString() + " ID from News where ID>0 " + condi + " order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "<div class=\"actions_menu\"><ul><li><a href='" + pathAdmin + "/News/AddNew.aspx?id={0}'  class=\"edit\">Sửa</a></li><li><a href='javascript:void(0);' onclick='ajxNews.Delete({0});' class=\"delete\">Xóa</a></li></ul></div>";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "odd";
                if (i % 2 == 0)
                    cl = "";
                temptd += String.Format(common.GetTemplate("SolutionList.tpl"),
                    /*0*/cl,
                    /*1*/common.ToString(o[0]),
                    /*2*/common.ToString(o[1]),
                    /*3*/common.ToString(o[2]),
                    /*4*/common.ToString(o[5]),
                    /*5*/common.GetEnumType(typeof(eStatusNews), common.ToString(o[3])),
                    /*6*/common.ToString(o[4]),
                    /*7*/String.Format(func, common.ToString(o[0]))
                    );
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("Solution.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
   
    private string ListImage(string SQL)
    {
        //string SQL = "select ID,photo from Produce where ID=" + id;
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            return common.ToString(o[1]);
        }
        return "";
    }

    //Theulogo
   
    private void DeleteLH()
    {
        ContactusDB td = new ContactusDB();
        String err = "";
        bool t = td.delete(ref err, common.ToString(Request.Form["id"]));
        Response.Write("");
        Response.End();
    }
    private void ChangeStatusContactUs()
    {
        ContactusDB td = new ContactusDB();
        Contactus TD = new Contactus();
        TD.Status = Convert.ToInt16(common.ToString(Request.Form["status"]));
        String err = "";
        String[] listid = common.ToString(Request.Form["id"]).TrimEnd(',').Split(',');
        for (int i = 0; i < listid.Length; i++)
        {
            TD.ID = Convert.ToInt32(listid[i]);
            bool t = td.updateStatus(ref err, TD);
        }
        Response.Write("");
        Response.End();
    }
    private void ListContactUs()
    {
        int count = 0;
        int pgIndex = 1;
        int rowsOnPage = Convert.ToInt32(ConfigurationManager.AppSettings["DisplayPage"]);
        int plFirstPage;
        if (Request.Form["pg"] != "")
        {
            pgIndex = Convert.ToInt32(Request.Form["pg"]);
        }
        plFirstPage = common.ToString(Request.Form["pg"]) != "" ? (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage + rowsOnPage : 0;
        count = getCountRecord("select count(ID) from Contactus");
        if (plFirstPage > count)
        {
            rowsOnPage = count - (int.Parse(common.ToString(Request.Form["pg"])) - 1) * rowsOnPage;
            plFirstPage = count;
        }
        string SQL = "select top " + rowsOnPage.ToString() + " ID,Name,Phone,Email,Address,Content,DatePost,Status from Contactus where ID in (select top " + plFirstPage.ToString() + " ID from Contactus order by ID desc)  order by ID asc";
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            string temptd = "";
            string func = "[<a href='" + pathAdmin + "/ContactUs/ViewDetail.aspx?id={0}'  class=\"view\">Xem</a>][<a href='javascript:void(0);' onclick='ajxContactUs.Delete({0});'>Xóa</a>]";
            for (int i = list.Count - 1; i >= 0; i--)
            {
                object[] o = (object[])list[i];
                string cl = "bgcol";
                if (i % 2 == 0)
                    cl = "bgcol1";
                temptd += String.Format(common.GetTemplate("ContactUsList.tpl"), cl, common.ToString(o[0]), common.ToString(o[4]), common.LaySoKyTuCuaChuoi(common.ToString(o[5]),200), common.ToString(o[1]), common.GetEnumType(typeof(eStatusContactUs), common.ToString(o[7])), common.ToString(o[6]), String.Format(func, common.ToString(o[0])));
            }
            Response.Write("<input id='hCurrentPage' type='hidden' value='" + (common.ToString(pgIndex) == "" ? "0" : common.ToString(pgIndex)) + "'><input id='hTotalRows' type='hidden' value='" + count + "'>" + String.Format(common.GetTemplate("ContactUs.tpl"), temptd));
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
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
    private void Logout()
    {
        Session.RemoveAll();
        Response.Write("");
        Response.End();
    }

}
