<%@ Page Language="C#" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="products" %>
<%@ Register TagPrefix="uc1" TagName="UcRight" Src="~/Uc/Right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeft" Src="~/Uc/Left.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Uc/Bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Uc/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ImageContent" Src="~/Uc/ImageContent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucSolution" Src="~/Uc/ucSolution.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCheckLogin" Src="~/Uc/ucCheckLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Services" Src="~/Uc/Services.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Project" Src="~/Uc/Project.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
     <meta content="thoitrangxuatkhau.net.vn" name="author"/>
    <meta name="description" content="Thời trang xuất khẩu: chuyên bán buôn thời trang xuất khẩu (vnxk) cao cấp, cho chất lượng giá tốt với bán lẻ buôn thời trang xuất khẩu, Thời trang nữ thu đông 2013 sành điệu & giá rẻ chỉ có tại thoitranxuatkhau.net.vn. Cùng mua chung theo nhóm những mẫu quần áo nữ, phụ kiện nữ trẻ trung & nổi bật, Chuyên cung cấp thời trang nam, áo khoác, áo thun, sơ mi nam hàn quốc, đa phong cách cực đẹp, độc cho giới trẻ." />
    <meta name="keywords" content="Bán buôn thời trang xuất khẩu vnxk, thời trang xuất khẩu, thời trang vnxk, bán lẻ bán buôn thời trang vnxk zara, MNG, H&M, thời trang nữ, thời trang, hotdeal, hotdeals, hot deal, mua hàng theo nhóm,mua chung, nhóm mua, cùng mua, deal, deals, giá tốt, giá rẻ, giảm giá, khuyến mại, ưu đãi, Group Buy, daily deals, Áo khoác nam, áo thun nam, sơ mi nam, sơ mi hàn quốc, quần jean, quần kaki. " />
    <meta content="index,follow" name="robots"/>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta content="pgZdXuU7BiuTZ+A9Gq2ZgjW6Y2DHNy7Kw48HtQWPbrI=" name="verify-v1"/>
    <title><%=title %> - <%=Titlepage%></title>
    <link type="image/x-icon"  id="favicon" runat="server" rel="shortcut icon">
       <link rel="stylesheet" id="StyleTag00" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag01" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag1" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag2" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag3" runat="server" type="text/css" />

	<script type="text/javascript" src="<%=pathClient %>/js/jquery.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/InitPath.js"></script>

</head>
<body>
    <form runat="server" id="form1">
      <div id="wrapper">
        <div id="page-content-wrapper">
            <script type="text/javascript">
                jQuery("document").ready(function ($) {

                    var nav = $('.banner');
                    $(window).scroll(function () {
                        if ($(this).scrollTop() > 150) {
                            nav.addClass("f-nav");
                        } else {
                            nav.removeClass("f-nav");
                        }
                    });

                });
            </script>
            <uc1:UcHeader ID="UcHeader1" runat="server" />

        <!-- Start WOW Slider.com HEAD section -->
        <script type="text/javascript" src="<%=pathClient %>/js/RCP/jquery.js"></script>
        <script type="text/javascript" src="<%=pathClient %>/js/RCP/a.js"></script>
        <!-- End WOW Slider.com HEAD section -->
        <div class="bannerslide">
            <!-- Start WOWSlider.com BODY section -->

          <div id="wowslider-container">
            <div class="ws_images">
                <ul>
                <li>
                    <a href="/">
                        <img src="<%=pathClient %>/images/vai_thun_1.jpg" alt="" title="" id='wows1_1'/>
                    </a>
                    <a class="sum" href="/">
                        
                    </a>
                </li>
             
                <li>
                    <a href="/">
                        <img src="<%=pathClient %>/images/vai_thun_2018.jpg" alt="" title="" id='wows1_2'/>
                    </a>
                    <a class="sum" href="/">
                        
                    </a>
                </li>
             
                <li>
                    <a href="/">
                        <img src="<%=pathClient %>/images/Slide_vaithun.jpg" alt="" title="" id='wows1_3'/>
                    </a>
                    <a class="sum" href="/">
                        <h2>Về <em>Lami Group</em></h2>
