﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListNews.aspx.cs" Inherits="Admins_News_ListNews" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tin tức</title>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/News.js"></script>
    <script type="text/javascript"  src="<%=pathClient%>/js/jquery.js"></script>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/DivPage.js"></script>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/InitAdmin.js"></script>
</head>
<body onload="InitlistNews();">
    <form id="form1" runat="server">
   <div id="wrapper">
         <uc1:UcHeader ID="UcHeader1" runat="server" />
         <div id="content">
			<div class="inner">
				<div class="section">
					<div class="title_wrapper">
						<span class="title_wrapper_top"></span>
						<div class="title_wrapper_inner">
							<span class="title_wrapper_middle"></span>
							<div class="title_wrapper_content">
								 <h2>Tin tức</h2>
							</div>
						</div>
						<span class="title_wrapper_bottom"></span>
					</div>
					<div class="section_content">
						<span class="section_content_top"></span>
						<div class="section_content_inner">
						        <h3>Tìm kiếm</h3>
						        <table class="tblheader">
                                    <tr>
                                        <td><label>Từ khóa:</label></td>
                                        <td><input id="txtKeyword" type="text" class="text-long" /></td>
                                        <td></td>
                                        <td></td>
                                         <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                         <td></td>
                                        <td></td>
                                        <td colspan="2">
                                            <input onclick="InitlistNews();" type="button" value="Tìm kiếm" style="margin-left:60px;" />
                                        </td>
                                   </tr>
                                </table><br/>
							<div class="table_tabs_menu">
							    <a href="<%=pathAdmin%>/News/AddNew.aspx" class="update"><span><span><em>Nhập mới</em><strong></strong></span></span></a>
							    <a href="javascript:void(0);" onclick="return ajxNews.ChangeStatus();" class="update" style="margin-left:3px;"><span><span>Thay đổi<strong></strong></span></span></a>
						        <select name="sltStatus" style="WIDTH:120px;height:25px;float:right;" id="sltStatus" runat="server" ></select>
						        <span style="float:right;">Trang thái:</span>
						       
							</div>
							<div class="table_wrapper">
								<div class="table_wrapper_inner">
								    <div id="ListTD"></div>
								</div>
							</div>
						</div>
							<div class="pagination_wrapper">
							<span class="pagination_top"></span>
							<div class="pagination_middle">
							<div class="pagination">
								<ul id="dvPaging" class="pag_list">
								</ul>
							</div>
							</div>
							<span class="pagination_bottom"></span>
							</div>
						<span class="section_content_bottom"></span>
					</div>
				</div>
			</div>
		</div>
    </div>
     <uc1:UcBottom ID="UcBottom" runat="server" />
    <asp:HiddenField ID="hdfRecordCount" runat="server" />
    </form>
</body>
</html>
