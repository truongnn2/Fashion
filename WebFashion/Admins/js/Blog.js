function AddNewBlog()
{
    if($("#txtTitle").val()=="")
    {
        alert("Bạn phải nhập tiêu đề!");
        $("#txtTitle").focus()
        return false;
    }
    var oEditor1 = FCKeditorAPI.GetInstance('txtContent') ;
    if(oEditor1.GetXHTML( true )=="")
    {
        alert("Bạn phải nhập nội dung!");
        $("#txtContent").focus()
        return false;
    }

}
function changeSelect(se,hd)
{
	document.getElementById(""+hd).value=document.getElementById(""+se).value;
}
 var ajxBlog= {
		listblog:function(spage){
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"listBlog",pg:spage,kw:$("#txtKeyword").val(),cat:$("#txtCat").val()},
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
				    alert("Bạn phải chọn bài viết!");
				    return false;
				}
				 if($("#sltStatus").val()=="")
                {
                    alert("Bạn phải chọn trạng thái!");
                    $("#sltStatus").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChStatusBlog",status:$("#sltStatus").val(),id:chked},
				function(){
				ajxBlog.listblog(1);
			});
		},
		ChangeDefault:function(){
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
				    alert("Bạn phải chọn bài viết!");
				    return false;
				}
				 if($("#sltDisplayDefault").val()=="")
                {
                    alert("Bạn phải chọn loại hiển thị!");
                    $("#sltDisplayDefault").focus()
                    return false;
                }
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"ChangeDefaultBlog",sltDisplayDefault:$("#sltDisplayDefault").val(),id:chked},
				function(){
				ajxBlog.listblog(1);
			});
		},
		Delete:function(idtd){
		        if (!confirm('Bạn có chắc chắn muốn xóa bài viết này không?'))
                    return false;
				$.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteBlog",id:idtd},
				function(){
				ajxBlog.listblog(1);
			});
		},
		DeleteImage:function(idtr,image,idtd){
		    $.post(PathAdmin +"/Handler/Admin.aspx", { act:"deleteImgBlog",id:idtd,img:image},
		    function(){
		     $("#"+idtr).hide();
			});
		},
		DeleteFile:function(idtr,filename,idNews){
		    $.post(PathAdmin +"/Handler/Admin.aspx", { act:"deletefile",filename:filename,idNews:idNews},
		    function(){
		     $("#"+idtr).hide();
			});
		},
		GetListCatDetail:function(){
				document.getElementById("hdCategoryDetail").value="";
			    $.post(PathAdmin +"/Handler/Admin.aspx", { act:"getListCatDetail",cat:$("#sltCategory").val()},
			    function(data){
			    if(data.XMLDocument!="")
			    {
		            var lcObjXmlDoc=data;
		            var lcNodes     = lcObjXmlDoc.getElementsByTagName("*")[0].childNodes;
		            if(lcNodes.length > 0)
		            {
			            try
			            {
				            removeSelectbox("sltCategoryDetail","Chọn");
				            var obj_select = document.getElementById("sltCategoryDetail");
				            for(var i_=obj_select.length-1; i_>=0; i_--)
				            {
					            obj_select.options[i_] = null;
				            }
				            for(var k = 0; k < lcNodes.length; k++)
				            {
					            var options_length = obj_select.length;
					            var option_value = lcNodes[k].childNodes[0];
					            var option_text  = lcNodes[k].childNodes[1];
					            while(option_text.childNodes[0].nodeValue.indexOf("|") !=-1)
					            {
						            option_text.childNodes[0].nodeValue = option_text.childNodes[0].nodeValue.replace("|","&");
					            }
					            if(k==0)
						            obj_select.options[options_length] = new Option("Chọn","");						
					            else	
						            obj_select.options[options_length] = new Option(option_text.childNodes[0].nodeValue,option_value.childNodes[0].nodeValue);
        						
					            document.getElementById("sltCategoryDetail").disabled = false;
				            }
			            }catch(e){
				            //alert(e);					
			            }
		            }
		            
	            }
    		    else
		            {
		                removeSelectbox("sltCategoryDetail","Loading...");
		            }    
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

function Initlistblog()
{
	ajxBlog.listblog(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxBlog.listblog(numberpage);
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