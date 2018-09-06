<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Right.ascx.cs" Inherits="Uc_Right" %>
<script src="<%=pathClient %>/js/jquery.marquee.js" type="text/javascript"></script>
<script type="text/javascript">



 $(function () {
        // basic version is: $('div.demo marquee').marquee() - but we're doing some sexy extras
        
        $('div.demo marquee').marquee('pointer').mouseover(function () {
            $(this).trigger('stop');
        }).mouseout(function () {
            $(this).trigger('start');
        }).mousemove(function (event) {
            if ($(this).data('drag') == true) {
                this.scrollLeft = $(this).data('scrollX') + ($(this).data('x') - event.clientX);
            }
        }).mousedown(function (event) {
            $(this).data('drag', true).data('x', event.clientX).data('scrollX', this.scrollLeft);
        }).mouseup(function () {
            $(this).data('drag', false);
        });
    });
</script>
<div style="padding-bottom:6px">
    <table cellpadding="0" cellspacing="0" width="100%"><tbody><tr><td class="left_menu_title"><%=TitleSupportOnline %></td></tr></tbody></table>
    <table style="border:1px #bbccdd solid; border-top:none; background:#d0e6fe" cellpadding="0" cellspacing="6" width="100%">
        <tbody>
            <tr>
                <td align="center" width="1%">
                    <%=Listsupport%>
                </td>
            </tr>
        </tbody>
   </table>
</div>
<div style="padding-bottom:6px">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr><td class="left_menu_title"><%=Titlesptt%></td></tr>
        </tbody>
    </table>
   
     <div class="demo" style="background:#d0e6fe">
        <marquee behavior="scroll" direction="up" scrollamount="2" height="200" width="200">
            <table style="border:none; background:#d0e6fe" cellpadding="3" cellspacing="0" width="100%">
                <tbody>
                    <%=hotnews%>
               </tbody>
            </table>
        </marquee>
    </div>    
</div>
<div style="padding-bottom:6px">
<%=boxqc%>
