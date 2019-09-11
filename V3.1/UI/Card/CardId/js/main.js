
var data = {
    list_value: ["Sage","Grand","Aereoe","hydrocarburant","sel","test","chocolat","beaucoup"],
};


function CreateInput() {
    for (var i = 0; i < data.list_value.length; i++) {
        $(".card").append("<input type='text' class='cinput'>");
    }
    $(".cinput").each(function (index) {
       $(this).css("top", 265 + (index%4) * 42);
       $(this).css("left", 248 + (((index/4) < 1 ? 0 : (index/4) > 1 ? 1 : (index/4).toFixed(0)) * 130));
    }); 
}


function CreateText() {
    for (var i = 0; i < data.list_value.length; i++) {
        $(".card").append("<p class='ctext'></p>");
    }
    $(".ctext").each(function (index) {
       $(this).css("top", 265 + (index%4) * 42);
       $(this).css("left", 248 + (((index/4) < 1 ? 0 : (index/4) > 1 ? 1 : (index/4).toFixed(0)) * 130));
        $(this).text(data.list_value[index]);
    }); 
}

$(function () {
    //CreateInput();
    CreateText();
    
    
})