<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="Admins_BoxAd_AddNew"  ValidateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Admins/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeftMenu" Src="~/Admins/LeftMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Admins/Bottom.ascx" %>
<%@ Register TagPrefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Box quảng cáo</title>
    <script type="text/javascript" src="<%=pathAdmin%>/js/initadmin.js"></script>
    <script type="text/javascript"  src="<%=pathAdmin%>/js/BoxAd.js"></script>
    <script type="text/javascript"  src="<%=pathClient%>/js/jquery.js"></script>

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
								    <h2>Nhập mới Box quảng cáo </h2>
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
            	                            <label><strong>Link:</strong></label>
            	                        </td>
            	                        <td>
            	                             <input id="txtUrl" type="text" class="text-long" runat="server" style="width: 561px" />
            	                        </td>
            	                    </tr>
            	                    <tr>
            	                        <td>
            	                            <label><strong>Vị trí:</strong></label>
            	                        </td>
            	                        <td>
            	                            <select name="sltCategory" style="WIDTH:150px" id="sltCategory" runat="server">
                                            </select>
            	                        </td>
            	                    </tr>
            	                    <!--tr>
            	                        <td>
            	                            <label><strong>Trang:</strong></label>
            	                        </td>
            	                        <td>
            	                            <select name="sltPage" style="WIDTH:150px" id="sltPage" runat="server">
                                            </select>
            	                        </td>
            	                    </tr--> 
            	                     <tr>
            	                        <td>
            	                            <label><strong>Trọng số vị trí:</strong></label>
            	                        </td>
            	                        <td>
            	                            <select name="sltLocation" style="WIDTH:70px" id="sltLocation" runat="server">
                                             </select> (Số càng lớn thì mục đó càng lên đầu tiên) 
            	                        </td>
            	                    </tr> 
            	                    <tr>
            	                         <td>
            	                            <label><strong>Nhập hình ảnh:</strong></label>
            	                        </td>
            	                        <td>
            	                           <asp:FileUpload ID="FileUpload1" runat="server" Width="311px" />
            	                           <%=listphoto %>
            	                        </td>
            	                        
            	                    </tr>
            	                    <tr>
            	                        <td></td>
            	                        <td>
            	                            <input id="Addnew" type="submit" value="Nhập mới" runat="server" onclick="return AddNewBoxAd();" style="margin-top:10px;" onserverclick="Addnew_ServerClick" /><INPUT id="btexit" onclick="javascript:location='ListBoxad.aspx';" tabIndex="9" type="button" value="Hủy" name="btexit" />
            	                           
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
        
    </form>
</body>
</html>
