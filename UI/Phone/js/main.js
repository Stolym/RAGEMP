var list_application = [];
var list_contact = [];
var current_number = "--";
var current_background = "https://ksassets.timeincuk.net/wp/uploads/sites/54/2019/03/Samsung-Galaxy-S10-Plus-Bender-hole-punch-wallpaper-485x1024.png";

var setting = {
    name: "Settings",
    img: "./logo/setting.svg",
    active: false,
    index: 0,
};

var call = {
    name: "Appel",
    img: "./logo/call.svg",
    active: false,
    index: 0,
};

var contact = {
    name: "Contact",
    img: "./logo/contact.svg",
    active: false,
    index: 0,
};

var photo = {
    name: "Picture",
    img: "./logo/photo.svg",
    active: false,
    index: 0,
};

var sms = {
    name: "Sms",
    img: "./logo/messenger.svg",
    active: false,  
    index: 0,
};

function push_application() {
    list_application.push(setting);
    list_application.push(call);
    list_application.push(contact);
    list_application.push(photo);
    list_application.push(sms);
}
push_application();

function set_bool_to_all_applications(value) {
    for (var i = 0; i < list_application.length; i++) {
        list_application[i].active = value;
    }
}

function application_manager(index, value) {
    $(".current_application").hide();
    $(".current_application").show();
    $(".application").each(function (i) {
       if ($(this).data("id") == index) {
           if (value == true) {
               $(this).show();
               $(".slot").hide();
               $(".widget").hide();
           } else if (value == false) {
               $(this).hide();
           }
       }
    });
}

function update_all_applications() {
    for (var i = 0; i < list_application.length; i++) {
        application_manager(i, list_application[i].active);
    }
}


function update_all_page(index, app) {
    switch (index) {
        case 0:
            break;
        case 1:
            $(".cpage").each(function (i) {
                if (app.index == i)
                    $(this).show();
                else
                    $(this).hide();
            });
            break;
        case 2:
            $(".capage").each(function (i) {
                if (app.index == i)
                    $(this).show();
                else
                    $(this).hide();
            });
            break;
        case 3:
            break;
        case 4:
            $(".spage").each(function (i) {
                if (app.index == i)
                    $(this).show();
                else
                    $(this).hide();
            });
            break;
    }
}

function update_active_applications() {
    for (var i = 0; i < list_application.length; i++) {
        if (list_application[i].active== true) {
            update_all_page(i, list_application[i]);
        }
    }
}


function increment_active_applications(value) {
    for (var i = 0; i < list_application.length; i++) {
        if (list_application[i].active== true) {
            list_application[i].index = value;
        }
    }
}

function make_list_application() {
    for (var i = 0; i < list_application.length; i++) {
        $(".applications").append("<div  data-id='"+i+"' data-enabled='"+list_application[i].active+"' class='slot'><img class='icon' src='"+list_application[i].img+"'></div>");
        var last_slot = $(".slot").last();
        switch (i) {
            case 0:
                last_slot.css("left", "75%");
                last_slot.css("top", "75%");
                break;
            case 1:
                last_slot.css("left", "50%");
                last_slot.css("top", "75%");
                break;
            case 2:
                last_slot.css("left", "25%");
                last_slot.css("top", "75%");
                break;
            case 3:
                last_slot.css("left", "0%");
                last_slot.css("top", "50%");
                break;
            case 4:
                last_slot.css("left", "0%");
                last_slot.css("top", "75%");
                break;
        }
    }
}



function getClockTime()
{
    
   var now    = new Date();
   var hour   = now.getHours();
   var minute = now.getMinutes();
   var second = now.getSeconds();
   if (hour   > 12) { hour = hour - 12;      }
   if (hour   == 0) { hour = 12;             }
   if (minute < 10) { minute = "0" + minute; }
   var timeString = hour+':'+minute+':'+second;
   document.getElementById('Clock').textContent = timeString;
}

function get_active() {
    for (var i = 0; i < list_application.length; i++) {
        if (list_application[i].active == true && list_application[i].index != 0) {
            return list_application[i];
        }
    }
    return (null);
}

function add_contact_letter() {
    for (var i = 0; i < 26; i++) {
        $(".listcontact").append("<p class='lcletter'>"+String.fromCharCode(i+65)+"</p>");
    }
}

function update_ca_number() {
    $(".ca").each(function (i) {
        if ($(this).data("id") != null) {
            if ($(this).data("id") == "number") {
                $(this).text(current_number);
            }
        }
    });
}

function insert_key(letter) {
    var size = current_number.length;
    if (size >= 11)
        return;
    var u = ((size - 3) / 3).toFixed(0);
    var r = u * 4;
    var ra = current_number.slice(r, size);
    var rb = current_number.slice(0, r);
    rb += letter;
    rb += ra;
    current_number = rb;
}


function init()
{
    $(".cbutton").click(function () {
       switch ($(this).data("id")) {
            case 0:
               
                set_bool_to_all_applications(false);
                list_application[2].active = true;
                update_all_applications();
                increment_active_applications(1);
                update_active_applications();
               break;   
            case 1:
                set_bool_to_all_applications(false);
                list_application[4].active = true;
                update_all_applications();
                increment_active_applications(1);
                update_active_applications();
               break;
            case 2:
               break;    
       } 
    });
    
    $(".csms").click(function () {
        increment_active_applications(1);
        update_active_applications();
    });
    
    $(".acontact").click(function () {
        increment_active_applications(1);
        update_active_applications();
    });
    
    $(".tocall").click(function () {
        increment_active_applications(1);
        update_active_applications();
    });
    $(".sbutton").click(function () {
        var input = $(".sinput").val();
        current_background = input;
        $("#screen").attr("src", current_background);
    });
    $(".cfunction").click(function () {
       if ($(this).data("key") != null) {
           switch ($(this).data("key")) {
               case "R":
                   current_number = "--";
                   update_ca_number();
                   break;
               default:
                   insert_key($(this).data("key"));
                   update_ca_number();
                   break;
           }
       } 
    });
    
    add_contact_letter();
    getClockTime();
    setInterval(getClockTime,1000);
    make_list_application();
    $(".slot").click(function () {
        set_bool_to_all_applications(false);
        list_application[$(this).data("id")].active = true;
        update_all_applications();
        update_active_applications();
    });
    $(".effect").click(function () {
       switch ($(this).data("name")) {
           case "Retour":
               var data = get_active();
               if (data == null) {
                   set_bool_to_all_applications(false);
                   update_all_applications();
                   $(".slot").show();
                   $(".widget").show();
               } else {
                increment_active_applications(data.index - 1);
                update_active_applications();
               }
               break;
           case "Home":
               
                increment_active_applications(0);
               set_bool_to_all_applications(false);
               update_all_applications();
               update_active_applications();

               $(".slot").show();
               $(".widget").show();
               break;
           case "List":
               break;
       } 
    });
}


$(() => {
    init();
    set_bool_to_all_applications(false);
    update_active_applications();
    update_all_applications();
    
});