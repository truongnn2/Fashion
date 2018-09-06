<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="Admins_CatServices_AddNew"  ValidateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nhập mới danh mục dịch vụ</title>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/CatServices.js"></script>
    <script type="text/javascript"  src="<%=pathClient%>/js/jquery.js"></script>
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
								    <h2>Nhập mới danh mục dịch vụ</h2>
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
            	                            <label>Tên danh mục:</label>
            	                        </td>
            	                        <td>
            	                            <input id="txtName" type="text" class="text-long" runat="server" />
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td>
            	                            <label>Tên Tiếng Anh:</label>
            	                        </td>
            	                        <td>
            	                            <input id="txtNameE" type="text" class="text-long" runat="server" />
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td>
            	                            <label>Trạng thái:</label>
            	                        </td>
            	                        <td>
            	                             <select name="sltStatus" style="WIDTH:200px" id="sltStatus" runat="server" >
                                             </select>
            	                        </td>
            	                    </tr>
            	                     <tr>
            	                        <td>
            	                           <label>Trọng số vị trí:</label>
            	                        </td>
            	                        <td>
            	                            <select name="sltLocation" style="WIDTH:70px" id="sltLocation" runat="server" >
                                            </select>
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td colspan="2">
            	                            <input id="Addnew" type="submit" value="Nhập" runat="server" onclick="return AddNewCatServices();" style="margin-top:10px;" onserverclick="Addnew_ServerClick" /><INPUT id="btexit" onclick="javascript:location='ListCatServices.aspx';" tabIndex="9" type="button" value="Hủy" name="btexit" />
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

                    	