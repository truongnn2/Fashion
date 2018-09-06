
 var ajxFileDownload= {
		listFileDownload:function(spage){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listFileDownload",pg:spage},
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
				    alert("Bạn phải chọn tài liệu!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusFileDownload",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxFileDownload.listFileDownload(1);
			});
		},
		Delete:function(idtd){
		        if (!confirm('Bạn có chắc chắn muốn xóa tài liệu này không?'))
                    return false;
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteFileDownload",id:idtd},
				function(){
				ajxFileDownload.listFileDownload(1);
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

function InitlistFileDownload()
{
	ajxFileDownload.listFileDownload(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxFileDownload.listFileDownload(numberpage);
}
function removeSelectbox(objID,initText){
	if(initText && initText.indexOf('*') != -1)
		initText = initText.replace('***','Select');
	var obj_select = document.getElementById(objID);
	obj_select.disabled = true;
	for(var k = obj_select.options.length-1; k >=0 ; k--){
		obj_select.options[k] = null;
	}
	if (initText != undefined || initText != null) {
		if(initText!='')obj_select.options[0] = new Option(initText,"");
	}
}