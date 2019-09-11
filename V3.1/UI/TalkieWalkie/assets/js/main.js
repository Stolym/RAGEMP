var data = {
    OnOff: false,
    Frequencies: 100.2,
}

$(function () {
    $(".fonoff").click(click_on_off);
    $("#next").click(next_frequencies);
    $("#back").click(back_frequencies);
});


function click_on_off() {
    data.OnOff = !data.OnOff;
    update();
}

function next_frequencies() {
    data.Frequencies += 0.1;
    
    if (data.Frequencies > 999)
        data.Frequencies = 100;
    update();
}

function back_frequencies() {
    data.Frequencies -= 0.1;
    if (data.Frequencies < 100)
        data.Frequencies = 999;
    update();
}

function update() {
    $(".fonoff").text(data.OnOff == true ? "On" : "Off");
    $(".frequencies").text(data.Frequencies.toFixed(2)+" Htz");
}

String.prototype.replaceAt=function(index, replacement) {
    return this.substr(0, index) + replacement+ this.substr(index + replacement.length);
}

function CREATE_BUTTON()
{
    for (var i = 0; i < 9; i++) {
        $(".space").append("<button data-id='"+(i+1)+"' class='fnum'>"+(i+1)+"</button>");
        $(".fnum").last().css("left", 345 + parseInt(i%3) * 43);
        $(".fnum").last().css("top", 390 + parseInt(i/3) * 26);
        //$("space").last(".fnum");
    }
    $(".space").append("<button data-id='"+0+"' class='fnum'>"+0+"</button>");
    $(".fnum").last().css("left", 345 + 43);
    $(".fnum").last().css("top", 390 + 78);

}

var index = 0;

$(function () {
    CREATE_BUTTON();
    $(".fnum").click(function () {
        
        if (index == 3)
            index++;
        if (index < 5) {
            data.Frequencies =  parseFloat(data.Frequencies.toString().replaceAt(index, $(this).data("id").toString()));
            index++;
        }
        else
            index = 0;
        update();
    });
})