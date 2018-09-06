<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuGioiThieu.ascx.cs" Inherits="MenuGioiThieu" %>
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

<div id="Left">
	<div class="urbangreymenu">
        <%=ml %>
        
        </div>
        
            <div class="spmoi"></div>
             <div class="box spmoi1" >
                <div class="demo">
                    <marquee behavior="scroll" direction="up" scrollamount="2" height="300" width="190">
                        <%=productsnew%>
                    </marquee>
                </div>            
                       
             </div>
              
        <div class="box">
        	<div class="link"></div>
            <select id="linkwebsite" name="linkwebsite" runat="server" onchange="lwebsite(this.value);" style="width:150px">
            </select>
        </div>
        <div id="boxtk" class="box" runat="server">
        	<div class="thongke"></div>
            <%=thongkesp%>
            Có <strong><% =Application["ActiveUsers"]%></strong> khách đang xem<br/>
            Có <strong>
                <!-- Start of StatCounter Code -->
                <script type="text/javascript">
                var sc_project=6712793; 
                var sc_invisible=0; 
                var sc_security="4153a178"; 
                var sc_text=4; 
                </script>

                <script type="text/javascript"
                src="http://www.statcounter.com/counter/counter.js"></script><noscript><div
                class="statcounter"><a title="counter customisable"
                href="http://statcounter.com/free_hit_counter.html"
                target="_blank"><img class="statcounter"
                src="http://c.statcounter.com/6712793/0/4153a178/0/"
                alt="counter customisable" ></a></div></noscript>
                <!-- End of StatCounter Code -->
            </strong> khách đã xem        
        </div>
        <%= boxqc%>
</div>
<script>
function lwebsite(lw)
{
    if(lw!="")
        window.open(lw);
}

</script>
