<div class="view_blog">
  <div id="listcomment">
  </div>
  <div id="Formcomment">
      <div id="author-info">
        <div class="row" style="{0}">
          <input style="color:#9196A2;"  type="text" size="40"  id="txtName" name="txtName"  value="Họ tên"  onblur="if(this.value=='')this.value='Họ tên';" onfocus="if (this.value=='Họ tên') this.value='';"/>
          </div>
        <div class="row" style="{0}">
          <input style="color:#9196A2;"  type="text" size="40"  id="txtEmail" name="txtEmail" value="Email"  onblur="if(this.value=='')this.value='Email';" onfocus="if (this.value=='Email') this.value='';"/>
        </div>
        <div class="row">
          <input style="color:#9196A2;"  type="text" size="40"  id="txtTitle" name="txtTitle" value="Tiêu đề"  onblur="if(this.value=='')this.value='Tiêu đề';" onfocus="if (this.value=='Tiêu đề') this.value='';"/>
         </div>
      </div>

      <!-- comment input -->
      <div class="row">
        <textarea cols="50" rows="8" class="validate required" id="comment" name="comment"></textarea>
      </div>
      <!-- /comment input -->
      <div class="clear-block">
        <div id="submitbox">
            <input type="button" value="Gửi ý kiến" class="button" id="btSend" name="btSend"  onclick="return SendCommentFont({2},'{1}');"/>
            <!--input type="button" value="Đóng lại" class="button" id="btDonglai" name="btDonglai" onclick="showformComment();" /-->
        </div>
      </div>
    </div>
</div>
<input type="hidden" id="hdFontID" value="{2}"/>