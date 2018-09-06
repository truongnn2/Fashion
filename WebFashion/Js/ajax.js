function GetXmlHttpObject(handler)
{ 
    var objXMLHttp=null;
    if (window.XMLHttpRequest)
    {
        objXMLHttp=new XMLHttpRequest();
    }
    else if (window.ActiveXObject)
    {
        objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    return objXMLHttp;
} 

var xmlRequest=GetXmlHttpObject();
if (xmlRequest==null)
{
    alert ("Browser does not support HTTP Request");
}
var nextFunctionName='';
var execFunctionWhenUrlExist='';
var execFunctionWhenUrlNotExist='';

function getRemoteXmlRequest(url, defaultFunction, altFunction){
	xmlRequest.open("GET", url, true);			
	xmlRequest.onreadystatechange=getRemoteXmlRequestResult;
    execFunctionWhenUrlExist=defaultFunction;
    execFunctionWhenUrlNotExist=altFunction;
    xmlRequest.setRequestHeader("Referer",url);
	xmlRequest.send(null);
}

function getRemoteXmlRequestResult(){
	if (xmlRequest.readyState == 4){
	    if(xmlRequest.status == 200){
            eval(execFunctionWhenUrlExist);
        }
        else{
            eval(execFunctionWhenUrlNotExist);
        }
	}
}


function postXmlRequest(url, strParams, functionName){
    url+='?callback=true';
	xmlRequest.open("POST", url, true);			
	xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
	xmlRequest.onreadystatechange=asynUpdate;
	nextFunctionName=functionName;
	xmlRequest.send(strParams);
}

function postRemoteXmlRequest(remoteUrl, urlReferer, strParams, nextFunctionName){
	xmlRequest.open("POST", remoteUrl, true);			
	xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
	xmlRequest.setRequestHeader("Content-length", strParams.length);
	xmlRequest.setRequestHeader("Referer",urlReferer);
	xmlRequest.setRequestHeader("Connection", "close");
	xmlRequest.onreadystatechange=nextFunctionName;
	xmlRequest.send(strParams);
}

function asynUpdate(){
	if (xmlRequest.readyState == 4 && xmlRequest.status == 200){
		var returnText=xmlRequest.responseText;
		if(returnText.indexOf('OK')>-1){
			if(nextFunctionName.length>0){
				eval(nextFunctionName)
			}
		}
		else{
			alert(xmlRequest.responseText);
		}
	}
}

function escapeHtml(htmlContent){
    while(htmlContent.indexOf('<')>-1){
        htmlContent=htmlContent.replace('<', '[[[');
    }
    
    while(htmlContent.indexOf('>')>-1){
        htmlContent=htmlContent.replace('>', ']]]');
    }

    while(htmlContent.indexOf('&')>-1){
        htmlContent=htmlContent.replace('&', '###AND###');
    }
    
    return htmlContent;
}

function postBackEncode(htmlContent){
    while(htmlContent.indexOf('<')>-1){
        htmlContent=htmlContent.replace('<', '[[[');
    }
    
    while(htmlContent.indexOf('>')>-1){
        htmlContent=htmlContent.replace('>', ']]]');
    }

    while(htmlContent.indexOf('&')>-1){
        htmlContent=htmlContent.replace('&', '#AND#');
    }
    
    return htmlContent;
}

function getPageHeader(pathPrefix, message){
    var htmlContent="<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN' >";
    htmlContent+="<HTML><HEAD><META http-equiv='Content-Type' content='text/html; charset=utf-8'>";
    htmlContent+="<LINK href='" + pathPrefix + "css.aspx' type='text/css' rel='stylesheet'>";
	htmlContent+="</HEAD><body style='background-color:white'><div class=textbodyblack><b><br>" + message + "</b><br><br></div><div>";
	return htmlContent;
}

function getPageFooter(message){
	return "</div><div class=textbodyblack><b><br>" + message + "</b><br><br></div></body></HTML>";
}
