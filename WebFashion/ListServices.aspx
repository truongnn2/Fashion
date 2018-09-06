<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListServices.aspx.cs" Inherits="ListServices" %>
<%@ Register TagPrefix="uc1" TagName="UcRight" Src="~/Uc/Right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuGioiThieu" Src="~/Uc/MenuGioiThieu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Uc/Bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Uc/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ImageContent" Src="~/Uc/ImageContent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeft" Src="~/Uc/Left.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucSolution" Src="~/Uc/ucSolution.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCheckLogin" Src="~/Uc/ucCheckLogin.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
     <title><%=title%> - <%=Titlepage%></title>
     <link type="image/x-icon"  id="favicon" runat="server" rel="shortcut icon">
    <meta content="thoitrangxuatkhau.net.vn" name="author"/>
    <meta name="description" content="Thời trang xuất khẩu: chuyên bán buôn thời trang xuất khẩu (vnxk) cao cấp, cho chất lượng giá tốt với bán lẻ buôn thời trang xuất khẩu, Thời trang nữ thu đông 2013 sành điệu & giá rẻ chỉ có tại thoitranxuatkhau.net.vn. Cùng mua chung theo nhóm những mẫu quần áo nữ, phụ kiện nữ trẻ trung & nổi bật, Chuyên cung cấp thời trang nam, áo khoác, áo thun, sơ mi nam hàn quốc, đa phong cách cực đẹp, độc cho giới trẻ." />
    <meta name="keywords" content="Bán buôn thời trang xuất khẩu vnxk, thời trang xuất khẩu, thời trang vnxk, bán lẻ bán buôn thời trang vnxk zara, MNG, H&M, thời trang nữ, thời trang, hotdeal, hotdeals, hot deal, mua hàng theo nhóm,mua chung, nhóm mua, cùng mua, deal, deals, giá tốt, giá rẻ, giảm giá, khuyến mại, ưu đãi, Group Buy, daily deals, Áo khoác nam, áo thun nam, sơ mi nam, sơ mi hàn quốc, quần jean, quần kaki. " />

    <meta content="index,follow" name="robots"/>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta content="pgZdXuU7BiuTZ+A9Gq2ZgjW6Y2DHNy7Kw48HtQWPbrI=" name="verify-v1"/>
  <link rel="stylesheet" id="StyleTag" runat="server" type="text/css" />
  
 <script type="text/javascript" src="<%=pathClient %>/js/jquery.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/crawler.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/javascript.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/InitPath.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/floater_xlib.js"></script>
    <script src="<%=pathClient %>/js/hoverImages.js" type="text/javascript"></script>
</head>
<body style="background:url(<%=pathClient %>/images/tgf1248982266.gif) top center fixed">
    <form id="form1" runat="server">
        <center>
            <uc1:UcHeader ID="UcHeader" runat="server" />

            <table id="content" cellpadding="0" cellspacing="0">
	            <tbody>
	                <tr>
		                <td id="content_left" valign="top">
		                    <uc1:UcLeft ID="UcLeft" runat="server" />
                        </td>
		                <td id="content_center" valign="top">
                            <div style="padding-bottom:6px">
                                <div id="url_path" style="margin:0px"><img class="url_path_icon" src="<%=pathClient %>/images/title_icon.gif" align="absmiddle"><%=title1%></div>
                                <div id="tab" class="tab_content">
                                    <table cellpadding="10" cellspacing="0" width="100%" style="padding:10px">
                                        <tbody>
                                               <%=sptt%>
                                        </tbody>
                                    </table>
                                    <div id="dvPaging" style="text-align:center;"></div>
                                </div>
                             </div>
                         </td>
		                <td id="content_right" valign="top">
		                    <uc1:UcRight ID="UcRight" runat="server" />
                        </td>
	                </tr>
                </tbody>
            </table>

            <uc1:UcBottom ID="UcBottom" runat="server" /> 
        </center>
        
        <asp:HiddenField ID="hdfRecordCount" runat="server" />
	 <script type="text/javascript">
	        var t=<%=b%>;
	        var link='<%=link1 %>';
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
		        window.location=link.replace("###",numberpage);
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
