﻿using System;
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

public partial class SolutionDetail : System.Web.UI.Page
{
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    getList db = new getList();
    public string sptt = "";
    public string title = "";
    public string proDetail = "";
    public string b = "1";
    public string link1 = "";
    public string otherSolution = "";
    public string Titlepage = "";
    public string titleService = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        favicon.Attributes.Add("href", pathClient + "/favicon.ico");
        StyleTag.Attributes.Add("href", pathClient + "/Css/FSportal.css");
        Titlepage = Global.Resource.GetString("lblTitlepage", Global.ci);
        titleService = Global.Resource.GetString("lblTitleMenuService", Global.ci);
        sptt = GetServices();
        otherSolution = GetServicesOther();
    }
    private string GetServices()
    {
        string ttt = "";
        string sql = "Select ID,Title,Photo,DateCreate,TitleE,Content,ContentE from Services where ID =" + common.ToString(Request.QueryString["id"]);
        IList listMenu = db.getlist(sql);
        if (listMenu != null && listMenu.Count > 0)
        {
            object[] o = (object[])listMenu[0];
            string tempTitle = common.ToString(o[4]);
            string tempContent = common.ToString(o[6]);
            if (common.ToString(Request.QueryString["l"]) == "0")
            {
                tempTitle = common.ToString(o[1]);
                tempContent = common.ToString(o[5]);
                
            }
            title = tempTitle;
            ttt += String.Format(common.GetTemplate("SolutionDetail.tpl"),
                /*0*/tempTitle,
                /*1*/tempContent
                );
        }
        return ttt;
    }
    private string GetServicesOther()
    {
        string serviceList = "";
        string sql = "Select top 10 ID,Title,Photo,DateCreate,TitleE,Content,ContentE,Category,CategorySub,(select Name from CatServices where ID=Category) as NameCat,(select Name from CatSubServices where ID=CategorySub) as NameCatSub from Services where status=0 and ID <>" + common.ToString(Request.QueryString["id"]) + " Order by ID desc";
        IList listMenu = db.getlist(sql);
        if (listMenu != null && listMenu.Count > 0)
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                object[] o = (object[])listMenu[i];
                string link = common.GetUrlServicesDetail(common.ToString(o[1]), common.ToString(o[0]), common.ToString(o[9]), common.ToString(o[7]), common.ToString(o[10]), common.ToString(o[8]), Global.l);//pathClient + "/ServicesDetail.aspx" + Global.l + "&id=" + common.ToString(o[0]) + "&cats=" + common.ToString(o[7]) + "&catdetails=" + common.ToString(o[8]);
                string title = common.ToString(o[1]);
                if (common.ToString(Request.QueryString["l"]) == "1")
                {
                    title = common.ToString(o[4]);
                }
                serviceList += String.Format(common.GetTemplate("ServiceDefaultItem.tpl"),
                    /*0*/title,
                    /*1*/link,
                    /*2*/pathClient
                    );
            }
            if (serviceList != "")
                serviceList = String.Format(common.GetTemplate("ServiceDefaultListItem.tpl"),
                    /*0*/serviceList,
                    /*1*/common.ToString(Request.QueryString["l"]) == "1" ? "Others Services" : "Các dịch vụ khác"
                 );
        }
        return serviceList;
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
