<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="uc1" TagName="UcRight" Src="Uc/Right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcLeft" Src="~/Uc/Left.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcBottom" Src="~/Uc/Bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UcHeader" Src="~/Uc/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucSolution" Src="~/Uc/ucSolution.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ImageContent" Src="~/Uc/ImageContent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCheckLogin" Src="~/Uc/ucCheckLogin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Project" Src="~/Uc/Project.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Services" Src="~/Uc/Services.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Search" Src="~/Uc/Search.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <meta content="thoitrangxuatkhau.net.vn" name="author" />
    <meta name="description" content="Thời trang xuất khẩu: chuyên bán buôn thời trang xuất khẩu (vnxk) cao cấp, cho chất lượng giá tốt với bán lẻ buôn thời trang xuất khẩu, Thời trang nữ thu đông 2013 sành điệu & giá rẻ chỉ có tại thoitranxuatkhau.net.vn. Cùng mua chung theo nhóm những mẫu quần áo nữ, phụ kiện nữ trẻ trung & nổi bật, Chuyên cung cấp thời trang nam, áo khoác, áo thun, sơ mi nam hàn quốc, đa phong cách cực đẹp, độc cho giới trẻ." />
    <meta name="keywords" content="Bán buôn thời trang xuất khẩu vnxk, thời trang xuất khẩu, thời trang vnxk, bán lẻ bán buôn thời trang vnxk zara, MNG, H&M, thời trang nữ, thời trang, hotdeal, hotdeals, hot deal, mua hàng theo nhóm,mua chung, nhóm mua, cùng mua, deal, deals, giá tốt, giá rẻ, giảm giá, khuyến mại, ưu đãi, Group Buy, daily deals, Áo khoác nam, áo thun nam, sơ mi nam, sơ mi hàn quốc, quần jean, quần kaki. " />
    <meta content="index,follow" name="robots" />
    <title><%=Titlepage%></title>
    <link type="image/x-icon" id="favicon" runat="server" rel="shortcut icon">
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <meta content="pgZdXuU7BiuTZ+A9Gq2ZgjW6Y2DHNy7Kw48HtQWPbrI=" name="verify-v1" />
    <link rel="stylesheet" id="StyleTag00" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag01" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag1" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag2" runat="server" type="text/css" />
    <link rel="stylesheet" id="StyleTag3" runat="server" type="text/css" />


    <script type="text/javascript" src="<%=pathClient %>/js/InitPath.js"></script>
    <script type="text/javascript" src="<%=pathClient %>/js/RCP/jquery.min.js.download.js"></script>
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

