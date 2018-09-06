function Showform()
{
    document.getElementById("form_infor").style.display="block";
}
function Deletesp(id,l)
{
    $.post(pathClient +"/Handler/handler.aspx", { act:"deletesp",id:id},
	function(data){
	if(data!="")
	{
        window.location=pathClient+"/giohang.aspx?l="+l;
	}
	});
}
function Update_sp(l)
{
    if($("#hdListID").val()=="")
    {
        if(l=="1")
            alert("Your cart is empty, you can not perform this function!");
        else
            alert("Giỏ hàng của bạn đang rỗng, bạn không thể thực hiện được chức năng này!");
        return false;
    }
    var temp="#";
    var arr=new Array();
    arr=$("#hdListID").val().split(','); 
    for(i=0;i<arr.length;i++)
    {
        temp+=arr[i]+"-"+$("#sp"+arr[i]).val()+"#";
    }
    $.post(pathClient +"/Handler/handler.aspx", { act:"updatedathang",sp:temp},
	function(data){
	if(data!="")
	{
        window.location=pathClient+"/giohang.aspx?l="+l;
	}
	});
}
function dathang(id,l) {
	$.post(pathClient +"/Handler/handler.aspx", { act:"dathang",id:id},
	function(data){
	if(data!="")
	{
        window.location=pathClient+"/giohang.aspx?l="+l;
	}
	});
}
