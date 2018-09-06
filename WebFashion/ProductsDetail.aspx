<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductsDetail.aspx.cs" Inherits="ProductsDetail" %>
<%@ Register TagPrefix="uc1" TagName="UcRight" Src="~/Uc/Right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeft" Src="~/Uc/Left.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Uc/Bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Uc/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ImageContent" Src="~/Uc/ImageContent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucSolution" Src="~/Uc/ucSolution.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCheckLogin" Src="~/Uc/ucCheckLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Project" Src="~/Uc/Project.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <meta content="thoitrangxuatkhau.net.vn" name="author"/>
    <meta name="description" content="Thời trang xuất khẩu: chuyên bán buôn thời trang xuất khẩu (vnxk) cao cấp, cho chất lượng giá tốt với bán lẻ buôn thời trang xuất khẩu, Thời trang nữ thu đông 2013 sành điệu & giá rẻ chỉ có tại thoitranxuatkhau.net.vn. Cùng mua chung theo nhóm những mẫu quần áo nữ, phụ kiện nữ trẻ trung & nổi bật, Chuyên cung cấp thời trang nam, áo khoác, áo thun, sơ mi nam hàn quốc, đa phong cách cực đẹp, độc cho giới trẻ." />
    <meta name="keywords" content="Bán buôn thời trang xuất khẩu vnxk, thời trang xuất khẩu, thời trang vnxk, bán lẻ bán buôn thời trang vnxk zara, MNG, H&M, thời trang nữ, thời trang, hotdeal, hotdeals, hot deal, mua hàng theo nhóm,mua chung, nhóm mua, cùng mua, deal, deals, giá tốt, giá rẻ, giảm giá, khuyến mại, ưu đãi, Group Buy, daily deals, Áo khoác nam, áo thun nam, sơ mi nam, sơ mi hàn quốc, quần jean, quần kaki. " />
    <meta content="index,follow" name="robots"/>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta content="pgZdXuU7BiuTZ+A9Gq2ZgjW6Y2DHNy7Kw48HtQWPbrI=" name="verify-v1"/>
    <title><%=title %> - <%=Titlepage%></title>
    <link type="image/x-icon"  id="favicon" runat="server" rel="shortcut icon">
    <link rel="stylesheet" id="StyleTag" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag1" runat="server" type="text/css"/>
    <link rel="stylesheet" id="StyleTag2" runat="server" type="text/css" />
 <script type="text/javascript" src="<%=pathClient %>/js/jquery.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/InitPath.js"></script>
    <script src="<%=pathClient %>/js/hoverImages.js" type="text/javascript"></script>
    <script src="<%=pathClient %>/js/Giohang.js" type="text/javascript"></script>
    <script src="<%=pathClient %>/js/LightBox.js" type="text/javascript"></script>
   <script>
       var tt = "<%=checkimages%>";
       if (tt == "1") {
           $(document).ready(function() {
               $(".lightbox-2").lightbox({
                   fitToScreen: true
               });

           });
       }
	</script>
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
                
        	        <%=proDetail%>
                         
                    <!--div class="button_01"><a href="#">View All</a></div-->
                </div>
                 <%=ProductsSimilar%>  
            </div> <!-- end of templatmeo_content -->
            
            
        </div> <!-- end of templatemo_wrapper -->

        <uc1:UcBottom ID="UcBottom" runat="server" />  <!-- end of footer_wrapper -->
    </form>
</body>
</html>
