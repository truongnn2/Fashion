function AddNewSupportOnline()
{
    if($("#txtName").val()=="")
    {
        alert("Bạn phải nhập tên!");
        $("#txtName").focus();
        return false;
    }
    if($("#txtNickName").val()=="")
    {
        alert("Bạn phải nhập NickName!");
        $("#txtNickName").focus();
        return false;
    }
    if($("#sltStatus").val()=="")
    {
        alert("Bạn phải chọn trạng thái!");
        $("#sltStatus").focus();
        return false;
    }
}
 var ajxSupportOnline= {
		listPD:function(spage){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listSupportOnline",pg:spage},
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
				else
				{
				    $('#ListTD').html("Chưa có dữ liệu!");
				    $("#dvPaging").hide();
				}
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
				    alert("Bạn phải chọn người hỗ trợ!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusSupportOnline",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxSupportOnline.listPD(1);
			});
		},
		DeleteSupportOnline:function(idtd){
		         if (!confirm('Bạn có chắc chắn muốn xóa người hỗ trợ này không?'))
                    return false;
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"DeleteSupportOnline",id:idtd},
				function(){
				ajxSupportOnline.listPD(1);
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

function InitListSupportOnline()
{
	ajxSupportOnline.listPD(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxSupportOnline.listPD(numberpage);
}