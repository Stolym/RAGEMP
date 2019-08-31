var single_home= {
    name: "YXZ",
    price: "20 000$",
    owner: "Free",
    hashcode: 0x213145,
};

var single_homea= {
    name: "Motel",
    price: "2 500$",
    owner: "Free",
    hashcode: 0x213145,
};


var single_homeb= {
    name: "Luxe",
    price: "2 500 000$",
    owner: "Free",
    hashcode: 0x213145,
};

function make_contain(json) {
    var data = JSON.parse(json);
    
    if (data === null)
        return;
    var action = "Virer";
    if (data.owner == "Free")
        action = "Louer";
    $("body").append("<div class='background'><p class='title'>"+data.name+"</p><p class='text'>Prix : </p><p class='texta'>"+data.price+"</p><p class='text'>Proprietaire : </p><p class='texta'>"+data.owner+"</p><button class='sbutton'>Acheter</button><button class='sbutton'>"+action+"</button></div>");
    $(".background").last().data("data", json);
    if (action == "Virer" && data.price != "0$")
        $(".background .sbutton").last().css("background-color", "#A64C4C");
}

$(() => {
    make_contain(JSON.stringify(single_home));
    make_contain(JSON.stringify(single_homea));
    make_contain(JSON.stringify(single_homeb));
    $(".sbutton").click(function(){
        var data = JSON.parse($(this).data("data"));
        $(this).parent().remove();
    });
});