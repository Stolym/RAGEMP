var ApplicationIndex = 0;
var CurrentApplication = -1;


$(() => {
    UpdateCApplication();
    $(".application").each(function (index) {
       $(this).css("left", 20 + 48 * (index%5).toFixed(0)); 
       $(this).css("top", 320 + 60 * RoundFixed(index/5)); 
    });
    $(".application").click(ApplicationClick);
    $(".libutton").click(BottomBarClick);
    $(".addcontact").click(ClickAddContact);
    $(".boxmessage").click(ClickMessagerie);
});

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