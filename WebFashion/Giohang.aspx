<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Giohang.aspx.cs" Inherits="TTgiamgia" ValidateRequest="false" %>
<%@ Register TagPrefix="uc1" TagName="UcRight" Src="~/Uc/Right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeft" Src="~/Uc/Left.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Uc/Bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Uc/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ImageContent" Src="~/Uc/ImageContent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucSolution" Src="~/Uc/ucSolution.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Project" Src="~/Uc/Project.ascx" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <meta content="thoitrangxuatkhau.net.vn" name="author"/>
    <meta name="description" content="Thời trang xuất khẩu: chuyên bán buôn thời trang xuất khẩu (vnxk) cao cấp, cho chất lượng giá tốt với bán lẻ buôn thời trang xuất khẩu, Thời trang nữ thu đông 2013 sành điệu & giá rẻ chỉ có tại thoitranxuatkhau.net.vn. Cùng mua chung theo nhóm những mẫu quần áo nữ, phụ kiện nữ trẻ trung & nổi bật, Chuyên cung cấp thời trang nam, áo khoác, áo thun, sơ mi nam hàn quốc, đa phong cách cực đẹp, độc cho giới trẻ." />
    <meta name="keywords" content="Bán buôn thời trang xuất khẩu vnxk, thời trang xuất khẩu, thời trang vnxk, bán lẻ bán buôn thời trang vnxk zara, MNG, H&M, thời trang nữ, thời trang, hotdeal, hotdeals, hot deal, mua hàng theo nhóm,mua chung, nhóm mua, cùng mua, deal, deals, giá tốt, giá rẻ, giảm giá, khuyến mại, ưu đãi, Group Buy, daily deals, Áo khoác nam, áo thun nam, sơ mi nam, sơ mi hàn quốc, quần jean, quần kaki. " />
    <meta content="index,follow" name="robots"/>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta content="pgZdXuU7BiuTZ+A9Gq2ZgjW6Y2DHNy7Kw48HtQWPbrI=" name="verify-v1"/>
    <title><%=Titlesptt %> - CÔNG TY TNHH XÂY DỰNG THƯƠNG MẠI VÀ DỊCH VỤ HOÀNG MINH KHANG</title>
    <link type="image/x-icon"  id="favicon" runat="server" rel="shortcut icon">
   <link rel="stylesheet" id="StyleTag" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag1" runat="server" type="text/css"/>
 <script type="text/javascript" src="<%=pathClient %>/js/jquery.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/crawler.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/InitPath.js"></script>
     <script src="<%=pathClient %>/js/Giohang.js" type="text/javascript"></script>
</head>
 <body>
    <form id="form1" runat="server">
     <div id="templatemo_wrapper">
	        <uc1:UcHeader ID="UcHeader" runat="server" />
            
            <div class="cleaner"></div>
            
            <uc1:UcLeft ID="UcLeft" runat="server" /> <!-- end of sidebar -->
            
            <div id="templatmeo_content">
            
    	        <uc1:Project ID="Project1" runat="server" /> <!-- end of latest_content_gallery -->
                
                <div class="content_section">
                
        	        <div class="BoxContact_M1">
                         <%=listsp%>
                        
                         <table class="fl mgt20" width="100%" border="0" cellspacing="2" id="form_infor" style="display:none;margin-bottom:30px;text-align:left;float:left;font-size: 11px;">
                          <tr>
                            <td width="100px"><%=hoten %>(<font color="#ff0000">* </font>)</td>
                            <td>&nbsp;</td>
                            <td><input name="" type="text" id="txtHoten" runat="server"/></td>
                          </tr>
                          <tr>
                            <td><%=diachi %></td>
                            <td>&nbsp;</td>
                            <td><input name="" type="text" id="txtDiachi" runat="server"/></td>
                          </tr>
                          <tr>
                            <td><%=dienthoai%></td>
                            <td>&nbsp;</td>
                            <td><input name="" type="text" id="txtSodienthoai" runat="server"/></td>
                          </tr>
                          <tr>
                            <td>Email(<font color="#ff0000">* </font>)</td>
                            <td>&nbsp;</td>
                            <td><input name="" type="text" id="txtEmail" runat="server"/></td>
                          </tr>
                          <tr>
                            <td valign="top"><%=noidung%>(<font color="#ff0000">* </font>)</td>
                            <td>&nbsp;</td>
                            <td valign="top" ><textarea style="width:350px;" rows="5" id="txtNoidung" runat="server"></textarea></td>
                          </tr>
                          <tr>
                            <td valign="top">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td valign="top" >
                            <input type="submit" name="button" id="button" value="Gửi" onclick="return SubmitForm();" runat="server" onserverclick="button_ServerClick"/></td>
                          </tr>
                        </table>
                        <div style="text-align:center;margin-bottom:20px;">
                         <input id="Cont" type="submit" runat="server" onserverclick="Cont_ServerClick" />
                         <INPUT id="btexit" onclick="javascript:Update_sp('<%=language %>');" type="button"  runat="server" name="btexit" />
                         <INPUT id="Button1" onclick="javascript:Showform();" type="button" runat="server" name="btexit" />
                         </div>
                  </div>
                         
                    <!--div class="button_01"><a href="#">View All</a></div-->
                </div>
                 
            </div> <!-- end of templatmeo_content -->
            
            
        </div> <!-- end of templatemo_wrapper -->

        <uc1:UcBottom ID="UcBottom" runat="server" />  <!-- end of footer_wrapper -->
       <asp:HiddenField ID="hdListID" runat="server" />
      <asp:HiddenField ID="hdLanguage" runat="server" />
	<script>
        function SubmitForm()
         {
            if($("#txtHoten").val()=="")
            {
                if($("#hdLanguage").val()=="1")
                    alert("Please, input Your name!");
                else
                    alert("Bạn phải nhập Họ tên!");
                $("#txtHoten").focus()
                return false;
            }
            if($("#txtEmail").val()=="")
            {
                if($("#hdLanguage").val()=="1")
                    alert("Please, input Your E-mail!");
                else
                    alert("Bạn phải nhập Email!");
                $("#txtEmail").focus()
                return false;
            }
            if($("#txtNoidung").val()=="")
            {
                if($("#hdLanguage").val()=="1")
                    alert("Please, input Content!");
                else
                    alert("Bạn phải nhập Nội dung!");
                $("#txtNoidung").focus()
                return false;
            }
         }
    </script>
    </form>

</body>
</html>


