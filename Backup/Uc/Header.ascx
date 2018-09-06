<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Uc_Header" %>
<script src="<%=pathClient %>/js/yu.js" type="text/javascript"></script>
<script src="<%=pathClient %>/js/tb.js" type="text/javascript"></script>
<script type="text/javascript">

        /*** 
            Simple jQuery Slideshow Script
            Released by Jon Raasch (jonraasch.com) under FreeBSD license: free to use or modify, not responsible for anything, etc.  Please link out to me if you like it :)
        ***/

        function slideSwitch() {
            var $active = $('#slideshow IMG.active');

            if ( $active.length == 0 ) $active = $('#slideshow IMG:last');

            // use this to pull the images in the order they appear in the markup
            var $next =  $active.next().length ? $active.next()
                : $('#slideshow IMG:first');

            // uncomment the 3 lines below to pull the images in random order
            
            // var $sibs  = $active.siblings();
            // var rndNum = Math.floor(Math.random() * $sibs.length );
            // var $next  = $( $sibs[ rndNum ] );


            $active.addClass('last-active');

            $next.css({opacity: 0.0})
                .addClass('active')
                .animate({opacity: 1.0}, 1000, function() {
                    $active.removeClass('active last-active');
                });
        }

        $(function() {
            setInterval( "slideSwitch()", 3000 );
        });

        </script>

        <style type="text/css">

        /*** set the width and height to match your images **/

        #slideshow {
            position:relative;
            height:329px;
	        width:521px;
        }

        #slideshow IMG {
            position:absolute;
            top:0;
            left:0;
            z-index:8;
            opacity:0.0;
        }

        #slideshow IMG.active {
            z-index:10;
            opacity:1.0;
        }

        #slideshow IMG.last-active {
            z-index:9;
        }

        </style>
<div class="TopHeader">
	<div class="Content">
       <div class="Logo"><a href="<%=pathClient %>"><img src="images/logo.png" width="363" height="162" /></a></div>                              
        <ul runat="server" id="mt">
            
        </ul>
        <div class="Language">
            <a href="<%=pathClient %>/Default.aspx"><img src="images/flag_vn.jpg" width="32" height="20" /></a>
            <a href="<%=pathClient %>/Default.aspx?l=1"><img src="images/flag_en.jpg" width="32" height="20" /></a>
        </div>
        <div class="Banner_top">
        	<div class="layermask"><div id="slideshow" class="showphoto"><%=listImage %></div></div>
        	<a href="#"><img src="images/1.jpg" width="585" height="266"/></a>
        </div>
        <div class="Aboutus">
        	<%=about %>
        </div>
        <div class="Search">
        	<h3><span><%=find %></span></h3>
            <input  id="kw"  type="text" class="input_text"  onkeypress="return KeyPress(event,'search');" />
        	<div class="Button">
                <div class="cornerL_button_2"></div>
                <div class="bg_button_2"><a href="javascript:void(0);" onclick="return search1();" ><%=find1 %></a></div>
                <div class="cornerR_button_2"></div>
            </div>
        </div>
   	</div>
   	<input id="hdLanguage1" type="hidden" value="<%=language %>">
</div>
<script>
    sUrl='<%=Request.Url.ToString()%>';
	if(sUrl.toLowerCase().indexOf('default')!=-1)
		document.getElementById('head1').className='current';
    else if(sUrl.toLowerCase().indexOf('about')!=-1)
		document.getElementById('head2').className='current';
 	else if(sUrl.toLowerCase().indexOf('services')!=-1)
 		document.getElementById('head3').className='current';
 	else if(sUrl.toLowerCase().indexOf('products')!=-1||sUrl.toLowerCase().indexOf('productsdetail')!=-1)
 		document.getElementById('head5').className='current';
	else if(sUrl.toLowerCase().indexOf('contactus')!=-1)
		document.getElementById('head4').className='current';
	else if(sUrl.toLowerCase().indexOf('giohang')!=-1)
		document.getElementById('head6').className='current';
	function KeyPress(e, type)
    {
	    var unicode=e.charCode? e.charCode : e.keyCode;	
	    if (unicode == 13)
	    {
		    switch(type) {
		    case "search":
			    search1();
			    return false;
			    break;
			}
	    }
	}
	function setDefaultPage()
    {
//	    $.post(pathClient +"/Handler/handler.aspx", { act:"setdefault",url:sUrl},
//	    function(data){
//	    if(data!="")
//	    {
//            alert("Đặt làm trang chủ thành công!");
//	    }
//	    });
        alert("Chức năng này đang triển khai!");
    }
    function search1()
    {
        if(document.getElementById("kw").value==''||document.getElementById("kw").value=='Sản phẩm cần tìm')
        {
            if($("#hdLanguage1").val()=="1")
                alert("Please, input key word!");
            else
                alert("Bạn phải nhập từ khóa để tìm!");
            document.getElementById("kw").focus();
            return false;
        }
        window.location="<%=pathClient %>/products.aspx?l="+$("#hdLanguage1").val()+"&kw="+document.getElementById("kw").value+"&pg=1";
    }	
    function setHome()
    {
       document.body.style.behavior='url(#default#homepage)';
       document.body.setHomePage(window.location.href);
    }
</script>