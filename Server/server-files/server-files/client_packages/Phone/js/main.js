







var background = "url";

var single_history = { from: "xxxx", to: "yyyy", id: 0, hashcode: 0x0, time:"09/23/85" }
var single_message = { from: "xxxx", to: "yyyy", id: 0, hashcode: 0x0, sms:"Comment ça vas ?"}

var single_contact = {
    name:"",
    lastname: "",
    number:"",
    email:"",
    description:"",
    sms:[],
    call_history:[],    
}

var current_contact = 0x0;



var list_contact = []
var list_function = []
var list_bool = [false, false, false, false ]
var application_name = [ "message_application", "chat_message", "contact_creator", "id_contact"]

function show(name, b) {
    if (b) {
        $("."+name).fadeTo( "slow" , 1, function() {
            $(this).removeClass("disabledbutton");
        });
    } else {
        
        $("."+name).fadeTo( "slow" , 0, function() {
            $(this).addClass("disabledbutton");
        });
    }
}

function create_contact() {
    
}

function print_all_contact() {
    for (var i = 0 ; i < list_contact.length; i++) {
        var data = JSON.parse(list_contact[i]);
        console.log("Name :"+data.name+" Number :"+data.number);
    }
    
}


function manager_application(index) {
    list_function[index]();
}



var menu = false;
var iterator = 0;

$(".send_message").click(function () {
   console.log("pass"); 
});


function gestion_application() {
    $(".list_application").append("<div class='application' id='messenger'></div>");
    $(".list_application").append("<div class='application' id='contact'></div>");
    $(".list_application").append("<div class='application' id='call'></div>"); 
    $("#contact").css("margin-left", "135px");
    $("#call").css("margin-left", "20px");
    $("#messenger").css("margin-left", "255px");
    $("#contact").click(function () {
       list_bool[0] = true;
        update();
    });
    $("#call").click(function () {
       list_bool[3] = true;
        update();
    });
    $("#messenger").click(function () {
       list_bool[1] = true;
        update();
    });
}

function update() {
    $( ".application" ).fadeTo( "slow" , 1, function() {
        $(this).removeClass("disabledbutton");
    });
    for (var i = 0; i < list_bool.length; i++) {
        if (list_bool[i]) {
            $( ".application" ).fadeTo( "slow" , 0, function() {
                $(this).addClass("disabledbutton");
            });
        }
            show(application_name[i], list_bool[i]);
    }
    
}

$(function () {
   console.log("Ready");
    
    gestion_application();
    update();
    $(".button_number").click(function () {
        $(".number_contact").text($(".number_contact").text()+$(this).text());
    });
    $(".add_contact").click(function () {
        for (var i = 0; i < list_bool.length; i++)
            list_bool[i] = false;
        list_bool[2] = true;
        update();
    });
    $(".button_creator").click(function () {
        var data = { name:$("#character").val(), number:$("#number").val() };
        $(".phone_border").css("background-image", "url("+data.number+")");
        list_contact.push(JSON.stringify(data));
        print_all_contact();
    });
    $(".back_button").click(function (){
        for (var i = 0; i < list_bool.length; i++)
            list_bool[i] = false;
        update();
    });
});


function getClockTime()
{
    
   var now    = new Date();
   var hour   = now.getHours();
   var minute = now.getMinutes();
   var second = now.getSeconds();
   if (hour   > 12) { hour = hour - 12;      }
   if (hour   == 0) { hour = 12;             }
   if (minute < 10) { minute = "0" + minute; }
   var timeString = "Clock "+hour+':'+minute+':'+second;
   document.getElementById('clock').textContent = timeString;
}

init();



function update_anim_calling() {
    if ($(".loading").text().length > 6)
        $(".loading").text(".");
    else
        $(".loading").text($(".loading").text()+".");
}



function init()
{
    getClockTime();
    setInterval(getClockTime,1000);
    setInterval(update_anim_calling,100);
}
