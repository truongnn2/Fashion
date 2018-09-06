function AddNewLinkWebsite()
{
    if($("#txtName").val()=="")
    {
        alert("Bạn phải nhập tên website!");
        $("#txtName").focus()
        return false;
    }
    if($("#txtUrl").val()=="")
    {
        alert("Bạn phải nhập đường link!");
        $("#txtUrl").focus()
        return false;
    }
  
}
 var ajxLinkWebsite= {
		listLinkWebsite:function(){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listLinkWebsite"},
				function(data){
				if(data!="")
				{
			        $('#ListTD').html(data);
				}
				else $('#ListTD').html("Chưa có dữ liệu!");
			});
		},
		ChangeStatus:function(){
		        var chked='';
		        if(document.form1.checkbox.length==undefined)
		        {
		            if(document.form1.checkbox.checked)
		                chked=document.form1.checkbox.value;
		        }
		        else
		        {
		            for( var i=0; i<document.form1.checkbox.length; i++ )
				    {
					    if(document.form1.checkbox[i].checked)
					    {
						    chked += document.form1.checkbox[i].value+",";
					    }
				    }
				}
				
				if(chked=='')
				{
				    alert("Bạn phải chọn website!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusLinkWebsite",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxLinkWebsite.listLinkWebsite();
			});
		},
		Delete:function(idtd){
		        if (!confirm('Bạn có chắc chắn muốn xóa website này không?'))
                    return false;
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteLinkWebsite",id:idtd},
				function(){
				ajxLinkWebsite.listLinkWebsite();
			});
		},
		DeleteImage:function(idtr,image,idtd){
		$.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteImgAlbum",id:idtd,img:image},
		function(){
		 $("#"+idtr).hide();
			});
		}
	}
	
function checkall()
{
	if(document.form1.check.checked==true)
	{						
			if(document.form1.checkbox.length==undefined)
			{								
				document.form1.checkbox.checked =true;
				return;	
			}							
			for( var i=0; i<document.form1.checkbox.length; i++ )
			document.form1.checkbox[i].checked =true;
	}
	else
	{								
			if(document.form1.checkbox.length==undefined)
			{
				document.form1.checkbox.checked =false;
				return;	
			}							
			for( var i=0; i<document.form1.checkbox.length; i++ )
			document.form1.checkbox[i].checked =false
	}										
}	

