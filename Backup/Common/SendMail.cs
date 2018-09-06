using System;
using System.Web;
using System.Data;
using System.Collections.Specialized;
using System.Security.Principal;

using System.Collections;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Configuration;
using System.Text;

using System.Web.Mail;

namespace Common
{
	/// <summary>
	///  Send email templates
	/// </summary>
	public class SendMail
	{
		// Current HttpContext
		protected HttpContext oCurrentContext;
		private static string  mMailServer;
	
		private  string  mTo_;
		private  string  mFrom_;
		private  string  mCc_;
		private  string  mSubject_;
		private  string  mBody_;
		private  string  mAttach_;
		

		public string mTo
		{
			get{ return mTo_;}
			set{ mTo_ = value;}
		}
		public string mFrom
		{
			get{ return mFrom_;}
			set{ mFrom_ = value;}
		}
		public string mCc
		{
			get{ return mCc_;}
			set{ mCc_ = value;}
		}
		public string mSubject
		{
			get{ return mSubject_;}
			set{ mSubject_ = value;}
		}
		public string mAttach
		{
			get{ return mAttach_;}
			set{ mAttach_ = value;}
		}
		public string mBody
		{
			get{ return mBody_;}
			set{ mBody_ = value;}
		}
		public SendMail()
		{
			//
			// TODO: Add constructor logic here
			//
			oCurrentContext= HttpContext.Current;
            mMailServer = ConfigurationManager.AppSettings["MailServer"];
			
		}
		//public string To{ get{return mTo;} set{ mTo = value;}}
		
			

		/// <summary>
		/// Sends an email by using the XSLT template file. The template file is transform over a IDictionary object
		/// to an XHTML document. The contents in the subject line are replaced by the contents of title tag
		/// and the html body becomes the email contents.
		/// </summary>
		/// <param name="emailto">To email address</param>
		/// <param name="xslttemplatename">XSLT template file name</param>
		/// <param name="objDictionary">Dictonary objects containing data to be inserted in the transformed doc.</param>
		static public string GetBody(string xslttemplatename, IDictionary objDictionary)
		{
            string templatepath = ConfigurationManager.AppSettings["EmailTemplates"];
			
			XslTransform objxslt = new XslTransform();

			objxslt.Load(templatepath + xslttemplatename);

      
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.AppendChild(xmldoc.CreateElement("DocumentRoot"));
			XPathNavigator xpathnav = xmldoc.CreateNavigator();

			
			XsltArgumentList xslarg = new XsltArgumentList();
			if (objDictionary  != null)
				foreach (DictionaryEntry entry in objDictionary )
				{
					xslarg.AddExtensionObject(entry.Key.ToString(), entry.Value);
				}
      
			StringBuilder emailbuilder = new StringBuilder();
			XmlTextWriter xmlwriter = new XmlTextWriter(new System.IO.StringWriter(emailbuilder));
      
			objxslt.Transform(xpathnav, xslarg, xmlwriter, null);

			string subjecttext, bodytext;
      			
			XmlDocument xemaildoc = new XmlDocument();
			xemaildoc.LoadXml(emailbuilder.ToString());
			XmlNode titlenode = xemaildoc.SelectSingleNode("//title");
			
			subjecttext = titlenode.InnerText;
			
			XmlNode bodynode = xemaildoc.SelectSingleNode("//body");
		
			bodytext = bodynode.InnerXml;
			if (bodytext.Length > 0)
			{
				bodytext = bodytext.Replace("&amp;","&");
			}

			
			return bodytext;
		}

		public string SendEmail()
		{			
			MailMessage objEmail = new MailMessage();
			objEmail.To =  mTo;
			objEmail.From = mFrom;
			
			objEmail.Cc = mCc;
			
			objEmail.BodyEncoding=Encoding.UTF8;

			objEmail.Subject = mSubject;
			objEmail.Body = mBody;
			objEmail.Priority = MailPriority.High;
			objEmail.BodyFormat = MailFormat.Html;
		
		
			// Make sure you have appropriate replying permissions from your local system
			
			SmtpMail.SmtpServer = mMailServer;
			//SmtpMail.SmtpServer ="localhost";

			string mess="";
			
			try
			{
				SmtpMail.Send(objEmail);
//				mess += " Your Email has been sent sucessfully - Thank You";
			}
			catch (Exception exc)
			{
				mess= "Send failure: " + exc.ToString();
			}
			return mess;

		}
	}
}