<p>C&ocirc;ng ty tr&aacute;ch nhiệm hữu hạn sản xuất thương mại v&agrave; dịch vụ La Mi được th&agrave;nh lập năm 2003 hoạt động trong lĩnh vực dệt may thời trang g&oacute;p phần đưa ng&agrave;nh dệt may thời trang Việt Nam trở th&agrave;nh ng&agrave;nh kinh tế mũi nhọn của quốc gia</p>
                    </a>
                </li>
             
                <li>
                    <a href="/">
                        <img src="<%=pathClient %>/images/Slide_vaithun_7.jpg" alt="" title="" id='wows1_4'/>
                    </a>
                    <a class="sum" href="/">
                        <h2>Ng&agrave;nh nghề<em> ch&iacute;nh</em></h2>
<p>Ph&aacute;p huy tối đa năng lực c&oacute; sẵn, C&ocirc;ng ty TNHH sản xuất thương mại v&agrave; dịch vụ La Mi hoạt động tr&ecirc;n ba lĩnh vực ch&iacute;nh: Kinh doanh c&aacute;c sản phẩm sợi dệt, Sản suất v&agrave; kinh doanh vải dệt kim, Mua b&aacute;n nguy&ecirc;n phụ liệu ng&agrave;nh may</p>
                    </a>
                </li>
             
                <li>
                    <a href="/">
                        <img src="<%=pathClient %>/images/Slide_vaithun_2.jpg" alt="" title="" id='wows1_5'/>
                    </a>
                    <a class="sum" href="/">
                        <h2>Phương <em>ch&acirc;m</em></h2>
