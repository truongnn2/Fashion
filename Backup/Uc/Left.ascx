<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Left.ascx.cs" Inherits="Uc_Left" %>
<div class="ColLeft">
    <div class="mar_b10" id="MainMenu">
	    <h2><%=title %></h2>
        <ul>
		    <%=ml %>
        </ul>
    </div>
    <!--div class="Service_L mar_b10">
	    <a href="dichvu.html"><img src="images/7.jpg" width="210" height="44" /></a>
    </div-->
    <div class="Support_L">
	    <h2><%=Titlesupport %></h2>
	    
        <%=Listsupport%>
    </div>
</div>
