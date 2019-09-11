$(function () {
    SET_CONTAIN_CHECK();
    SET_CONTAIN_OBJECT();
    SET_CONTAIN_OBJECT_ANALYZE();
});

function SET_CONTAIN_OBJECT() {
    $(".ContainObject").each(function () {
        if ($(this).data("id") != null) {
            $(this).css("top", parseInt($(this).data("id")/2) * 80 + 0);
            $(this).css("left", parseInt($(this).data("id")%2) * 300 + 90);
        }
    });
}


function SET_CONTAIN_OBJECT_ANALYZE() {
    $(".ContainObject").each(function () {
        if ($(this).data("set") != null) {
            $(this).css("top", $(this).data("set") * 80 + 80);
        }
    });
}


function SET_CONTAIN_CHECK() {
    $(".ContainCheck").each(function () {
        if ($(this).data("id") != null) {
            $(this).css("top", parseInt($(this).data("id")/2) * 80 + 10);
            $(this).css("left", parseInt($(this).data("id")%2) * 300 + 10);
        }
    });
}