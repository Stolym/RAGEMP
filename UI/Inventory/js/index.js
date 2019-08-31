




var actual = { value: null, active: false };
var index_object = 0;
var icon_list = [ "./rest/Billet.png", "./rest/coffee.png", "./rest/Beer.png", "./rest/Briquet.png", "./rest/Burger.png", "./rest/camera.png", "./rest/champagne.png", "./rest/cigarette.png", "./rest/cola.png", "./rest/donuts.png", "./rest/frite.png", "./rest/join_weed.png", "./rest/jumelles.png", "./rest/key_car.png", "./rest/key_house.png", "./rest/malette.png", "./rest/menotte.png", "./rest/micro.png", "./rest/paquet.png", "./rest/parachute.png", "./rest/parapluie.png", "./rest/radio.png", "./rest/rse.png", "./rest/sandwich.png", "./rest/scalpel.png", "./rest/seringue.png", "./rest/seven_up.png", "./rest/sim.png", "./rest/tacos.png", "./rest/talkie.png", "./rest/tel.png", "./rest/water.png", "./rest/Whiski.png", "./rest/Body.png", "./rest/portefeuille.png"];
var list_matrix = [];


function active_menu_usage(current) {
    actual.value = current.data("info");
    actual.active = actual.active == true ? false : true;
    if (actual.active == true) {
        $(".interaction_div").css("opacity", "1.0");
    } else if (actual.active == false) {
        $(".interaction_div").css("opacity", "0.0");      
    }
}

// { id_icon: 0, name:"", menu: "inventory", stock: 1, slot: 0, id_object:[] }
var basic_item = { id_icon: 0, name:"Billet", menu: "inventory", stock: 2, slot: 0, id_object:[
    2183721,
    2132134,
] };

function add_item(json) {
    var item = JSON.parse(json);
    
    $("body").append("<img class=\"object\" id=\"object"+index_object.toString()+"\" src=\""+icon_list[item.id_icon]+"\">");
    $("#object"+index_object).data("info", json);
    var position = $("#drop_zone_"+item.menu+"_"+item.slot).position();
    $("#object"+index_object.toString()).css('top', position.top);
    $("#object"+index_object.toString()).css('left', position.left);
     $("#object"+index_object).hover(function() {
        $(this).css('cursor','pointer').attr('title', item.name);
    }, function() {
        $(this).css('cursor','auto');
    });
    
    //$("#object"+index_object).draggable();
    $("#object"+index_object).click(function() {
        active_menu_usage($(this));
    });
    index_object++;
}


var item_a = {
    id: 0,
    hashcode: 0x02AB77A1,
    description: "",
};

var stack_a = {
    id: 0,
    limit: 10,
    list_item: [item_a, item_a, item_a, item_a, item_a, item_a],
    x: 3,
    hashcode: 0x1F3A57A8,
};


var stack_b = {
    id: 11,
    limit: 10,
    list_item: [item_a],
    x: 4,
    hashcode: 0x1F3A57A8,
};

var matrix_a = {
    name: "Own Inventory",
    state: 1,
    money: 2000,
    stack_size: 10,
    list_stack: [stack_a, stack_b],
    hashcode: 0x02AB5138,
};

var index = 1;

var adder = {
    contain: append_contain,
    stack: append_stack,
    item_stack: append_item_stack,
};

function append_stack($value, json, data) {
    $value.append("<div class='stack'></div>");
}

function append_item_stack($value, json, data, drag = true, count = true) {
    if (drag == true && count == true)
        $value.append("<div data-info='"+JSON.stringify(data)+"' class='scursor'><img class='icon_stack' src='"+icon_list[data.id]+"'><p class='stack_size'>*"+data.list_item.length+"</p></div>");
    else if (drag == false && count == true) {
        
    } else if (drag == false && count == false) {
        $value.append("<div data-info='"+JSON.stringify(data)+"' class='scursor'><img class='icon_stack' src='"+icon_list[data.id]+"'></div>");
        $(".scursor").last().draggable({
            disabled: true
        });
    }
}

function append_contain($value, json, data) {
    var money = data.money.toString();
    
    for (var i = 0; i < money.length / 3; i++) {
        var a = money.substr(0, i);
        var b = money.substr(i, money.length);
        var nmoney = a + " " + b;
    }
    
    money = nmoney;
    $value.append("<div data-info='"+json+"' data-id='"+index+"' data-state='"+data.state+"' data-name='"+data.name+"' class='contain'><p class='contain_title'>"+data.name+"</p><p class='money'>"+money+"$</p><div data-name='"+data.name+"' class='contain_list_item'></div></div>");
    
    $(".contain").last().css("top", 100);
    $(".contain").last().css("left", index * 600);
}
    

var body = {
    id: 33,
    limit: 10,
    list_item: [],
    x: 0,
    hashcode: 0x1F3A57A8,
};


var wallet = {
    id: 34,
    limit: 10,
    list_item: [],
    x: 1,
    hashcode: 0x1F3A57A8,
};


var keyring = {
    id: 14,
    limit: 10,
    list_item: [],
    x: 2,
    hashcode: 0x1F3A57A8,
};

var state_player = [
    body,
    wallet,
    keyring,
];

