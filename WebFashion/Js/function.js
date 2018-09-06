function getDayEN(){
	    var today = new Date();
	    var d=today.getDate();
	    var m;
	    var w;
	    var y=today.getFullYear();
	    var h=today.getHours();
	    var minu=today.getMinutes();
	    var arrDay=new Array("Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday")
	    var arrMonth=new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec");
    	
	    for(i=0;i<arrMonth.length;i++){
		    if(today.getMonth()==i){
			    m=arrMonth[i];
		    }
	    }
	    for(j=0;j<arrDay.length;j++){
		    if(today.getDay()==j){
			    w=arrDay[j];
		    }
	    }
	    var str='';
	    var s1='';
        
        if(d==1 || d==21 || d==31){
		        str="st";
	        }
        else if(d==2 || d==22){
	        str="nd";
        }
        else if(d==3 || d==23){
	        str="rd";
        }
        else{
	        str="th";
        }
        s1=w + ', ' + d + '<sup>' + str + '</sup>' + ' ' + m + ', ' + y;

	    document.write(s1);
    }


function getDayVN(){
	    var today = new Date();
	    var d=today.getDate();
	    var m;
	    var w;
	    var y=today.getFullYear();
	    var h=today.getHours();
	    var minu=today.getMinutes();
	    var arrDay=new Array("Chủ nhật","Thứ hai","Thứ ba","Thứ tư","Thứ năm","Thứ sáu","Thứ bảy")
	    var arrMonth=new Array("01","02","03","04","05","06","07","08","09","10","11","12");
    	
	    for(i=0;i<arrMonth.length;i++){
		    if(today.getMonth()==i){
			    m=arrMonth[i];
		    }
	    }
	    for(j=0;j<arrDay.length;j++){
		    if(today.getDay()==j){
			    w=arrDay[j];
		    }
	    }
	    var str='';
	    if (d<10){
	        str=w + ", ngày 0" + d + "/" + m + "/" + y;
	    }
	    else{
	        str=w + ", ngày  " + d + "/" + m + "/" + y;
	    }
	    document.write(str);
    }

function getDayFR(){
	    var today = new Date();
	    var d=today.getDate();
	    var m;
	    var w;
	    var y=today.getFullYear();
	    var h=today.getHours();
	    var minu=today.getMinutes();
	    var arrDay=new Array("Dimanche","Lundi","Mardi","Mercredi","Jeudi","Vendredi","Samedi")
	    var arrMonth=new Array("Jan","Fév","Mar","Avr","Mai","Juin","Juil","Août","Sep","Oct","Nov","Déc");
    	
	    for(i=0;i<arrMonth.length;i++){
		    if(today.getMonth()==i){
			    m=arrMonth[i];
		    }
	    }
	    for(j=0;j<arrDay.length;j++){
		    if(today.getDay()==j){
			    w=arrDay[j];
		    }
	    }
	    document.write(w + ", " + d + " " + m + " " + y);
    }

function hideTooltip(obj){
    var div=obj.childNodes(1);
    div.style.display='none';
    obj.style.cursor='normal';
}

function showTooltip(obj){
    var pos=findPos(obj);
    var left=pos[0];
    var top=pos[1];
    var div=obj.childNodes(1);
    div.style.display='block';
    div.style.left=left;
    div.style.top=top+12;
    obj.style.cursor='pointer';

}

function findPos(obj) {
	var curleft = curtop = 0;
	if (obj.offsetParent) {
		curleft = obj.offsetLeft
		curtop = obj.offsetTop
		while (obj = obj.offsetParent) {
			curleft += obj.offsetLeft
			curtop += obj.offsetTop
		}
	}
	return [curleft,curtop];
}

function subString(strSource, intLen){
	var strReturn=strSource;
	if(strSource.length>intLen){
		strReturn=strSource.substring(0, intLen);
		var endIndex=strReturn.lastIndexOf(" ");
		strReturn=strReturn.substring(0, endIndex);
	}
	
	return  strReturn + "...";
}

function toTitleCase(strInput){
	var strArray=strInput.split(' ');
	var strOutput='';
	for(i=0;i<strArray.length;i++){
		var word=strArray[i];
		var c=word.charAt(0);
		if(!isSpecialChars(c)){
	        strOutput+=c.toUpperCase() + word.substring(1, word.length);
	    }
	    
	    else{
	        if(word.length>1){
	            strOutput+=c + word.charAt(1).toUpperCase() + word.substring(2, word.length);
            }else{
                strOutput+=c + word.substring(1, word.length);
            }
	    }
	    		
		if(i<strArray.length-1){
			strOutput+=' ';
		}		
        
	}

	return trim(strOutput);
}

