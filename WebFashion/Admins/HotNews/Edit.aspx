﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admins_AboutUs_Edit"  ValidateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<%@ Register TagPrefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Hiệu chỉnh thông tin <%=tt %></title>
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
								 <h2>Hiệu chỉnh thông tin <%=tt %></h2>
							</div>
						</div>
						<span class="title_wrapper_bottom"></span>
					</div>
					<div class="section_content">
						<span class="section_content_top"></span>
						<div class="section_content_inner">
						    <table class="style2" cellSpacing="1" cellPadding="0" style="width:900px;" border="0">
						        <tr class="br6" >
									<td style="padding-top:10px;padding-bottom:10px;font-weight:bold;">Tiếng Việt</td>
								</tr>
								<tr class="br6">
									<td >
                                        <textarea id="txtNoidung" rows="6" cols="120" name="text_field" runat="server" style="width: 561px;height:80px;"/></td>
								</tr>
								<tr class="br6">
									<td style="padding-top:10px;padding-bottom:10px;font-weight:bold;">Tiếng Anh</td>
								</tr>	
								<tr class="br6">
									<td >
                                        <textarea id="txtContent" rows="6" cols="120" name="text_field" runat="server" style="width: 561px;height:80px;"/></td>
								</tr>
								<tr class="br1">
									<td class="style2" align="left" height="26">
										<center><input id="Addnew" type="submit" value="Hiệu chỉnh" runat="server" style="margin-top:10px;"  onserverclick="Addnew_ServerClick"  /><INPUT id="btexit" onclick="javascript:location='HotNews.aspx?id=<%=Request.QueryString["id"] %>';" tabIndex="9" type="button" value="Thoát" name="btexit" /></center>
									</td>
								</tr>
							</table>
							
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

    </form>
</body>
</html>