<p>Với phương ch&acirc;m: &ldquo;Uy T&iacute;n, Chất Lượng, Gi&aacute; Cả Cạnh Tranh&rdquo; ch&uacute;ng t&ocirc;i phấn đấu để trở th&agrave;nh doanh nghiệp sản xuất vải thun cao cấp v&agrave; tin tưởng c&oacute; thể đ&aacute;p ứng c&aacute;c y&ecirc;u cầu kỹ thuật, mỹ thuật, chất lượng cũng như c&aacute;c y&ecirc;u cầu về tiến độ, thời trang</p>
                    </a>
                </li>
             
                <li>
                    <a href="/">
                        <img src="<%=pathClient %>/images/16_12_59_Slide_vaithun.jpg" alt="" title="" id='wows1_6'/>
                    </a>
                    <a class="sum" href="/">
                        
                    </a>
                </li>
            	        
            </ul>

            </div>



        </div>

            <script type="text/javascript" src="<%=pathClient %>/js/RCP/wowslider.js"></script>
            <script type="text/javascript" src="<%=pathClient %>/js/RCP/script.js"></script>
            <!-- End WOWSlider.com BODY section -->
        </div>

        <script type="text/javascript" src="<%=pathClient %>/js/RCP/owl.carousel.js.download.js"></script>



        <script type="text/javascript" src="<%=pathClient %>/js/RCP/owl.carousel.partner.js.download.js"></script>
       

    <div class="main">

            <div class="main_fix_home">
                <div class="main_box_full"> 
                    <div class="main_bar main_bar_sp">
                        <h2>Sản phẩm</h2>
                    </div>
                    
                    <div class="animation-element bounce-up cf" data-wow-delay="0.8s">
                        <div class="subject">                   
                            <div class="main_content"> 
                                <div class="noidung"></div> 
                                <ul class="box_services">
                                                      
                                            <li>
                                                <div class="csanphamtieubieuitem">
                                                    <div class="csanphamtieubieuitem_img">
                                                        <a href="/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                                            <img alt='Vải thun cotton 100% 2c, 4c' src='<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg' />
                                                        </a>
                                                    </div>
                                                    <div class="csanphamtieubieu_info">
                                                        <a class="title" href="/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                                            <h3>Vải thun cotton 100% 2c, 4c</h3>
                                                        </a> 
                                                        <a class="addcart" href="/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                                    </div>
                                                </div>
                                            </li>
                                              
                                            <li>
                                                <div class="csanphamtieubieuitem">
                                                    <div class="csanphamtieubieuitem_img">
                                                        <a href="/vai-thun-65-35-2.html">
                                                            <img alt='Vải thun 65/35' src='<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg' />
                                                        </a>
                                                    </div>
                                                    <div class="csanphamtieubieu_info">
                                                        <a class="title" href="/vai-thun-65-35-2.html">
                                                            <h3>Vải thun 65/35</h3>
                                                        </a> 
                                                        <a class="addcart" href="/dat-hang/vai-thun-65-35-2"><span></span>Mua hàng</a>
                                                    </div>
                                                </div>
                                            </li>
                                              
                                            <li>
                                                <div class="csanphamtieubieuitem">
                                                    <div class="csanphamtieubieuitem_img">
                                                        <a href="/vai-thun-ca-sau-poly-16.html">
                                                            <img alt='Vải Thun Cá Sấu Poly' src='<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg' />
                                                        </a>
                                                    </div>
                                                    <div class="csanphamtieubieu_info">
                                                        <a class="title" href="/vai-thun-ca-sau-poly-16.html">
                                                            <h3>Vải Thun Cá Sấu Poly</h3>
                                                        </a> 
                                                        <a class="addcart" href="/dat-hang/vai-thun-ca-sau-poly-16"><span></span>Mua hàng</a>
                                                    </div>
                                                </div>
                                            </li>
                                              
                                            <li>
                                                <div class="csanphamtieubieuitem">
                                                    <div class="csanphamtieubieuitem_img">
                                                        <a href="/vai-thun-ca-sau-65-35-15.html">
                                                            <img alt='Vải thun cá sấu 65 35' src='<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg' />
                                                        </a>
                                                    </div>
                                                    <div class="csanphamtieubieu_info">
                                                        <a class="title" href="/vai-thun-ca-sau-65-35-15.html">
                                                            <h3>Vải thun cá sấu 65 35</h3>
                                                        </a> 
                                                        <a class="addcart" href="/dat-hang/vai-thun-ca-sau-65-35-15"><span></span>Mua hàng</a>
                                                    </div>
                                                </div>
                                            </li>
                                              
                                            <li>
                                                <div class="csanphamtieubieuitem">
                                                    <div class="csanphamtieubieuitem_img">
                                                        <a href="/vai-thun-vay-cotton-spandex-17.html">
                                                            <img alt='Vải thun Vảy Cotton + Spandex' src='<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg' />
                                                        </a>
                                                    </div>
                                                    <div class="csanphamtieubieu_info">
                                                        <a class="title" href="/vai-thun-vay-cotton-spandex-17.html">
                                                            <h3>Vải thun Vảy Cotton + Spandex</h3>
                                                        </a> 
                                                        <a class="addcart" href="/dat-hang/vai-thun-vay-cotton-spandex-17"><span></span>Mua hàng</a>
                                                    </div>
                                                </div>
                                            </li>
                                              
                                            <li>
                                                <div class="csanphamtieubieuitem">
                                                    <div class="csanphamtieubieuitem_img">
                                                        <a href="/vai-thun-ca-sau-pe-3.html">
                                                            <img alt='Vải thun Cá sấu PE' src='<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg' />
                                                        </a>
                                                    </div>
                                                    <div class="csanphamtieubieu_info">
                                                        <a class="title" href="/vai-thun-ca-sau-pe-3.html">
                                                            <h3>Vải thun Cá sấu PE</h3>
                                                        </a> 
                                                        <a class="addcart" href="/dat-hang/vai-thun-ca-sau-pe-3"><span></span>Mua hàng</a>
                                                    </div>
                                                </div>
                                            </li>
                                              
                                            <div id="dvPaging" class="page_view">
                                                 
                                            </div>              
                                           
                                </ul>
                            </div>  
                        </div>
                    </div>                  
                </div>
            </div>
        </div>



        <script type="text/javascript" src="<%=pathClient %>/js/RCP/jQuery.scrollSpeed.js.download.js"></script>
        <script type="text/javascript">
            $(function () {

                jQuery.scrollSpeed(100, 800);

            });
        </script>

        <a href="tel:0944400034" class="call-now" rel="nofollow">
            <div class="mypage-alo-phone">
                <div class="animated infinite zoomIn mypage-alo-ph-circle"></div>
                <div class="animated infinite pulse mypage-alo-ph-circle-fill"></div>
                <div class="animated infinite tada mypage-alo-ph-img-circle"></div>
            </div>
        </a>
        <script type="text/javascript">
            $(document).ready(function () {
                var $animation_elements = $('.animation-element');
                var $window = $(window);

                function check_if_in_view() {
                    var window_height = $window.height();
                    var window_top_position = $window.scrollTop();
                    var window_bottom_position = (window_top_position + window_height);

                    $.each($animation_elements, function () {
                        var $element = $(this);
                        var element_height = $element.outerHeight();
                        var element_top_position = $element.offset().top;
                        var element_bottom_position = (element_top_position + element_height);

                        //check to see if this current container is within viewport
                        if ((element_bottom_position >= window_top_position) &&
                            (element_top_position <= window_bottom_position)) {
                            $element.addClass('in-view');
                        } else {
                            $element.removeClass('in-view');
                        }
                    });
                }

                $window.on('scroll resize', check_if_in_view);
                $window.trigger('scroll');
            });
    </script>
        <div class="animation-element bounce-up cf" data-wow-delay="0.8s">
            <div class="subject">

                <div class="contact" id="contact">
                    <div class="contact_fix">
                        <div class="contact_col1">
                            <div class="contact_content">
                                <p>
                                    <img src="<%=pathClient %>/images/logo(1).png" alt="" width="125" height="95"></p>
                                <ul>
                                    <li>CÔNG TY TNHH SX TM &amp; DV LA MI</li>
                                    <li>VP: 2C Phạm Phú Thứ, P. 11, Q. Tân Bình</li>
                                    <li>CN 1: 97&nbsp;Phạm Phú Thứ, P. 11, Q. Tân Bình</li>
                                    <li>CN2: 74 Phan Sào Nam, P. 11, Q. Tân Bình</li>
                                    <li>Nhà Xưởng: 261 Hồ Văn Tắng, Huyện Củ Chi</li>
                                    <li>Điện thoại: (028) 3971 8092</li>
                                    <li>Fax: (028) 3949 1482</li>
                                    <li>Email: info@vaithun.com</li>
                                    <li>Website: www.vaithun.com</li>
                                </ul>
                                <p>&nbsp;</p>
                            </div>
                        </div>
                        <div class="contact_col2">
                            <div class="contact_col_head">
                                <h3>Sản phẩm tiêu biểu</h3>
                            </div>
                            <ul>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">Vải thun cotton 100% 2c, 4c</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-65-35-2.html">Vải thun 65/35</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-ca-sau-poly-16.html">Vải Thun Cá Sấu Poly</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-ca-sau-65-35-15.html">Vải thun cá sấu 65 35</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-vay-cotton-spandex-17.html">Vải thun Vảy Cotton + Spandex</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-ca-sau-pe-3.html">Vải thun Cá sấu PE</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-cat-giay-22.html">Vải thun Cát giấy</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-ca-map-21.html">Vải thun Cá mập</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/vai-thun-bo-gan-19.html">Vải thun bo gân</a>
                                </li>

                            </ul>
                        </div>
                        <div class="contact_col3">
                            <div class="contact_col_head">
                                <h3>Hình ảnh</h3>
                            </div>
                            <ul>

                                <li>
                                    <a href="http://vaithun.com/hinh-anh/">
                                        <img alt="" src="<%=pathClient %>/images/Lami_footer_1.jpg">
                                    </a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/hinh-anh/">
                                        <img alt="" src="<%=pathClient %>/images/Lami_footer_2.jpg">
                                    </a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/hinh-anh/">
                                        <img alt="" src="<%=pathClient %>/images/Lami_footer_3.jpg">
                                    </a>
                                </li>

                            </ul>
                        </div>
                        <div class="contact_col4">
                            <div class="contact_col_head">
                                <h3>Bán hàng &amp; Hỗ trợ</h3>
                            </div>
                            <div class="contact_content">
                                <ul>
                                    <li>Hotline CSKH: 09444 000 34 (Tư vấn kỹ thuật dệt nhuộm)</li>
                                    <li>Hotline Sale Online: 09334 000 34</li>
                                    <li>CSKH Doanh Nghiệp: 0976 369 009</li>
                                    <li>CSKH Doanh Nghiệp: 0945678 892</li>
                                    <li>Hotline Bán Lẻ: 091 171 77 99</li>
                                    <li>Kỹ Thuật: info@vaithun.com</li>
                                    <li>Kinh doanh 1: sale@vaithun.com</li>
                                    <li>Kinh doanh 2: kinhdoanh@vaithun.com</li>
                                    <li>Kinh doanh 3: lamigroup@gmail.com</li>
                                    <li>Kinh doanh 4: lami@vaithun.com</li>
                                    <li>Kế toán: ketoan@vaithun.com</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="footer">
                    <div class="footer_fix">
                        <div class="footer_content">
                            <p>Copyrights © 2017 LAMI CO,.LTD. All rights reserved.</p>
                            <a class="copyright" href="http://ketnoiviet.net/">Thiết kế web Kết Nối Việt</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="bttop"></div>
        <script type="text/javascript">$(function () { $(window).scroll(function () { if ($(this).scrollTop() != 0) { $('#bttop').fadeIn(); } else { $('#bttop').fadeOut(); } }); $('#bttop').click(function () { $('body,html').animate({ scrollTop: 0 }, 800); }); });</script>
        <div class="non">
            <div class="geo">
                GEO: 
       
                <span class="latitude">10.7780732</span>, 
       
                <span class="longitude">106.5762487</span>
            </div>
            <div class="vcard">
                <a class="url fn" href="http://vaithun.com/">CÔNG TY TNHH SX - TM - DV LA MI</a>
                <div class="adr">
                    <span class="type">Work</span>:
       
                    <div class="street-address">info@vaithun.com</div>
                    <span class="locality">Ho Chi Minh City</span>,  
       
                    <abbr class="region" title="California">HCMC</abbr>
                    <span class="postal-code">700000</span>
                    <div class="country-name">Vietnam</div>
                </div>
                <span class="tel">
                    <span class="type">Cell</span>:
               
                    <span class="value">0976 369 009</span>
                </span>
            </div>
            <div itemscope="" itemtype="http://schema.org/LocalBusiness">
                <span itemprop="name">CÔNG TY TNHH SX - TM - DV LA MI</span>
                <span itemprop="description">CÔNG TY TNHH SX - TM - DV LA MI</span>
                <div itemprop="address" itemscope="" itemtype="http://schema.org/PostalAddress">
                    <span itemprop="streetAddress">TP.HCM</span>
                    <span itemprop="addressLocality">Ho Chi Minh City</span>,
       
                    <span itemprop="addressRegion">HCMC</span>
                    <span itemprop="addressCountry">Vietnam</span><br>
                    <span itemprop="postalCode">700000</span><br>
                    <span itemprop="email">info@vaithun.com</span>
                </div>
                Điện thoại: <span itemprop="telephone">vaithun.com</span>
                <meta itemprop="openingHours" content="Mo-Sa 08:00-17:30">
                T2-T7 8am - 5:30pm
       
                <img itemprop="image" width="365" height="179" align="right" src="<%=pathClient %>/images/logo(2).png" alt="CÔNG TY TNHH SX - TM - DV LA MI">
                <span itemprop="priceRange">VND200000 - VND500000</span>
            </div>
            <h2>CÔNG TY TNHH SX - TM - DV LA MI - Chuyên mua bán các loại vải thun cao cấp - vải thun giá rẻ</h2>
            <h3>CÔNG TY TNHH SX - TM - DV LA MI</h3>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {

                $(".btn-slide").click(function () {
                    $("#panel").slideToggle("slow");
                    $(this).toggleClass("active2"); return false;
                });


            });
