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

var BinderEvent = [false, false, false]

$(function () {
    BIND_COMBINE_EVENT();
    UPDATE_EVENT_STACK();
    UPDATE_EVENT_INVENTORY();
});

function BIND_COMBINE_EVENT() 
{
    $("body").unbind("keydown");
    $("body").bind("keydown", function(event) {
        BinderEvent[0] = event.ctrlKey;
        BinderEvent[1] = event.altKey;
        BinderEvent[2] = event.shiftKey;
    });

    $("body").unbind("keyup");
    $("body").bind("keyup", function(event) {
        BinderEvent[0] = event.ctrlKey;
        BinderEvent[1] = event.altKey;
        BinderEvent[2] = event.shiftKey;
    });
}

function UPDATE_EVENT_INVENTORY() {
    $(".InventorySlot").unbind("droppable");
    $(".InventorySlot").droppable({
        drop: function(event, ui) {
            ui.draggable.data("dropped", true);
            $(this).css('background', '#11111181');
        },
        over: function(event, ui) {
            $(this).css('background', '#333333FF');
        },
        out: function(event, ui) {
            $(this).css('background', '#11111181');
        }
    });
}

function UPDATE_EVENT_STACK() {
    $(".Stack").unbind("draggable");
    $(".Stack").draggable({
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

    

    $(".Stack").unbind("mouseup");
    $('.Stack').mouseup(function(event) {
        if ($(this).data("dropped") == false)
            return;
        switch (event.which) {
            case 1:
                LEFT_USE_STACK_OBJECT();
                //alert('Left Mouse button pressed.');
                break;
            case 2:
                //alert('Middle Mouse button pressed.');
                break;
            case 3:
                RIGHT_USE_STACK_OBJECT();
                //alert('Right Mouse button pressed.');
                break;
            default:
                alert('You have a strange Mouse!');
        }
    });
}

function RIGHT_USE_STACK_OBJECT() 
{
    if (BinderEvent[0] == true)
        return GIVE_STACK_OBJECT();
    else if (BinderEvent[1] == true)
        return SPLIT_STACK_OBJECT();
    else if (BinderEvent[2] == true)
        return USE_ALL_STACK_OBJECT();
    JUST_USE_ONE_ITEM_OBJECT();
}

function LEFT_USE_STACK_OBJECT() 
{
    if (BinderEvent[0] == true)
        return GIVE_STACK_OBJECT();
    else if (BinderEvent[1] == true)
        return SPLIT_STACK_OBJECT();
    else if (BinderEvent[2] == true)
        return USE_ALL_STACK_OBJECT();
    JUST_USE_ONE_ITEM_OBJECT();
}

function JUST_USE_ONE_ITEM_OBJECT() 
{
    alert("LEFT CLICK");
}

function USE_ALL_STACK_OBJECT()
{
    alert("SHIFT + LEFT CLICK");

}

function SPLIT_STACK_OBJECT()
{
    alert("ALT + LEFT CLICK");

}

function GIVE_STACK_OBJECT()
{
    alert("CONTROL + LEFT CLICK");
}
