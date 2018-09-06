<%@ Page Language="C#" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="products" %>
<%@ Register TagPrefix="uc1" TagName="UcRight" Src="~/Uc/Right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeft" Src="~/Uc/Left.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Uc/Bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Uc/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ImageContent" Src="~/Uc/ImageContent.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta content="Thiết bị điện Hàm Luông - HL Electric Co. Ltd " name="author"/>
    <meta name="description" content="Thiết bị điện Hàm Luông - HL Electric Co. Ltd, chuyên kinh doanh: biến dòng, bơm điện, công tơ, điện cơ, dong co dien, động cơ điện, emic, may bien ap, máy biến áp, thiết bị điện." />
    <meta name="keywords" content="biến dòng, bơm điện, công tơ, điện cơ, dong co dien, động cơ điện, emic, may bien ap, máy biến áp, thiết bị điện" />
    <meta content="index,follow" name="robots"/>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta content="pgZdXuU7BiuTZ+A9Gq2ZgjW6Y2DHNy7Kw48HtQWPbrI=" name="verify-v1"/>
    <title><%=title %> - HL Electric Co. Ltd</title>
    <link type="image/x-icon" href="favicon.png" rel="shortcut icon">
    <link rel="stylesheet" type="text/css" href="css/style.css"/>
      <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/InitPath.js"></script>
    <script src="js/ddaccordion.js" type="text/javascript"></script>
    <script src="js/Giohang.js" type="text/javascript"></script>
    <script src="js/hoverImages.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <center>
        <uc1:UcHeader ID="UcHeader2" runat="server" />
        <div class="ContentPages">
	        <uc1:UcLeft ID="UcLeft" runat="server" />
            <div class="ColMiddle">
                <div class="M_Box_1 mar_b10">
                    <div class="TitleBox_M1">
                        <div class="cornerL"></div><div class="cornerR"></div>
                        <h2><%=title%></h2>
                    </div>
                    <div class="ContentBox_M1">
                        <div class="BoxPro_M1">
                            <ul>
                               <%=sptt%>
                                
                            </ul>
                      </div>
                    </div>
                </div>
                <div id="dvPaging" style="text-align:center;"></div>
            </div>
            <uc1:UcRight ID="UcRight" runat="server" />
        </div>
        <uc1:UcBottom ID="UcBottom" runat="server" /> 
     <center>
	<asp:HiddenField ID="hdfRecordCount" runat="server" />
	 <script type="text/javascript">
	        var t=<%=b%>;
	        if(t==1)
	        {
		        var tps = (parseInt(document.getElementById("hTotalRows").value)/parseInt(document.getElementById("hdfRecordCount").value) - parseInt(parseInt(document.getElementById("hTotalRows").value)/parseInt(document.getElementById("hdfRecordCount").value)))>0?((parseInt(parseInt(document.getElementById("hTotalRows").value)/parseInt(document.getElementById("hdfRecordCount").value)))+1):parseInt(parseInt(document.getElementById("hTotalRows").value)/parseInt(document.getElementById("hdfRecordCount").value));
		        if(tps<document.getElementById("hCurrentPage").value)
			        document.getElementById("hCurrentPage").value=1;
		        mjDrawLbPageNew(tps, document.getElementById("hCurrentPage").value, "dvPaging","gotoPage");
	        }
	        function gotoPage(numberpage)
	        {			
		        pg = numberpage;
		        window.location='<%=link1 %>'+numberpage;
	        }

	        function mjDrawLbPageNew(TotalPages_, CurrentPage_, ElementID_,sGotoPageFunction)
            {
                var _START_PAGE=0;
                var _END_PAGE=0;
                var _CPAGE=0;
                var _ITEMS_PAGES=10;
                var _ITEMS_PAGES_Admin=20;
                var _PART_PAGES=10;
                _CPAGE=CurrentPage_;
                if(_CPAGE>TotalPages_)
	                _CPAGE=TotalPages_;
                _START_PAGE = 1;
                _END_PAGE = 1 + (_PART_PAGES - 1);
                if(TotalPages_ < _PART_PAGES){_END_PAGE = TotalPages_;}
                else
                {
	                if(CurrentPage_ >= _END_PAGE)
	                {
		                _START_PAGE += 8;
		                if((_END_PAGE + 8) < TotalPages_){_END_PAGE += 8;}
		                else{_END_PAGE = TotalPages_;}
		                while(CurrentPage_ >= _END_PAGE && CurrentPage_ < TotalPages_)
		                {
			                _START_PAGE = _END_PAGE - 1;
			                if((TotalPages_ - _END_PAGE) < _PART_PAGES){
				                if(TotalPages_ - _START_PAGE <= _PART_PAGES)
				                {
					                _END_PAGE = TotalPages_;
					                if((_END_PAGE - _START_PAGE) == _PART_PAGES)
					                {_END_PAGE = _START_PAGE + (_PART_PAGES - 1);}
				                }
				                else{_END_PAGE = _START_PAGE + _PART_PAGES - 1;}
			                }
			                else{_END_PAGE = _START_PAGE + _PART_PAGES - 1;}
		                }
	                }
	                if(CurrentPage_ == TotalPages_){
		                _END_PAGE = TotalPages_;_START_PAGE = parseInt(TotalPages_/8)*8 - 1; 
		                if(_START_PAGE > _END_PAGE) _START_PAGE = _START_PAGE - 8;}
                };
                var theme = "<div class='st_uti'><div class='page'>";
                //phan chia dau/truoc/tiep/cuoi
                var next;
                var pre;
                if(CurrentPage_==1)
	                pre=1;
                else pre=CurrentPage_-1;
                if(CurrentPage_==TotalPages_)
	                next=TotalPages_;
                else next=parseInt(CurrentPage_)+1;
                
                //theme+= "[<a href='javascript:"+sGotoPageFunction+"(1)' style='color:black'>Trang đầu</a>]";
                theme+= "<a href='javascript:"+sGotoPageFunction+"("+ pre +")' >Trang trước</a>";
                for( var k = _START_PAGE; k <= _END_PAGE; k++){
	                if(CurrentPage_ != k)theme+= "<a href='javascript:"+sGotoPageFunction+"("+ (k) +")' >"+ (k) +"</a>";
	                else //theme+= "<span class='pgSelected'><b><u>"+ (k) +"</u></b></span>";
	                theme+= "<a ><font color='red'><b>"+ (k) +"</b></font></a>";
                }
                theme+= "<a href='javascript:"+sGotoPageFunction+"("+ next +")' >Trang sau</a>";
                //theme+= "[<a href='javascript:"+sGotoPageFunction+"("+ TotalPages_ +")' style='color:black'>Trang cuối</a>]";
                theme+= "</div></div>";	
                if (TotalPages_>1) {
	                document.getElementById(ElementID_).style.display='block';
	                document.getElementById(ElementID_).innerHTML=theme;
	                }
            }
        </script>
    </form>

</body>
</html>
