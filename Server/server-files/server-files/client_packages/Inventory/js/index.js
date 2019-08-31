var icon_list = [
    "./items/000_bank_notes.svg",
    "./items/001_burger.svg",
    "./items/002_water_bottle.svg",
    "./items/003_coffee.svg",
    "./items/004_coca_bottle.svg",
    "./items/005_donuts.svg",
    "./items/006_tacos.svg",
    "./items/007_cigarette.svg",
    "./items/008_paquet_de_cigarette.svg",
    "./items/009_briquet.svg",
    "./items/010_jumelles.svg",
    "./items/011_parapluie.svg",
    "./items/012_roses.svg",
    "./items/013_radio_station_radio.svg",
    "./items/014_sim.svg",
    "./items/015_smartphone.svg",
    "./items/016_talkies.svg",
    "./items/017_malette.svg",
    "./items/018_sandwich.svg",
    "./items/019_porte_feuille.svg",
    "./items/020_bill_bank_notes.svg",
    "./items/021_key_house.svg",
    "./items/022_credit_card.svg",
    "./items/023_card_gun.svg",
    "./items/024_card_medic.svg",
    "./items/025_card_police.svg",
    "./items/026_id_card",
    "./items/027_pot.svg",
    "./items/028_dirt-bag.svg",
    "./items/029_parachute.svg",
    "./items/030_money_bag.svg",
    "./items/031_fish_box.svg",
    "./items/032_fish.svg",
    "./items/033_barrel_brut.svg",
    "./items/034_barrel_gazol.svg",
    "./items/035_blanc_rouge.svg",
    "./items/036_bouteille_de_vin_riuge.svg",
    "./items/037_bouteille_de_vin_blanc.svg",
    "./items/038_champagne.svg",
    "./items/039_raisin_blanc.svg",
    "./items/040_beer.svg",
    "./items/041_malt.svg",
    "./items/042_orge.svg",
    "./items/043_potato.svg",
    "./items/044_rhum.svg",
    "./items/045_vodka.svg",
    "./items/046_cocaine_paper.svg",
    "./items/047_ghb.svg",
    "./items/048_cocaine_seed.svg",
    "./items/049_weed_seed.svg",
    "./items/050_cocaine_pouch.svg",
    "./items/051_weed_pouch.svg",
    "./items/052_weed.svg",
    "./items/053_doliprane.svg",
    "./items/054_seringue.svg",
    "./items/055_cocktail.svg",
    "./items/056_frite.svg",
    "./items/057_ear_ring.svg",
    "./items/058_bracelet.svg",
    "./items/059_collier.svg",
    "./items/060_costume.svg",
    "./items/061_gants.svg",
    "./items/062_lunette.svg",
    "./items/063_montre.svg",
    "./items/064_bag.svg",
    "./items/065_maillot_de_bain.svg",
    "./items/066_pantalon.svg",
    "./items/067_shorts.svg",
    "./items/068_sous_vetement.svg",
    "./items/069_basket.svg",
    "./items/070_bikini.svg",
    "./items/071_bonet.svg",
    "./items/072_cam.svg",
    "./items/073_car_key.svg",
    "./items/074_casquette.svg",
    "./items/075_chapeau.svg",
    "./items/076_classic_shoes.svg",
    "./items/077_chemise.svg",
    "./items/078_claquette.svg",
    "./items/079_cravatte.svg",
    "./items/080_echarpe.svg",
    "./items/081_manche_courte.svg",
    "./items/082_manche_longue.svg",
    "./items/083_manteau.svg",
    "./items/084_masque.svg",
    "./items/085_micro.svg",
    "./items/086_shoes_montant.svg",
    "./items/087_noeud_papillon.svg",
    "./items/088_x_x.svg",
    "./items/089_perche.svg",
    "./items/090_veste.svg",
    "./items/091_veste_de_costume.svg",
    "./items/092_veste_sans_manche.svg",
    "./items/093_mbody.png",
    "./items/094_mboucle_oreilles.svg",
    "./items/095_mchapeau.svg",
    "./items/096_mgants.svg",
    "./items/097_mjumelles.svg",
    "./items/098_mleg.svg",
    "./items/099_mmasque.svg",
    "./items/100_mbag.svg",
    "./items/101_mshirt.svg",
    "./items/102_mshoes.svg",
    "./items/103_mtie.svg",
    "./items/104_mt_shirt.svg",
    "./items/105_drive_license.svg",
]