function make_matrix(json)
{
    var data = JSON.parse(json);
    
    adder.contain($("body"), json, data);
    for (var i = 0; i < data.stack_size; i++) {
        adder.stack($(".contain_list_item").last(), json, data);
        if (data.state == 1 && i < 3)  {
            append_item_stack($(".stack").last(), json, state_player[i], false, false);
        } else if (data) {
            for (var j = 0; j < data.list_stack.length; j++) {
                if (data.list_stack[j].x == i && data.list_stack[j].list_item.length > 0) {
                    append_item_stack($(".stack").last(), json, data.list_stack[j], true, true);
                }
            }
        }
    }
    
    event_manager();
    update_draggable();
    index--;
    /*$("body").append("<div data-info='"+json+"' data-id='"+index+"' data-state='"+data.state+"' data-name='"+data.name+"' class='contain'><p class='contain_title'>"+data.name+"</p><p class='money'>"+data.money+"$</p><div data-name='"+data.name+"' class='contain_list_item'></div></div>");
    
    $(".contain").last().css("top", index * 400);
    
    for (var i = 0; i < data.stack_size; i++) {
        $(".contain").last().append("<div class='stack'></div>");
    }*/
}

function check_state($stack) {
    var data = $stack.find(".scursor").data("info");
    
    console.log($stack.find(".scursor").data("info"));
    if (data.id == 14 || data.id == 33 || data.id == 34)
        return true;
    return false;
}

function update_draggable() {
    $(".scursor").unbind("draggable");
    $(".scursor").draggable({
        start: function (event, ui) {
            $(this).data("dropped", false);
        },
        stop: function (event, ui) {
            if (ui.helper.data("dropped") == false) {
                ui.helper.css("top", "0%");
                ui.helper.css("left", "0%");
            }
        }
    });
    
    $(".stack").unbind("droppable");
    $(".stack").droppable({
        drop: function(event, ui) {

            if (check_state($(this)) == false) {
                ui.draggable.data("dropped", true);
            }
            if (ui.draggable == $(this).data("info")) {
                ui.draggable.css("top", "0%");
                ui.draggable.css("left", "0%");
            }
            $(this).css('background', '#11111181');
        },
        over: function(event, ui) {
            $(this).css('background', '#333333FF');
        },
        out: function(event, ui) {
            $(this).css('background', '#11111181');
        }
    });
    
    $(".contain").unbind("droppable");
    $(".contain").droppable({
        drop: function(event, ui) {
        },
        over: function(event, ui) {
            ui.draggable.css('z-index', 9999);
            //$(this).insertAfter($(".contain").last());
        },
        out: function(event, ui) {
        }
    });
}
                 


function add_list_in_matrix(name, json)
{
    var data = JSON.stringify(json);
    
    
}

function emake_matrix(name,x,y) {
    $(".menu").append("<div class=\"menu_item\" id=\""+name+"\"></div>");
    for (var i = 0; i < x + y; i++) {
        $( ".menu_item#"+name ).append( "<div class=\"dropzone\" id=\"drop_zone_"+name+"_"+i.toString()+"\"></div>");
    }
}

function body() {
    
}

function fwallet() {
}

function keyring() {
    
}

function sub_menu_enabled($value) {
    console.log($value.data("enabled"));
    $value.data("enabled", !$value.data("enabled"));
    if ($value.data("enabled") == true) {
        $value.show();        
    } else if ($value.data("enabled") == false) {
        $value.hide();        
    }
}

function event_manager() {
    $(".scursor").unbind("click");
    $(".scursor").click(function () {
        var data = $(this).data("info");
        if (data.id == 14 || data.id == 33 || data.id == 34) {
            switch(data.id) {
                case 14:
                    sub_menu_enabled($(".interact"));
                    sub_menu_enabled($(".cursor"));
                    break;
                case 33:
                    sub_menu_enabled($(".ibody"));
                    break;
                case 34:
                    sub_menu_enabled($(".interact"));       
                    sub_menu_enabled($(".cursor"));
                    break;
            }
        } 
    });
}


$(document).ready(function(){
    //sevent_manager();
    /*for (var i = 0; i < 7; i++) {
        $( ".menu_player" ).append( "<div class=\"menu_player_dropzone id"+i.toString()+"\"></div>" );
    }*/
    make_matrix(JSON.stringify(matrix_a));
    matrix_a.state = 0;
    matrix_a.name = "Coffre vehicle";
    make_matrix(JSON.stringify(matrix_a));
	//make_matrix("inventory", 9, 1);
    //add_item(JSON.stringify(basic_item));
	//make_matrix("inventory_2", 13, 12);
    
    /*$("#additem").click(function() {
        add_item(JSON.stringify({ id: 0, name: "billet", stock: 1, menu: "inventory", slot: 0 }));
        add_item(JSON.stringify({ id: 1, name: "clope", stock: 1, menu: "inventory_2", slot: 0 }));
    });*/
    
    /*$(".object").draggable();
    $(".dropzone").droppable({
        drop: function(event, ui) {
            $(this).css('background', 'rgb(0,200,0)');
            var position = $(this).position();
            var id = ui.draggable.attr("id");
            $(".object#"+id).css('top', position.top);
            $(".object#"+id).css('left', position.left);
        },
        over: function(event, ui) {
            $(this).css('background', 'orange');
        },
        out: function(event, ui) {
            $(this).css('background', 'cyan');
        }
    });
    $(".menu_player_dropzone").droppable({
        drop: function(event, ui) {
            var id = ui.draggable.attr("id");
            $(this).css('background-color', '#000');
            var position = $(this).position();
            $(".object#"+id).css('top', position.top);
            $(".object#"+id).css('left', position.left);
        },
        over: function(event, ui) {
            $(this).css('background-color', '#000');
        },
        out: function(event, ui) {
            $(this).css('background-color', '#FFF0');
        }
    });*/
});