<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Admin_Header" %>
<%@ Register TagPrefix="uc1" TagName="UcCheckLogin" Src="~/Admins/CheckLogin.ascx" %>
<script type="text/javascript" src="<%=pathAdmin%>/js/Logout.js"></script>
<script type="text/javascript" src="<%=pathAdmin%>/js/InitAdmin.js"></script>
<link media="screen" rel="stylesheet" type="text/css" href="<%=pathAdmin%>/css/admin.css"  />
<link media="screen" rel="stylesheet" type="text/css" href="<%=pathAdmin%>/css/admin-white.css"  />

<div id="header_main_menu">
		<span id="header_main_menu_bg"></span>
		<div id="header">
			<div class="inner">
				<h1 id="logo"><a href="#">websitename <span>Administration Panel</span></a></h1>
				<div id="user_details">
					<ul id="user_details_menu">
						<li class="welcome">Welcome <strong>Administrator</strong></li>
						<li>
							<ul id="user_access">
								<li class="last"><a href="javascript:ajxLogout.Logout();">Log out</a></li>
							</ul>
						</li>
					</ul>
				</div>
			</div>
		</div>
		<div id="main_menu">
			<div class="inner">
			<ul>
				<li>
					<a id="m1" href="<%=pathAdmin%>/Products/ListProducts.aspx"  ><span class="l"><span></span></span><span class="m"><em>Quản lý hệ thống</em><span></span></span><span class="r"><span></span></span></a>
					<ul id="ul1"  style="display:none;">
						<li><a id="s3" href="<%=pathAdmin%>/Products/ListProducts.aspx"><span class="l"><span></span></span><span class="m"><em>Sản phẩm</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="s2" href="<%=pathAdmin%>/Menu/ListCategory.aspx"><span class="l"><span></span></span><span class="m"><em>Danh mục sản phẩm</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="s1" href="<%=pathAdmin%>/MenuSub/ListCategorySub.aspx?cat=0"><span class="l"><span></span></span><span class="m"><em>Danh mục sản phẩm chi tiết</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="s6" href="<%=pathAdmin %>/AboutUs/AboutUs.aspx?id=1"><span class="l"><span></span></span><span class="m"><em>Giới thiệu</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="s7" href="<%=pathAdmin %>/AboutUs/AboutUs.aspx?id=2"><span class="l"><span></span></span><span class="m"><em>Dịch vụ</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="s9" href="<%=pathAdmin %>/ContactUs/ContactUs.aspx"><span class="l"><span></span></span><span class="m"><em>KH Góp ý - Liên hệ</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="s8" href="<%=pathAdmin%>/Album/Addnew.aspx"><span class="l"><span></span></span><span class="m"><em>Hinh Banner giữa</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="s5" href="<%=pathAdmin%>/SupportOnline/ListSupportOnline.aspx"><span class="l"><span></span></span><span class="m"><em>Hỗ trợ trực tuyến</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="s4" href="<%=pathAdmin%>/BoxAd/ListBoxAd.aspx"><span class="l"><span></span></span><span class="m"><em>Quảng Cáo</em><span></span></span><span class="r"><span></span></span></a></li>
						
					</ul>
				</li>
				<li style="display:none;">
					<a id="m3" href="<%=pathAdmin%>/Customer/ListCustomer.aspx?cat=0"><span class="l"><span></span></span><span class="m"><em>Khách hàng - Đối tác</em><span></span></span><span class="r"><span></span></span></a>
					<ul id="ul2" style="display:none;">
						<li><a id="n1" href="<%=pathAdmin%>/Customer/ListCustomer.aspx?cat=0"><span class="l"><span></span></span><span class="m"><em>Khách hàng</em><span></span></span><span class="r"><span></span></span></a></li>
						<li><a id="n2" href="<%=pathAdmin%>/Customer/ListCustomer.aspx?cat=1"><span class="l"><span></span></span><span class="m"><em>Đối tác</em><span></span></span><span class="r"><span></span></span></a></li>
					</ul>
				</li>
				<li>
					<a id="m2" href="<%=pathAdmin%>/DoiPass/DoiPass.aspx"><span class="l"><span></span></span><span class="m"><em>Đổi Mật khẩu đăng nhập</em><span></span></span><span class="r"><span></span></span></a>
				</li>
			</ul>
			</div>
			<span class="sub_bg"></span>
		</div>
		</div>

<uc1:UcCheckLogin ID="UcCheckLogin1" runat="server" />  

 <script>
    sUrl='<%=Request.Url.ToString()%>';
	if(sUrl.toLowerCase().indexOf('doipass')!=-1)
	    document.getElementById('m2').className='selected_lk';
	else if(sUrl.toLowerCase().indexOf('customer')!=-1)
	{
	    document.getElementById('m3').className='selected_lk';
	    document.getElementById('ul2').style.display="";
	    if(sUrl.toLowerCase().indexOf('listcustomer.aspx?cat=0')!=-1)
	        document.getElementById('n1').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('listcustomer.aspx?cat=1')!=-1)
	        document.getElementById('n2').className='selected_lk';
	}   
	else
	{	
	    document.getElementById('ul1').style.display="";
		document.getElementById('m1').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('menusub/listcategorysub.aspx')!=-1||sUrl.toLowerCase().indexOf('menusub/addnew.aspx')!=-1)
	        document.getElementById('s1').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('aboutus.aspx?id=1')!=-1||sUrl.toLowerCase().indexOf('aboutus/edit.aspx?id=1')!=-1)
	        document.getElementById('s6').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('menu/listcategory.aspx')!=-1||sUrl.toLowerCase().indexOf('menu/addnew.aspx')!=-1)
	        document.getElementById('s2').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('products/listproducts.aspx')!=-1||sUrl.toLowerCase().indexOf('products/addnew.aspx')!=-1)
	        document.getElementById('s3').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('aboutus.aspx?id=2')!=-1||sUrl.toLowerCase().indexOf('aboutus/edit.aspx?id=2')!=-1)
	        document.getElementById('s7').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('boxad')!=-1)
	        document.getElementById('s4').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('contactus')!=-1)
	        document.getElementById('s9').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('album')!=-1)
	        document.getElementById('s8').className='selected_lk';
	    if(sUrl.toLowerCase().indexOf('listsupportonline')!=-1||sUrl.toLowerCase().indexOf('supportonline/addnew')!=-1)
	        document.getElementById('s5').className='selected_lk';
	}	
	
</script>