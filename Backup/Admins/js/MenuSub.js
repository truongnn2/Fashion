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
 function AddNewMenuSub()
 {
    if($("#txtName").val()=="")
    {
        alert("Bạn phải nhập tên loại sản phẩm chi tiết!");
        $("#txtName").focus()
        return false;
    }
    if($("#sltCategory").val()=="")
    {
        alert("Bạn phải chọn loại!");
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
 var ajxMenuSub= {
		listDV:function(spage){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listMenuSub",pg:spage,category:$("#sltCategory").val()},
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
				    alert("Bạn phải chọn Loại chi sản phẩm tiết!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusMenuSub",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxMenuSub.listDV(1);
			});
		},
		DeleteCatSub:function(idtd){
		         if (!confirm('Bạn có chắc chắn muốn xóa loại danh mục này không?'))
                    return false;
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"DeleteCatSub",id:idtd},
				function(){
				ajxMenuSub.listDV(1);
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

function InitListMenuSub()
{
	ajxMenuSub.listDV(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxMenuSub.listDV(numberpage);
}



