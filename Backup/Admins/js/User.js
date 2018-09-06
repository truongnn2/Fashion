function AddNewUser()
{
    if($("#txtName").val()=="")
    {
        alert("Bạn phải nhập tên!");
        $("#txtName").focus()
        return false;
    }

    if($("#txtUsername").val()=="")
    {
        alert("Bạn phải nhập Username!");
        $("#txtUsername").focus()
        return false;
    }
    if($("#txtPassword").val()=="")
    {
        alert("Bạn phải nhập Password!");
        $("#txtPassword").focus()
        return false;
    }
    if($("#sltStatus").val()=="")
    {
        alert("Bạn phải chọn trạng thái!");
        $("#sltStatus").focus()
        return false;
    }
}
 var ajxUser= {
		listPD:function(spage){  
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listUser",pg:spage,name:$("#txtName").val()},
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
				    alert("Bạn phải chọn Người dùng!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusUser",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxUser.listPD(1);
			});
		},
		Delete:function(idtd){
		        if (!confirm('Bạn có chắc chắn muốn xóa người dùng này không?'))
                    return false;
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteUser",id:idtd},
				function(){
				ajxUser.listPD(1);
			});
		},
		ListRole:function(idUser){
		        ajxUser.ChangeRole($("#sltRole").val());
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listRole",idUser:idUser},
				function(data){
				if(data!="")
				{
			        $('#ListTD').html(data);
				}
				else $('#ListTD').html("Chưa có dữ liệu!");
			});
		},
		AddRole:function(idUser){
		    if($("#sltRole").val()=="")
            {
                alert("Bạn phải chọn quyền!");
                $("#sltRole").focus()
                return false;
            }
            if( $("#cat").css("display") == "inline"&& $("#sltCategory").val()=="") 
            {
                alert("Bạn phải chọn loại tin!");
                $("#sltCategory").focus()
                return false;
            }
		    $.post(PathAdmin +"/Handler/Admin.aspx", { act:"addRole",idUser:idUser,role:$("#sltRole").val(),cat:$("#sltCategory").val()},
		    function(data){
		    if(data!="")
		    {
	           ajxUser.ListRole(idUser);
		    }
		    else
		        alert("Quyền này đã tồn tại rồi!");
			});
		},
		DeleteRole:function(idtd,idUser){
            if (!confirm('Bạn có chắc chắn muốn xóa quyền này không?'))
                return false;
		    $.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteRole",id:idtd},
		    function(){
		        ajxUser.ListRole(idUser);
			});
		},
		ChangeStatusRole:function(idUser){
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
				    alert("Bạn phải chọn quyền cần thay đổi trạng thái!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusRole",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxUser.ListRole(idUser);
			});
		},
		ChangeRole:function(v)
		{
		    if(v=="2")
		        $("#cat").attr("style", "display:inline"); 
		    else
		    {
		        $("#cat").attr("style", "display:none"); 
		        document.getElementById("sltCategory").value="";
		    }
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

function InitListUser()
{
	ajxUser.listPD(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxUser.listPD(numberpage);
}