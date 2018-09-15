<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Uc_Header" %>



        <div class="banner">
            <div class="banner_fix">
                <a href="<%=pathClient %>/#menu-toggle" id="menu-toggle"></a>
                <div class="logo">
                    <a href="<%=pathClient %>">
                        <img alt="thinhphu.com" src="<%=pathClient %>/images/logo.png"></a>
                </div>
                <div class="banner_right">
                    <div class="fbanner">
                        <div class="hotline">
                            <ul>
                                <li><strong>(093) 3850 287</strong><br>
                                    info@thinhphu.com</li>
                                <li><strong>08:00 - 18:00</strong><br>
                                    Thứ 2 đến Thứ 7</li>
                            </ul>
                        </div>
                        <!--a class="dangtin" href="<%=pathClient %>/dang-tin/">Đăng tin</a-->
                        <div class="mxh">
                            <ul>
                                <li>
                                    <a href="https://facebook.com/" target="_blank">
                                        <img alt="Facebook" src="<%=pathClient %>/images/mxh1.png">
                                    </a>
                                </li>

                                <li>
                                    <a href="https://twitter.com/" target="_blank">
                                        <img alt="Twitter" src="<%=pathClient %>/images/mxh2.png">
                                    </a>
                                </li>

                                <li>
                                    <a href="https://youtube.com/" target="_blank">
                                        <img alt="Youtube" src="<%=pathClient %>/images/mxh3.png">
                                    </a>
                                </li>

                            </ul>
                        </div>
                        <div class="lang">
                            <ul>
                                <li><a href="<%=pathClient %>/0/trang-chu.aspx" class="vn"></a></li>
                                <li><a href="<%=pathClient %>/1/trang-chu.aspx" class="en"></a></li>
                            </ul>
                        </div>
                    </div>
                    <%=menutop %>

                </div>
            </div>
        </div>

        <!-- Sidebar -->

           <%=menutopMobile %>
        
        <!-- /#sidebar-wrapper -->
        <script type="text/javascript">
            $("#menu-toggle").click(function (e) {
                e.preventDefault();
                $("#wrapper").toggleClass("toggled");
            });
        </script>

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
