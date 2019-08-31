var json_data = {
    name: "Jessica",
    lastname: "Marno",
    nat: "Italien",
    birth: "29/03/92",
    from_birth: "Rome",
    sex: "F",
    height: "6 feet",
    del: "01/01/21",
    exp: "01/01/24",
};

function display(json) {
    var data = JSON.parse(json);
    
   $("button").css( "opacity", "0");
   $("button").css( "pointer-events", "none");
   $("input").css( "opacity", "0");
   $("input").css( "pointer-events", "none");
   $("p").css( "opacity", "1");
   $("p").css( "pointer-events", "auto");
    if (data == null)
        return;
    $(".Name_Input").text(data.lastname);
    $(".Prenom_Input").text(data.name);
    $(".Nationnal_Input").text(data.nat);
    $(".Birth_Input").text(data.birth);
    $(".From_Birth_Input").text(data.from_birth);
    $(".Sex").text(data.sex);
    $(".Height").text(data.height);
    $(".Del").text(data.del);
    $(".Exp").text(data.exp);
}

function input() {
   $("input").css( "opacity", "1");
   $("input").css( "pointer-events", "auto");
   $("button").css( "opacity", "1");
   $("button").css( "pointer-events", "auto");
   $("button").css( "transition", "500ms");
   $("p").css( "opacity", "0");
   $("p").css( "pointer-events", "none");
}

$(function () {
   $("p").css( "opacity", "0");
   $("p").css( "pointer-events", "none");
    
   $("input").css( "opacity", "0");
   $("input").css( "pointer-events", "none");
    
    
   $("button").css( "transition", "0ms");
   $("button").css( "opacity", "0");
   $("button").css( "pointer-events", "none");
});

function Send() {
    json_data.lastname = $(".Name_Input").val();
    json_data.name = $(".Prenom_Input").val();
    json_data.nat = $(".Nationnal_Input").val();
    json_data.birth = $(".Birth_Input").val();
    json_data.from_birth = $(".From_Birth_Input").val();
    
    
    if (json_data.lastname.length < 3 ||
        json_data.name.length < 3 ||
        json_data.nat.length < 3 ||
        json_data.birth.length < 3 ||
        json_data.from_birth.length < 3)
        mp.trigger("CEFNotify", "Input invalid veuillez insérez 3 caractère minimum");
    else
        mp.trigger("setIDCharacter", JSON.stringify(json_data));
}