<!--
    <div class="ws_bullets"><div>
	     
                    <a href="#" title=""></a>
             
                    <a href="#" title=""></a>
             
                    <a href="#" title="LAMI GROUP">LAMI GROUP</a>
             
                    <a href="#" title="Lĩnh vực kinh doanh">Lĩnh vực kinh doanh</a>
             
                    <a href="#" title="Phương châm">Phương châm</a>
             
                    <a href="#" title=""></a>
            
    </div></div>
    <div class="ws_shadow"></div>-->

        </div>

            <script type="text/javascript" src="<%=pathClient %>/js/RCP/wowslider.js"></script>
            <script type="text/javascript" src="<%=pathClient %>/js/RCP/script.js"></script>
            <!-- End WOWSlider.com BODY section -->
        </div>

        <script type="text/javascript" src="<%=pathClient %>/js/RCP/owl.carousel.js.download.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#owl-demo-sanphamtieubieu").owlCarousel({
                    items: 3,
                    lazyLoad: true,
                    autoPlay: true,
                    navigation: true,
                    navigationText: true,
                    pagination: false,
                });
            });
        </script>
        <div class="animation-element bounce-up cf" data-wow-delay="0.8s">
            <div class="subject">
                <div class="sanphamtieubieu" id="sanphamtieubieu">
                    <div class="sanphamtieubieu_fix">
                        <div class="sanphamtieubieu_head">
                            <a href="http://vaithun.com/san-pham/">
                                <h3>Sản phẩm <em>Tiêu biểu</em></h3>
                            </a>
                        </div>
                        <div class="clear"></div>
                        <div id="owl-demo-sanphamtieubieu" class="owlCarousel text-center">
                            <div class="csanphamtieubieuitem">
                                <div class="csanphamtieubieuitem_img">
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <img alt="Vải thun cotton 100% 2c, 4c" src="<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg">
                                    </a>
                                </div>
                                <div class="csanphamtieubieu_info">
                                    <a class="title" href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <h3>Vải thun cotton 100% 2c, 4c</h3>
                                    </a>
                                    <a class="addcart" href="http://vaithun.com/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                </div>
                            </div>
                            <div class="csanphamtieubieuitem">
                                <div class="csanphamtieubieuitem_img">
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <img alt="Vải thun cotton 100% 2c, 4c" src="<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg">
                                    </a>
                                </div>
                                <div class="csanphamtieubieu_info">
                                    <a class="title" href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <h3>Vải thun cotton 100% 2c, 4c</h3>
                                    </a>
                                    <a class="addcart" href="http://vaithun.com/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                </div>
                            </div>
                            <div class="csanphamtieubieuitem">
                                <div class="csanphamtieubieuitem_img">
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <img alt="Vải thun cotton 100% 2c, 4c" src="<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg">
                                    </a>
                                </div>
                                <div class="csanphamtieubieu_info">
                                    <a class="title" href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <h3>Vải thun cotton 100% 2c, 4c</h3>
                                    </a>
                                    <a class="addcart" href="http://vaithun.com/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                </div>
                            </div>
                           <div class="csanphamtieubieuitem">
                                <div class="csanphamtieubieuitem_img">
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <img alt="Vải thun cotton 100% 2c, 4c" src="<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg">
                                    </a>
                                </div>
                                <div class="csanphamtieubieu_info">
                                    <a class="title" href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <h3>Vải thun cotton 100% 2c, 4c</h3>
                                    </a>
                                    <a class="addcart" href="http://vaithun.com/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                </div>
                            </div>
                            <div class="csanphamtieubieuitem">
                                <div class="csanphamtieubieuitem_img">
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <img alt="Vải thun cotton 100% 2c, 4c" src="<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg">
                                    </a>
                                </div>
                                <div class="csanphamtieubieu_info">
                                    <a class="title" href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <h3>Vải thun cotton 100% 2c, 4c</h3>
                                    </a>
                                    <a class="addcart" href="http://vaithun.com/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                </div>
                            </div>
                            <div class="csanphamtieubieuitem">
                                <div class="csanphamtieubieuitem_img">
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <img alt="Vải thun cotton 100% 2c, 4c" src="<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg">
                                    </a>
                                </div>
                                <div class="csanphamtieubieu_info">
                                    <a class="title" href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <h3>Vải thun cotton 100% 2c, 4c</h3>
                                    </a>
                                    <a class="addcart" href="http://vaithun.com/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                </div>
                            </div>
                            <div class="csanphamtieubieuitem">
                                <div class="csanphamtieubieuitem_img">
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <img alt="Vải thun cotton 100% 2c, 4c" src="<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg">
                                    </a>
                                </div>
                                <div class="csanphamtieubieu_info">
                                    <a class="title" href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <h3>Vải thun cotton 100% 2c, 4c</h3>
                                    </a>
                                    <a class="addcart" href="http://vaithun.com/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                </div>
                            </div>
                           <div class="csanphamtieubieuitem">
                                <div class="csanphamtieubieuitem_img">
                                    <a href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <img alt="Vải thun cotton 100% 2c, 4c" src="<%=pathClient %>/images/cotton_4_chieu_100_phan_tram_2375020181278_b_.jpg">
                                    </a>
                                </div>
                                <div class="csanphamtieubieu_info">
                                    <a class="title" href="http://vaithun.com/vai-thun-cotton-100-phan-tram-2c-4c-1.html">
                                        <h3>Vải thun cotton 100% 2c, 4c</h3>
                                    </a>
                                    <a class="addcart" href="http://vaithun.com/dat-hang/vai-thun-cotton-100-phan-tram-2c-4c-1"><span></span>Mua hàng</a>
                                </div>
                            </div>
                        </div>
                        <div class="clear"></div>
                        <div class="loaisanpham">
                            <ul>

                                <li>
                                    <a href="http://vaithun.com/san-pham-vai-thun-1/">Sản phẩm vải thun
                                    </a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/thanh-ly-hang-ton-kho-2/">Thanh lý hàng tồn kho
                                    </a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/soi-cac-loai-3/">Sợi các loại
                                    </a>
                                </li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="animation-element bounce-up cf" data-wow-delay="0.8s">
            <div class="subject">
                <div class="raovat" id="raovat">
                    <div class="raovat_fix">
                        <div class="raovat_head">
                            <h3>Rao vặt <em>dệt may</em></h3>
                        </div>
                        <div class="raovat_col1">
                            <div class="raovat_col_head">
                                <h3>Tin đăng mới nhất</h3>
                            </div>
                            <ul>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/chuyen-cung-cap-soi-cotton-cac-loai-14.html">Chuyên cung cấp sợi cotton các loại</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/top-nhung-mau-dong-ho-nam-chat-nhat-neu-ban-la-mot-tinh-do-cua-thoi-trang-va-dang-muon-kiem-mot-phu-kien-gi-moi-me-co-the-noi-len-duoc-ca-tinh-cung-13.html">Top những mẫu đồng hồ nam chất &amp; nhất Nếu bạn là một tính đồ của thời trang và đang muốn kiếm một phụ kiện gì mới mẻ có thể nói lên được cá tính cũng </a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/can-ban-may-kiem-loi-vai-hieu-jf-12.html">Cần bán máy kiểm lổi vải hiệu JF</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/nhanh-tay-so-huu-ngay-chiec-ao-thoi-trang-hang-hieu-tu-arisle-11.html">Nhanh tay sở hữu ngay chiếc áo thời trang hàng hiệu từ Arisle</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/may-dong-phuc-sk-uniform-8.html">May đồng phục SK Uniform</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/cau-nang-o-to-1-tru-gia-re-mua-o-dau--15.html">Cầu nâng ô tô 1 trụ giá rẻ mua ở đâu?</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/may-dong-phuc-hoc-sinh-sinh-vien-gia-re-6.html">May đồng phục học sinh sinh viên giá rẻ</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/trum-vai-thun-the-thao-sai-gon-3.html">Trùm vải thun thể thao Sài Gòn</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/cung-cap-cac-mat-hang-vai-thun-cao-cap-7.html">Cung cấp các mặt hàng vải thun cao cấp</a>
                                </li>

                            </ul>
                            <a class="viewmore" href="http://vaithun.com/rao-vat/">Xem tất cả</a>
                        </div>
                        <div class="raovat_col2">
                            <div class="raovat_col_head">
                                <h3>Chuyên mục rao vặt</h3>
                            </div>
                            <ul>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/vai-cac-loai-1/">Vải các loại</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/soi-cac-loai-2/">Sợi các loại</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/nguyen-phu-lieu-3/">Nguyên phụ liệu</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/cat-may-in-an-4/">Cắt, may, in ấn</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/dong-phuc-5/">Đồng phục</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/det-nhuom-hoan-tat-vai-6/">Dệt, nhuộm, hoàn tất vải</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/thoi-trang-nam-7/">Thời trang nam</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/thoi-trang-nu-8/">Thời trang nữ</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/quan-ao-tre-em-9/">Quần áo trẻ em</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/khac-10/">Khác</a>
                                </li>

                            </ul>
                            <a class="viewmore" href="http://vaithun.com/rao-vat/">Xem tất cả</a>
                        </div>
                        <div class="raovat_col3">
                            <div class="raovat_col_head">
                                <h3>Theo khu vực</h3>
                            </div>
                            <ul>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/tp-ho-chi-minh-1">TP Hồ Chí Minh</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/ha-noi-2">Hà Nội</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/da-nang-3">Đà Nẵng</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/binh-duong-4">Bình Dương</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/dong-nai-5">Đồng Nai</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/quang-nam-6">Quảng Nam</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/can-tho-7">Cần Thơ</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/tien-giang-8">Tiền Giang</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/binh-phuoc-9">Bình Phước</a>
                                </li>

                                <li>
                                    <a href="http://vaithun.com/rao-vat/tinh-thanh/dak-lak-10">Dak Lak</a>
                                </li>

                            </ul>
                            <a class="viewmore" href="http://vaithun.com/rao-vat/">Xem tất cả</a>
                        </div>
                        <div class="raovat_col4">
                            <div class="raovat_bar">Bấm để đăng tin miễn phí của bạn!</div>
                            <a class="dangtinraovat" href="http://vaithun.com/dang-tin/">Đăng tin miễn phí</a>
                            <div class="raovat_content">
                                Lưu ý:
                       
                                <ul>
                                    <li>- Nội dung tin đăng dành cho ngành dệt may</li>
                                    <li>- Nội dung sẽ được kiểm duyệt trước khi được đăng lên website</li>
                                    <li>- Chúng tôi không chịu trách nhiệm về các nội dung của tin đăng</li>
                                    <li>- Tin đăng sẽ tự xóa sau 30 ngày</li>
                                    <li>- Mỗi tin đăng chỉ cho phép kèm 1 hình ảnh, dung lượng ảnh &lt; 150KB</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <script type="text/javascript">
            $(document).ready(function () {
                $("#owl-demo-tintuc").owlCarousel({
                    items: 3,
                    lazyLoad: true,
                    autoPlay: true,
                    navigation: false,
                    navigationText: true,
                    pagination: false,
                });
            });
    </script>
        <div class="animation-element bounce-up cf" data-wow-delay="0.8s">
            <div class="subject">
                <div class="tintuc" id="tintuc">
                    <div class="tintuc_fix">
                        <div class="tintuc_head">
                            <h3>Tin tức - <em>Báo chí</em></h3>
                        </div>
                        <div class="clear"></div>
                        <div id="owl-demo-tintuc" class="owlCarousel text-center">

                           <div class="ctintucitem2">
                                <div class="ctintucitem2_img">
                                    <a href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">
                                        <img alt="Cấu tạo các loại sợi vải" src="<%=pathClient %>/images/multicolored_fabrics_2473120181429_s_.jpg">
                                    </a>
                                </div>
                                <div class="datenews">24/01/2018</div>
                                <div class="ctintucitem_info">
                                    <a class="title" href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">
                                        <h3>Cấu tạo các loại sợi vải</h3>
                                    </a>
                                    <p>Vải sợi là những cấu trúc dạng phẳng, được tạo thành từ các loại tơ sợi được đan lại với nhau theo 1 cách nào đó. Những sợi này có dạng...</p>
                                    <a class="detail" href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">Xem chi tiết
                                    </a>
                                </div>
                            </div>
                            <div class="ctintucitem2">
                                <div class="ctintucitem2_img">
                                    <a href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">
                                        <img alt="Cấu tạo các loại sợi vải" src="<%=pathClient %>/images/multicolored_fabrics_2473120181429_s_.jpg">
                                    </a>
                                </div>
                                <div class="datenews">24/01/2018</div>
                                <div class="ctintucitem_info">
                                    <a class="title" href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">
                                        <h3>Cấu tạo các loại sợi vải</h3>
                                    </a>
                                    <p>Vải sợi là những cấu trúc dạng phẳng, được tạo thành từ các loại tơ sợi được đan lại với nhau theo 1 cách nào đó. Những sợi này có dạng...</p>
                                    <a class="detail" href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">Xem chi tiết
                                    </a>
                                </div>
                            </div>
                            <div class="ctintucitem2">
                                <div class="ctintucitem2_img">
                                    <a href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">
                                        <img alt="Cấu tạo các loại sợi vải" src="<%=pathClient %>/images/multicolored_fabrics_2473120181429_s_.jpg">
                                    </a>
                                </div>
                                <div class="datenews">24/01/2018</div>
                                <div class="ctintucitem_info">
                                    <a class="title" href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">
                                        <h3>Cấu tạo các loại sợi vải</h3>
                                    </a>
                                    <p>Vải sợi là những cấu trúc dạng phẳng, được tạo thành từ các loại tơ sợi được đan lại với nhau theo 1 cách nào đó. Những sợi này có dạng...</p>
                                    <a class="detail" href="http://vaithun.com/tin-tuc/cau-tao-cac-loai-soi-vai-27.html">Xem chi tiết
                                    </a>
                                </div>
                            </div>




                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="animation-element bounce-up cf" data-wow-delay="0.8s">
            <div class="subject">
                <div class="tintuc bgwhite" id="tintuc">
                    <div class="tintuc_fix">
                        <div class="tintuc_head main_bar_sp">
                            <h3>Đội ngũ <em>nhân sự</em></h3>
                        </div>
                        <div class="tintuc_content">
                            <p>Với Phương châm: Uy Tín, Chất Lượng, Giá Cả Cạnh Tranh chúng tôi phấn đấu để trở thành doanh nghiệp sản xuất vải thun cao cấp.</p>

                            <p>Đội ngũ nhân viên của chúng tôi nhiều năm kinh nghiệm trong lĩnh vực dệt kim sẽ tư vấn cho quý khách những giải pháp tốt nhất.</p>
                            <a class="viewmore" href="http://vaithun.com/gioi-thieu/">Về chúng tôi</a>
                        </div>
                        <div class="clear"></div>
                        <ul class="photoitem2">
                        </ul>
                    </div>
                </div>
            </div>
        </div>



        <script type="text/javascript" src="<%=pathClient %>/js/RCP/owl.carousel.partner.js.download.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#owl-demo2").owlCarousel2({
                    items: 6,
                    lazyLoad: true,
                    autoPlay: true,
                    navigation: true,
                    navigationText: true,
                    pagination: false,
                });
            });
