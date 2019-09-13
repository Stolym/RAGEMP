var ApplicationIndex = 0;
var CurrentApplication = -1;


var AppData = [

    {
        BackColor: "linear-gradient(0deg, rgba(59,59,59,1) 0%, rgba(170,170,170,1) 100%)",
        Icon: "Assets/Pictures/settings.png",
        Name: "Settings",
    },
    
    {
        BackColor: "linear-gradient(0deg, rgba(29,74,217,1) 0%, rgba(123,187,255,1) 100%)",
        Icon: "Assets/Pictures/phone-book.png",
        Name: "Contact",
    },
    {
        BackColor: "linear-gradient(0deg, rgba(148,149,4,1) 0%, rgba(251,255,60,1) 100%)",
        Icon: "Assets/Pictures/email.png",
        Name: "SMS",
    },
    {
        BackColor: "linear-gradient(0deg, rgba(28,164,53,1) 0%, rgba(85,255,72,1) 100%)",
        Icon: "Assets/Pictures/phone.png",
        Name: "Call",
    },
    {
        BackColor: "linear-gradient(0deg, rgba(97,23,119,1) 0%, rgba(240,118,255,1) 100%)",
        Icon: "Assets/Pictures/collaboration.png",
        Name: "Social",
    },
                
    {
        BackColor: "linear-gradient(0deg, rgba(255,129,51,1) 0%, rgba(255,210,103,1) 100%)",
        Icon: "Assets/Pictures/bank.png",
        Name: "Bank",
    },
    {
        BackColor: "linear-gradient(0deg, rgba(217,59,20,1) 0%, rgba(255,166,149,1) 100%)",
        Icon: "Assets/Pictures/photo-camera.png",
        Name: "Cam",
    },
    {
        BackColor: "linear-gradient(0deg, rgba(217,59,20,1) 0%, rgba(255,166,149,1) 100%)",
        Icon: "Assets/Pictures/photo-camera.png",
        Name: "Snake",
    },
];

var AppRequestData = {
    AppPosition: [0, 1, 2, 3, 4, 5, 6, 7 ],
    Notify: [0, 0, 0, 0, 0, 0, 0, 0 ],
};

var click = {
    x: 0,
    y: 0
};


$(() => {
    UpdateCApplication();
    //REMOVE_APPLICATION();
    SET_CONTAIN_APPLICATION({ size: 15 });
    REQUEST_APP_DATA(JSON.stringify(AppRequestData));
    //$(".application").click(ApplicationClick);
    $(".libutton").click(BottomBarClick);
    //$(".addcontact").click(ClickAddContact);
    //$(".boxmessage").click(ClickMessagerie);
});

function REMOVE_APPLICATION() {
    $(".application").remove();
}

function REQUEST_APP_DATA(json)
{
    console.log(json);
    var data = JSON.parse(json);
    var j = 0;

    if (data == null)
        return;
    REMOVE_APPLICATION();
    for (var i = 0; i < data.AppPosition.length; i++) {
        for (var j = 0; j < 15; j++) {
            if (j == data.AppPosition[i]) 
                ADD_APPLICATION_DATA(GET_CONTAIN_DATA(j),AppData[i], i);
        }
    }
    UPDATE_EVENT_APPLICATION($(".application"));
}

function GET_CONTAIN_DATA(pos)
{
    var $src = null;
    $(".ContainApplication").each(function () {
        if ($(this).data("id") == null)
            return null;
        if ($(this).data("id") == pos)
            $src = $(this);
    });
    return $src;
};

function ADD_APPLICATION_DATA($src, data, id)
{
    $src.append("<div data-id='"+id+"' class='application' style='background: "+data.BackColor+"'><img class='appicon' src='"+data.Icon+"'><p class='appname'>"+data.Name+"</p></div>");
    $(".application").last().css("top", 0);
    $(".application").last().css("left", 0);
}

