
var array = [ 
    {
        name: "Lost",
        hashcode: 0,
        bought: {
            size: 2,
            price: 300,
            tick: 0,
        },
    },
    {
        name: "Reborn",
        hashcode: 1,
        bought: {
            size: 10,
            price: 22546,
            tick: 0,
        },
    },
]


function ClearAction() {
    $(".transacttest").remove();
}

UpdateActionCEF(JSON.stringify(array));

$(function () {
    $(".usage").click(BuyAction);
});

function UpdateActionCEF(json) {
    ClearAction();
    var data = JSON.parse(json);

    for (var i = 0; i < data.length; i++)
        AddAction(data[i], i);
    GainPotential(data);
    $(".sellparttrade").click(SellAction); 
}

function GainPotential(data) {
    var value = 0;

    for (var i = 0; i < data.length; i++) {
            
        var calcul = {
            actual_price: (data_list[data[i].hashcode].sum/49).toFixed(0),
            prc: 0,
        }
        calcul.prc = (calcul.actual_price/data[i].bought.price).toFixed(1) - 1;
        for (var j = 0; j < data[i].bought.size; j++) {
            value +=  calcul.actual_price - data[i].bought.price;
        }
    }
    if (value < 0)
        $("#solde").css("color", "#FF0000");
    else
        $("#solde").css("color", "#52c495");
    $("#solde").text(value+" $");
}

function AddAction(data, index)
{
    var date = new Date();
    var test = new Date(data.bought.tick);
    var calcul = {
        actual_price: (data_list[data.hashcode].sum/49).toFixed(0),
        prc: 0,
    }
    calcul.prc = (calcul.actual_price/data.bought.price).toFixed(1) - 1;
    $(".historyspace").append("<div class='transacttest'><div class='transactionhistoryspace'><p class='transactionhistoryname' style='position: absolute; top: 7px; float: left;'>"+data.name+"</p><p class='transactionhistoryname' style='position: absolute; top: 7px; left: 200px; float: left;'>"+date.getDate()+"/"+date.getMonth()+"/"+date.getFullYear()+" "+date.getHours()+":"+date.getMinutes()+"</p><p class='transactionhistoryname' style='position: absolute; top: 7px; float: left; left: 430px;'>"+data.bought.size+" Actions</p><button class='sellparttrade' data-id='"+index+"'>$</button></div><p class='transactobject' style='position: absolute; float: left; left: 22px; margin-top: 20px; margin-right: 0px'>Acheter</p><p class='transactobject' style='position: absolute; float: left; left: 205px; margin-top: 20px;'>"+test.getDate()+"/"+test.getMonth()+"/"+test.getFullYear()+" "+test.getHours()+":"+test.getMinutes()+"</p><p class='transactobject' style='position: absolute; left: 460px; margin-top: 20px; color: #FA2200'>"+data.bought.price+" $</p><p class='transactobject' style='position: absolute; float: left; left: 22px; margin-top: 60px; margin-right: 0px'>Vente</p><p class='transactobject' style='position: absolute; float: left; left: 245px; margin-top: 60px; color: #52c495'>+ "+calcul.prc.toFixed(2)+" %</p><p class='transactobject' style='position: absolute; left: 460px; margin-top: 60px; color: #52c495'>"+calcul.actual_price+" $</p></div>");
}


function SellAction() {
    var data = [];
    for (var i = 0; i < array.length; i++) {
        if (i != $(this).data("id"))
            data.push(array[i]);
    }
    array = data;
    $(this).parents(".transacttest").remove();
    UpdateActionCEF(JSON.stringify(data));
}

function BuyAction() {
    var idx = $(this).data("id");
    var val = null;
    var ndata = { name: "", hashcode: 0, bought: { size: 0, price: 0, tick: 0 }};

    $(".binput").each(function (index) {
        if (idx == $(this).data("id"))
            val = $(this).val();
    });
    ndata.name = data_list[idx].name;
    ndata.hashcode = data_list[idx].hashcode;
    ndata.bought.size = val;
    ndata.bought.price = (data_list[idx].sum/49).toFixed(0);
    ndata.bought.tick = Date.now();
    array.push(ndata);
    GainPotential(array);
    UpdateActionCEF(JSON.stringify(array));
}