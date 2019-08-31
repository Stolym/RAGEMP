
var tenue = {
    male: [ 
            [ [0, 0], [0, 0], [0, 0], [32, 0], [62, 0], [0, 0], [35, 0], [0, 0], [160, 0], [0, 0], [0, 0], [279, 0] ],
            [ [0, 0], [0, 0], [0, 0], [12, 0], [20, 1], [0, 0], [12, 0], [0, 0], [12, 0], [0, 0], [0, 0], [23, 0], [8, 0] ],
            [ [0, 0], [0, 0], [0, 0], [15, 0], [61, 0], [0, 0], [34, 0], [0, 0], [130, 0], [0, 0], [0, 0], [252, 0] ],
            [ [0, 0], [0, 0], [0, 0], [0, 0], [2, 0], [0, 0], [4, 0], [0, 0], [57, 0], [0, 0], [0, 0], [3, 0] ],              
        ],
    female: [
            [ [0, 0], [0, 0], [0, 0], [32, 0], [62, 0], [0, 0], [35, 0], [0, 0], [160, 0], [0, 0], [0, 0], [279, 0] ],
            [ [0, 0], [0, 0], [0, 0], [15, 0], [61, 0], [0, 0], [34, 0], [0, 0], [130, 0], [0, 0], [0, 0], [252, 0] ],
            [ [0, 0], [0, 0], [0, 0], [0, 0], [2, 0], [0, 0], [4, 0], [0, 0], [57, 0], [0, 0], [0, 0], [3, 0] ],    
            [ [0, 0], [0, 0], [0, 0], [12, 0], [20, 1], [0, 0], [12, 0], [0, 0], [12, 0], [0, 0], [0, 0], [23, 0], [8, 0] ],   
        ],
}



var Test = {
    cloth : [ [0, 0], [0, 0], [0, 0], [0, 0], [0, 0], [0, 0], [0, 0], [0, 0], [0, 0], [0, 0], [0, 0]],
    facefeature: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    decoration: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    facialDecoration: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    father : 20,
    mother : 10,
    grandparent : 5,
    skinMix : 20,
    heridity : 23,
    heridityparent : 30,
    degrade : 0,
    hair: 0,
    hair_color: 0,
    sourcils: 0,
    sourcils_color: 0,
    barbes: 0,
    barbes_color: 0,
    eyes: 0,
    poils: 0,
    poils_color: 0,
    skinSick: 0,
    vieille: 0,
    teint: 0,
    taches: 0,
    aspect: 0,
    makeup: 0,
    blush_color: 0,
    makeup_color: 0,
    blush: 0,
    tenue: 0,
    gender: 1
};


var WorldEditorData = {
    facefeature: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    decoration: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    facialDecoration: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    father : 0,
    mother : 0,
    grandparent : 0,
    skinMix : 0,
    heridity : 0,
    heridityparent : 0,
    degrade : 0,
    hair: 0,
    hair_color: 0,
    sourcils: 0,
    sourcils_color: 0,
    barbes: 0,
    barbes_color: 0,
    eyes: 0,
    poils: 0,
    poils_color: 0,
    skinSick: 0,
    vieille: 0,
    teint: 0,
    taches: 0,
    aspect: 0,
    makeup: 0,
    blush_color: 0,
    makeup_color: 0,
    blush: 0,
    tenue: 0,
    gender: 0
};

//UpdateCharacterBodyValues(JSON.stringify(Test));