function UPDATE_EVENT_APPLICATION($src)
{
    $src.unbind("click");
    $src.click(ApplicationClick);
    $src.unbind("draggable");
    $src.draggable({
 
        start: function (event, ui) {
            $(this).data("dropped", false);
            click.x = event.clientX;
            click.y = event.clientY;
        },
        drag: function(event, ui) {

            var zoom = GET_SCALE("body");
    
            var original = ui.originalPosition;
            ui.position = {
                left: (event.clientX - click.x + original.left) / zoom,
                top:  (event.clientY - click.y + original.top ) / zoom
            };
        },
        stop: function (event, ui) {
            if (ui.helper.data("dropped") == false) {
                ui.helper.css("top", "0%");
                ui.helper.css("left", "0%");
            }
        }
    });
}

function SET_CONTAIN_APPLICATION(data) 
{
    for (var i = 0; i < data.size; i++) {
        $(".all_application").append("<div data-id='"+i+"' class='ContainApplication'></div>");
        $(".ContainApplication").last().css("left", 20 + 120 * (i%5).toFixed(0));
        $(".ContainApplication").last().css("top", 550 + 180 * RoundFixed(i/5));
    }
    $(".ContainApplication").unbind("droppable");
    $(".ContainApplication").droppable({
        drop: function(event, ui) {
            if ($(this).children(".application").length != 0)
                return;
            ui.draggable.data("dropped", true);
            AppRequestData.AppPosition[ui.draggable.data("id")] = $(this).data("id");
            REQUEST_APP_DATA(JSON.stringify(AppRequestData));
        },
        over: function(event, ui) {
            $(this).css('background', '#FFFFFF40');
            $(this).css('border-radius', 20);
        },
        out: function(event, ui) {
            $(this).css('background', '#11111100');
        }
    });
}

function UpdateCApplication(bool = true) {
    $(".capplication").each(function (index) {
        if (bool == true)
            $(this).hide();
        else
            $(this).fadeOut(1000);
    });
}

function ClickMessagerie() {
    ApplicationIndex++;
    UpdateApplication();
    $(".capplication").each(function (index) {
       if ($(this).data("id") == CurrentApplication) {
           if ($(this).children(".multiscreen").length != 0)
               UpdateMultiScreen($(this));
           $(this).fadeIn(500);
       } else {
            $(this).fadeOut(500);
       }
    });
}


function BottomBarClick() {
    if ($(this).data("id") == null)
        return;
    switch ($(this).data("id")) {
        case 0:
            if (ApplicationIndex > 1) {
                ApplicationIndex--;
                UpdateApplication();
                $(".capplication").each(function (index) {
                   if ($(this).data("id") == CurrentApplication) {
                       if ($(this).children(".multiscreen").length != 0)
                           UpdateMultiScreen($(this));
                       $(this).fadeIn(500);
                   } else {
                        $(this).fadeOut(500);
                   }
                });
            } else {
                UpdateCApplication(false);
                UpdateApplication(true);
                ApplicationIndex = 0;
            }
            break;
        case 1:
            UpdateCApplication(false);
            UpdateApplication(true);
            ApplicationIndex = 0;
            break;
        case 2:
            break;
            
    }
}

function UpdateApplication(bool) {
    
    $(".application").each(function (index) {
        if (bool == true)
            $(this).fadeIn(1000);
        else
            $(this).fadeOut(500);
    });
    if (bool == true)
        $(".widget").fadeIn(1000);
    else
        $(".widget").fadeOut(500);
}

function UpdateMultiScreen(object) {
    object.children(".multiscreen").each(function (index) {
       if ($(this).data("id") == ApplicationIndex - 1) {
            $(this).show();
       } else {
            $(this).hide();
       }
    });
}

function ClickAddContact() {
    ApplicationIndex++;
    UpdateApplication();
    $(".capplication").each(function (index) {
       if ($(this).data("id") == CurrentApplication) {
           if ($(this).children(".multiscreen").length != 0)
               UpdateMultiScreen($(this));
           $(this).fadeIn(500);
       } else {
            $(this).fadeOut(500);
       }
    });
}

function ApplicationClick() {
    ApplicationIndex++;
    UpdateApplication();
    CurrentApplication = $(this).data("id");
    $(".capplication").each(function (index) {
       if ($(this).data("id") == CurrentApplication) {
           if ($(this).children(".multiscreen").length != 0)
               UpdateMultiScreen($(this));
           $(this).fadeIn(500);
       } else {
            $(this).fadeOut(500);
       }
    });
}


function RoundFixed(value) {
    var data = value.toString()[0];
    value = parseFloat(data);
    return value;
}