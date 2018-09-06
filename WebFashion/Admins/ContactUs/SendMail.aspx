<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendMail.aspx.cs" Inherits="Admins_ContactUs_SendMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gửi Email phản hồi</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="email-friend">
				<div class="pcont">
					<table width="100%" border="0" cellpadding="3">
						<tr>
							<td scope="col" colspan="2" align="center">
								<span id="lblSubject">Gửi Email phản hồi</span>
							</td>
						</tr>	
					    <tr>
							<td scope="col" colspan="2" align="center">
							</td>
						</tr>
						 <tr>
							<td scope="col" colspan="2" align="center">
							</td>
						</tr>
						<tr>

							<td><span id="Label5">Email người nhận</span></td>
							<td><input name="txtEmailTo" type="text" id="txtEmailTo" maxlength="50" size="27" runat="server" /></td>
							
							
						</tr>
						<tr>
							<td colspan="2"><span id="Label">Thư gửi </span></td>
						</tr>
						<tr>
							<td colspan="2"><textarea name="txtMessage" id="txtMessage" rows="7" style="width: 290px" runat="server"></textarea></td>

						</tr>
						<tr>
							<td colspan="2" align="right">
                                <input id="Addnew" type="submit" value="Gửi" runat="server" onclick="return CheckSendMail();" style="margin-top:10px;" onserverclick="Addnew_ServerClick" />
							</td>
						</tr>
						<tr>
							<td colspan="2" align="right">
								<span id="Span1" style="color:Red;float:left;"><%=success %></span>
								<br>
							</td>
						</tr>

					</table>
				</div>
			</div>
        <script>
            function CheckSendMail()
            {
                if(document.getElementById("txtEmailTo").value=="")
                {
                    alert("Bạn phải nhập Email người nhận!");
                    document.getElementById("txtEmailTo").focus()
                    return false;
                }
                if(document.getElementById("txtMessage").value=="")
                {
                    alert("Bạn phải nhập nội dung!");
                    document.getElementById("txtMessage").focus()
                    return false;
                }
            }
        </script>
    </form>
</body>
</html>
