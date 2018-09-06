function onchange_(i)
 {
	if (i=='1') 
	{
		document.forms[0].select_status_2.value = document.forms[0].select_status_1.value;	
	}
	if (i=='2') 
	{
		document.forms[0].select_status_1.value = document.forms[0].select_status_2.value;	
	}
 }
 function AddNewCatSubServices()
 {
    if($("#txtName").val()=="")
    {
        alert("Bạn phải nhập loại dịch vụ cấp 2!");
        $("#txtName").focus()
        return false;
    }
    if($("#sltCategory").val()=="")
    {
        alert("Bạn phải chọn loại dịch vụ cấp 1!");
        $("#sltCategory").focus()
        return false;
    }
    if($("#sltStatus").val()=="")
    {
        alert("Bạn phải chọn trạng thái!");
        $("#sltStatus").focus()
        return false;
    }
 }
 var ajxCatSubServices= {
		listDV:function(spage){
		$.post(PathAdmin + "/Handler/Admin.aspx", { act: "listCatSubServices", pg: spage, category: $("#sltCategory").val() },
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
				    alert("Bạn phải chọn loại dịch vụ cấp 2!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
                $.post(PathAdmin + "/Handler/Admin.aspx", { act: "ChStatusCatSubServices", status: $("#sltStatus").val(), id: chked },
				function(){
				ajxCatSubServices.listDV(1);
			});
		},
		DeleteCatSubServices: function(idtd) {
		         if (!confirm('Bạn có chắc chắn muốn xóa loại danh mục này không?'))
                    return false;
                $.post(PathAdmin + "/Handler/Admin.aspx", { act: "DeleteCatSubServices", id: idtd },
				function(){
				ajxCatSubServices.listDV(1);
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

function InitListCatSubServices()
{
	ajxCatSubServices.listDV(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxCatSubServices.listDV(numberpage);
}



