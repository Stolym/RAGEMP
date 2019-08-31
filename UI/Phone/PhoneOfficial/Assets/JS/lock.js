var lock = true;

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
        $('.lock_clock').text(new Date().getHours()+":"+new Date().getMinutes()+":"+new Date().getSeconds());
    }, 200);
});