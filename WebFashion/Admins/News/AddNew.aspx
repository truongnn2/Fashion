﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="Admins_News_AddNew"  ValidateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<%@ Register TagPrefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nhập mới Tin tức</title>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/News.js"></script>
    <script type="text/javascript"  src="<%=pathClient%>/js/jquery.js"></script>

    <link href="/css/transdmin.css" media="screen" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
    	 <uc1:UcHeader ID="UcHeader2" runat="server" />
            
            <div id="content">
		        <div class="inner">
                    <div class="section">
                        <div class="title_wrapper">
						    <span class="title_wrapper_top"></span>
						    <div class="title_wrapper_inner">
							    <span class="title_wrapper_middle"></span>
							    <div class="title_wrapper_content">
								    <h2>Nhập mới Tin tức</h2>
							    </div>
						    </div>
						    <span class="title_wrapper_bottom"></span>
					    </div>
            	        <div class="section_content">
            	            <span class="section_content_top"></span>
            	            <div class="section_content_inner">
            	                <table>
            	                    <tr>
            	                        <td>
            	                            <label><strong>Tiêu đề:</strong></label>
            	                        </td>
            	                        <td>
            	                              <input id="txtTitle" type="text" class="text-long" runat="server" style="width: 561px" />
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td>
            	                            <label><strong>Tiêu đề (Tiếng Anh):</strong></label>
            	                        </td>
            	                        <td>
            	                              <input id="txtTitleE" type="text" class="text-long" runat="server" style="width: 561px" />
            	                        </td>
            	                    </tr>
            	                   
            	                    <tr>
            	                        <td>
            	                            <label><strong>Trọng số vị trí:</strong></label>
            	                        </td>
            	                        <td>
            	                               <select name="sltLocation" style="WIDTH:70px" id="sltLocation" runat="server" >
                                            </select> (Chọn số càng lớn thì tin đó càng lên đầu tiên)
            	                        </td>
            	                    </tr>
            	                    <tr style="display:none;">
            	                        <td>
            	                            <label><strong>Sơ lược:</strong></label>
            	                        </td>
            	                        <td>
            	                              <textarea id="txtIntro" rows="6" cols="120" name="text_field" runat="server" style="width: 561px;height:80px;"/>
            	                        </td>
            	                    </tr>
            	                     <tr>
            	                        <td>
            	                            <label><strong>Nội dung:</strong></label>
            	                        </td>
            	                        <td>
            	                             <fckeditorv2:fckeditor id="txtContent" runat="server" BasePath="./../FCKeditor/" Height="500px"></fckeditorv2:fckeditor>
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td>
            	                            <label><strong>Nội dung (Tiếng Anh):</strong></label>
            	                        </td>
            	                        <td>
            	                             <fckeditorv2:fckeditor id="txtContentE" runat="server" BasePath="./../FCKeditor/" Height="500px"></fckeditorv2:fckeditor>
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                         <td>
            	                            <label><strong>Nhập hình ảnh:</strong></label>
            	                        </td>
            	                        <td>
            	                            <asp:FileUpload ID="FileUpload1" runat="server" Width="311px" /><br/>
            	                           
            	                        </td>
            	                        
            	                    </tr>
            	                    <tr>
            	                        <td colspan="2">
            	                             <%=listphoto %>
            	                        </td>
            	                    </tr>
            	                   
            	                    <tr>
            	                        <td>
            	                            <input id="Addnew" type="submit" value="Nhập mới" runat="server" onclick="return AddNewNews();" style="margin-top:10px;" onserverclick="Addnew_ServerClick" /><INPUT id="Button1" onclick="javascript:location='ListProducts.aspx';" tabIndex="9" type="button" value="Hủy" name="btexit" />
            	                           
            	                        </td>
            	                        
            	                    </tr>
            	                </table>
                            </div>
            	        </div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>	
          
             <asp:HiddenField ID="hdIDUser" runat="server" />
            <asp:HiddenField ID="hdCategoryDetail" runat="server" />
            <uc1:UcBottom ID="UcBottom" runat="server" />
    </div>
    </form>
</body>
</html>
