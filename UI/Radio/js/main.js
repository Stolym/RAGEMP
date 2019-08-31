
var radio = {
    active: true,
    connected: false,
    current_hertz: 69.80,
    hashcode: 0x01,
}

var search = 0.0;

var l_hertz = [];



var frequency = {
    hertz: 128.80,
    hashcode: 0x01,
};


var frequencyb = {
    hertz: 32.30,
    hashcode: 0x01,
};

l_hertz.push(frequency);
l_hertz.push(frequencyb);

var event = [
  "wfoff.svg",
  "woff.svg",
  "won.svg",
  "wfon.svg",
  "wcaon.svg",
  "wcaoff.svg",
  "wcon.svg",
  "wcoff.svg",
];


function update_radio(json) {
    var data = JSON.parse(json);
    
    if (data == null)
        return;
    var action = data.active && data.connected ? 3 : data.active && !data.connected ? 2 : !data.active && data.connected ? 1 : !data.active && !data.connected ? 0 : -1;
    
    $("img").attr('src', "./svg/"+event[action]);
    $(".frequency").text(data.current_hertz.toString()+" Hz");
}

function searching() {
    if (search >= 200)
        search = 20;
    search += 0.10;
    for (var i = 0; i < l_hertz.length; i++) {
        if (search.toFixed(2) == l_hertz[i].hertz) {
            radio.connected = true;
            radio.current_hertz = l_hertz[i].hertz;
            update_radio(JSON.stringify(radio));
            $('audio#radio')[0].pause();
            return;
        }
    }
    $(".frequency").text(search.toFixed(2).toString()+" Hz");
    setTimeout(searching, 1);
}

$(() => {
    update_radio(JSON.stringify(radio));
    
    $(".change_h").hover(function() {
        if (!radio.connected)
            $("img").attr('src', "./svg/"+event[5]);
        else
            $("img").attr('src', "./svg/"+event[4]);
    });
    
    $( ".change_h" ).mouseout(function() {
        var action = radio.active && radio.connected ? 3 : radio.active && !radio.connected ? 2 : !radio.active && radio.connected ? 1 : !radio.active && !radio.connected ? 0 : -1;

        $("img").attr('src', "./svg/"+event[action]);
    });
    
    $(".change_h").click(function () {
        radio.active = !radio.active;
        
        $('audio#turn')[0].play();
        
        if (radio.active)
            $(".change_radio_a").prop("disabled", false);
        else if (!radio.active)
            $(".change_radio_a").prop("disabled", true);
        
        update_radio(JSON.stringify(radio));
    });
    
    
    $(".change_radio_a").click(function() {
        radio.connected = false;
        update_radio(JSON.stringify(radio));
        search = radio.current_hertz;
        $('audio#radio')[0].play();
        setTimeout(searching, 1);
    });
    
    $(".change_radio_a").hover(function() {
        
        if (radio.active && radio.connected)
            $("img").attr('src', "./svg/"+event[6]);
        else if (radio.active && !radio.connected)
            $("img").attr('src', "./svg/"+event[7]);
        
    });
    
    $( ".change_radio_a" ).mouseout(function() {
        var action = radio.active && radio.connected ? 3 : radio.active && !radio.connected ? 2 : !radio.active && radio.connected ? 1 : !radio.active && !radio.connected ? 0 : -1;

        $("img").attr('src', "./svg/"+event[action]);
    });
    
});