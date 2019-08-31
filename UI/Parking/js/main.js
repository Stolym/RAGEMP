var single_vehicule= {
    name: "Zentorno",
    owner: "Paul Manequin nue",
    hashcode: 0x213145,
};

var single_vehiculea= {
    name: "106Custom",
    owner: "Stolym Novaxx",
    hashcode: 0x213145,
};


var single_vehiculeb= {
    name: "MiniCooper",
    owner: "Zednok Stunner",
    hashcode: 0x213145,
};

var single_vehiculec= {
    name: "BMW",
    owner: "Quim Shira",
    hashcode: 0x213145,
};

function make_contain(json) {
    var data = JSON.parse(json);
    
    if (data === null)
        retur;
    $("body").append("<div class='background'>\n<p class='title'>"+data.name+"</p>\n<p class='title'>Proprietaire : "+data.owner+"</p>\n<button class='sbutton'>Sortir</button>\n</div>");
    $(".sbutton").last().data("data", json);
}

$(() => {
    make_contain(JSON.stringify(single_vehicule));
    make_contain(JSON.stringify(single_vehiculea));
    make_contain(JSON.stringify(single_vehiculeb));
    make_contain(JSON.stringify(single_vehiculec));
    $(".sbutton").click(function(){
        var data = JSON.parse($(this).data("data"));
        alert(data.name);
        $(this).parent().remove();
    });
});