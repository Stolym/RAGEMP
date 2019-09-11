$(function () {
    $('.Slider').bind('input', function(e){
        var i = $(this).data("id");
        var values = $(this).val();
        $(".ContainObject").each(function (index) {
            if (i == $(this).data("id"))
                $(this).text("Values : "+values);
        });
    });
    /*$(".Slider").slider({
        change: function(event, ui) {
            alert("test");
        }
    });*/
 
    //$(".Slider").on("slide", function() {
    //    alert("sliding");
    //})
});