</script>
</div>
      </div>

        <asp:HiddenField ID="hdfRecordCount" runat="server" />
	 <script type="text/javascript">
	        var t=<%=b%>;
	        var link='<%=link1 %>';
	        if(t==1)
	        {
		        var tps = (parseInt(document.getElementById("hTotalRows").value)/parseInt(document.getElementById("hdfRecordCount").value) - parseInt(parseInt(document.getElementById("hTotalRows").value)/parseInt(document.getElementById("hdfRecordCount").value)))>0?((parseInt(parseInt(document.getElementById("hTotalRows").value)/parseInt(document.getElementById("hdfRecordCount").value)))+1):parseInt(parseInt(document.getElementById("hTotalRows").value)/parseInt(document.getElementById("hdfRecordCount").value));
		        if(tps<document.getElementById("hCurrentPage").value)
			        document.getElementById("hCurrentPage").value=1;
		        mjDrawLbPageNew(tps, document.getElementById("hCurrentPage").value, "dvPaging","gotoPage");
	        }
	        function gotoPage(numberpage)
	        {			
		        pg = numberpage;
		        window.location=link.replace("###",numberpage);
	        }

	        function mjDrawLbPageNew(TotalPages_, CurrentPage_, ElementID_,sGotoPageFunction)
            {
                var _START_PAGE=0;
                var _END_PAGE=0;
                var _CPAGE=0;
                var _ITEMS_PAGES=10;
                var _ITEMS_PAGES_Admin=20;
                var _PART_PAGES=10;
                _CPAGE=CurrentPage_;
                if(_CPAGE>TotalPages_)
	                _CPAGE=TotalPages_;
                _START_PAGE = 1;
                _END_PAGE = 1 + (_PART_PAGES - 1);
                if(TotalPages_ < _PART_PAGES){_END_PAGE = TotalPages_;}
                else
                {
	                if(CurrentPage_ >= _END_PAGE)
	                {
		                _START_PAGE += 8;
		                if((_END_PAGE + 8) < TotalPages_){_END_PAGE += 8;}
		                else{_END_PAGE = TotalPages_;}
		                while(CurrentPage_ >= _END_PAGE && CurrentPage_ < TotalPages_)
		                {
			                _START_PAGE = _END_PAGE - 1;
			                if((TotalPages_ - _END_PAGE) < _PART_PAGES){
				                if(TotalPages_ - _START_PAGE <= _PART_PAGES)
				                {
					                _END_PAGE = TotalPages_;
					                if((_END_PAGE - _START_PAGE) == _PART_PAGES)
					                {_END_PAGE = _START_PAGE + (_PART_PAGES - 1);}
				                }
				                else{_END_PAGE = _START_PAGE + _PART_PAGES - 1;}
			                }
			                else{_END_PAGE = _START_PAGE + _PART_PAGES - 1;}
		                }
	                }
	                if(CurrentPage_ == TotalPages_){
		                _END_PAGE = TotalPages_;_START_PAGE = parseInt(TotalPages_/8)*8 - 1; 
		                if(_START_PAGE > _END_PAGE) _START_PAGE = _START_PAGE - 8;}
                };
                var theme = "<div class='st_uti'><div class='page'>";
                //phan chia dau/truoc/tiep/cuoi
                var next;
                var pre;
                if(CurrentPage_==1)
	                pre=1;
                else pre=CurrentPage_-1;
                if(CurrentPage_==TotalPages_)
	                next=TotalPages_;
                else next=parseInt(CurrentPage_)+1;
                
                //theme+= "[<a href='javascript:"+sGotoPageFunction+"(1)' style='color:black'>Trang đầu</a>]";
                theme+= "<a href='javascript:"+sGotoPageFunction+"("+ pre +")' >Trang trước</a>";
                for( var k = _START_PAGE; k <= _END_PAGE; k++){
	                if(CurrentPage_ != k)theme+= "<a href='javascript:"+sGotoPageFunction+"("+ (k) +")' >"+ (k) +"</a>";
	                else //theme+= "<span class='pgSelected'><b><u>"+ (k) +"</u></b></span>";
	                theme+= "<a ><font color='red'><b>"+ (k) +"</b></font></a>";
                }
                theme+= "<a href='javascript:"+sGotoPageFunction+"("+ next +")' >Trang sau</a>";
                //theme+= "[<a href='javascript:"+sGotoPageFunction+"("+ TotalPages_ +")' style='color:black'>Trang cuối</a>]";
                theme+= "</div></div>";	
                if (TotalPages_>1) {
	                document.getElementById(ElementID_).style.display='block';
	                document.getElementById(ElementID_).innerHTML=theme;
	                }
            }
        </script>
    </form>
</body>
</html>
