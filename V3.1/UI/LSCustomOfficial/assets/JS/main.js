$(function () {
    SET_CONTAIN_OBJECT();
});

function SET_CONTAIN_OBJECT() {
    $(".ContainObject").each(function(index) {
        $(this).css("top", 100 + index * 130);
        $(this).css("left", 100);
    });
}