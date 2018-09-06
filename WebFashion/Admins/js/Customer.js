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
 function AddNewCustomer()
 {
    if($("#txtName").val()=="")
    {
        alert("Bạn phải nhập tên!");
        $("#txtName").focus()
        return false;
    }
    if($("#sltStatus").val()=="")
    {
        alert("Bạn phải chọn trạng thái!");
        $("#sltStatus").focus()
        return false;
    }
 }
 var ajxCustomer= {
		listDV:function(spage){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listCustomer",pg:spage,cat:$("#hdType").val()},
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
				    if($("#hdType").val()=="0")
				        alert("Bạn phải chọn Khách hàng!");
				    else if($("#hdType").val()=="1")
				        alert("Bạn phải chọn Đối tác!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusCustomer",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxCustomer.listDV(1);
			});
		},
		Delete:function(idtd){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteCustomer",id:idtd},
				function(){
				ajxCustomer.listDV(1);
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

function InitListCustomer()
{
	ajxCustomer.listDV(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxCustomer.listDV(numberpage);
}



