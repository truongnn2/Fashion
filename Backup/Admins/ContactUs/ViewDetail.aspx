<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDetail.aspx.cs" Inherits="Admins_ContactUs_ViewDetail" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Xem chi tiết thông tin liên hệ</title>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/ContactUs.js"></script>
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
								    <h2>Xem chi tiết thông tin liên hệ</h2>
							    </div>
						    </div>
						    <span class="title_wrapper_bottom"></span>
					    </div>
            	        <div class="section_content">
            	            <span class="section_content_top"></span>
            	            <div class="section_content_inner">
            	                <table  class="style2">
            	                    <tr>
            	                        <td class="style2">
            	                            <label><strong>Họ tên người gửi:</strong></label>
            	                        </td>
            	                        <td class="style2">
            	                              <asp:Label ID="lblName" runat="server"></asp:Label>
            	                        </td>
            	                    </tr>
            	                     <tr>
            	                        <td class="style2">
            	                            <label><strong>Email:</strong></label>
            	                        </td>
            	                        <td class="style2">
            	                              <asp:Label ID="lblEmail" runat="server"></asp:Label>
            	                        </td>
            	                    </tr> 
            	                    <tr>
            	                        <td class="style2">
            	                            <label><strong>Di động:</strong></label>
            	                        </td>
            	                        <td class="style2">
            	                               <asp:Label ID="lblMobilePhone" runat="server"></asp:Label>
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td class="style2">
            	                            <label><strong>Địa chỉ:</strong></label>
            	                        </td>
            	                        <td class="style2">
            	                              <asp:Label ID="lblAddress" runat="server"></asp:Label>
            	                        </td>
            	                    </tr>
            	                     <tr>
            	                        <td class="style2">
            	                            <label><strong>Nội dung liên hệ:</strong></label>
            	                        </td>
            	                        <td class="style2">
            	                              <asp:Label ID="lblContent" runat="server"></asp:Label>
            	                        </td>
            	                    </tr>
            	                     <tr>
            	                        <td class="style2">
            	                            <label><strong>Trạng thái:</strong></label>
            	                        </td>
            	                        <td class="style2">
            	                             <asp:Label ID="lblStatus" runat="server"></asp:Label>
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td class="style2">
            	                            <label><strong>Ngày tạo:</strong></label>
            	                        </td>
            	                        <td class="style2">
            	                               <asp:Label ID="lblDate" runat="server"></asp:Label>
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td class="style2">
            	                            <label><strong>Đơn hàng:</strong></label>
            	                        </td>
            	                        <td class="style2">
            	                               <asp:Label ID="lblDonhang" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>
            	                        </td>
            	                    </tr>
            	                    
            	                    <tr>
            	                        <td class="style2" colspan="2" align="right">
            	                            <INPUT id="Button2" onclick="javascript:location='ContactUs.aspx';" tabIndex="9" type="button" value="Quay lại" name="btexit" />
            	                           
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
