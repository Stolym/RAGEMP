var lock = true;
var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
var months = ['January', 'Febuary', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
UpdateScreenLock();

function UpdateScreenLock() {
    if (lock == true) {
        $(".screen_locked").show();
        $(".screen_unlocked").hide();
        $(".topbar").hide();
        $(".all_application").hide();
        $(".widget").hide();
        $(".bottombar").hide();
        $(".lock").show();
    } else {
        $(".screen_unlocked").fadeIn(1500);
        $(".all_application").fadeIn(1500);
        $(".widget").fadeIn(1300);
        $(".topbar").fadeIn(1500);
        $(".bottombar").fadeIn(1500);
        $(".screen_locked").fadeOut(500);
        $(".lock").fadeOut(500);
    }
}

function UnlockClick() {
    lock = false;
    UpdateScreenLock();
}

$(() => {
   $(".unlock_button").click(UnlockClick);
    setInterval(function() {
        $(".lock_clock").each(function (index) {
            if ($(this).data("id") == null)
                return;
            var date = new Date();
            switch ($(this).data("id")) {
                case "clock":
                    $(this).text(date.getHours()+":"+date.getMinutes());
                break;
                case "day":
                    $(this).text(days[date.getDay()]);
                break;
                case "month":
                    $(this).text(months[date.getMonth()]);
                break;
            }
        });
    }, 200);
});