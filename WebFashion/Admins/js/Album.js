function AddNewAlbum()
{
    if($("#txtName").val()=="")
    {
        alert("Bạn phải nhập tên Album!");
        $("#txtName").focus()
        return false;
    }
  
}
 var ajxAlbum= {
		listAlbum:function(spage){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listAlbum",pg:spage,name:$("#txtName").val()},
				function(data){
				if(data!="")
				{
			        $('#ListTD').html(data);
			        var tps = (parseInt($("#hTotalRows").val())/parseInt($("#hdfRecordCount").val()) - parseInt(parseInt($("#hTotalRows").val())/parseInt($("#hdfRecordCount").val())))>0?((parseInt(parseInt($("#hTotalRows").val())/parseInt($("#hdfRecordCount").val())))+1):parseInt(parseInt($("#hTotalRows").val())/parseInt($("#hdfRecordCount").val()));
			        if(tps<$("#hCurrentPage").val())
				        $("#hCurrentPage").val()=1;
				    if(tps==1)  $("#dvPaging").hide();
			        mjDrawLbPageNew(tps, $("#hCurrentPage").val(), "dvPaging","gotoPage");
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
				    alert("Bạn phải chọn Album!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusAlbum",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxAlbum.listAlbum(1);
			});
		},
		Delete:function(idtd){
		        if (!confirm('Bạn có chắc chắn muốn xóa Album này không?'))
                    return false;
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteAlbum",id:idtd},
				function(){
				ajxAlbum.listAlbum(1);
			});
		},
		DeleteImage:function(idtr,image){
		$.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteImgAlbum",img:image},
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

function InitListAlbum()
{
	ajxAlbum.listAlbum(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxAlbum.listAlbum(numberpage);
}