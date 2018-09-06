<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="Admins_Download_AddNew"  ValidateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nhập mới liên kết website</title>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/LinkWebsite.js"></script>
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
								    <h2>Nhập mới liên kết website</h2>
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
            	                            <label>Tên website:</label>
            	                        </td>
            	                        <td>
            	                            <input id="txtName" type="text" class="text-long" runat="server" />
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td>
            	                            <label>Link:</label>
            	                        </td>
            	                        <td>
            	                            <input id="txtUrl" type="text" class="text-long" runat="server" />
            	                        </td>
            	                    </tr>
            	                    
            	                    <tr>
            	                        <td colspan="2">
            	                            <input id="Addnew" type="submit" value="Nhập" runat="server" onclick="return AddNewLinkWebsite();" style="margin-top:10px;" onserverclick="Addnew_ServerClick" /><INPUT id="btexit" onclick="javascript:location='ListLinkWebsite.aspx';" tabIndex="9" type="button" value="Quay lại" name="btexit" />
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
