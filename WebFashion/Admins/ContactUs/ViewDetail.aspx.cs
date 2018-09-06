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

public partial class Admins_ContactUs_ViewDetail : System.Web.UI.Page
{
    private getList db = new getList();
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public string pathAdmin = ConfigurationManager.AppSettings["PathAdmin"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Showdata();
        }
    }
    private void Showdata()
    {
        string SQL = "select Name,Email,Phone,Address,Status,DatePost,Content,Donhang from Contactus where ID = " + common.ToString(Request.QueryString["id"]);
        IList list = db.getlist(SQL);
        if (list != null && list.Count > 0)
        {
            object[] o = (object[])list[0];
            lblName.Text = common.ToString(o[0]);
            lblEmail.Text = common.ToString(o[1]);
            lblMobilePhone.Text = common.ToString(o[2]);
            lblAddress.Text = common.ToString(o[3]);
            lblStatus.Text = common.GetEnumType(typeof(eStatusContactUs), common.ToString(o[4]));
            lblDate.Text = common.ToString(o[5]);
            lblContent.Text = common.ToString(o[6]);
            if(common.ToString(o[7])!="")
            {
                string listID = "";
                string[] temp = common.ToString(o[7]).Trim('#').Split('#');
                for (int i = 0; i < temp.Length; i++)
                {
                    listID += temp[i].Split('-')[0] + ",";
                }
                string SQL1 = "select ID,Title from Products where ID in(" + listID.Trim(',') + ")";
                IList list1 = db.getlist(SQL1);
                if (list1 != null && list1.Count > 0)
                {
                    for (int j = 0; j < list1.Count; j++)
                    {
                        object[] o1 = (object[])list1[j];
                        lblDonhang.Text += common.ToString(o1[1]) + " (số lượng: " + getCount(common.ToString(o[7]), common.ToString(o1[0])) + "), ";
                    }
                }
                lblDonhang.Text = lblDonhang.Text.Trim().Trim(',');
            }
        }
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
