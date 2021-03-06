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


public partial class Admins_Customer_ListCustomer : System.Web.UI.Page
{
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string nametitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        hdfRecordCount.Value = ConfigurationManager.AppSettings["DisplayPage"];
        common.ShowCombobox(sltStatus, typeof(eStatusMenuSub), "", "Chọn");
        nametitle = common.ToString(Request.QueryString["cat"]) == "0" ? "Khách hàng" : "Đối tác";
        hdType.Value = common.ToString(Request.QueryString["cat"]);
    }
}
