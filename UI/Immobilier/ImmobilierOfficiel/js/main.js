var menu = [false, false, false, false, false, false, false, false, false, false];

var index_nav_side = -1;


function SetAllMenu(value) {
    for (var i = 0; i < menu.length; i++) {
        menu[i] = value;
    }
}

function UpdateMenu() {
    $(".submenu").each(function (index) {
        if (menu[$(this).data("id")] == true) {
            $(this).show();
            //$(this).css("opacity", "1");
        }
        else {
            $(this).hide();
            //$(this).css("opacity", "0");
        }
    });
}



function UpdateNavSide() {
    $(".historyspace").each(function (index) {
        if ($(this).data("id") == null)
            return;
        if ($(this).data("id") == index_nav_side)
            $(this).show();
        else
            $(this).hide();

    });
}


$(() => {
    UpdateNavSide();
    
    $(".navsideselector").click(function () {
       index_nav_side = $(this).data("id");
        UpdateNavSide();
    });
    $(".transacbutton").click(function () {
       if ($(this).data("id") == null)
           return;
        SetAllMenu(false);
        UpdateMenu();
    });
    $(".transacttest").hide();
    $(".transacttest").show();
    $("transactionhistoryspace").show();
    
    $(".condanation").click(function () {
       $(this).data("enable", !$(this).data("enable")); 
        if ($(this).data("enable") == true) {
            $(this).children(".ctext").show();
            $(this).children(".ctext").css("opacity", "1");
            $(this).css("height", "40%");
        } else if ($(this).data("enable") == false) {
            $(this).css("height", "8%");
            $(this).children(".ctext").css("opacity", "0");
            $(this).children(".ctext").hide();
        }
    });
    
    $(".close").click(function () {
        SetAllMenu(false);
        UpdateMenu();
    });
    
    $(".selector").click(function () {
        SetAllMenu(false);
        menu[$(this).data("id")] = true;
        UpdateMenu();
    });
    
    
    $(".add_account").click(function () {
        SetAllMenu(false);
        
        if ($(this).data("id") != 4)
            menu[$(this).data("id")] = true;
        else if ($(this).data("id") == 4) {
            menu[0] = true;
        }
        UpdateMenu();
    });
    
    
    $(".add_button").click(function () {
        SetAllMenu(false);
        menu[$(this).data("id")] = true;
        UpdateMenu();
    });
    
    
    $(".open").click(function () {
        SetAllMenu(false);
        switch ($(this).data("id")) {
            case 0:
                menu[3] = true;
                break;
            case 1:
                menu[3] = true;
                break;
            case 2:
                menu[1] = true;
                break;
            case 3:
                menu[2] = true;
                break;
        
        
            case 4:
                menu[8] = true;
                break;
            case 5:
                menu[9] = true;
                break;
            case 7:
                menu[7] = true;
                break;
        }
        UpdateMenu();
    });
    
    
    
    UpdateMenu();
});