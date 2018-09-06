<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="Admins_Album_AddNew"  ValidateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Hình Banner giữa</title>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/Album.js"></script>
    <script type="text/javascript"  src="<%=pathClient%>/js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Div1">
    	 <uc1:UcHeader ID="UcHeader2" runat="server" />
            
            <div id="content">
		        <div class="inner">
                    <div class="section">
                        <div class="title_wrapper">
						    <span class="title_wrapper_top"></span>
						    <div class="title_wrapper_inner">
							    <span class="title_wrapper_middle"></span>
							    <div class="title_wrapper_content">
								    <h2>Nhập hình Banner giữa:</h2>
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
            	                            <asp:FileUpload ID="FileUpload1" runat="server" Width="311px" />
            	                             
            	                        </td>
            	                        <td>
            	                             Mô tả: <input id="txtDescription" type="text" class="text-long" runat="server" style="width: 200px" />
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td>
            	                            <asp:FileUpload ID="FileUpload2" runat="server" Width="311px" />
            	                        </td>
            	                        <td>
            	                             Mô tả: <input id="txtDescription1" type="text" class="text-long" runat="server" style="width: 200px" />
            	                        </td>
            	                    </tr>
            	                           <%=listphoto %>
            	                    <tr>
            	                        <td colspan="2">
            	                            <input id="Addnew" type="submit" value="Nhập" runat="server" onclick="return AddNewAlbum();" style="margin-top:10px;" onserverclick="Addnew_ServerClick" />
            	                        </td>
            	                        
            	                    </tr>
            	                </table>
                            </div>
            	        </div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>	
            
            <uc1:UcBottom ID="UcBottom" runat="server" />
    </div>
    </form>
</body>
</html>
