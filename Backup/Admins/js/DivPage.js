function mjDrawLbPageNew(TotalPages_, CurrentPage_, ElementID_,sGotoPageFunction)
{
    var _START_PAGE=0;
    var _END_PAGE=0;
    var _CPAGE=0;
    var _ITEMS_PAGES=10;
    var _ITEMS_PAGES_Admin=20;
    var _PART_PAGES=10;
    _CPAGE=CurrentPage_;
    if(_CPAGE>TotalPages_)
        _CPAGE=TotalPages_;
    _START_PAGE = 1;
    _END_PAGE = 1 + (_PART_PAGES - 1);
    if(TotalPages_ < _PART_PAGES){_END_PAGE = TotalPages_;}
    else
    {
        if(CurrentPage_ >= _END_PAGE)
        {
            _START_PAGE += 8;
            if((_END_PAGE + 8) < TotalPages_){_END_PAGE += 8;}
            else{_END_PAGE = TotalPages_;}
            while(CurrentPage_ >= _END_PAGE && CurrentPage_ < TotalPages_)
            {
                _START_PAGE = _END_PAGE - 1;
                if((TotalPages_ - _END_PAGE) < _PART_PAGES){
	                if(TotalPages_ - _START_PAGE <= _PART_PAGES)
	                {
		                _END_PAGE = TotalPages_;
		                if((_END_PAGE - _START_PAGE) == _PART_PAGES)
		                {_END_PAGE = _START_PAGE + (_PART_PAGES - 1);}
	                }
	                else{_END_PAGE = _START_PAGE + _PART_PAGES - 1;}
                }
                else{_END_PAGE = _START_PAGE + _PART_PAGES - 1;}
            }
        }
        if(CurrentPage_ == TotalPages_){
            _END_PAGE = TotalPages_;_START_PAGE = parseInt(TotalPages_/8)*8 - 1; 
            if(_START_PAGE > _END_PAGE) _START_PAGE = _START_PAGE - 8;}
    };
    var theme = "";
    //phan chia dau/truoc/tiep/cuoi
    var next;
    var pre;
    if(CurrentPage_==1)
        pre=1;
    else pre=CurrentPage_-1;
    if(CurrentPage_==TotalPages_)
        next=TotalPages_;
    else next=parseInt(CurrentPage_)+1;
    
    //theme+= "[<a href='javascript:"+sGotoPageFunction+"(1)' style='color:black'>Trang đầu</a>]";
    theme+= "<li><a href='javascript:"+sGotoPageFunction+"("+ pre +")'  class='pag_nav'><span><span>Trang trước</span></span></a></li>";
    for( var k = _START_PAGE; k <= _END_PAGE; k++){
        if(CurrentPage_ != k)theme+= "<li><a href='javascript:"+sGotoPageFunction+"("+ (k) +")' >"+ (k) +"</a></li>";
        else //theme+= "<span class='pgSelected'><b><u>"+ (k) +"</u></b></span>";
        theme+= "<li><a class=\"current_page\" href=''><span><span>"+(k)+"</span></span></a></li>";
    }
    theme+= "<li><a href='javascript:"+sGotoPageFunction+"("+ next +")' class='pag_nav'><span><span>Trang sau</span></span></a></li>";
    //theme+= "[<a href='javascript:"+sGotoPageFunction+"("+ TotalPages_ +")' style='color:black'>Trang cuối</a>]";
    theme+= "";	
    if (TotalPages_>1) {
        document.getElementById(ElementID_).style.display='block';
        document.getElementById(ElementID_).innerHTML=theme;
        }
}