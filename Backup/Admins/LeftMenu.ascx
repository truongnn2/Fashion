<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="Admins_LeftMenu" %>
<ul class="sideNav">
	<li><a id="t10" href="<%=pathAdmin %>/Menu/ListMenu.aspx" >Loại sản phẩm</a></li>
    <li><a id="t11" href="<%=pathAdmin %>/MenuSub/ListMenuSub.aspx" >Loại sản phẩm chi tiết</a></li>
    <li><a id="t12" href="<%=pathAdmin %>/Products/ListProducts.aspx">Sản phẩm</a></li>
    <li><a id="t2" href="<%=pathAdmin %>/News/ListNews.aspx">Ý nghĩa quà tặng</a></li>
    <li><a id="t14" href="<%=pathAdmin %>/LinkWebsite/ListLinkWebsite.aspx">Liên kết website</a></li>
    <li><a id="t1" href="<%=pathAdmin %>/Album/AddNew.aspx">Hình trang chủ</a></li>
    <li><a id="t3" href="<%=pathAdmin %>/Huongdan/Huongdan.aspx">Hướng dẫn</a></li>
    <li><a id="t4" href="<%=pathAdmin %>/BoxAd/ListBoxAd.aspx">Hình quảng cáo</a></li>
    <li><a id="t8" href="<%=pathAdmin %>/AboutUs/AboutUs.aspx?id=1">Giới thiệu</a></li>
    <li><a id="t13" href="<%=pathAdmin %>/AboutUs/AboutUs.aspx?id=2">Liên hệ</a></li>
    <li><a id="t9" href="<%=pathAdmin %>/ContactUs/ContactUs.aspx">KH liên hệ - Góp ý</a></li>

</ul>
 <script>
    sUrl='<%=Request.Url.ToString()%>';

	if(sUrl.indexOf('News')!=-1)
	    document.getElementById('t2').className='active';
	else if(sUrl.indexOf('Album/AddNew.aspx')!=-1)
	    document.getElementById('t1').className='active';
	else if(sUrl.indexOf('AboutUs/AboutUs.aspx?id=1')!=-1||sUrl.indexOf('AboutUs/Edit.aspx?id=1')!=-1)
	    document.getElementById('t8').className='active';
	else if(sUrl.indexOf('AboutUs/AboutUs.aspx?id=2')!=-1||sUrl.indexOf('AboutUs/Edit.aspx?id=2')!=-1)
	    document.getElementById('t13').className='active';
	else if(sUrl.indexOf('Huongdan')!=-1||sUrl.indexOf('Huongdan/Edit.aspx')!=-1)
	    document.getElementById('t3').className='active';
	else if(sUrl.indexOf('BoxAd')!=-1)
	    document.getElementById('t4').className='active';
	else if(sUrl.indexOf('ContactUs')!=-1)
	    document.getElementById('t9').className='active';
    else if(sUrl.indexOf('ListMenu.aspx')!=-1||sUrl.indexOf('Menu/AddNew.aspx')!=-1)
	    document.getElementById('t10').className='active';
	else if(sUrl.indexOf('ListMenuSub.aspx')!=-1||sUrl.indexOf('MenuSub/AddNew.aspx')!=-1)
	    document.getElementById('t11').className='active';
    else if(sUrl.indexOf('ListProducts.aspx')!=-1||sUrl.indexOf('Products/AddNew.aspx')!=-1)
	    document.getElementById('t12').className='active';
	else if(sUrl.indexOf('ListLinkWebsite')!=-1||sUrl.indexOf('LinkWebsite/AddNew.aspx')!=-1)
	    document.getElementById('t14').className='active';
</script>