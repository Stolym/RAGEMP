

var is = 0;
var size = 0;
var currentbuy = [];
var currentrepair = [false, false, false, false];
var currentlist = [];

var hat = {
    current: [0, 2],
    drawable: [4, 2, 9],
    texture: [10, 20, 30, 40],
};

currentlist.push(hat);


function ClearContain() {
    $("input").remove();
    $(".ptext").remove();
    $(".pointer").remove();
    
}

function GetSlider(id) {
    var select = null;
    $(".slider_").each(function(index) {
         if (index == id)
             select = $(this);
    });
    return select;
}

function UpdatePointer() {
    $(".pointer").each(function(index) {
        var slider = GetSlider(index);
        currentlist[is].current[index] = slider.val();
        $(this).text(slider.val());
        $(this).css("left", (slider.val()/slider.data("max")) * 100 * 2.16 + 30);
        $(this).css("top", 67 * (index + 1));
    });
}

function AddSliderRange(name, length, value) {
    $(".panier").append("<p class='ptext'>"+name+"</p><input data-id='"+size+"' data-max='"+length+"' value='"+value+"' min='0' max='"+length+"' class='slider_' type='range'><p data-id='"+size+"' class='pointer'>50</p>");
    size++;
}

function AddInputInContain(json, id) {
    var data = JSON.parse(json);
    
    if (data == null)
        return;
    ClearContain();
    for (var d = 0; d < data.length; d++) {
        if (d == id) {
            AddSliderRange("Drawable", data[d].drawable.length - 1, data[d].current[0]);
            AddSliderRange("Texture", data[d].texture[data[d].current[0]], data[d].current[1]);
            UpdatePointer();
        }
    }
}

function ChangeRange(e) {
    if ($(this).data("id") == 0) {
        UpdatePointer();
        size = 0;
        AddInputInContain(JSON.stringify(currentlist), is);
        $('input').change(ChangeRange);
    } else
        UpdatePointer();
}

function ItemSelect() {
    UpdatePointer();
    switch ($(this).data("id")) {
        case 1:
            is = 0;
            break;
        case 3:
            is = 2;
            break;
        case 4:
            is = 3;
            break;
        case 5:
            is = 1;
            break;
        case 7:
            is = 4;
            break;
        case 10:
            is = 5;
            break;
    }
    size = 0;
    AddInputInContain(JSON.stringify(currentlist), is);
    $('input').change(ChangeRange);
}

function panier() {
    var sum = 0;
    for (var d in currentbuy)
        sum += 50;
    if (sum == 0)
        return;
    $('audio#checkout')[0].play();
    currentbuy = [];
    $(".buy").text("Panier : " + 0+"$");
}

function clear() {
    currentbuy = [];
    var sum = 0;
    $(".buy").text("Panier : " + sum+"$");
}

function add() {
    var sum = 0;
    currentbuy.push(currentlist[is].current);
    for (var d in currentbuy) {
        sum += 50;
    }
    $(".buy").text("Panier : " + sum+"$");
}

function UpdateIcon($this) {
    if($this.data("active") == false) {
        $this.children(".icon_a").css("opacity", "0");
    } else {
        $this.children(".icon_a").css("opacity", "1");        
    }
}

function UpdatePartCar() {
    $(".car_part").each(function (index) {
        UpdateIcon($(this));
        $(this).css("top", parseInt($(this).data("id")/2) * 110 + 80);    
        $(this).css("left", ($(this).data("id")%2) * 110 + 140);   
    });
}


$(() => {
    $(".car_part").click(function () {
        currentrepair[$(this).data("id")] = !currentrepair[$(this).data("id")];
        $(this).data("active", !$(this).data("active"));
        UpdatePartCar();
        var sum = 0;
        for (var i = 0; i < currentrepair.length; i++)
            if (currentrepair[i] == true)
                sum += 1000;
        $(".buy").text("Réparation : "+sum+"$");
    });
    
    UpdatePartCar();
    $(".buy").click(panier);
});