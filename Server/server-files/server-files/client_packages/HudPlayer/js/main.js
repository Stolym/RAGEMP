


function loop_speedometer() {
    var index = getRandomInt(200);
    set_vehicle_speed(index);
    setTimeout(loop_speedometer, 5000);
}

function loop() {
    var $parent = $(".icon_on").parent(".icon_slider");
    var int = parseInt($parent.css("width"));
    if (int > 50)
        $parent.css("width", "0px");
    else if (int <= 50) {
        int += 1;
        $parent.css("width", int+"px");
    }
    setTimeout(loop, 200);
}

function getRandomInt(max) {
  return Math.floor(Math.random() * Math.floor(max));
}

var current_speed = 0;
var stop_speed = 0;



function set_values(json) {
    var data = JSON.parse(json);
    
    $("#Food").css("width", ((data.Food / 100) * 60).toFixed(0) + "px");
    $("#Water").css("width", ((data.Water / 100) * 60).toFixed(0) + "px");
    $("#Alcool").css("width", ((data.Alcool / 100) * 60).toFixed(0) + "px");
    $("#Voice").css("width", ((data.Voice / 100) * 60).toFixed(0) + "px");
}

function set_gazol(index) {
    
    $("#Gazol").css("width", ((index / 100) * 60).toFixed(0) + "px");
}

function set_vehicle_speed(speed) {
    var choose = 0;
    
    if (stop_speed < speed)
        choose = 1;
    else
        choose = 2;
    stop_speed = speed;
    switch (choose) {
        case 1:
        increase_speed();
            break;
        case 2:
        decrease_speed();
            break;
    }
}

function speedo_color() {
    if (current_speed <= 30)
        $(".speedometer").css("color", "#42f572");
    else if (current_speed > 30 && current_speed <= 90)
        $(".speedometer").css("color", "#faea3e");
    else
        $(".speedometer").css("color", "#fa413e");
    
}

function increase_speed() {
    speedo_color();
    if (current_speed < stop_speed)
        $(".speedometer").text(current_speed + " km/h");
    else
        return;
    current_speed += 1;
    setTimeout(increase_speed, 60);
}



function decrease_speed() {
    speedo_color();
    if (current_speed > stop_speed)
        $(".speedometer").text(current_speed + " km/h");
    else
        return;
    current_speed -= 1;
    setTimeout(decrease_speed, 60);
}



$(() => {
});