<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelpClient.aspx.cs" Inherits="HelpClient" %>
<%@ Register TagPrefix="uc1" TagName="UcRight" Src="~/Uc/Right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeft" Src="~/Uc/Left.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Uc/Bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Uc/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ImageContent" Src="~/Uc/ImageContent.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <meta content="Doanh nghiệp giày Hoàng Thủy" name="author"/>
    <meta name="description" content="Doanh nghiệp giày Hoàng Thủy hoạt động trong lĩnh vực sản xuất và kinh doanh các loại sản phẩm giày dép thời trang." />
    <meta name="keywords" content="Giày Hoàng Thủy, thời trang, giày, giay, thoi trang, shoe, shoes, sandal, fashion, dép, dep, nam, nu, nữ" />
    <meta content="index,follow" name="robots"/>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta content="pgZdXuU7BiuTZ+A9Gq2ZgjW6Y2DHNy7Kw48HtQWPbrI=" name="verify-v1"/>
    <title>HƯỚNG DẪN MUA HÀNG - Hoang Thuy - www.hamluong.net </title>
    <link type="image/x-icon" href="favicon.png" rel="shortcut icon">
    <link rel="stylesheet" type="text/css" href="css/style.css"/>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/InitPath.js"></script>
     <script src="js/ddaccordion.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="conten">
	      <div id="contener">
		     <uc1:UcHeader ID="UcHeader1" runat="server" />
    		 <div id="main">
                <uc1:UcLeft ID="UcLeft1" runat="server" />      
                <div id="Right">
                    <div class="bgtt">
                    	Hướng dẫn mua hàng
                    </div>
                    <div  class="boxnoidung0">
                     <%=cont %>
                    </div>

                </div>    
            </div>		
		     
	    </div>
       </div>
	    <uc1:UcBottom ID="UcBottom1" runat="server" />
    </form>

</body>
</html>
