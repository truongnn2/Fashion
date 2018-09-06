<div class="view_blog">
  <h3>{0}</h3>
  {1}
  <span class="st_twitter_large" displayText="Tweet"></span><span class="st_facebook_large" displayText="Facebook"></span><span class="st_ybuzz_large" displayText="Yahoo! Buzz"></span><span class="st_gbuzz_large" displayText="Google Buzz"></span><span class="st_email_large" displayText="Email"></span><span class="st_sharethis_large" displayText="ShareThis"></span>
  <p style="padding:20px 0 0 0;{2}">
      <strong>
        <u>Các bài  viết khác trong blog</u>
      </strong>
      <p>
        <ul>
         {3}
        </ul>
      </p>
    </p>
  


  <div id="listcomment">
  </div>
  <input type="hidden" id="hdBlogID" value="{4}"/>
  
  
  <!--div>
    <input type="button" value="Ý kiến bạn đọc" class="button" id="bt_showform" onclick="showformComment();"  name="cancel-reply"/>
  </div-->
  <div id="Formcomment">
      <div id="author-info">
        <div class="row" style="{5}">
          <input style="color:#9196A2;"  type="text" size="40"  id="txtName" name="txtName"  value="Họ tên"  onblur="if(this.value=='')this.value='Họ tên';" onfocus="if (this.value=='Họ tên') this.value='';"/>
          </div>
        <div class="row" style="{5}">
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
            <input type="button" value="Gửi ý kiến" class="button" id="btSend" name="btSend"  onclick="return SendComment({4},'{6}');"/>
            <!--input type="button" value="Đóng lại" class="button" id="btDonglai" name="btDonglai" onclick="showformComment();" /-->
        </div>
      </div>
    </div>
</div>