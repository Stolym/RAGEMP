
/*

Data to player after analyze


*/

var receiveAnalyze = {
    Success: true,
    body: [false, true, false,false, true, false,false, true, false,false, true, false ],
    CanHealthOnPlace: true,
}


//Receive Analyze
function ReceiveAnalyzePlayer(json) {
    var data = JSON.parse(json);
    ClearBalPinOther();
    AddNewBalPinOther(data);
    ActiveButton(data.CanHealthOnPlace);
}

//Clear Balise P in Other
function ClearBalPinOther() {
    $(".analyze").remove();
}

//Add New Balise P in Other
function AddNewBalPinOther(data) {
    $(".other").append("<p class='analyze'>Success Analyze : "+data.Success.toString()+"</p>");
    $(".other").append("<p class='analyze'>Vous pouvez soigner le patient sur place : "+data.CanHealthOnPlace.toString()+"</p>");
    
}

//Active Button Health
function ActiveButton(onOff) {
    
    
}


    
//Analyze
function AnalyzeButton() {
    $(".Analyze").click(function () {
       //Trigger event analyze player 
    });
}

//Heatlh Player
function HealthButton() {
    $(".Health").click(function () {
        //Trigger event Health
    });
}




$(function () {
    AnalyzeButton();
    ReceiveAnalyzePlayer(JSON.stringify(receiveAnalyze));
    $(".svgbodypart").attr("fill", "#FFFFFF");
    $("#dos").attr("fill", "#00FF00");
    $("#ventre").attr("fill", "#00FF00");
    $("#tete").attr("fill", "#00FF00");
    $("#cou").attr("fill", "#00FF00");
    $("#brasgauche").attr("fill", "#00FF00");
    $("#brasdroit").attr("fill", "#00FF00");
    $("#torse").attr("fill", "#00FF00");
    $("#jambegauche").attr("fill", "#00FF00");
    $("#jambedroite").attr("fill", "#00FF00");
})