var actual = { value: null, active: false };
var index_object = 0;






/*var icon_list = [ "./rest/Billet.png", "./rest/coffee.png", "./rest/Beer.png", "./rest/Briquet.png", "./rest/Burger.png", "./rest/camera.png", "./rest/champagne.png", "./rest/cigarette.png", "./rest/cola.png", "./rest/donuts.png", "./rest/frite.png", "./rest/join_weed.png", "./rest/jumelles.png", "./rest/key_car.png", "./rest/key_house.png", "./rest/malette.png", "./rest/menotte.png", "./rest/micro.png", "./rest/paquet.png", "./rest/parachute.png", "./rest/parapluie.png", "./rest/radio.png", "./rest/rse.png", "./rest/sandwich.png", "./rest/scalpel.png", "./rest/seringue.png", "./rest/seven_up.png", "./rest/sim.png", "./rest/tacos.png", "./rest/talkie.png", "./rest/tel.png", "./rest/water.png", "./rest/Whiski.png", "./rest/body.png", "./rest/portefeuille.png", "./rest/hand.png"];*/
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
    $("#object"+index_object).click(function() {
        active_menu_usage($(this));
    });
    index_object++;
}


var index = 1;


/*
Make Matrix
*/



function make_matrix(json)
{
    var data = JSON.parse(json);
    
    console.log(json);
    for (var h = 0; h < data.length; h++) {
        adder.contain($("body"), json, data[h]);
        for (var i = 0; i < data[h].stack_size; i++) {
            adder.stack($(".contain_list_item").last(), json, data[h]);
            if (data[h].list_stack[i] == null)
                continue;
            else {
                for (var j = 0; j < data[h].list_stack.length; j++) {
                    if (data[h].list_stack[j].x == i) {
                        if (data[h].state == 1 && i < 3)
                            append_item_stack($(".stack").last(), json, data[h].list_stack[j], false, false);
                        else
                            append_item_stack($(".stack").last(), json, data[h].list_stack[j], true, true);
                    }
                }
            }
        }
        index--;
    }
    event_manager();
    update_draggable();
}

/*
Adder Object
*/

var adder = {
    contain: append_contain,
    stack: append_stack,
    item_stack: append_item_stack,
};

// Append Contain

function append_contain($value, json, data) {
    var money = data.money.toString();
    
    for (var i = 0; i < money.length / 3; i++) {
        var a = money.substr(0, i);
        var b = money.substr(i, money.length);
        var nmoney = a + " " + b;
    }
    money = nmoney;
    
    if (data.state == 1)
        $value.append("<div data-info='"+JSON.stringify(data)+"' data-id='"+index+"' data-state='"+data.state+"' data-name='"+data.name+"' class='contain'><p class='contain_title'>"+data.name+"</p><p class='money'>"+money+"$</p><div data-name='"+data.name+"' class='contain_list_item'></div></div>");
    else
        $value.append("<div data-info='"+JSON.stringify(data)+"' data-id='"+index+"' data-state='"+data.state+"' data-name='"+data.name+"' class='contain'><p class='contain_title'>"+data.name+"</p><div data-name='"+data.name+"' class='contain_list_item'></div></div>");

    $(".contain").last().css("top", 100);
    $(".contain").last().css("left", index * 600);
}

// Append Stack

function append_stack($value, json, data) {
    $value.append("<div class='stack'></div>");
}

// Append Item Stack

function append_item_stack($value, json, data, drag = true, count = true) {
    if (data.id == 424242)
        return;
    
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

// Clear Matrix

function clear_matrix() {
    $(".contain").remove();
    index = 1;
}

// Client Event

// Move Stack Event

function move_stack_event() {
    
}


// Use Drop Item in Stack Event

function use_drop_event(json) {
    //mp.trigger("UseDropStack", json);
}



function check_state($stack) {
    var data = $stack.find(".scursor").data("info");
    
    console.log($stack.find(".scursor").data("info"));
    if (data.id == 21 || data.id == 19 || data.id == 93)
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
        },
        out: function(event, ui) {
        }
    });
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

