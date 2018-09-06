<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Uc_Search" %>

<%=hotnews %>
 
<div style="padding-bottom:6px;">
    <table class="center_search" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td class="form_name_search" align="center">
                    <img src="images/kinhlup.gif" align="absmiddle">&nbsp; &nbsp;<%=find1 %> : 
                    <input title="Từ khóa" class="form_control_search" id="kw" name="keyword" style="width:230px" onkeypress="return KeyPress(event,'search');" type="text"> &nbsp; 
                    <input title="<%=find1 %>" value="&nbsp; <%=find1 %> &nbsp;" class="form_button" onclick="return search1();" type="button">
                </td>
            </tr>
            <tr bgcolor="#0d6ed5" height="4"><td></td></tr>
        </tbody>
     </table>
 </div>
 
