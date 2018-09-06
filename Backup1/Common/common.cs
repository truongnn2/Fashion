using System;
using System.Web;
using System.Data;
using System.Collections;
using System.IO;
using System.Resources;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Security.AccessControl;

namespace Common
{
    public class common
    {
        private static string chuoiNguyenAm = "Ð Ð đ a e i o u â ê ô ư ơ ă y";
        private static string dauHuyen = "Ð Ð đ à è ì ò ù ầ ề ồ ừ ờ ằ ỳ";
        private static string dauSac = "Ð Ð đ á é í ó ú ấ ế ố ứ ớ ắ ý";
        private static string dauNang = "Ð Ð đ ạ ẹ ị ọ ụ ậ ệ ộ ự ợ ặ ỵ";
        private static string dauHoi = "Ð Ð đ ả ẻ ỉ ỏ ủ ẩ ể ổ ử ở ẳ ỷ";
        private static string dauNga = "Ð Ð đ ã ẽ ĩ õ ũ ẫ ễ ỗ ữ ỡ ẵ ỹ";
        private static string khongDau = "D D d a e i o u a e o u o a y";
        public static XmlDocument pXMLDoc = null;
        public static string pFirstRow = "";
        public static string PathTemp = ConfigurationManager.AppSettings["WebTemplate"];
        public static string pathClient = ConfigurationManager.AppSettings["PathClient"];
        public static string ToString(object input)
        {
            if (input == null) return "";
            return input.ToString();
        }
        private static XmlDocument EnumDoc()
        {
            XmlDocument docXMLEnum = new XmlDocument();
            docXMLEnum.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml") + "\\Enum.xml");
            return docXMLEnum;
        }
        public static void ShowCombobox(System.Web.UI.HtmlControls.HtmlSelect select, Type enumType, params object[] pSetTextOnTop)
        {
            pXMLDoc = EnumDoc();
            if (pXMLDoc != null)
            {
                select.Items.Clear();
                if (pSetTextOnTop != null)
                {
                    if (pSetTextOnTop.Length == 2 && pSetTextOnTop[1].ToString() == "")
                    {
                        select.Items.Add(pFirstRow.ToString());
                        select.Items[0].Value = pSetTextOnTop[0].ToString();

                    }
                    else
                    {
                        select.Items.Add(pSetTextOnTop[1].ToString());
                        select.Items[0].Value = pSetTextOnTop[0].ToString();
                    }
                }

                /*XmlDocument doc = new XmlDocument();
                doc.Load(ConfigurationSettings.AppSettings["pathxml"]+"\\Enum.xml");*/
                XmlNode node_type = pXMLDoc.SelectSingleNode("//tag[@value='" + enumType.Name + "']");
                XmlNodeList nodelist = null;

                nodelist = node_type.ChildNodes;
                int i = 1;
                if (pSetTextOnTop == null) i = 0;

                foreach (XmlNode v_enum in nodelist)
                {
                    select.Items.Add(v_enum.InnerText);
                    select.Items[i].Value = v_enum.Attributes["value"].Value;
                    i += 1;
                }
            }
        }
        public static void ShowCombobox(System.Web.UI.HtmlControls.HtmlSelect select, IList list, params object[] pSetTextOnTop)
        {
            select.Items.Clear();
            int iCount = 0;
            if (pSetTextOnTop != null)
            {
                if (pSetTextOnTop.Length == 2 && pSetTextOnTop[0].ToString() == "")
                {
                    select.Items.Add("Chọn");
                    select.Items[0].Value = pSetTextOnTop[0].ToString();
                    iCount++;
                }
                else
                {
                    select.Items.Add(pSetTextOnTop[1].ToString());
                    select.Items[0].Value = pSetTextOnTop[0].ToString();
                    iCount++;
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                IEnumerator ieList = list.GetEnumerator();
                while (ieList.MoveNext())
                {
                    try
                    {
                        object[] vObjText = (object[])ieList.Current;
                        select.Items.Add(vObjText[1].ToString());
                        select.Items[iCount].Value = vObjText[0].ToString();
                        iCount++;
                    }
                    catch { }
                }
            }
        }
        public static void ShowCombobox(System.Web.UI.WebControls.DropDownList select, IList list, params object[] pSetTextOnTop)
        {
            select.Items.Clear();
            int iCount = 0;
            if (pSetTextOnTop != null)
            {
                if (pSetTextOnTop.Length == 2 && pSetTextOnTop[1].ToString() == "")
                {
                    select.Items.Add(pFirstRow.ToString());
                    select.Items[0].Value = pSetTextOnTop[0].ToString();
                    iCount++;
                }
                else
                {
                    select.Items.Add(pSetTextOnTop[1].ToString());
                    select.Items[0].Value = pSetTextOnTop[0].ToString();
                    iCount++;
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                IEnumerator ieList = list.GetEnumerator();
                while (ieList.MoveNext())
                {
                    try
                    {
                        object[] vObjText = (object[])ieList.Current;
                        select.Items.Add(vObjText[1].ToString());
                        select.Items[iCount].Value = vObjText[0].ToString();
                        iCount++;
                    }
                    catch { }
                }
            }
        }

        public static string GetTemplate(string nametemp)
        {
            try
            {
                StreamReader s2 = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Template") + @"\" + nametemp);
                return s2.ReadToEnd();
                s2.Close();
            }
            catch { }
            return "";
        }
        public static string GetEnumType(Type enumType, string vNum)
        {
            if (vNum.Length == 0 || vNum.Trim().Equals("")) return "";

            /*XmlDocument doc = new XmlDocument();
            doc.Load(ConfigurationSettings.AppSettings["pathxml"]+"\\Enum.xml");*/
            pXMLDoc = EnumDoc();
            XmlNode node_type = pXMLDoc.SelectSingleNode("//tag[@value='" + enumType.Name + "']");
            //XmlNodeList node_type = pXMLDoc.GetElementsByTagName("//tag[@value='"+ enumType.Name + "']");
            string node_ = "";

            foreach (XmlNode v_enum in node_type)
            {
                if (v_enum.Attributes["value"].Value == vNum) node_ = v_enum.InnerText;
            }

            return node_;

        }

        public static int GetNumberEnum(Type enumType)
        {
            /*XmlDocument doc = new XmlDocument();
            doc.Load(ConfigurationSettings.AppSettings["pathxml"]+"\\Enum.xml");*/
            pXMLDoc = EnumDoc();
            XmlNode node_type = pXMLDoc.SelectSingleNode("//tag[@value='" + enumType.Name + "']");
            XmlNodeList nodelist = null;
            nodelist = node_type.ChildNodes;

            return nodelist.Count;

        }

        public static int GetEnumType(System.Web.UI.HtmlControls.HtmlSelect select, string input)
        {
            return select.Items.IndexOf(select.Items.FindByValue(input));
        }

        public static string CreateDirectory(string path)
        {
            try
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                    File.SetAttributes(path, FileAttributes.Archive);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return path;
        }
        public static string ChangeName()
        {
            DateTime dt = DateTime.Now;
            return dt.Day.ToString() + dt.Month.ToString() +
                dt.Year.ToString() + dt.Hour.ToString() +
                dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
        }
        public static string LaySoKyTuCuaChuoi(string _String, int _SoKyTu)
        {
            string sResult = "";
            if (_String.Length > _SoKyTu)
            {
                for (int i = 0; i < _String.Length; i++)
                {
                    if (_String.Substring(i, 1) == " " && i >= _SoKyTu)
                        return sResult + "...";
                    else
                        sResult += _String.Substring(i, 1);
                }
                sResult += "...";
            }
            else sResult = _String;
            return sResult;
        }
        public static IList getEnumList(Type enumType)
        {
            //
            pXMLDoc = EnumDoc();
            IList listArr = new ArrayList();
            if (pXMLDoc != null)
            {

                XmlNode node_type = pXMLDoc.SelectSingleNode("//tag[@value='" + enumType.Name + "']");
                XmlNodeList nodelist = null;

                nodelist = node_type.ChildNodes;

                foreach (XmlNode v_enum in nodelist)
                {
                    listArr.Add(new string[] { v_enum.Attributes["value"].Value, v_enum.InnerText });
                }
            }
            return listArr;
        }
        public static string GetVirtualPath()
        {
            return System.Web.HttpContext.Current.Server.MapPath("~/FileUpload");
        }
        public static string Uploadfile(FileUpload f, string pathUpload, string ThumSize)
        {
            if (f != null && f.PostedFile.FileName != "")
            {
                string paththumb = "";
                string[] Ext = f.PostedFile.FileName.ToString().Split('.');
                string filename = common.ChangeName() + "." + Ext[Ext.Length - 1].ToString();
                f.PostedFile.SaveAs(pathUpload + "\\" + filename);
                bool thumb = false;
                //string ThumSize = ConfigurationManager.AppSettings["imageSizeDuAn"] + ";" + ConfigurationManager.AppSettings["imageSizeDuAnS"];
                string[] sThumb = ThumSize.Split(';');
                if (sThumb.Length > 0 && ThumSize != "" && ThumSize != null)
                {
//                     System.Drawing.Image img = System.Drawing.Image.FromFile(pathUpload + "\\" + filename);
//                     foreach (string sSize in sThumb)
//                     {
//                         paththumb = pathUpload + "\\" + sSize;
//                         common.CreateDirectory(paththumb);
//                         if (sSize.Trim() == ThumSize)
//                         {
//                             if (img.Width > img.Height)
//                             {
//                                 thumb = IResize.DrawThumbs(sSize, pathUpload, paththumb, filename);
//                             }
//                             else
//                             {
//                                 thumb = IResize.getThumbs(sSize, pathUpload, paththumb, filename);
//                             }
//                         }
//                         else
//                         {
//                             thumb = IResize.DrawThumbs(sSize, pathUpload, paththumb, filename);
//                         }
// 
//                     }	
                    System.Drawing.Image img = System.Drawing.Image.FromFile(pathUpload + "\\" + filename);
                    foreach (string sSize in sThumb)
                    {
                        paththumb = pathUpload + "\\" + sSize;
                        common.CreateDirectory(paththumb);
                        thumb = IResize.DrawThumbs(sSize, pathUpload, paththumb, filename);
                    }
                    img.Dispose();
                }

                return filename;
            }
            return "";
        }
        public static string Uploadfile1(FileUpload f, string pathUpload, string filename)
        {
            if (f != null && f.PostedFile.FileName != "")
            {
                f.PostedFile.SaveAs(pathUpload + "\\" + filename);
            }
            return filename;
        }
        public static string replaceWidthImage(string content, int width)
        {
            MatchCollection mc = Regex.Matches(content, @"<img[\s\S]*?>");
            if (mc.Count > 0)
            {

                for (int i = 0; i < mc.Count; i++)
                {
                    string image = mc[i].Value;
                    string tempimag = image;

                    // xu ly width
                    Regex reg = new Regex(string.Format(@"width=[{0}|{1}][\s\S]*?[{0}|{1}]", "\"", "'"), (RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant));
                    string _width = reg.Match(image).Value;
                    Regex reg1 = new Regex(string.Format(@"height=[{0}|{1}][\s\S]*?[{0}|{1}]", "\"", "'"), (RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant));
                    string _height = reg1.Match(image).Value;
                    string tempwidth = _width;
                    if (_width != "" && _width != null)
                    {
                        string sint = Regex.Match(_width, @"(\d)+").Value;
                        if (sint != "" && sint != null)
                        {
                            if (Convert.ToInt32(sint) > width)
                            {
                                _width = Regex.Replace(_width, sint, width.ToString());// rep
                                image = Regex.Replace(image, tempwidth, _width, (RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant));
                                if (_height != "" && _height != null)
                                {
                                    image = Regex.Replace(image, _height, "", (RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant));
                                }
                                content = content.Replace(tempimag, image);

                            }
                        }
                    }
                }
            }
            return content;
        }
        public static void UpdateEnumType(Type enumType, string vNum)
        {
            if (vNum.Length == 0 || vNum.Trim().Equals("")) return;
            pXMLDoc = EnumDoc();
            XmlNode node_type = pXMLDoc.SelectSingleNode("//tag[@value='" + enumType.Name + "']");

            foreach (XmlNode v_enum in node_type)
            {
                if (v_enum.Attributes["value"].Value == vNum)
                {
                    v_enum.InnerText="abc";
                    v_enum.Attributes["value"].Value = "def";
                }
            }
            pXMLDoc.Save(System.Web.HttpContext.Current.Server.MapPath("~/Xml") + "\\Enum.xml");
        }
        public static string RemoveTag(string input, string opentag, string closetag)
        {
            /* Remove chuoi bat dau opentag va ket thuc closetag
             * Tra ve chuoi moi sau khi da duoc remove
             */
            string pattern = opentag + @"[\s\S]*?" + closetag;
            MatchCollection m = Regex.Matches(input, pattern, (RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant));
            if (m.Count > 0 && input != "")
            {
                for (int i = 0; i < m.Count; i++)
                {
                    Match m1 = m[i];
                    input = input.Replace(m1.Value, "");
                }
            }
            return input;
        }
        public static void ShowImg(string path, string name, string text, string imgSize, string pathfont, int textsize)
        {
            IResize.BuildNoImage(path, name, text, imgSize, pathfont, textsize);
        }
        public static bool BuildUploadAdmin(string path, string name, string text, string imgSize, string pathfont, int textsize)
        {
            return IResize.BuildUploadAdmin(path, name, text, imgSize, pathfont, textsize);
        }
        public static void ShowImgAdmin(string path, string name, string text, string imgSize, string pathfont, int textsize)
        {
            IResize.BuildNoImageAdmin(path, name, text, imgSize, pathfont, textsize);
        }
        public static string doiTiengVietKhongDau(string chuoi)
        {
            string rtn = chuoi;
            rtn = doiChu(rtn, chuoiNguyenAm, khongDau);
            rtn = doiChu(rtn, dauHuyen, khongDau);
            rtn = doiChu(rtn, dauSac, khongDau);
            rtn = doiChu(rtn, dauNang, khongDau);
            rtn = doiChu(rtn, dauHoi, khongDau);
            rtn = doiChu(rtn, dauNga, khongDau);
            return rtn;
        }
        public static string doiChu(string chuoi, string source, string target)
        {
            for (int i = 1; i < source.Length; i++)
            {
                chuoi = chuoi.Replace(source[i].ToString(), target[i].ToString());
                chuoi = chuoi.Replace(source[i].ToString().ToUpper(), target[i].ToString().ToUpper());
            }

            return chuoi;
        }
        public static string GetUrlDownload(string name, string namefile, string id)
        {
            return pathClient + "/font-download-" + replaceSpecial(name.Replace(" ", "-")).Replace("--","-") + "-" + namefile + "/" + id + ".htm";
        }
        public static string GetUrlKeyword(string keyword, string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/danh-sach-san-pham/" + keyword.Replace(" ", "-").Replace("--", "-") + ".aspx";
        }
        public static string GetUrlProducts(string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/danh-sach-san-pham.aspx";
        }
        public static string GetUrlCat(string catname, string id,string l,string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/" + id + "/danh-sach-san-pham/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + ".aspx";
        }
        public static string GetUrlCatSub(string catname, string id,string catnamesub,string idsub, string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/" + id + "/" + idsub + "/danh-sach-san-pham/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + "/" + common.doiTiengVietKhongDau(catnamesub).Replace(" ", "-").Replace("--", "-") + ".aspx";
        }
        public static string GetUrlCatSubSub(string catname, string id, string catnamesub, string idsub, string catnamesubSub, string idSubSub, string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/" + id + "/" + idsub + "/" + idSubSub + "/danh-sach-san-pham/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + "/" + common.doiTiengVietKhongDau(catnamesub).Replace(" ", "-").Replace("--", "-") + "/" + common.doiTiengVietKhongDau(catnamesubSub).Replace(" ", "-").Replace("--", "-") + ".aspx";
        }
        public static string GetUrlServices(string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/dich-vu-xay-dung.aspx";
        }
        public static string GetUrlCatServices(string catname, string id, string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/" + id + "/dich-vu-xay-dung/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + ".aspx";
        }
        public static string GetUrlCatServicesSub(string catname, string id, string catnamesub, string idsub, string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/" + id + "/" + idsub + "/dich-vu-xay-dung/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + "/" + common.doiTiengVietKhongDau(catnamesub).Replace(" ", "-").Replace("--", "-") + ".aspx";
        }
        public static string GetUrlProductDetailCat(string title,string id,string catname, string idMenu, string l)
        {
            return pathClient + "/" + l + "/" + id + "/" + idMenu + "/san-pham/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + "/" + replaceSpecial(common.doiTiengVietKhongDau(title).Replace(" ", "-")).Replace("--", "-") + ".aspx";
        }
        public static string GetUrlProductDetailCatSub(string title, string id, string catname, string idMenu, string catnameSub, string idMenuSub, string l)
        {
            return pathClient + "/" + l + "/" + id + "/" + idMenu + "/" + idMenuSub + "/san-pham/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + "/" + common.doiTiengVietKhongDau(catnameSub).Replace(" ", "-").Replace("--", "-") + "/" + replaceSpecial(common.doiTiengVietKhongDau(title).Replace(" ", "-")).Replace("--", "-") + ".aspx";
        }
        public static string GetUrlProductDetailCatSubSub(string title, string id, string catname, string idMenu, string catnameSub, string idMenuSub, string catnameSubSub, string idMenuSubSub, string l)
        {
            return pathClient + "/" + l + "/" + id + "/" + idMenu + "/" + idMenuSub + "/" + idMenuSubSub + "/san-pham/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + "/" + common.doiTiengVietKhongDau(catnameSub).Replace(" ", "-").Replace("--", "-") + "/" + common.doiTiengVietKhongDau(catnameSubSub).Replace(" ", "-").Replace("--", "-") + "/" + replaceSpecial(common.doiTiengVietKhongDau(title).Replace(" ", "-")).Replace("--", "-") + ".aspx";
        }
        public static string GetUrlProductDetail(string title, string id, string catname, string idMenu, string catnameSub, string idMenuSub, string catnameSubSub, string idMenuSubSub, string l)
        {
            string link = "";
            if (idMenuSubSub != "" && idMenuSubSub != "0")
                link=GetUrlProductDetailCatSubSub(title, id, catname, idMenu, catnameSub, idMenuSub, catnameSubSub, idMenuSubSub, l);
            else if (idMenuSub != "" && idMenuSub != "0")
                link=GetUrlProductDetailCatSub(title, id, catname, idMenu, catnameSub, idMenuSub, l);
            else
                link=GetUrlProductDetailCat(title,id,catname, idMenu, l);
            return link;
        }
        public static string GetUrlServicesDetailCat(string title, string id, string catname, string idMenu, string l)
        {
            return pathClient + "/" + l + "/" + id + "/" + idMenu + "/dich-vu-xay-dung/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + "/" + replaceSpecial(common.doiTiengVietKhongDau(title).Replace(" ", "-")).Replace("--", "-") + ".aspx";
        }
        public static string GetUrlServicesDetailCatSub(string title, string id, string catname, string idMenu, string catnameSub, string idMenuSub, string l)
        {
            return pathClient + "/" + l + "/" + id + "/" + idMenu + "/" + idMenuSub + "/dich-vu-xay-dung/" + common.doiTiengVietKhongDau(catname).Replace(" ", "-").Replace("--", "-") + "/" + common.doiTiengVietKhongDau(catnameSub).Replace(" ", "-").Replace("--", "-") + "/" + replaceSpecial(common.doiTiengVietKhongDau(title).Replace(" ", "-")).Replace("--", "-") + ".aspx";
        }
        public static string GetUrlServicesDetail(string title, string id, string catname, string idMenu, string catnameSub, string idMenuSub, string l)
        {
            string link = "";
            if (idMenuSub != "" && idMenuSub != "0")
                link = GetUrlServicesDetailCatSub(title, id, catname, idMenu, catnameSub, idMenuSub, l);
            else
                link = GetUrlServicesDetailCat(title, id, catname, idMenu, l);
            return link;
        }
        public static string GetUrlNews(string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/tin-tuc.aspx";
        }
        public static string GetUrlNewsDetail(string title, string id, string l)
        {
            return pathClient + "/" + l + "/" + id  +  "/tin-tuc/" + replaceSpecial(common.doiTiengVietKhongDau(title).Replace(" ", "-")).Replace("--", "-") + ".aspx";
        }
        public static string GetUrlBlogDetail(string title, string id,string cat)
        {
            return pathClient + "/bai-viet-"+cat+"/" + replaceSpecial(common.doiTiengVietKhongDau(title).Trim().Replace(" ", "-")).Replace("--", "-") + "-" + id + ".htm";
        }
        public static string GetUrlPromotion(string l, string page)
        {
            return pathClient + "/" + l + "/trang-" + page + "/khuyen-mai.aspx";
        }
        public static string GetUrlPromotionDetail(string title, string id, string l)
        {
            return pathClient + "/" + l + "/" + id + "/khuyen-mai/" + replaceSpecial(common.doiTiengVietKhongDau(title).Replace(" ", "-")).Replace("--", "-") + ".aspx";
        }
        public static string replaceSpecial(string s)
        {
            s = s.Replace("?", "");
            s = s.Replace("|", "");
            s = s.Replace("<", "");
            s = s.Replace(">", "");
            s = s.Replace(":", "");
            s = s.Replace("&", "");
            s = s.Replace(",", "");
            s = s.Replace("'", "");
            s = s.Replace(";", "");
            s = s.Replace("\"", "");
            return s.Trim();
        }
        public static string[] getListFile(string path)
        {
            if (Directory.Exists(path))
            {
                string[] filenameArray = Directory.GetFiles(path);
                return filenameArray;
            }
            return null;
        }
        public static string[] getListDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                string[] filenameArray = Directory.GetDirectories(path);
                return filenameArray;
            }
            return null;
        }
        public static void DeleteFile(string pathfont)
        {
            string[] file = getListFile(pathfont);
            if (file!=null)
            {
                for (int i = 0; i < file.Length; i++)
                {
                    try
                    {
                        File.Delete(file[i]);
                    }
                    catch (System.Exception )
                    {
                    }
                }
            }
            string[] folder = getListDirectory(pathfont);
            if (folder!=null)
            {
                for (int i = 0; i < folder.Length; i++)
                {
                    if (Directory.Exists(folder[i]))
                    {
                        try
                        {
                            DeleteFile(folder[i]);
                        }
                        catch (System.Exception )
                        {
                        	
                        }
                    }
                }
            }
            if (Directory.Exists(pathfont))
            {
                try
                {
                    Directory.Delete(pathfont);
                }
                catch (System.Exception)
                {
                }
            }
        }
        public static string HTML(string vel_)
        {
            vel_ = HttpContext.Current.Server.HtmlEncode(vel_);
            vel_ = vel_.Replace("\r\n", "<br>");
            vel_ = vel_.Replace("\n", "<br>");
            return vel_;
        }
    }

}
