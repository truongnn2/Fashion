<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" ValidateRequest="false"%>
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
    <title><%=Titlesptt %> - HL Electric Co. Ltd</title>
    <link type="image/x-icon" href="favicon.png" rel="shortcut icon">
    <link rel="stylesheet" type="text/css" href="css/style.css"/>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/InitPath.js"></script>
    <script src="js/ddaccordion.js" type="text/javascript"></script>
    <script>
         function SubmitForm()
         {
            if($("#txtHoten").val()=="")
            {
                if($("#hdLanguage").val()=="1")
                    alert("Please, input Your name!");
                else
                    alert("Bạn phải nhập Họ tên!");
                $("#txtHoten").focus()
                return false;
            }
            if($("#txtEmail").val()=="")
            {
                if($("#hdLanguage").val()=="1")
                    alert("Please, input Your E-mail!");
                else
                    alert("Bạn phải nhập Email!");
                $("#txtEmail").focus()
                return false;
            }
            if($("#txtNoidung").val()=="")
            {
                if($("#hdLanguage").val()=="1")
                    alert("Please, input Content!");
                else
                    alert("Bạn phải nhập Nội dung!");
                $("#txtNoidung").focus()
                return false;
            }
         }
         
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <center>
        <uc1:UcHeader ID="UcHeader" runat="server" />
        <div class="ContentPages">
	        <uc1:UcLeft ID="UcLeft" runat="server" />
            <div class="ColMiddle">
                <div class="M_Box_1 mar_b10">
                    <div class="TitleBox_M1">
                        <div class="cornerL"></div><div class="cornerR"></div>
                        <h2><%=Titlesptt %></h2>
                    </div>
                    <div class="ContentBox_M1">
                        <div class="BoxContact_M1">
                            <table width="100%" border="0" cellspacing="2" style="text-align:left;">
                              <tr>
                                <td width="100px"><%=hoten %>(<font color="#ff0000">* </font>)</td>
                                <td>&nbsp;</td>
                                <td><input name="" type="text" id="txtHoten" runat="server"/></td>
                              </tr>
                              <tr>
                                <td><%=diachi %></td>
                                <td>&nbsp;</td>
                                <td><input name="" type="text" id="txtDiachi" runat="server"/></td>
                              </tr>
                              <tr>
                                <td><%=dienthoai%></td>
                                <td>&nbsp;</td>
                                <td><input name="" type="text" id="txtSodienthoai" runat="server"/></td>
                              </tr>
                              <tr>
                                <td>Email(<font color="#ff0000">* </font>)</td>
                                <td>&nbsp;</td>
                                <td><input name="" type="text" id="txtEmail" runat="server"/></td>
                              </tr>
                              <tr>
                                <td valign="top"><%=noidung%>(<font color="#ff0000">* </font>)</td>
                                <td>&nbsp;</td>
                                <td valign="top" ><textarea style="width:350px;" rows="5" id="txtNoidung" runat="server"></textarea></td>
                              </tr>
                              <tr>
                                <td valign="top">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td valign="top" >
                                <input type="submit" name="button" id="button" onclick="return SubmitForm();" runat="server" onserverclick="button_ServerClick"/></td>
                              </tr>
                            </table>
                            <asp:HiddenField ID="hdLanguage" runat="server" />
                      </div>
                    </div>
                </div>
                
            </div>
            <uc1:UcRight ID="UcRight" runat="server" />
        </div>
        <uc1:UcBottom ID="UcBottom" runat="server" /> 
     
       </center>
    </form>
</body>
</html>
