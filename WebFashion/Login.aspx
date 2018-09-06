<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <script>
		function load()
		{
			document.getElementById('txtUserName').focus();
		}
	</script>
</head>
<body onload="load();">
    <form id="form1" runat="server" >
    <table width="100%" cellpadding="0" cellspacing="0" align="center">
				<tr>
					<td colspan="3" height="23" style="HEIGHT: 23px">&nbsp;</td>
				</tr>
				<tr>
					<td width="272">&nbsp;</td>
					<td width="250"><table width="99%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="88%" class="brlogin">
                                    &nbsp;</td>
							</tr>
							<tr>
								<td class="brlogin">&nbsp;</td>
							</tr>
							<tr>
								<td class="brlogin" align="center"><table width="97%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="19%" height="20">&nbsp;</td>
											<td colspan="2" class="stylelogin"><strong>User Name:</strong></td>
										</tr>
										<tr>
											<td width="19%" height="11">&nbsp;</td>
											<td class="stylelogin">
												<asp:TextBox id="txtUserName" runat="server" style="FONT-SIZE:11px" Width="130"></asp:TextBox>
												<asp:RequiredFieldValidator id="RequiredFieldValidator1" ErrorMessage="*" runat="server" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
											</td>
											<td class="stylelogin">&nbsp;</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td colspan="2" class="stylelogin"><strong>Password:</strong></td>
										</tr>
										<tr>
											<td height="11">&nbsp;</td>
											<td class="stylelogin">
												<asp:TextBox id="txtPsw" runat="server" style="FONT-SIZE:11px" Width="130" TextMode="Password" ></asp:TextBox>
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" ErrorMessage="*" runat="server" ControlToValidate= "txtPsw"></asp:RequiredFieldValidator>
											</td>
											<td class="stylelogin">&nbsp;</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
											<td width="65%" align="right"><strong>
													<asp:LinkButton id="lbtnLogin" runat="server" CssClass="textlink" OnClick="lbtnLogin_Click">Login...</asp:LinkButton></strong></td>
											<td width="16%">&nbsp;</td>
										</tr>
									</table>
									&nbsp;</td>
							</tr>
							<tr>
								<td class="brlogin" align="center" height="20">
									<asp:Label id="lbErrorMsg" runat="server" style="FONT-SIZE:11px" Font-Bold="True"></asp:Label></td>
							</tr>
							<tr>
								<td class="brlogin">&nbsp;</td>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</td>
					<td>&nbsp;</td>
				</tr>
			</table>
    </form>
</body>
</html>
