var ajxLogout= {
		Logout:function(){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"logout"},
				function(){
				window.location=PathAdmin+"/Login.aspx";
				});
		}
	}
