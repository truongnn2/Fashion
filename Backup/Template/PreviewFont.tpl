<div class="view_font">
  <table width="650" align="center">
    <tr>
      <td width="805" height="140" rowspan="3">
        <div style="margin-left:-3px;" id="img">
          <img src="{0}" width="650" height="114"  alt="{6}" title="{6}"/>
        </div>
      </td>
     </tr>
  </table>
  <table width="650" align="center">
    <tr>
      <td width="45" height="50" rowspan="3"></td>
        <td>
          <font size="2" face="Arial, Helvetica, sans-serif" color="#000000">
            <b>Thử font: </b>
          </font>
          <input type="text" size="24" maxlength="20" value="Nhập text" onblur="if(this.value=='')this.value='Nhập text';" onfocus="if (this.value=='Nhập text') this.value='';"  name="Inputtext" id="Inputtext" onkeyup="ShowImg({2},'{3}',{5});"/>
            &nbsp; <input type="button" value="Reset Text" onclick="javascript:resettext(); return true;" name="button"/>
      </td>
      <td height="40" width="125">
        <a href="{1}">
          <img height="auto" border="0" width="80" alt="Download Windows Font" src="{4}/images/icon/winlogo.png"/>
        </a>
      </td>
    </tr>
  </table>
</div>