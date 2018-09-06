<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HotNews.aspx.cs" Inherits="Admins_HotNews_HotNews" ValidateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=tt %></title>
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
								 <h2><%=tt %></h2>
							</div>
						</div>
						<span class="title_wrapper_bottom"></span>
					</div>
					<div class="section_content">
						<span class="section_content_top"></span>
						<div class="section_content_inner">
						    <table cellSpacing="1" cellPadding="0" style="width:800px;" border="0">
						         <tr class="br6" >
									<td style="padding-top:10px;padding-bottom:10px;font-weight:bold;">Tiếng Việt</td>
								</tr>
								<tr >
									<td >
                                        <asp:Label ID="lblNoidung" runat="server"></asp:Label></td>
								</tr>
								<tr class="br6">
									<td style="padding-top:10px;padding-bottom:10px;font-weight:bold;">Tiếng Anh</td>
								</tr>	
								<tr >
									<td >
                                        <asp:Label ID="lblContent" runat="server"></asp:Label></td>
								</tr>
								<tr >
									<td align="center" >
										<INPUT id="btexit" onclick="javascript:location='Edit.aspx?id=<%=Request.QueryString["id"] %>';" tabIndex="9" type="button" value="Hiệu chỉnh"
												name="btexit" />&nbsp;
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