function UpdateCharacterBodyValues(json) 
{
    var data = JSON.parse(json);
    console.log(data);
    
    WorldEditorData.gender = data.gender;
    WorldEditorData.father = data.father;
    WorldEditorData.mother = data.mother;
    for (var i = 0; i < data.facefeature.length; i++)
        WorldEditorData.facefeature[i] = data.facefeature[i];
    for (var i = 0; i < data.decoration.length; i++)
        WorldEditorData.decoration[i] = data.decoration[i];
    for (var i = 0; i < data.decoration.length; i++)
        WorldEditorData.facialDecoration[i] = data.facialDecoration[i];
    WorldEditorData.grandparent = data.grandparent;
    WorldEditorData.skinMix = data.skinMix;
    WorldEditorData.heridity = data.heridity;
    WorldEditorData.heridityparent = data.heridityparent;
    WorldEditorData.degrade = data.degrade;
    WorldEditorData.hair = data.hair;
    WorldEditorData.hair_color = data.hair_color;
    WorldEditorData.sourcils = data.sourcils;
    WorldEditorData.sourcils_color = data.sourcils_color;
    WorldEditorData.barbes = data.barbes;
    WorldEditorData.barbes_color = data.barbes_color;
    WorldEditorData.eyes = data.eyes;
    WorldEditorData.poils = data.poils;
    WorldEditorData.poils_color = data.poils_color;
    WorldEditorData.skinSick = data.skinSick;
    WorldEditorData.tenue = data.tenue;
    
    if (data.gender == 1) {
        $(".twoChoice .block input").attr('checked');
        $(".twoChoice .block input").attr('checked', true);
    } else if (data.gender == 0)
        $(".twoChoice .block input").prop('checked');
    $("#skinParent").val(data.grandparent);
    $("#skinHeredity").val(data.heridity);
    $("#skinParentSkin").val(data.heridityparent);
    $("#skinSkin").val(data.skinMix);
    $("#Coiffure").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Sourcils").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Barbes").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Yeux").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Poils").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#PPeau").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Vieillissement").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Teint").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Taches").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Aspect").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Makeup").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#Blush").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#AYeux").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#ANez").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#AArete").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#ABout").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#APommettes").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#AJoues").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#ALevre").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#AMachoire").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#AProfil").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
    $("#AForme").data("x", JSON.stringify([ data.hair, data.hair_color, 0]));
}


