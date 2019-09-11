

/*

Action Index

-- Player 0

Carte Bancaire 1
Donner de l'argent 2
Donner un Object 2
Inventaire 4
Fouillez 5
presenterPapiersCivils 8
presenterPapiersPolice 9
presenterPapiersWeapon 10
Saluer 11
Danser 12
S'asseoir 13
Mettre Dans la voiture 14
Mettre Dans le Coffre 15
Soigner 16
Arrest 17
Ouvrir fermer une porte 18
Métier 19
Telephone 20
Micro Volume 21


-- Vehicle 1

Ouvrir Fermer vehicle 0
Ouvrir Fermer Porte vehicle 1
Ouvrir Fermer Coffre vehicle 2
Custom Vehicle 3
Repair Vehicle 4


-- Item 2

Get Item 0


*/
/*
public enum InteractionFlags {
            OwnInventory,
            ClosestCarInventory,
            GetClosestPlant,
            GetClosestObject,
            CheckClosestPlayer,
            GiveIdCardClosestPlayer,
            GiveDriveCardClosestPlayer,
            GiveLSPDCardClosestPlayer,
            GiveLSDHCardClosestPlayer,
            GiveCarCardClosestPlayer,
            ClosestObjectInventory,
            OpenHouse,
            CloseHouse,
            RingHouse,
            OpenCar,
            CloseCar,
            OpenDoorCar,
            CloseDoorCar,
            CloseBootCar,
            OpenBootCar,
            OnEngineCar,
            OffEngineCar,
            OnLightCar,
            OffLightCar,
            OnRadarCar,
            OffRadarCar,
            OffRadioCar,
            OnRadioCar,
            OnJobsAction,
            OffJobsAction,
            OffJobsService,
            OnJobsService,
            OnJobsComputer,
            OffJobsComputer,
            SeatChair,
            UnSeatChair,
            OpenDoorOutside,
            CloseDoorOutside,
        }*/

 var actions = {
        ListAction: [ 
        { text: "Inventaire", icon: "chairdown.png" },
        { text: "Closest\nCar\nInventory", icon: "chairdown.png" },
        { text: "Get\nClosest\nPlant", icon: "chairdown.png" },
        { text: "GetClosestObject", icon: "getobject.png" },
        { text: "CheckClosestPlayer", icon: "getobject.png" },
        { text: "GiveIdCardClosestPlayer", icon: "papierscivil.png" },
        { text: "GiveDriveCardClosestPlayer", icon: "papierscivil.png" },
        { text: "GiveLSPDCardClosestPlayer", icon: "papierspolice.png" },
        { text: "GiveLSDHCardClosestPlayer", icon: "papierspolice.png" },
        { text: "GiveCarCardClosestPlayer", icon: "papierscivil.png" },
        { text: "ClosestObjectInventory", icon: "papierspolice.png" },
        { text: "OpenHouse", icon: "papierspolice.png" },
        { text: "CloseHouse", icon: "papierscivil.png" },
        { text: "RingHouse", icon: "papierspolice.png" },
        { text: "OpenCar", icon: "papierspolice.png" },
        { text: "CloseCar", icon: "papierscivil.png" },
        { text: "OpenDoorCar", icon: "papierspolice.png" },
        { text: "CloseDoorCar", icon: "papierspolice.png" },
        { text: "CloseBootCar", icon: "papierspolice.png" },
        { text: "OpenBootCar", icon: "papierscivil.png" },
        { text: "OnEngineCar", icon: "papierspolice.png" },
        { text: "OffEngineCar", icon: "papierspolice.png" },
        { text: "OnLightCar", icon: "papierspolice.png" },
        { text: "OffLightCar", icon: "papierscivil.png" },
        { text: "OnRadarCar", icon: "papierspolice.png" },
        { text: "OffRadarCar", icon: "papierspolice.png" },
        { text: "OffRadioCar", icon: "papierspolice.png" },
        { text: "OnRadioCar", icon: "papierspolice.png" },
        { text: "OnJobsAction", icon: "papierspolice.png" },
        { text: "OffJobsAction", icon: "papierspolice.png" },
        { text: "OffJobsService", icon: "papierspolice.png" },
        { text: "OnJobsService", icon: "papierspolice.png" },
        { text: "OnJobsComputer", icon: "papierspolice.png" },
        { text: "OffJobsComputer", icon: "papierspolice.png" },
        { text: "SeatChair", icon: "papierspolice.png" },
        { text: "UnSeatChair", icon: "papierspolice.png" },
        { text: "OpenDoorOutside", icon: "papierspolice.png" },
        { text: "CloseDoorOutside", icon: "papierspolice.png" },
        ]
};



var data_f = {
    ListCommand: [ 0, 1, 2, 0, 0, 0, 0, 0, 9 ],
};



function ActiveButton(index, bool = false) {
    if (bool == true)
        $("#c"+index).show();
    else
        $("#c"+index).hide();
}


