
var data = {
    list_value: ["Sage","Grand"],
    list_permis: [false, true, false, false, true],
};


function CreateInput() {
    for (var i = 0; i < data.list_value.length; i++) {
        $(".card").append("<input type='text' class='cinput'>");
    }
    $(".cinput").each(function (index) {
       $(this).css("top", 250);
       $(this).css("left", 248 + index * 130);
    }); 
}


function CreateText() {
    for (var i = 0; i < data.list_value.length; i++) {
        $(".card").append("<p class='ctext'></p>");
    }
    $(".ctext").each(function (index) {
       $(this).css("top", 250);
       $(this).css("left", 255 + index * 130);
        $(this).text(data.list_value[index]);
    }); 
}

function SetValuesCheck() {
    $(".ccheck").each(function (index) {
        $(this).prop("checked", data.list_permis[index]);
    });
}

$(function () {
    //CreateInput();
    CreateText();
    
    SetValuesCheck();
})