$("#overlayHair .left").click(function() {
  WorldEditorData.decoration[0]--;
  if (WorldEditorData.decoration[0] < 0)
    WorldEditorData.decoration[0] = 100;
    $(this).parent().children('.name').text(WorldEditorData.decoration[0].toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});

$("#overlayHair .right").click(function() {
  WorldEditorData.decoration[0]++;
  if (WorldEditorData.decoration[0] > 100)
    WorldEditorData.decoration[0] = 0;
    $(this).parent().children('.name').text(WorldEditorData.decoration[0].toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});

$("#tenue .left").click(function() {
    WorldEditorData.tenue--;
    if (WorldEditorData.gender == 0) {
        if (WorldEditorData.tenue < 0)
            WorldEditorData.tenue = tenue.female.length - 1;
        
        tenue.female[WorldEditorData.tenue][2] = [WorldEditorData.hair, 0];
        mp.trigger("CEFCharacterEditorTenue", JSON.stringify(tenue.female[WorldEditorData.tenue]));
    } else {
        if (WorldEditorData.tenue < 0)
            WorldEditorData.tenue = tenue.male.length - 1;
        
        tenue.male[WorldEditorData.tenue][2] = [WorldEditorData.hair, 0];
        mp.trigger("CEFCharacterEditorTenue", JSON.stringify(tenue.male[WorldEditorData.tenue]));
    }
    $(this).parent().children('.name').text(WorldEditorData.tenue.toString());
});

$("#tenue .right").click(function() {
    WorldEditorData.tenue++;
     if (WorldEditorData.gender == 0) {
        if (WorldEditorData.tenue > tenue.female.length - 1)
            WorldEditorData.tenue = 0;
         
       tenue.female[WorldEditorData.tenue][2] = [WorldEditorData.hair, 0];
        mp.trigger("CEFCharacterEditorTenue", JSON.stringify(tenue.female[WorldEditorData.tenue]));
    } else {
        if (WorldEditorData.tenue > tenue.male.length - 1)
            WorldEditorData.tenue = 0;
        
        tenue.male[WorldEditorData.tenue][2] = [WorldEditorData.hair, 0];
        mp.trigger("CEFCharacterEditorTenue", JSON.stringify(tenue.male[WorldEditorData.tenue]));
    }
    $(this).parent().children('.name').text(WorldEditorData.tenue.toString());
});













/*
var maxWidth  = 1920;
var maxHeight = 1080;

$(window).resize(function(evt) {
    var $window = $(window);
    var width = $window.width();
    var height = $window.height();
    var scale;

    // early exit
    if(width >= maxWidth && height >= maxHeight) {
        $('#wrapper').css({'-webkit-transform': ''});
        return;
    }

    scale = Math.min(width/maxWidth, height/maxHeight);

    $('#wrapper').css({'-webkit-transform': 'scale(' + scale + ')'});
});
*/


var names = ["Hannah", "Aubrey", "Jasmine", "Gisele", "Amelia", "Isabella", "Zoe", "Ava", "Camila", "Violet", "Sophia", "Evelyn", "Nicole", "Ashley", "Gracie", "Brianna", "Natalie", "Olivia", "Elizabeth", "Charlotte", "Emma", "Misty"];

var names_m = ["Benjamin", "Daniel", "Joshua", "Noah", "Andrew", "Juan", "Alex", "Isaac", "Evan", "Ethan", "Vincent", "Angel", "Diego", "Adrian", "Gabriel", "Michael", "Santiago", "Kevin", "Louis", "Samuel", "Anthony", "Claude", "Niko", "John"];

var names_1 = ["Aucun", "Joues roses", "Cutanée", "Hot Flush", "Coup de soleil", "Meurtri", "Alcoolique", "Inégal", "Totem", "Vaisseaux", "Endommagé", "Pâle", "Fantome"];

var names_2 = ["Aucun", "Petites rides", "Premiers signes", "Âge moyen", "Soucis", "Dépressif", "Distingué", "Vieilli", "Patiné", "Ridé", "Affaissement", "Vie dur", "Ancien", "Retraité", "Junkie", "Vieux"];

var names_3 = ["Aucun", "Chérubin", "Partout", "Irrégulier", "Dot Dash", "Pont", "Poupée", "Lutin", "Gorgés de soleil", "Marques de beauté", "Aligner", "Modelesque", "Occasionnel", "Tacheté", "Gouttes de pluie", "Double trempette", "Un côté", "Paires", "Croissance"];

var names_4 = ["Aucun", "Inégal", "Papier de verre", "Inégal", "Rugueux", "Coriace", "Texturé", "Grossier", "Raboteux", "Plié", "Fissuré", "Graveleux"];

var names_5 = ["Aucun", "Noir Fumé", "Bronze", "Gris doux", "Rétro glamour", "Aspect naturel", "Yeux de chat", "Chola", "Vamp", "Vinewood Glamour", "Bubblegum", "Aqua Dream", "Pin Up", "Violet Passion", "Yeux de chat", "Ruby", "Princesse"];


var names_y = ["Vert", "émeraude", "Bleu clair", "Bleu Océan", "Marron clair", "Marron foncé", "Noisette", "Gris foncé", "Gris clair", "Rose", "Jaune", "Violet", "Blackout", "Nuances de gris", "Tequila Sunrise", "Atomique", "Chaîne", "ECola", "Space Ranger", "Ying Yang", "Bullseye", "Lézard", "Dragon", "Extra terrestre", "Bouc", "Smiley", "Possédé", "Démon", "Infecté", "Alien", "Mort-vivant", "Zombie"];


//const eyeColors = ["Green", "Emerald", "Light Blue", "Ocean Blue", "Light Brown", "Dark Brown", "Hazel", "Dark Gray", "Light Gray", "Pink", "Yellow", "Purple", "Blackout", "Shades of Gray", "Tequila Sunrise", "Atomic", "Warp", "ECola", "Space Ranger", "Ying Yang", "Bullseye", "Lizard", "Dragon", "Extra Terrestrial", "Goat", "Smiley", "Possessed", "Demon", "Infected", "Alien", "Undead", "Zombie"];

var HeadOverlayValue = {
    "NoseWidth": 0, "NoseHeight": 0, "NoseLength": 0, "NoseBridge": 0, "NoseTip": 0, "NoseBridgeShift": 0,
    "BrowHeight": 0, "BrowWidth": 0, "CBoneHeight": 0, "CBoneWidth": 0, "CheekWidth": 0, "Eyes": 0, "Lips": 0,
    "JawWidth": 0, "ChinLength": 0, "ChinPos": 0, "ChinWidth": 0, "ChinShape": 0, "NeckWidth": 0,
}

var HeadOverayName = [  
    "NoseWidth", "NoseHeight", "NoseLength", "NoseBridge", "NoseTip", "NoseBridgeShift",
    "BrowHeight", "BrowWidth", "CBoneHeight", "CBoneWidth", "CheekWidth", "Eyes", "Lips",
    "JawWidth", "ChinLength", "ChinPos", "ChinWidth", "ChinShape", "NeckWidth",
]

var cindex = 0;

var dindex = 0;

var data_other = { 
    gender: 0,
    father: 0,
    mother: 0,
    heredity: 0,
    skin: 0,
    eye_colors: 0,
    hat: 0,
    hair: 0,
    haut: 0,
    mihaut: 0,
    torse: 0,
    bas: 0,
    shoes: 0,
    overlayHair: 0,
    facefeature: Array.from(Array(20), () => 0),
    eye_head_blend: 0,
    noose_head_blend: { x: 0, y: 0 },
    head_overlay_index: Array.from(Array(10), () => 0),
    head_overlay_opacity: Array.from(Array(10), () => 0),
    cloth: Array.from(Array(11), () => 0),
};



var data_user = {
    father: 0,
    mother: 0,
    grandp: 0,
    skin: 0,
    skinp: 0,
    heredity: 0,
    
    overlayHair: 0,
    facefeature: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    decoration: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    facialDecoration: [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    hair: 0,
    hair_color: 0,
    sourcils: 0,
    sourcils_color: 0,
    barbes: 0,
    barbes_color: 0,
    eyes: 0,
    poils: 0,
    poils_color: 0,
    skinSick: 0,
    vieille: 0,
    teint: 0,
    taches: 0,
    aspect: 0,
    makeup: 0,
    blush_color: 0,
    makeup_color: 0,
    blush: 0,
    haut: 0,
    mihaut: 0,
    torse: 0,
    bas: 0,
    shoes: 0,
    gender: 0,
};

$(document).on('change', '#skinHeredity', function() {
    WorldEditorData.heridity = parseFloat($(this).val())/100;
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});

$(document).on('change', '#skinParent', function() {
    WorldEditorData.grandparent = parseFloat($(this).val());
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});

$(document).on('change', '#skinParentSkin', function() {
    WorldEditorData.heridityparent = parseFloat($(this).val())/100;
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});

$(document).on('change', '#skinSkin', function() {
    WorldEditorData.skinMix = parseFloat($(this).val())/100;
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});


$(document).on('change', '#range1D', function() {

console.log($("#modifyWindow .labell").text());    
switch ($("#modifyWindow .labell").text()) {

    case "Eyes":
        WorldEditorData.facefeature[11] = parseFloat($(this).val())/100*2*-1;
        break;
    case "Joues":
        WorldEditorData.facefeature[9] = parseFloat($(this).val())/100*2;
        break;
    case "Lèvre":
        WorldEditorData.facefeature[12] = parseFloat($(this).val())/100*2*-1;
        break;
    case "Yeux":
        WorldEditorData.eyes = parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Coiffure":
        WorldEditorData.hair =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Sourcils":
        WorldEditorData.sourcils =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Barbes":
        WorldEditorData.barbes =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Poils":
        WorldEditorData.poils =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Problème de peau":
        WorldEditorData.skinSick =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Signes de vieillissement":
        WorldEditorData.vieille =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Teint":
        WorldEditorData.teint =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Taches cutanées":
        WorldEditorData.taches =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Aspect de la peau":
        WorldEditorData.poils =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Makeup":
        WorldEditorData.makeup =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Blush":
        WorldEditorData.blush =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    }
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});


$(document).on('change', '#RGBrange1D', function() {

console.log($("#modifyWindow .labell").text());    
switch ($("#modifyWindow .labell").text()) {
    case "Coiffure":
        WorldEditorData.hair_color =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Sourcils":
        WorldEditorData.sourcils_color =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Barbes":
        WorldEditorData.barbes_color =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Poils":
        WorldEditorData.poils_color =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Blush":
        WorldEditorData.blush_color =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    case "Makeup":
        WorldEditorData.makeup_color =  parseInt((parseFloat($(this).val())/10).toFixed(0)) < 0 ? (parseInt((parseFloat($(this).val())/10).toFixed(0)) * -1) * 2 : parseInt((parseFloat($(this).val())/10).toFixed(0));
        break;
    }
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});

var click = {
    x: 0,
    y: 0
};

$("#marker").draggable({
    
    start: function(event) {
        click.x = event.clientX;
        click.y = event.clientY;
    },
  containment: "#markerbounds",
  drag: function(event, ui) {
    var original = ui.originalPosition;

    var pos = slider.get_position();
      
    // jQuery will simply use the same object we alter here
    if ((event.clientX - click.x + original.left) / basePage.scale >= 0 && 
       (event.clientX - click.x + original.left) / basePage.scale <= 150 &&
       (event.clientY - click.y + original.top ) / basePage.scale >= 0 &&
       (event.clientY - click.y + original.top ) / basePage.scale <= 150) {
        ui.position = {
            left: (event.clientX - click.x + original.left) / basePage.scale,
            top:  (event.clientY - click.y + original.top ) / basePage.scale
        };
    } else {
        ui.position = {
            left: slider.position.left,
            top:  slider.position.top,
        }
    }
    //var pos = slider.get_position();
      
    switch ($("#modifyWindow .labell").text()) {
        case "Nez":
            WorldEditorData.facefeature[1] = (pos.x*4-2)*-1;
            WorldEditorData.facefeature[0] = (pos.y*4-2)*-1;
            break;
        case "Bout du nez":
            WorldEditorData.facefeature[4] = (pos.x*4-2)*-1;
            WorldEditorData.facefeature[5] = pos.y*4-2;
            break;
        case "Arête du nez":
            WorldEditorData.facefeature[5] = (pos.x*4-2)*-1;
            WorldEditorData.facefeature[3] = pos.y*4-2;
            break;
        case "Pommettes":
            WorldEditorData.facefeature[8] = (pos.x*4-2)*-1;
            WorldEditorData.facefeature[10] = (pos.y*4-2);
            break;
        case "Mâchoire":
            WorldEditorData.facefeature[13] = (pos.x*4-2)*-1;
            WorldEditorData.facefeature[14] = (pos.y*4-2)*-1;
            break;
        case "Profil menton":
            WorldEditorData.facefeature[15] = (pos.x*4-2)*-1;
            WorldEditorData.facefeature[17] = (pos.y*4-2)*-1;
            break;
        case "Forme du menton":
            WorldEditorData.facefeature[18] = pos.x*4-2;
            WorldEditorData.facefeature[16] = (pos.y*4-2)*-1;
            break;

            
    }
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
  },
    
});
/*$(document).on('change', '#headoverlay', function() {
    data_user.head_overlay_index[cindex] = parseInt($(this).val());
    ////console.log(data_user);
    //data_user.heredity = $(this).val();
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});


$(document).on('change', '#opacityh', function() {
    data_user.head_overlay_opacity[cindex] = parseFloat($(this).val()/100);
    ////console.log(data_user);
    //data_user.heredity = $(this).val();
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});



$(document).on('change', '#facefeature', function() {
    data_user.facefeature[dindex] = parseFloat($(this).val()/100);
    ////console.log(data_user);
    //data_user.heredity = $(this).val();
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});


$(document).on('change', '#skinHeredity', function() {
    //console.log($(this).val());
    data_user.heredity = $(this).val();
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});


$(document).on('change', '#skinSkin', function() {
    //console.log($(this).val());
    data_user.skin = $(this).val();
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});*/

$(".twoChoice .block input").click(function() 
{    
   if( $('input[type=checkbox]').is(':checked') ){
       WorldEditorData.gender = 1;
       tenue.male[WorldEditorData.tenue][2] = [WorldEditorData.hair, 0];
       mp.trigger("CEFCharacterEditorTenue", JSON.stringify(tenue.male[WorldEditorData.tenue]));
   } else {
       WorldEditorData.gender = 0;
       tenue.female[WorldEditorData.tenue][2] = [WorldEditorData.hair, 0];
       mp.trigger("CEFCharacterEditorTenue", JSON.stringify(tenue.female[WorldEditorData.tenue]));
   }
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});


/*


$("#headoverlayindex .left").click(function() {
  cindex--;
    if (cindex >= 10)
        cindex = 0;
    else if (cindex <= 0)
        cindex = 10;
    $(this).parent().children('.name').text(cindex.toString());
    
    //mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#headoverlayindex .right").click(function() {
  cindex++;
  if (cindex >= 10)
      cindex = 0;
  else if (cindex <= 0)
      cindex = 10;
    $(this).parent().children('.name').text(cindex.toString());
    
    //mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});


$("#facefeatureindex .left").click(function() {
  dindex--;
    if (dindex >= 20)
        dindex = 0;
    else if (dindex <= 0)
        dindex = 20;
    $(this).parent().children('.name').text(dindex.toString());
    
    //mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#facefeatureindex .right").click(function() {
  dindex++;
  if (dindex >= 20)
      dindex = 0;
  else if (dindex <= 0)
      dindex = 20;
    $(this).parent().children('.name').text(dindex.toString());
    
    //mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});*/



/*$("#eyes .left").click(function() {
  data_user.eye_colors--;
  if (data_user.eye_colors < 0)
    data_user.eye_colors = 0;
  if (names_y[data_user.eye_colors] != null)
    $(this).parent().children('.name').text(names_y[data_user.eye_colors].toString());
  else
    $(this).parent().children('.name').text(data_user.eye_colors.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#eyes .right").click(function() {
  data_user.eye_colors++;
  if (data_user.eye_colors > names_y.length - 1)
    data_user.eye_colors = names_y.length - 1;
  if (names_y[data_user.eye_colors] != null)
    $(this).parent().children('.name').text(names_y[data_user.eye_colors].toString());
  else
    $(this).parent().children('.name').text(data_user.eye_colors.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});



$("#hat .left").click(function() {
  data_user.overlayHair--;
  if (data_user.overlayHair < 0)
    data_user.overlayHair = 100;
    $(this).parent().children('.name').text(data_user.overlayHair.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#hat .right").click(function() {
  data_user.overlayHair++;
  if (data_user.overlayHair > 100)
    data_user.overlayHair = 0;
    $(this).parent().children('.name').text(data_user.overlayHair.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});*/
/*
$("#overlayHair .left").click(function() {
  data_user.decoration[0]--;
  if (data_user.decoration[0] < 0)
    data_user.decoration[0] = 100;
    $(this).parent().children('.name').text(data_user.decoration[0].toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#overlayHair .right").click(function() {
  data_user.decoration[0]++;
  if (data_user.decoration[0] > 100)
    data_user.decoration[0] = 0;
    $(this).parent().children('.name').text(data_user.decoration[0].toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});


$("#torse .left").click(function() {
  data_user.torse--;
  if (data_user.torse < 0)
    data_user.torse = 50;
    $(this).parent().children('.name').text(data_user.torse.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#torse .right").click(function() {
  data_user.torse++;
  if (data_user.torse > 50)
    data_user.torse = 0;
    $(this).parent().children('.name').text(data_user.torse.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});


/*$("#hair .left").click(function() {
  data_user.hair--;
  if (data_user.hair < 0)
    data_user.hair = 50;
    $(this).parent().children('.name').text(data_user.hair.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#hair .right").click(function() {
  data_user.hair++;
  if (data_user.hair > 50)
    data_user.hair = 0;
    $(this).parent().children('.name').text(data_user.hair.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});*/


/*

$("#haut .left").click(function() {
  data_user.haut--;
  if (data_user.haut < 0)
    data_user.haut = 252;
    $(this).parent().children('.name').text(data_user.haut.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#haut .right").click(function() {
  data_user.haut++;
  if (data_user.haut > 252)
    data_user.haut = 0;
    $(this).parent().children('.name').text(data_user.haut.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#mi-haut .left").click(function() {
  data_user.mihaut--;
  if (data_user.mihaut < 0)
    data_user.mihaut = 130;
    $(this).parent().children('.name').text(data_user.mihaut.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#mi-haut .right").click(function() {
  data_user.mihaut++;
  if (data_user.mihaut > 50)
    data_user.mihaut = 0;
    $(this).parent().children('.name').text(data_user.mihaut.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#bas .left").click(function() {
  data_user.bas--;
  if (data_user.bas < 0)
    data_user.bas = 50;
    $(this).parent().children('.name').text(data_user.bas.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#bas .right").click(function() {
  data_user.bas++;
  if (data_user.bas > 50)
    data_user.bas = 0;
    $(this).parent().children('.name').text(data_user.bas.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#shoes .left").click(function() {
  data_user.shoes--;
  if (data_user.shoes < 0)
    data_user.shoes = 50;
    $(this).parent().children('.name').text(data_user.shoes.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});

$("#shoes .right").click(function() {
  data_user.shoes++;
  if (data_user.shoes > 50)
    data_user.shoes = 0;
    $(this).parent().children('.name').text(data_user.shoes.toString());
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(data_user));
});
*/

//Mere//
$("#motherName .right").click(function() {
  WorldEditorData.mother++;
  if (WorldEditorData.mother > names.length - 1)
    WorldEditorData.mother = names.length - 1;
  if (names[WorldEditorData.mother] != null)
    $(this).parent().children('.name').text(names[WorldEditorData.mother].toString());
  else
    $(this).parent().children('.name').text(WorldEditorData.mother.toString());
    
    $(".mother_png").attr("src", "img_perso/female_"+WorldEditorData.mother.toString()+".png");
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});

$("#motherName .left").click(function() {
  WorldEditorData.mother--;
  if (WorldEditorData.mother < 0)
    WorldEditorData.mother = 0;
  if (names[WorldEditorData.mother] != null)
    $(this).parent().children('.name').text(names[WorldEditorData.mother].toString());
  else
    $(this).parent().children('.name').text(WorldEditorData.mother.toString());
    
    $(".mother_png").attr("src", "img_perso/female_"+WorldEditorData.mother.toString()+".png");
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});


//Pere//
$("#fatherName .right").click(function() {
  WorldEditorData.father++;
  if (WorldEditorData.father > names_m.length - 1)
    WorldEditorData.father = names_m.length - 1;
  if (names_m[WorldEditorData.father] != null)
    $(this).parent().children('.name').text(names_m[WorldEditorData.father].toString());
  else
    $(this).parent().children('.name').text(WorldEditorData.father.toString());
    
    
    $(".father_png").attr("src", "img_perso/male_"+WorldEditorData.father.toString()+".png");
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});


$("#fatherName .left").click(function() {
  WorldEditorData.father--;
  if (WorldEditorData.father < 0)
    WorldEditorData.father = 0;
  if (names_m[WorldEditorData.father] != null)
    $(this).parent().children('.name').text(names_m[WorldEditorData.father].toString());
  else
    $(this).parent().children('.name').text(WorldEditorData.father.toString());
    
    $(".father_png").attr("src", "img_perso/male_"+WorldEditorData.father.toString()+".png");
    
    
    mp.trigger("CEFCharacterEditorCommand", JSON.stringify(WorldEditorData));
});



$(".modifyBtn").click(function() {
  if ($(this).hasClass("fa-pencil-ruler")) {
    modifyWindow.openRange(this);
  } else {
    modifyWindow.closeRange();
  }
});

$(".closeBtn").click(function() {
  modifyWindow.closeRange();
});

var modifyWindow = {
  openRange: function(element) {
    //get the text data to place them in the modifyWindow
    var data = $(element).data('text');
    var dataX = JSON.parse($(element).data('x'));
    var dataRange = $(element).data('range-type');
    //set the text value
    /*
    */
    $("#modifyWindow .labell").text(data.list_button[0].name);
      
    $("#modifyWindow .slider").hide();
    $("#modifyWindow .slider2D").hide();
    $("#modifyWindow .RGBslider").hide();
    $("#modifyWindow .Opaslider").hide();
    var onFunction = [ function() {
        $("#modifyWindow #left").text(data.list_button[0].right);
        $("#modifyWindow #right").text(data.list_button[0].left);
        $("#range1D").val(dataX[0] - 100);
        $("#modifyWindow .slider").show();
    }, function() {
        $(".RGBslider #left").text(data.list_button[1].right);
        $(".RGBslider #right").text(data.list_button[1].left);
        $("#RGBrange1D").val(dataX[1] - 100);

        $("#modifyWindow .RGBslider").show();
    }, function() {
        $(".Opaslider #left").text(data.list_button[2].right);
        $(".Opaslider #right").text(data.list_button[2].left);
        $("#Opaslider1D").val(dataX[2] - 100);

        $("#modifyWindow .Opaslider").show();
    }, function() {
        $("#modifyWindow #left").text(data.list_button[0].left);
        $("#modifyWindow #right").text(data.list_button[0].right);
        $("#modifyWindow #up").text(data.list_button[0].up);
        $("#modifyWindow #down").text(data.list_button[0].down);
        $("#marker").css("left", dataX[0] * slider.width);
        $("#marker").css("top", (1 - dataX[1]) * slider.height);
        $("#modifyWindow .slider2D").show();
    }];
    switch (dataRange) {
        case 1:
            onFunction[0]();
            break;
        case 2:
            onFunction[1]();
            break;
        case 3:
            onFunction[0]();
            onFunction[1]();
            break;
        case 4:
            onFunction[2]();
            break;
        case 5:
            onFunction[0]();
            onFunction[2]();
            break;
        case 6:
            onFunction[1]();
            onFunction[2]();
            break;
        case 7:
            onFunction[0]();
            onFunction[1]();
            onFunction[2]();
            break;
        case 8:
            onFunction[3]();
            break;
            
    }
    /*if ($(element).data('range-type') == '1D') {
      //set the text value
      $("#modifyWindow #left").text(data.list_button[0].right);
      $("#modifyWindow #right").text(data.list_button[0].left);

    //$("#range1D").val(data_other[$("#modifyWindow .labell").text()] );
      //set the data value
      //$("#modifyWindow .slider .range1D").value = $(element).data('x');
    } else if ($(element).data('range-type') == '2D') {
      $("#modifyWindow #left").text(data.list_button[0].left);
      $("#modifyWindow #right").text(data.list_button[0].right);
      $("#modifyWindow #up").text(data.list_button[0].up);
      $("#modifyWindow #down").text(data.list_button[0].down);

      //set the data value
      $("#modifyWindow .slider .range2DVertical").value = $(element).data('x');
      $("#modifyWindow .slider .range2DHorizontal").value = $(element).data('y');
    }
    if ($(element).data('range-type') == 'RGB1D' || data.list_button.length > 1) {
      //set the text value
      $(".RGBslider #left").text(data.list_button[1].right);
      $(".RGBslider #right").text(data.list_button[1].left);

      //set the data value
      //$("#modifyWindow .slider .range1D").value = $(element).data('x');
    }
    if ($(element).data('range-type') == 'O1D' || data.list_button.length > 2) {
      //set the text value
      $(".Opaslider #left").text(data.list_button[2].right);
      $(".Opaslider #right").text(data.list_button[2].left);

      //set the data value
      //$("#modifyWindow .slider .range1D").value = $(element).data('x');
    }*/
    //set the coord value NEED TO CREATE A FUNCTION THAT WHILE SET VALUE AT EACH MODIFICATION
    //$("#modifyWindow #left").data("x", 0)

    //change the pen icon to close
    $(element).removeClass("fa-pencil-ruler");
    $(element).addClass("fa-times");

    //select the button and blur the other
    $(element).parent().addClass("hovered").addClass("selected");
    $('.facial .selector:not(.selected)').addClass('blur');
    $('.apparence .selector:not(.selected)').addClass('blur');

    //make the slider and the modifyWindow pop
    /*if ($(element).data('range-type') == '1D') {
      $(".range").css("background-color", "#ffffff38");
      $("#modifyWindow .slider").show();
    } else {
        $("#modifyWindow .slider").hide();
    }
      
    if ($(element).data('range-type') == '2D') {
      $("#modifyWindow .slider2D").show();
    } else {
      $("#modifyWindow .slider2D").hide();        
    }
       
    if ($(element).data('range-type') == 'RGB1D' || data.list_button.length > 1) {
      $(".range").css("background-color", "#000000FF");
      $("#modifyWindow .RGBslider").show();
    } else {
      $("#modifyWindow .RGBslider").hide();        
    }
      
    if ($(element).data('range-type') == 'O1D' || data.list_button.length > 2) {
      $(".range").css("background-color", "#000000FF");
      $("#modifyWindow .Opaslider").show();
    } else {
      $("#modifyWindow .Opaslider").hide();        
    }*/
    $("#modifyWindow").fadeIn(100);
  },

  closeRange: function() {
    //the close icon back to pen
    $('.facial .selector.selected .modifyBtn').removeClass("fa-times");
    $('.facial .selector.selected .modifyBtn').addClass("fa-pencil-ruler");
      
    $('.apparence .selector.selected .modifyBtn').removeClass("fa-times");
    $('.apparence .selector.selected .modifyBtn').addClass("fa-pencil-ruler");

    //unblur the other selector
    $('.facial .selector:not(.selected)').removeClass('blur');
    $('.apparence .selector:not(.selected)').removeClass('blur');

    //hide the window and the slider
    $("#modifyWindow").fadeOut(100);
    if ($('.facial .selector.selected .modifyBtn').data('range-type') == '1D') {
      $("#modifyWindow .slider").hide();
        //data_other[$("#modifyWindow .labell").text()] = $("#range1D").val();
        //console.log(data_other[$("#modifyWindow .labell").text()].toString())
        
      //save x in the data attribute
      $(".facial .selector.selected .modifyBtn").data('x', $("#modifyWindow .slider .range1D").val());

    } else if ($('.facial .selector.selected .modifyBtn').data('range-type') == '2D') {
      $("#modifyWindow .slider2D").hide();

      //save x/y in the data attribute
      //$(".facial .selector.selected .modifyBtn").data('x') = $("#modifyWindow .slider .range2DVertical").val();
      //$(".facial .selector.selected .modifyBtn").data('y') = $("#modifyWindow .slider .range2DHorizontal").val();

    }
    //deselect the properties in last
    $('.facial .selector.selected').removeClass("hovered").removeClass("selected");
    $('.apparence .selector.selected').removeClass("hovered").removeClass("selected");
  }
}



/*
Reset Button Event
*/

$(".ResetButton").click(function () {
   mp.trigger("CEFCharacterEditorReset"); 
});

