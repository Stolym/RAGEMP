$(function () {
    REOGANIZE();

});

function REOGANIZE() {
    $(".text").each(function () {
        if ($(this).data("id") != null) {
            $(this).css('left', 400 + parseInt($(this).data("id")%2) * 800);
            $(this).css('top', 100 + parseInt($(this).data("id")/2) * 120);
        }
    });

    $(".input_add").each(function () {
        if ($(this).data("id") != null) {
            $(this).css('left', 400 + parseInt($(this).data("id")%2) * 800);
            $(this).css('top', 200 + parseInt($(this).data("id")/2) * 120);
        }
    });

}