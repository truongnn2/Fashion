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
 function AddNewMenuSubSub()
 {
    if($("#txtName").val()=="")
    {
        alert("Bạn phải nhập tên Danh mục cấp 3!");
        $("#txtName").focus()
        return false;
    }
    if($("#sltCategory").val()=="")
    {
        alert("Bạn phải chọn Danh mục cấp 1!");
        $("#sltCategory").focus()
        return false;
    }
    if ($("#sltCategorySub").val() == "") {
        alert("Bạn phải chọn Danh mục cấp 2!");
        $("#sltCategorySub").focus()
        return false;
    }
    if($("#sltStatus").val()=="")
    {
        alert("Bạn phải chọn trạng thái!");
        $("#sltStatus").focus()
        return false;
    }
}
function changeSelect(se, hd) {
    document.getElementById("" + hd).value = document.getElementById("" + se).value;
}
 var ajxMenuSubSub = {
     listDV: function(spage) {
     $.post(PathAdmin + "/Handler/Admin.aspx", { act: "ListMenuSubSub", pg: spage, category: $("#sltCategory").val() },
				function(data) {
				    if (data != "") {
				        $('#ListTD').html(data);
				        var tps = (parseInt($("#hTotalRows").val()) / parseInt($("#hdfRecordCount").val()) - parseInt(parseInt($("#hTotalRows").val()) / parseInt($("#hdfRecordCount").val()))) > 0 ? ((parseInt(parseInt($("#hTotalRows").val()) / parseInt($("#hdfRecordCount").val()))) + 1) : parseInt(parseInt($("#hTotalRows").val()) / parseInt($("#hdfRecordCount").val()));
				        if (tps < $("#hCurrentPage").val())
				            $("#hCurrentPage").val() = 1;
				        if (tps == 1) $("#dvPaging").hide();
				        mjDrawLbPageNew(tps, $("#hCurrentPage").val(), "dvPaging", "gotoPage");
				    }
				    else {
				        $('#ListTD').html("Chưa có dữ liệu!");
				        $("#dvPaging").hide();
				    }
				});
     },
     ChangeStatus: function() {
         var chked = '';
         if (document.form1.checkbox.length == undefined) {
             if (document.form1.checkbox.checked)
                 chked = document.form1.checkbox.value;
         }
         else {
             for (var i = 0; i < document.form1.checkbox.length; i++) {
                 if (document.form1.checkbox[i].checked) {
                     chked += document.form1.checkbox[i].value + ",";
                 }
             }
         }

         if (chked == '') {
             alert("Bạn phải chọn danh mục cấp 3!");
             return false;
         }
         if ($("#sltStatus").val() == "") {
             alert("Bạn phải chọn trạng thái!");
             $("#sltStatus").focus()
             return false;
         }
         $.post(PathAdmin + "/Handler/Admin.aspx", { act: "ChStatusMenuSubSub", status: $("#sltStatus").val(), id: chked },
				function() {
				    ajxMenuSubSub.listDV(1);
				});
     },
     DeleteCatSub: function(idtd) {
         if (!confirm('Bạn có chắc chắn muốn xóa loại danh mục này không?'))
             return false;
         $.post(PathAdmin + "/Handler/Admin.aspx", { act: "DeleteCatSubSub", id: idtd },
				function() {
				    ajxMenuSubSub.listDV(1);
				});
     },
     GetListCatDetail: function() {
         document.getElementById("hdCategoryDetail").value = "";
         $.post(PathAdmin + "/Handler/Admin.aspx", { act: "getListCatDetail", cat: $("#sltCategory").val() },
			            function(data) {
			                if (data.XMLDocument != "") {
			                    var lcObjXmlDoc = data;
			                    var lcNodes = lcObjXmlDoc.getElementsByTagName("*")[0].childNodes;
			                    if (lcNodes.length > 0) {
			                        try {
			                            removeSelectbox("sltCategorySub", "Chọn");
			                            var obj_select = document.getElementById("sltCategorySub");
			                            for (var i_ = obj_select.length - 1; i_ >= 0; i_--) {
			                                obj_select.options[i_] = null;
			                            }
			                            for (var k = 0; k < lcNodes.length; k++) {
			                                var options_length = obj_select.length;
			                                var option_value = lcNodes[k].childNodes[0];
			                                var option_text = lcNodes[k].childNodes[1];
			                                while (option_text.childNodes[0].nodeValue.indexOf("|") != -1) {
			                                    option_text.childNodes[0].nodeValue = option_text.childNodes[0].nodeValue.replace("|", "&");
			                                }
			                                if (k == 0)
			                                    obj_select.options[options_length] = new Option("Chọn", "");
			                                else
			                                    obj_select.options[options_length] = new Option(option_text.childNodes[0].nodeValue, option_value.childNodes[0].nodeValue);

			                                document.getElementById("sltCategorySub").disabled = false;
			                            }
			                        } catch (e) {
			                            //alert(e);					
			                        }
			                    }

			                }
			                else {
			                    removeSelectbox("sltCategorySub", "Loading...");
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

function InitListMenuSubSub()
{
	ajxMenuSubSub.listDV(1);
}
function gotoPage(numberpage)
{			
    pg = numberpage;
    ajxMenuSubSub.listDV(numberpage);
}
function removeSelectbox(objID, initText) {
    if (initText && initText.indexOf('*') != -1)
        initText = initText.replace('***', 'Select');
    var obj_select = document.getElementById(objID);
    obj_select.disabled = true;
    for (var k = obj_select.options.length - 1; k >= 0; k--) {
        obj_select.options[k] = null;
    }
    if (initText != undefined || initText != null) {
        if (initText != '') obj_select.options[0] = new Option(initText, "");
    }
}