</script>
        <!-- //requried-jsfiles-for owl -->
        <!-- start content_slider -->
        <div class="doitac" id="doitac">
            <div class="doitac_fix">
                <div class="clear"></div>
                <div id="owl-demo2" class="owl-carousel2 text-center">
                    <div class="doitac_imgs">
                        <a title="" href="http://aothun.vn/" target="_blank">
                            <img class="draw" alt="" src="<%=pathClient %>/images/aothun_vn.jpg">
                        </a>
                    </div>
                    <div class="doitac_imgs">
                                    <a title="Lime Orange" href="http://vaithun.com/" target="_blank">
                                        <img class="draw" alt="Lime Orange" src="<%=pathClient %>/images/lime.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="TNG" href="http://vaithun.com/" target="_blank">
                                        <img class="draw" alt="TNG" src="<%=pathClient %>/images/tng.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://canifa.com/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/canifa_com.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://hantex.com.vn/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/hantex_com_vn.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://haprosimexjsc.com/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/haprosimexjsc_com.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://jme.com.vn/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/jme_com_vn.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://nhabe.com.vn/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/nha_be_com_vn.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://pdg.com.vn/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/pdg_com_vn.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://seahorseunderwear.com/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/seahorseunderwear_com.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://sonkim.com.vn/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/son_kim_com_vn.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://thethaophima.com/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/the_thao_phi_ma_com.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://vietthy.com/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/viet_thy_com.jpg">
                                    </a>
                                </div>
                    <div class="doitac_imgs">
                                    <a title="" href="http://yfk.com.vn/" target="_blank">
                                        <img class="draw" alt="" src="<%=pathClient %>/images/yfk_com_vn.jpg">
                                    </a>
                                </div>
                    


                    
                </div>
            </div>
        </div>
        <!--//sreen-gallery-cursual---->

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
    </form>
</body>
</html>
