<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
    <LINK rel="stylesheet" type="text/css" href="css/login.css">
    <script type="text/javascript"  src="<%=pathClient%>/js/jquery.js"></script>
    <script type="text/javascript">
		function load()
		{
			document.getElementById('txtUserName').focus();
		}
		
	</script>
</head>
<body >
    <div id="wrapper">
	<div id="wrapper2">
	<div id="wrapper3">
	<div id="wrapper4">
	<span id="login_wrapper_bg"></span>
	<div id="stripes">
		<div id="login_wrapper">
          <form id="form1" runat="server" >
                  <fieldset>
					<h1>Please log in</h1>
					<div class="formular">
						<span class="formular_top"></span>
						<div class="formular_inner">
						<label>
							<strong>Username:</strong>
							<span class="input_wrapper">
								<input type="text" id="txtUserName" name="txtUserName" runat="server"  onfocus="this.value='';" onblur="if (this.value=='') {this.value='Username';}" value="Username" />
								<asp:RequiredFieldValidator id="RequiredFieldValidator3" ErrorMessage="*" runat="server" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
							</span>
						</label>
						<label>
							<strong>Password:</strong>
							<span class="input_wrapper">
								<input type="password" id="txtPsw" name="txtPsw" runat="server" value="******" onfocus="this.value='';" onblur="if (this.value=='') {this.value='******';}" />
                                                 <asp:RequiredFieldValidator id="RequiredFieldValidator4" ErrorMessage="*" runat="server" ControlToValidate= "txtPsw"></asp:RequiredFieldValidator>
							</span>
						</label>
						<ul class="form_menu">
							<li><span class="button"><span><span><em>SUBMIT</em></span></span><input id="Button1" value="" type="submit" name="login"  runat="server" onserverclick="Button1_ServerClick" /></span></li>
						</ul>
						</div>
						<span class="formular_bottom"></span>
					</div>
				</fieldset>
         </form>
		<span class="reflect"></span>
		<span class="lock"></span>
		</div>
	    </div>
		</div>
     	</div>
		</div>	
	</div>
</body>
</html>