function SetDataButton(index, value)
{
    $("#co"+index).unbind("click");
    $("#co"+index).unbind("mouseenter");
    $("#co"+index).unbind("mouseleave");
    $("#co"+index).data("descriptor", actions.ListAction[value].text);
    $("#co"+index).data("text", actions.ListAction[value].text);
    $("#co"+index).data("id", index.toString());
    $("#co"+index).data("value", value);
    
    $("#i"+index).attr("href", "assets/Blanc/" + actions.ListAction[value].icon);
    $("#co"+index).mouseenter(function () {
        $("#i"+$(this).data("id")).attr("href", "assets/Blue/" + actions.ListAction[value].icon);
        $("#middletext").html($(this).data("text").split("\n").join("<br/>"));
    });
    $("#co"+index).mouseleave(function () {
        $("#i"+$(this).data("id")).attr("href", "assets/Blanc/" + actions.ListAction[value].icon);
        $("#middletext").html("");
    });
    $("#co"+index).click(function () {
        alert($(this).data("value"));
    })
}

function AllActiveButton(bool)
{
    for (var i = 1; i < 9; i++)
        ActiveButton(i);
}

var bool_menu = false;


function ACTIVE_SUB_MENU(bool, color) {
    if (bool == true) {
        switch (color) {
            case 0:
                $(".expand").css("fill", "#494949FF");
            break;
            case 1:
                $(".expand").css("fill", "#4848D8FF");
            break;
        }
        $(".collapse").css("fill", "#49494900");
    }
    if (bool == false) {
        switch (color) {
            case 0:
                $(".collapse").css("fill", "#494949FF");
            break;
            case 1:
                $(".collapse").css("fill", "#4848D8FF");
            break;
        }
        $(".expand").css("fill", "#49494900");
    }
}

var sub_menu = true;

function SUB_MENU_GESTION() {
    $(".g_box").each(function () {
        if ($(this).data("id") == 8) {
            $(this).css("opacity", "0");
        }
    });
    $("#i8").hide();
    ACTIVE_SUB_MENU(sub_menu, 0);
    $(".g_box").each(function () {
        $(this).css("filter", "url(#dropshadow)");
    });
    $("#co8").mouseenter(function () {
        ACTIVE_SUB_MENU(sub_menu, 1);
        
        $("#middletext").html("Autres\nActions".split("\n").join("<br/>"));
    });
    $("#co8").mouseleave(function () {
        ACTIVE_SUB_MENU(sub_menu, 0);
        $("#middletext").html("");
    });
    $("#co8").click(function () {
        sub_menu = !sub_menu;
        ACTIVE_SUB_MENU(sub_menu, 1);
        
    })
}

function LIST_ACTION_SUB_MENU(data) {

}

function UpdateButtonAction(json) {
    var data = JSON.parse(json);
    
    AllActiveButton(false);
    if (data.ListCommand.length < 9) {
        for (var i = 0; i < data.ListCommand.length; i++) {
            ActiveButton(i + 1, true);
            SetDataButton(i + 1, data.ListCommand[i]);
        }
    } else {
        for (var i = 0; i < 7; i++) {
            ActiveButton(i + 1, true);
            SetDataButton(i + 1, data.ListCommand[i]);
        }
        ActiveButton(8, true);
        SUB_MENU_GESTION();
    }
}

$(() => {
    UpdateButtonAction(JSON.stringify(data_f));
});


function_ret = {
    "inventaire":[ 4, 0 ],
    "utiliserCB":[ 6, 0 ],
    "fermerVoiture":[ 0, 1 ],
    "donnerArgent":[ 5, 0 ],
    "donnerObjet":[ 7, 0 ],
    "coffreVoiture":[ 1, 1 ],
    "presenterPapiersCivils":[ 8, 0 ],
    /*"presenterPapiersPolice":[ 9, 0 ],
    "ouvrirVoiture":[ 0, 0 ],
    "coffreVoiture":[ 1, 0 ],
    "GetObject":[ 0, 2 ],
    "Saluer":[ 9, 0 ],
    "OuvrirLaPorte":0,
    "Reload":6,
    "Danser":2,
    "S'assoir":3,*/
}



/*menu([
    "inventaire",
    "utiliserCB",
    "fermerVoiture",
    "donnerArgent",
    "donnerObjet",
    "coffreVoiture",
    "presenterPapiersCivils",
    "presenterPapiersPolice",
    /*"ouvrirVoiture",
    "coffreVoiture",
    "GetObject",
    "Saluer",
    "OuvrirLaPorte",
    "Reload",
    "Danser",
    "S'assoir",
]);*/

function voidfunct(e){
    mp.trigger("CallActionCEFtoClient", function_ret[e.currentTarget.dataset.descriptor], 1);
    
    //alert("choix : "+function_ret[e.currentTarget.dataset.descriptor]);
}