function clear_append_interact($this, $interact, data)
{
    if (data.id == 19)
        $interact.find(".interact_title").text("Porte-feuille");
    else 
        $interact.find(".interact_title").text("Trousseau a clé");
    $interact.find(".list_item").find(".item").remove();
    if (data.list_item.length == 0)
        return;
    for (var i = 0; i < data.list_item.length; i++) {
         $interact.find(".list_item").append("<div class='item'><div data-item='"+JSON.stringify(data.list_item[i])+"' class='scursor'><img class='icon_stack' src='"+icon_list[data.list_item[i].id]+"'></div></div>");
        
    }
    $interact.find(".list_item").find(".item").find(".scursor").mouseup(function(event) {
            switch (event.which) {
                case 1:
                        sub_menu_enabled($(".cursor"));
                        $(".cursor").find(".interact_title").text($(this).data("item").id);
                        $(".cursor").find(".item_text").text($(this).data("item").description);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    alert('You have a strange Mouse!');
            }
    });
}

function clear_append_ibody($this, $interact, data)
{
    for (var i = 0; i < data.list_item.length; i++) {
        if (data.list_item[i].component == null)
            continue;
        //alert(data.list_item[i].component[0].toString());
        //alert(data.list_item[i].component[1].toString());
        switch (i) {
                case 4:
                    $("#Leg").data("item", data.list_item[i]);
                    $("#Leg").unbind("click");
                    if (data.list_item[i].component[0] >= 0 ) {
                        $("#Leg").css("background-color", "green");
                        $("#Leg").click(() => {
                            mp.trigger("CEFInventory", JSON.stringify($("#Leg").data("item")), 4);
                            sub_menu_enabled($(".ibody"));
                        });
                    } else {                        
                        $("#Leg").css("background-color", "black");
                    }
                    break;
                case 6:
                    $("#Shoes").data("item", data.list_item[i]);  
                    $("#Shoes").unbind("click");
                    if (data.list_item[i].component[0] >= 0 && data.list_item[i].component[0] != 91) {
                        $("#Shoes").css("background-color", "green");
                        $("#Shoes").click(() => {
                            mp.trigger("CEFInventory", JSON.stringify($("#Shoes").data("item")), 4);
                            sub_menu_enabled($(".ibody"));
                        });
                    } else {                        
                        $("#Shoes").css("background-color", "black");
                    }
                    break;
                case 8:
                    $("#T-shirt").data("item", data.list_item[i]);
                    $("#T-shirt").unbind("click");
                    if (data.list_item[i].component[0] >= 0) {
                        $("#T-shirt").css("background-color", "green");
                        $("#T-shirt").click(() => {
                            mp.trigger("CEFInventory", JSON.stringify($("#T-shirt").data("item")), 4);
                            sub_menu_enabled($(".ibody"));
                        });
                    } else {                        
                        $("#T-shirt").css("background-color", "black");
                    }
                    break;
                default:
        }
    }
    
    $interact.find(".ibody").unbind("mouseup");
    $interact.find(".ibody").find(".scursor").mouseup(function(event) {
            switch (event.which) {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
            }
    });
}

function event_manager() {
    $(".scursor").unbind("mouseup");
    $('.scursor').mouseup(function(event) {
        var data = $(this).data("info");
        if ($(this).data("dropped") == false)
            return;
        switch (event.which) {
            case 1:
                if (data.id == 21 || data.id == 19 || data.id == 93) {
                    switch(data.id) {
                        case 21:
                            sub_menu_enabled($(".interact"));
                            clear_append_interact($(this), $(".interact"), data);
                            //sub_menu_enabled($(".cursor"));
                            break;
                        case 93:
                            sub_menu_enabled($(".ibody"));
                            clear_append_ibody($(this), $(".ibody"), data);
                            break;
                        case 19:
                            sub_menu_enabled($(".interact"));
                            clear_append_interact($(this), $(".interact"), data);
                            //sub_menu_enabled($(".cursor"));
                            break;
                    } 
                } else {
                    mp.trigger("CEFInventory", JSON.stringify(data), 0);
                }
                //alert('Left Mouse button pressed.');
                break;
            case 2:
                    mp.trigger("CEFInventory", JSON.stringify(data), 2);
                //alert('Middle Mouse button pressed.');
                break;
            case 3:
                    mp.trigger("CEFInventory", JSON.stringify(data), 1);
                //alert('Right Mouse button pressed.');
                break;
            default:
                alert('You have a strange Mouse!');
        }
    });
}





$(document).ready(function(){
    sub_menu_enabled($(".interact"));       
    sub_menu_enabled($(".cursor"));
    sub_menu_enabled($(".ibody"));
});