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
<div class="ColRight">
        <div class="R_Box_1">
            <div class="TitleBox_R1">
                <div class="cornerL"></div><div class="cornerR"></div>
                <h2><%=Titlesptt %></h2>
            </div>
            <div class="ContentBox_M1">
            	<div class="BoxPro_New_1">
            	     <div class="demo">
                        <marquee behavior="scroll" direction="up" scrollamount="2" height="300" width="190">
                            <ul>
                              <%=hotnews %>
                            </ul>
                        </marquee>
                    </div>       
                    
                </div>
            </div>
      	</div>
        <%=boxqc %>
    </div>
