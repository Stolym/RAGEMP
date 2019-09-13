var Animate = true;
var AnimateB = true;

$(function () {
    ANIMATION_PWIDGET(Animate);
    ANIMATION_TWIDGET(AnimateB);
    $(".widgetfrontpolitics").mouseover(function() {
        $(this).css("background-color", "rgba(255,255,255,0.2)");
        $(".widgetpolitics").css("transition", "500ms");
        $(".widgetpolitics").css("height", "330px");
        $(".widgettrading").css("top", "340px");
        if (Animate == true) {
            Animate = false;
        } else 
            Animate = true;
        ANIMATION_PWIDGET(Animate);
    });
    $(".widgetfrontpolitics").mouseout(function() {
        $(this).css("background-color", "rgba(255,255,255,0.0)");
        $(".widgetpolitics").css("height", "80px");
        setTimeout(function() {
            $(".widgettrading").css("top", "100px");
        }, 500);
    });
    $(".widgetfronttrading").mouseover(function() {
        $(this).css("background-color", "rgba(255,255,255,0.2)");
        $(".widgettrading").css("transition", "500ms");
        $(".widgettrading").css("height", "330px");
        if (AnimateB == true) {
            AnimateB = false;
        } else 
            AnimateB = true;
        ANIMATION_TWIDGET(AnimateB);
    });
    $(".widgetfronttrading").mouseout(function() {
        $(this).css("background-color", "rgba(255,255,255,0.0)");
        $(".widgettrading").css("height", "80px");
    });
});

var ActualChildren = null;
var ActualChildrenB = null;

function ANIMATION_PWIDGET(bool) {
    if (bool == true) {
        if (anime.running[0] != null) {
            anime.running[0].children = ActualChildren
        } else {
            anime.timeline({loop: true})
            .add({
                targets: '.ptitle',
                translateX: [40,0],
                translateZ: 0,
                opacity: [0,1],
                easing: "easeOutExpo",
                duration: 2100,
                delay: (el, i) => 500 + 30 * i
            }).add({
                targets: '.ptitle',
                translateX: [0,-30],
                opacity: [1,0],
                easing: "easeInExpo",
                duration: 2100,
                delay: (el, i) => 100 + 30 * i
            });
        }
    } else {
        if (ActualChildren == null)
            ActualChildren = anime.running[0].children;
        anime.running[0].children = null;
    }
}


function ANIMATION_TWIDGET(bool) {
    if (bool == true) {
        if (anime.running[1] != null) {
            anime.running[1].children = ActualChildrenB
        } else {
            anime.timeline({loop: true})
            .add({
                targets: '.pttitle',
                translateX: [40,0],
                translateZ: 0,
                opacity: [0,1],
                easing: "easeOutExpo",
                duration: 2100,
                delay: (el, i) => 500 + 30 * i
            }).add({
                targets: '.pttitle',
                translateX: [0,-30],
                opacity: [1,0],
                easing: "easeInExpo",
                duration: 2100,
                delay: (el, i) => 100 + 30 * i
            });
        }
    } else {
        if (ActualChildrenB == null)
            ActualChildrenB = anime.running[1].children;
        anime.running[1].children = null;
    }
}