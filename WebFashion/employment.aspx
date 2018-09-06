<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employment.aspx.cs" Inherits="employment" %>
<%@ Register TagPrefix="uc1" TagName="UcRight" Src="~/Uc/Right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeft" Src="~/Uc/Left.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Uc/Bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Uc/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCheckLogin" Src="~/Uc/ucCheckLogin.ascx" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <meta content="Shop qua tang truc tuyen DOD" name="author"/>
    <meta name="description" content="DOD - Quà tặng độc đáo cho người thân yêu của bạn." />
    <meta name="keywords" content="DOD - Quà Tặng - Qua Tang, quà xinh, qua xinh, qua dep, quà đẹp, quà, qua, lưu niệm, luu niem, tranh khắc gỗ, tranh gỗ, chân dung, photo, tranh khac go, chan dung" />
    <meta content="index,follow" name="robots"/>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta content="pgZdXuU7BiuTZ+A9Gq2ZgjW6Y2DHNy7Kw48HtQWPbrI=" name="verify-v1"/>
    <title>THÔNG TIN TUYỂN DỤNG - Hoang Thuy - www.hamluong.net</title>
    <link rel="stylesheet" type="text/css" href="css/style.css"/>
    <link href="images/aknt.ico" rel="shortcut icon"/>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/InitPath.js"></script>
    <script src="js/yu.js" type="text/javascript"></script>
    <script src="js/tb.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/chrome.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
	      <div id="content">
	        
		     <uc1:UcHeader ID="UcHeader1" runat="server" />
    		 <div id="main">
                <uc1:UcLeft ID="UcLeft1" runat="server" />      
                <div class="ColRigh">
           	      <div class="ttRight">TUYỂN DỤNG</div>
                    <h1>THÔNG TIN TUYỂN NHÂN VIÊN TỪ AK&T FASHION SHOP</h1>
                    <div align="center">
                     <%=diachi %>
                     <div align="left">
                        <%=cont%>
                     </div>
                     <%=img%>
                    </div>

                </div>    
            </div>		
		     <uc1:UcBottom ID="UcBottom1" runat="server" />
	    </div>
       </div>
	
    </form>

</body>
</html>
