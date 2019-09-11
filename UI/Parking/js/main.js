
var data_tmp = [
    {
        name: "Zentorno",
        Key: 23,
        Hashcode: 0x23242526,
    },
    {
        name: "Adder",
        Key: 10,
        Hashcode: 0x23242526,
    },
    {
        name: "Monroe",
        Key: 11,
        Hashcode: 0x23242526,
    },
    {
        name: "Blista",
        Key: 83,
        Hashcode: 0x23242526,
    },
];

function CLEAR_CONTAIN()
{
    $(".contain").children(".list").remove();
}

function UPDATE_CONTAIN(json)
{
    var data = JSON.parse(json);

    if (data == null)
        return;
    for (var i = 0; i < data.length; i++) {
        ADD_LIST_OBJECT(data[i]);
    }
    $(".outbutton").click(function () {
        $(this).parent().remove();
    });
}

function ADD_LIST_OBJECT(data)
{
    $(".contain").append("<div class='list'><p class='listobject' style='top: 20px;'>"+data.name+"</p><p class='listobject' style='top: 80px;'>Key: "+data.Key+"</p><button class='outbutton'>Sortir</button></div>");
}

function make_contain(json) {
    var data = JSON.parse(json);
    
    if (data === null)
        retur;
    $("body").append("<div class='background'>\n<p class='title'>"+data.name+"</p>\n<p class='title'>Proprietaire : "+data.owner+"</p>\n<button class='sbutton'>Sortir</button>\n</div>");
    $(".sbutton").last().data("data", json);
}

$(() => {
    CLEAR_CONTAIN();
    UPDATE_CONTAIN(JSON.stringify(data_tmp));
    /*make_contain(JSON.stringify(single_vehicule));
    make_contain(JSON.stringify(single_vehiculea));
    make_contain(JSON.stringify(single_vehiculeb));
    make_contain(JSON.stringify(single_vehiculec));
    $(".sbutton").click(function(){
        var data = JSON.parse($(this).data("data"));
        alert(data.name);
        $(this).parent().remove();
    });*/
});