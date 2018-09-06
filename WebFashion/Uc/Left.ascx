<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Left.ascx.cs" Inherits="Uc_Left" %>
<script src="<%=pathClient %>/js/jquery.marquee.js" type="text/javascript"></script>
<script type="text/javascript">



    $(function() {
        // basic version is: $('div.demo marquee').marquee() - but we're doing some sexy extras

        $('div.demo marquee').marquee('pointer').mouseover(function() {
            $(this).trigger('stop');
        }).mouseout(function() {
            $(this).trigger('start');
        }).mousemove(function(event) {
            if ($(this).data('drag') == true) {
                this.scrollLeft = $(this).data('scrollX') + ($(this).data('x') - event.clientX);
            }
        }).mousedown(function(event) {
            $(this).data('drag', true).data('x', event.clientX).data('scrollX', this.scrollLeft);
        }).mouseup(function() {
            $(this).data('drag', false);
        });
    });
</script>
<div id="sidebar"><div class="sidebar_top"></div><div class="sidebar_bottom"></div>
            	
    <div class="sidebar_section">
    
        <%=ml%>
    </div>
    
    <div class="sidebar_section">
    
        <h2><%=TitleSupportOnline%></h2>
        <%=Listsupport%>
    
    </div>  
    
    <%=DiscountProducts%>
    
     <%=boxqc%>
</div>         