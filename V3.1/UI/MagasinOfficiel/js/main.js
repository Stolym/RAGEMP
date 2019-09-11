
function hover_right() {
    
   $(this).css("transition", "1000ms");
   $(this).css("transform", "perspective(500px) rotateY(0deg)");
}

function mouseout_right() {
   $(this).css("transform", "perspective(500px) rotateY(-20deg)");
   $(this).css("transition", "1000ms");
}

function hover_left() {
    
   $(this).css("transition", "1000ms");
   $(this).css("transform", "perspective(500px) rotateY(0deg)");
}

function mouseout_left() {
   $(this).css("transform", "perspective(500px) rotateY(20deg)");
   $(this).css("transition", "1000ms");
}

function hover_middle() {
    
   $(this).css("transition", "1000ms");
}

function mouseout_middle() {
   $(this).css("transition", "1000ms");
}

function valueUpdated(e) {
    var val = $(e.element).val();
    console.log(val);
}

/*

--------------------------------------------

*/


var burger = {
    id: 0,
    picture: "./pictures/burger.svg",
    price: 30,
};

var water_bottle = {
    id: 1,
    picture: "./pictures/burger.svg",
    price: 20,
};

var phone = {
    id: 2,
    picture: "./pictures/burger.svg",
    price: 200,
};

var cola = {
    id: 3,
    picture: "./pictures/burger.svg",
    price: 30,
};


var is = 0;
var size = 0;
var currentbuy = [];
var currentlist = [];
var allitem = [ burger, water_bottle, phone, cola ];


var cefdata = [ [1, -1], [2, -1], [3, -1], [3, -1] ]



UpdateMarketList(JSON.stringify(cefdata));

/* UpdateMarketList */

function UpdateMarketList(json) {
    var data = JSON.parse(json);
    
    $(".slot").each(function (index) {
        $(this).children(".icon_a").remove();
        $(this).data("object", null);
        if (data.length > index) {
            $(this).data("object", data[index]);
            $(this).append("<img class='icon_a' src='"+allitem[data[index][0]].picture+"'>");
        }
    });
}


/* ClearMarketList */




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
            AddSliderRange("Drawable", data[d].drawable.length, data[d].current[0]);
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
    is = parseInt($(this).data("id"));
    size = 0;
    //AddInputInContain(JSON.stringify(currentlist), is);
    //$('input').change(ChangeRange);
}

function panier() {
    var sum = 0;
    for (var i = 0; i < currentbuy.length; i++)
        sum += currentbuy[i].price;
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
    if (is > currentlist.length - 1)
        return;
    
    currentbuy.push(currentlist[is]);
    for (var i = 0; i < currentbuy.length; i++) {
        sum += currentbuy[i].price;
    }
    $(".buy").text("Panier : " + sum+"$");
}


$(() => {
    /* AddInputInContain(JSON.stringify(currentlist), is); */
    ClearContain();
    $(".add").click(add);
    $(".clear").click(clear);
    $(".buy").click(panier);
    $(".slot").click(ItemSelect);
    //$('.slider_').on('change', valueUpdated);
    $('input').change(ChangeRange);
    
    $(".slot").each(function(index) {
        
        $(this).css("top", ((index - 1) / 3).toFixed(0) * 250);
        $(this).css("left", ((index % 3) * 300));
       if ((parseInt($(this).data("id")) + 1) % 3 == 0 && index != 0) {
           $(this).css("transform", "perspective(500px) rotateY(-10deg)");
            $(this).hover(hover_right);
            $(this).mouseout(mouseout_right);
       } else if ((parseInt($(this).data("id")) + 1) % 2 == 0 && index != 0 && index != 3 && index != 9 || index == 4 || index == 10) {
           $(this).css("transform", "perspective(500px) rotateY(0deg)");
            $(this).hover(hover_middle);
            $(this).mouseout(mouseout_middle);
       } else {
            $(this).hover(hover_left);
            $(this).mouseout(mouseout_left);
       }
        
        
    });
    
});