function isSpecialChars(c){
    var reg=/[^-_=\+\\\|<>,.\?:;'‘’`“”~!\@\#\$\%\^\&\*\(\)\""\[\]\{\}\t\r\n\x20\s ]+/;
	var foundChars=c.match(reg);

	if(foundChars!=null){
		return false;
	}
	else{
		return true;
	}    
}

function convertHtml2Text(strInput){
	strInput=stringreplace(strInput, "<", "[");
	strInput=stringreplace(strInput,">", "]");
	return strInput
}

function convertText2Html(strInput){
	strInput=stringreplace(strInput, "[", "<");
	strInput=stringreplace(strInput,"]", ">");
	return strInput
}

function charIsValid(txt){
	var strInput=txt.value;
	var regSpecialChars=/[^a-zA-Z0-9_-]/g;
	var foundChars=strInput.match(regSpecialChars);
	if(foundChars!=null){
		alert("Tên nhập vào không hợp lệ!\n\nKý tự bắt buộc phải là TIẾNG VIỆT KHÔNG DẤU và có giá trị trong phạm vi từ a đến z, từ A đến Z,\ndấu gạch ngang (-), dấu gạch dưới (_), số từ 0 đến 9.\nNgoài ra, ký tự nhập vào không được bao gồm khoảng trắng và các ký tự đặc biệt khác");
		txt.focus();
		txt.select();		
		return false;
	}
	else{
		return true;
	}
}

function checkDateTime(txtDateTime) 
{ 
   var sDate = txtDateTime.value;
   var bValid = false; 
//   var aMatch =/^\d{2}[\/-](1|2|3|4|5|6|7|8|9|10|11|12)[\/-]\d{4}$/.exec(sDate); 
   var aMatch =/^\d{2}[\/-](01|02|03|04|05|06|07|08|09|10|11|12)[\/-]\d{4}$/.exec(sDate);      
   if (sDate.length==0) { return true; } 

   if (aMatch == null) 
  { 
     alert(sDate + " không đúng định dạng!\nNgày tháng bắt buộc phải ở dạng: Ngày-Tháng-Năm (dd-mm-yyyy)\n\nDate value is not valid format! Date must be in format of: dd-mm-yyyy");  txtDateTime.focus(); 
     return bValid; 
  } 
               
  var DateArray = sDate.split("-"); 
  

// Convert the text month to a number - zero based month 

	
	
  switch (DateArray[1]) 
  { 
     case "01":   DateArray[1] = 0; break; 
     case "02":   DateArray[1] = 1; break; 
     case "03":   DateArray[1] = 2; break; 
     case "04":   DateArray[1] = 3; break; 
     case "05":   DateArray[1] = 4; break; 
     case "06":   DateArray[1] = 5; break; 
     case "07":   DateArray[1] = 6; break; 
     case "08":   DateArray[1] = 7; break; 
     case "09":   DateArray[1] = 8; break; 
     case "10":   DateArray[1] = 9; break; 
     case "11":   DateArray[1] = 10; break; 
     case "12":   DateArray[1] = 11; break; 
  }
var oDate = new Date(DateArray[2], DateArray[1], DateArray[0]);

// Validate whether the date itself is a valid calendar date.  
if (DateArray[2] != oDate.getFullYear() || DateArray[1] != oDate.getMonth())
{ 
    alert(sDate + " có giá trị không hợp lệ!\nVí dụ: 30-2 là ngày không hợp lệ"); 
    return bValid; 
} 


  bValid = true; 
  return bValid; 

}

function checkEmail(emailStr) {
	var emailPat=/^(.+)@(.+)$/
	var specialChars="\\(\\)<>@,;:\\\\\\\"\\.\\[\\]"
	var validChars="\[^\\s" + specialChars + "\]"
	var quotedUser="(\"[^\"]*\")"
	var ipDomainPat=/^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/
	var atom=validChars + '+'
	var word="(" + atom + "|" + quotedUser + ")"
	var userPat=new RegExp("^" + word + "(\\." + word + ")*$")
	var domainPat=new RegExp("^" + atom + "(\\." + atom +")*$")
	var matchArray=emailStr.match(emailPat)
	
	if (matchArray==null) {
		return false
	}
	var user=matchArray[1]
	var domain=matchArray[2]


	if (user.match(userPat)==null) {
		return false
	}

	var IPArray=domain.match(ipDomainPat)
	if (IPArray!=null) {
		for (var i=1;i<=4;i++) {
			if (IPArray[i]>255) {
				return false
			}
		}
		return true
	}

	var domainArray=domain.match(domainPat)
	if (domainArray==null) {
		return false
	}

	var atomPat=new RegExp(atom,"g")
	var domArr=domain.match(atomPat)
	var len=domArr.length
	
	if (domArr[domArr.length-1].length<2 || domArr[domArr.length-1].length>3) {
		return false
	}

	if (len<2) {
		return false
	}

	return true;
}

function replaceStr(strSrc, strSearch, strReplace){
	var startIndex=strSrc.lastIndexOf(strSearch);
	var endIndex=strSrc.lastIndexOf(".");
	var endStr=strSrc.substring(endIndex);
	
	var strResult=strSrc.substring(0, startIndex) + strReplace + endStr;
	return strResult;				
}

function showPopupText(strURL, w, h){
	var left, top, setting;
			
	left=(screen.width - w)/2;
	top=(screen.height - h)/2;
		
	setting = "width=" + w + ",height=" + h + ", scrollbars=1, toolbar=0,titlebar=no," 
				+ "dependent=yes, menubar=0,location=no,status=1, directories=0, "	
				+ "top=" + top + ", left=" + left + "'";
	
	popupWin=window.open(strURL,"",setting);

}

function showPopup(strURL, w, h){
/*
	var left, top, setting;
	var scrollbars="0";
	var defaultW=640;
	var defaultH=480;
	
	if(w>defaultW || h>defaultH){
		strURL+="&scroll=yes";
		if(w>defaultW){
			w=defaultW;
		}
		
		if(h>defaultH){
			h=defaultH;
		}
		w+=18;
		h+=18;
	}
	
	else{
		strURL+="&scroll=no";	
	}
	
	top=(screen.height - h)/2;
	left=(screen.width - w)/2;
	
	setting = "width=" + w + ",height=" + h + ", toolbar=0,titlebar=no," 
				+ "dependent=yes, menubar=0,location=no,status=1, directories=0, resizable=no, "		
				+ "top=" + top + ", left=" + left;
	popupWin=window.open(strURL,"",setting);
*/

	var left, top, setting;
			
	left=(screen.width - w)/2;
	top=(screen.height - h)/2;
		
	setting = "width=" + w + ",height=" + h + ", scrollbars=1, toolbar=0,titlebar=no," 
				+ "dependent=yes, menubar=0,location=no,status=1, directories=0, "	
				+ "top=" + top + ", left=" + left + "'";
    strURL=strURL.replace(jsPathPrefix, '');
	popupWin=window.open(jsPathPrefix + strURL,"",setting);	

}


function isNumeric(objName,minval,maxval,comma,period,hyphen){
// only allow 0-9 be entered, plus any values passed
// (can be in any order, and don't have to be comma, period, or hyphen)
// if all numbers allow commas, periods, hyphens or whatever,
// just hard code it here and take out the passed parameters
	var checkOK = "0123456789" + comma + period + hyphen;
	var checkStr = objName;
	var allValid = true;
	var decPoints = 0;
	var allNum = "";

	for (i = 0;  i < checkStr.value.length;  i++){
		ch = checkStr.value.charAt(i);
		for (j = 0;  j < checkOK.length;  j++)
			if (ch == checkOK.charAt(j)) break;
			
		if (j == checkOK.length){
			allValid = false;
			break;
		}
		
		if (ch != ",") allNum += ch;
	}
	
	if (!allValid){	
		alertsay = "Xin nhập các chữ số trong phạm vi sau \""
		alertsay = alertsay + checkOK + "\" vào textbox này!\n\nHoặc nhấn Ctrl+Z để phục hồi giá trị cũ"
		alert(alertsay);
		return (false);
	}

	// set the minimum and maximum
	var chkVal = allNum;
	
	var prsVal = parseInt(allNum);
	
	if (chkVal != "" && !(prsVal >= minval && prsVal <= maxval)){
		alertsay = "Xin hãy nhập giá trị lớn hơn hoặc "
		alertsay = alertsay + "bằng với \"" + minval + "\" và nhỏ hơn hoặc "
		alertsay = alertsay + "bằng với \"" + maxval + "\" vào textbox này!"
		alert(alertsay);
		return (false);
	}
}

function checkTextBoxIsNumeric(txtTextBox){
	if(txtTextBox.value=="0.00" || txtTextBox.value=="0" || txtTextBox.value=="0."  || txtTextBox.value==".0" || txtTextBox.value=="" || txtTextBox.value=="." || txtTextBox.value==","){
		txtTextBox.value="0";
	}			
	return checkNumeric(txtTextBox, 0, 1000000000, ",", ".", "");

}
function checkNumeric(objName,minval, maxval,comma,period,hyphen)
{
	var numberfield = objName;
	if (isNumeric(objName,minval,maxval,",",".","") == false)
	{
		numberfield.select();
		numberfield.focus();
		return false;
	}
	else
	{
		return true;
	}
}

//prevent Enter key
function handleEnter (field, event) {
	var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
	if (keyCode == 13) {
		var i;
		for (i = 0; i < field.form.elements.length; i++)
			if (field == field.form.elements[i])
				break;
		i = (i + 1) % field.form.elements.length;
		field.form.elements[i].focus();
		return false;
	} 
	else{
		return true;
	}
} 




//end prevent enter key
//allow Enter key to submit
function enterSubmit (field, nextElementID, event) {
	var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
	if (keyCode == 13) {
		field.form[nextElementID].click();
//		field.form[nextElementID].disabled=true;		
		return false;
	} 
	else{
		return true;
	}
}      


function trim(instring,inchar)
{
	if (!inchar) inchar = " ";
	while (instring.charAt(0) == inchar) instring = instring.substring(1);
	while (instring.charAt((instring.length-1)) == inchar) instring = instring.substring(0,(instring.length-1));
	return instring;
}

//SLICE GOES HERE
function fillup(){
	
	if (iedom){
		cross_slide=document.getElementById? document.getElementById("test2") : document.all.test2
		cross_slide2=document.getElementById? document.getElementById("test3") : document.all.test3
		cross_slide.innerHTML=cross_slide2.innerHTML=leftrightslide
		actualwidth=document.all? cross_slide.offsetWidth : document.getElementById("temp").offsetWidth
		cross_slide2.style.left=actualwidth+slideshowgap+"px"
	}
	else if (document.layers){
		ns_slide=document.ns_slidemenu.document.ns_slidemenu2
		ns_slide2=document.ns_slidemenu.document.ns_slidemenu3
		ns_slide.document.write(leftrightslide)
		ns_slide.document.close()
		actualwidth=ns_slide.document.width
		ns_slide2.left=actualwidth+slideshowgap
		ns_slide2.document.write(leftrightslide)
		ns_slide2.document.close()
	}
	lefttime=setInterval("slideleft()",30)

}

function slideleft(){
	if (iedom){
		if (parseInt(cross_slide.style.left)>(actualwidth*(-1)+8))
			cross_slide.style.left=parseInt(cross_slide.style.left)-copyspeed2+"px"
		else
			cross_slide.style.left=parseInt(cross_slide2.style.left)+actualwidth+slideshowgap+"px"

		if (parseInt(cross_slide2.style.left)>(actualwidth*(-1)+8))
			cross_slide2.style.left=parseInt(cross_slide2.style.left)-copyspeed2+"px"
		else
			cross_slide2.style.left=parseInt(cross_slide.style.left)+actualwidth+slideshowgap+"px"

	}
	else if (document.layers){
		if (ns_slide.left>(actualwidth*(-1)+8))
			ns_slide.left-=copyspeed2
		else
			ns_slide.left=ns_slide2.left+actualwidth+slideshowgap

		if (ns_slide2.left>(actualwidth*(-1)+8))
			ns_slide2.left-=copyspeed2
		else
			ns_slide2.left=ns_slide.left+actualwidth+slideshowgap
	}
}

function getIndexByValue(strValue, lst){
	var lstLen=lst.options.length;
    strValue=(unescape(strValue)).toUpperCase();
    while(strValue.indexOf('+')>-1){
        strValue=strValue.replace('+', ' ');
    }
	var index=-1;
	var opt=null;
	for(i=0;i<lstLen;i++){
		opt=lst.options[i].value.toUpperCase();
		if(opt==strValue){
			index=i;
			return index;
		}
	}
    
    return index;
}

