<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageContent.ascx.cs" Inherits="ImageContent" %>
<script src="<%=pathClient %>/js/jquery.imagecube.js" type="text/javascript"></script>
<div class="bn250" runat="server" style="display:none;" id="ImageBanner">
	<div class="container" id="defaultCube">
     <%=listImage%>
	</div>
    <script type="text/javascript">
      $('#defaultCube').imagecube();
       $.imagecube.setDefaults({speed: 1000, pause: 5000});
        </script>
</div>