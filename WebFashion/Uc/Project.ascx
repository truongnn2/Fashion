<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Project.ascx.cs" Inherits="Uc_Project" %>
<script type="text/javascript">
function SlideNo(param) {
  $('.newsjsctl').hide();
  $('#divNewMain_' + param).fadeIn(50);

  NextVipNew('divNewMain_', param);

  // ChangeLiClass(param);
  }
  function ChangeLiClass(p) {
  $('#divNewMain_' + p + ' .slideControl li').removeClass('current');
  $('#divNewMain_' + p + ' .slideControl #sli' + p).addClass('current');
  }
  //--&gt;
</script>
<script type="text/javascript" src="<%=pathClient %>/js/jquery.carouFredSel-3.2.1-min.js"></script>

<script type="text/javascript">
    $(function() {
        //	Scrolled by user interaction
        $('#ulDaVipMainMnu').carouFredSel({
            //auto: true,
            items: 4,
            auto: 5000,
            prev: '#prev',
            next: '#next',
            // pagination: "#pager2",
            mousewheel: true,
            scroll: {
                items: 1,
                duration: 500
                //timeoutDuration: 5000
            },
            swipe: {
                onMouse: true,
                onTouch: true
            }
        });
    });
</script>
<%=sp%>