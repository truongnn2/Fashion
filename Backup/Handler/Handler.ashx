<%@ WebHandler Language="C#" Class="Handler" %>

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

public class Handler : IHttpHandler {
    public string pathClient = ConfigurationManager.AppSettings["PathClient"];
    public void ProcessRequest (HttpContext context) {
       string act = context.Request.Form["act"];
       switch (act)
       {
           case "ShowImg":
               //ShowImg(context);
               break;
       }

    }
   
    public bool IsReusable {
        get {
            return false;
        }
    }

}