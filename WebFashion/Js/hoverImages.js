/*
 * Image preview script 
 * powered by jQuery (http://www.jquery.com)
 * 
 * written by Alen Grakalic (http://cssglobe.com)
 * 
 * for more info visit http://cssglobe.com/post/1695/easiest-tooltip-and-image-preview-using-jquery
 *
 */

this.imagePreview = function() {
    /* CONFIG */

    xOffset = 10;
    yOffset = 30;

    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result

    /* END CONFIG */
    $("a.product_name").hover(function(e) {
        this.t = this.title;
        this.title = "";
        var c = (this.t != "") ? "<br/>" + this.t : "";
        $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' />" + c + "</p>");
        var left = e.pageX + yOffset; 
        if (e.pageX + yOffset == 530)
            left = 420;
        $("#preview")
			.css("top", (e.pageY - xOffset - 170) + "px")
			.css("left", left + "px")
			.fadeIn("medium");

    },
	function() {
	    this.title = this.t;
	    $("#preview").remove();
	});
    $("a.product_name").mousemove(function(e) {
        var left = e.pageX + yOffset;
        if (e.pageX + yOffset == 530)
            left = 420;
        $("#preview")
			.css("top", (e.pageY - xOffset - 170) + "px")
			.css("left", left + "px");

    });
};

this.screenshotPreview = function() {
    /* CONFIG */

    xOffset = 10;
    yOffset = 30;

    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result

    /* END CONFIG */
    $("a.product_name").hover(function(e) {
        this.t = this.title;
        this.title = "";
        var c = (this.t != "") ? "" + this.t : "";
        $("body").append("<p id='preview'><img src='" + this.rel + "' alt='url preview' />" + c + "</p>");
        if (e.pageX > 800) e.pageX = 500;
        var left = e.pageX + yOffset; 
        if (e.pageX + yOffset == 530)
            left = 380;
        $("#preview")
                .css("top", (e.pageY - xOffset - 170) + "px")
                .css("left", left + "px")
                .fadeIn("medium");
    },
            function() {
                this.title = this.t;
                $("#preview").remove();
            });
    $("a.product_name").mousemove(function(e) {
        if (e.pageX > 800) e.pageX = 500;
        var left = e.pageX + yOffset;
        if (e.pageX + yOffset == 530)
            left = 420;
        $("#preview")
                            .css("top", (e.pageY - xOffset - 170) + "px")
                            .css("left", left + "px");
    });
};
// starting the script on page load
$(document).ready(function(){
	screenshotPreview();
});

function EditLeft() 
{
    
}