<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Uc_Header" %>
<div id="templatemo_menu">
                <%=menutop%>   	
            </div> <!-- end of templatemo_menu -->
            
            <div id="templatemo_header_bar">
            
                    <div id="header"><div class="right"></div>
                    
                        <h1><a href="#">
                            <img src="<%=pathClient %>/images/templatemo_logo.png" alt="Site Title" />
                            <span>Online Store Template</span>
                        </a></h1>
                    </div>
                    
                    <div id="search_box">
                        <div style="position:absolute;margin-left:43px;margin-top:-61px" class="Language">
	                        <a href="<%=pathClient %>/0/trang-chu.aspx"><img width="32" height="20" src="<%=pathClient %>/images/flag_vn.jpg"><span style="color:#FFF;font-weight:bold;padding-left:5px;font-size:14px;margin-right:20px;">Việt Nam</span></a>
	                        <a href="<%=pathClient %>/1/trang-chu.aspx"><img width="32" height="20" src="<%=pathClient %>/images/flag_en.jpg"><span style="color:#FFF;font-weight:bold;padding-left:5px;font-size:14px;">English</span></a>
                        </div>
                        <form action="#" method="get">
                            <input type="text" value="Enter keyword here..." name="q" size="10" id="searchfield" title="searchfield" onfocus="clearText(this)" onblur="clearText(this)"  onkeypress="return KeyPress(event,'search');" />
                            <input type="button" name="Search" value="" alt="Search" id="searchbutton" title="Search" onclick="search1();" />
                        </form>
                    </div>
            
            </div> <!-- end of templatemo_header_bar --> 
<input id="hdLanguage1" type="hidden" value="<%=language %>">

<script>
   
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
	function clearText(field) {
	    if (field.defaultValue == field.value) field.value = '';
	    else if (field.value == '') field.value = field.defaultValue;
	}
	function search1() {
	    var kw = document.getElementById("searchfield").value;
        if (kw == '' || kw == 'Sản phẩm cần tìm')
        {
            if($("#hdLanguage1").val()=="1")
                alert("Please, input key word!");
            else
                alert("Bạn phải nhập từ khóa để tìm!");
            document.getElementById("searchfield").focus();
            return false;
        }
        while (kw.indexOf(" ") != -1) {
            kw=kw.replace(" ", "-");
        }
        window.location = "<%=pathClient %>/" + $("#hdLanguage1").val() + "/trang-1/danh-sach-san-pham/" + kw + ".aspx";
    }	
   
</script>
<script>
    sUrl = '<%=Request.Url.ToString()%>';
    if (sUrl.toLowerCase().indexOf('default.aspx') != -1)
        document.getElementById('mn0').className = 'current';
    else if (sUrl.toLowerCase().indexOf('about.aspx') != -1) 
        document.getElementById('mn1').className = 'current';
    else if (sUrl.toLowerCase().indexOf('products.aspx') != -1 || sUrl.toLowerCase().indexOf('productsdetail.aspx') != -1) 
        document.getElementById('mn2').className = 'current';
    else if (sUrl.toLowerCase().indexOf('listnews.aspx') != -1 || sUrl.toLowerCase().indexOf('newsdetail.aspx') != -1) 
        document.getElementById('mn3').className = 'current';
    else if (sUrl.toLowerCase().indexOf('solutiondetail.aspx') != -1 || sUrl.toLowerCase().indexOf('listsolution.aspx') != -1) 
        document.getElementById('mn4').className = 'current';
    else if (sUrl.toLowerCase().indexOf('contactus.aspx') != -1)
        document.getElementById('mn5').className = 'current';
</script>