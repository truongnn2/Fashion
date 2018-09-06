<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoiPass.aspx.cs" Inherits="Admin_DoiPass_DoiPass" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Thay đổi mật khẩu</title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/transdmin.css" media="screen" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
             <uc1:UcHeader ID="UcHeader2" runat="server" />
            
            <div id="content">
		        <div class="inner">
                    <div class="section">
                        <div class="title_wrapper">
						    <span class="title_wrapper_top"></span>
						    <div class="title_wrapper_inner">
							    <span class="title_wrapper_middle"></span>
							    <div class="title_wrapper_content">
								    <h2>Đổi Mật khẩu đăng nhập</h2>
							    </div>
						    </div>
						    <span class="title_wrapper_bottom"></span>
					    </div>
            	        <div class="section_content">
            	            <span class="section_content_top"></span>
            	            <div class="section_content_inner">
            	                <table>
            	                    <tr>
            	                        <td>
            	                            <label>Nhập mật khẩu mới:</label>
            	                        </td>
            	                        <td>
            	                            <input id="txtPass" type="text" name="txtPass" runat="server" style="width: 200px"/>
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td>
            	                            <label>Nhập lại mật khẩu :</label>
            	                        </td>
            	                        <td>
            	                            <input id="txtRepass"  type="text" name="txtRepass" runat="server" style="width: 200px"/>
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td colspan="2">
            	                            <input id="btnAdd"  type="submit" value="Thay đổi" onclick="return CheckPass();" name="btnAdd" runat="server" onserverclick="btnAdd_ServerClick"/><input id="Button1" onclick="javascript:window.location='<%=pathClient %>/admins/Products/ListProducts.aspx';" tabIndex="9" type="button" value="Thoát" name="btexit" />
            	                        </td>
            	                        
            	                    </tr>
            	                </table>
                            </div>
            	        </div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>	
            
            <uc1:UcBottom ID="UcBottom" runat="server" />
        </div>
        
		<script type="text/javascript">
		    function CheckPass()
		    {
		        if(document.getElementById("txtPass").value=="")
		        {
		            alert("Bạn phải nhập mật khẩu mới!");
		            document.getElementById("txtPass").focus();
		            return false;
		        }
		        if(document.getElementById("txtRepass").value=="")
		        {
		            alert("Bạn phải nhập lại mật khẩu mới!");
		            document.getElementById("txtRepass").focus();
		            return false;
		        }
		        if(document.getElementById("txtRepass").value!=document.getElementById("txtPass").value)
		        {
		            alert("Bạn nhập lại mật khẩu chưa đúng!");
		            document.getElementById("txtRepass").focus();
		            return false;
		        }
		    }
		    function CheckPass1()
		    {
		        if(document.getElementById("txtPass1").value=="")
		        {
		            alert("Bạn phải nhập mật khẩu mới!");
		            document.getElementById("txtPass1").focus();
		            return false;
		        }
		        if(document.getElementById("txtRepass1").value=="")
		        {
		            alert("Bạn phải nhập lại mật khẩu mới!");
		            document.getElementById("txtRepass1").focus();
		            return false;
		        }
		        if(document.getElementById("txtRepass1").value!=document.getElementById("txtPass1").value)
		        {
		            alert("Bạn nhập lại mật khẩu chưa đúng!");
		            document.getElementById("txtRepass1").focus();
		            return false;
		        }
		    }
		</script>
    </form>
</body>
</html>