/*OverMenu(JSON.stringify([
    "Inventory",
    "LockVehicle",
    "EngineVehicle",
    "CheckWithPartner",
    "OpenContainInventory",
    "PresentIdCard",
    "PresentLSPDCard",
    "PresentLSDHCard",
    "GetObject",
]));*/

/*
function OverMenu(json) {
    var ListAction = JSON.parse(json);
    
    
    
}*/


function menu(actionsList) {

   
    for (var i=0; i<7; i++) {
        var btn = document.getElementById(`c${i+1}`);

        if (i<Math.min(actionsList.length)) {
            btn.dataset.disabled = false;
            btn.dataset.descriptor = actionsList[i];
            btn.dataset.text = actions[actionsList[i]].text;

            btn.addEventListener("click", function(e){
                e.stopPropagation();
                actions[e.currentTarget.dataset.descriptor].funct(e);
            }, true);
            
            btn.addEventListener("mouseenter", function(e){
                e.stopPropagation();
                document.getElementById('middletext').innerHTML = e.currentTarget.dataset.text.split("\n").join("<br/>");
                e.currentTarget.lastElementChild.setAttribute('href', "assets/Blue/"+actions[e.currentTarget.dataset.descriptor].icon);
            }, true);

            btn.addEventListener("mouseleave", function(e){
                e.stopPropagation();
                document.getElementById('middletext').innerHTML = "";
                e.currentTarget.lastElementChild.setAttribute('href', "assets/Blanc/"+actions[e.currentTarget.dataset.descriptor].icon);
            }, true);

            btn.lastElementChild.setAttribute('href', "assets/Blanc/"+actions[actionsList[i]].icon);
        }
        else {
            btn.addEventListener("mouseenter", function(e){
                e.stopPropagation();
                document.getElementById('middletext').innerHTML = "Indisponible";
            }, true);

            btn.addEventListener("mouseleave", function(e){
                e.stopPropagation();
                document.getElementById('middletext').innerHTML = "";
            }, true);
        }
    }

    var btn = document.getElementById("cl");

    if (actionsList.length <= 7) {
        btn.addEventListener("mouseenter", function(e){
            e.stopPropagation();
            document.getElementById('middletext').innerHTML = "Indisponible";
        }, true);

        btn.addEventListener("mouseleave", function(e){
            e.stopPropagation();
            document.getElementById('middletext').innerHTML = "";
        }, true);
    }

    else {
        btn.dataset.disabled = false;
        btn.firstElementChild.setAttribute("style", "fill-opacity: 0");
        btn.lastElementChild.setAttribute("style", "fill-opacity: 100%");

        var submenu = document.getElementById("subMenu");
        var collapsed = submenu.style.height == "0px";

        btn.addEventListener("click", function(e){
            e.stopPropagation();
            collapsed = submenu.classList.contains("collapsed");
            submenu.classList.toggle("collapsed");
            document.getElementById("collapse").dataset.disabled = !collapsed;
            document.getElementById("expand").dataset.disabled = collapsed;
        })


        btn.addEventListener("mouseenter", function(e){
            e.stopPropagation();
            document.getElementById('middletext').innerHTML = collapsed ? "Moins<br>d'options" : "Plus<br>d'options";
        }, true);

        btn.addEventListener("mouseleave", function(e){
            e.stopPropagation();
            document.getElementById('middletext').innerHTML = "";
        }, true);

        
        
        for (var i=7; i< actionsList.length; i++) {
            var activeContainer;

            if ((i-7)%5===0) {
                activeContainer = document.createElement('div');
                activeContainer.setAttribute('class', 'subMenuLine');
                document.getElementById("subMenu").appendChild(activeContainer);
            }
            
            var btn = document.createElement('div');
            btn.setAttribute('class', 'subMenuItem');
            btn.dataset.descriptor = actionsList[i];
            btn.dataset.text = actions[actionsList[i]].text;
            
            btn.addEventListener("click", function(e){
                e.stopPropagation();
                actions[e.currentTarget.dataset.descriptor].funct(e);
            }, true);
            
            btn.addEventListener("mouseenter", function(e){
                e.stopPropagation();
                if (e.currentTarget === e.target) {
                    document.getElementById('middletext').innerHTML = e.currentTarget.dataset.text.split("\n").join("<br/>");
                    e.currentTarget.firstChild.setAttribute('src', "assets/Blue/"+actions[e.currentTarget.dataset.descriptor].icon);
                }
            }, true);
            
            btn.addEventListener("mouseleave", function(e){
                e.stopPropagation();
                if (e.currentTarget === e.target) {
                    document.getElementById('middletext').innerHTML = "";
                    e.currentTarget.firstChild.setAttribute('src', "assets/Blanc/"+actions[e.currentTarget.dataset.descriptor].icon);
                }
            }, true);
            
            var img = document.createElement('img');
            img.setAttribute('class', 'icon');
            img.setAttribute('src', "assets/Blanc/"+actions[actionsList[i]].icon);
            btn.appendChild(img);
            
            activeContainer.appendChild(btn);
        }
    }
};