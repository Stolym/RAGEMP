var menu = [false, false, false, false];


function SetAllMenu(value) {
    for (var i = 0; i < menu.length; i++) {
        menu[i] = value;
    }
}

/*
    

    100 000 * 0.49 = sum_part / 100 = part

    100 000$ - x part acheter
    49 000$ - x part acheter
    490
*/


var single_graph = {
    name:"Lost",
    sum:20000,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}

function get_price_part(sum, part)
{
    var part_price = 0;
    var sum_part = 0;

    if (part >= 490)
        return -1;
    for (var i = 0; i < part; i++)
    {
        sum_part = sum * 0.49;
        part_price = sum_part / 1000;
        sum -= part_price;
    }
    return part_price;
}

function UpdateValues(graph, mod) {
    for (var i = 0; i < 24; i++) {
        graph.sum += Math.random() * (1000 * mod - -1000 * mod) + -1000 * mod;   
        var part = get_price_part(graph.sum, graph.part);
        graph.values.push(part);
        graph.labels.push(i);
        
        if (i == 0) {
            graph.colors.push('rgb(129,204,0)');
            continue;
        }
        
        if (graph.values[i] > graph.values[i - 1])
            graph.colors.push('rgb(129,204,0)');
        else
            graph.colors.push('rgb(178,7,11)');
    }
}

var index = 0;

function create_graphical(graph) {
    $(".interact").append("<div data-id='0' class='bourse_tab'><div data-id='0' class='bourse_graph'><canvas data-id='0' class='chart'></canvas></div><p data-id='0' class='btext'>Part Actuel : "+get_price_part(graph.sum, graph.part).toFixed(2)+"$</p><p data-id='0' class='btext'>Vous possedez : "+graph.part+"</p><button data-id='0' class='usage'>Acheter</button><button data-id='0' class='usage'>Vendre</button></div>");
    
    var ctx = $("canvas").last()[0].getContext('2d');
    //var ctx = document.getElementById('chart').getContext('2d');
    
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: graph.labels,
            datasets: [{
                label: "# Part de l'entreprise des "+graph.name,
                backgroundColor: 'rgba(160, 0, 255, 0.1)',
                borderColor: graph.colors,
                data: graph.values,
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
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

var list_bourse = []

var single_graphb = {
    name:"Ventura",
    sum:1459300,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}


var single_graphc = {
    name:"Weazel News",
    sum:1000,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}

list_bourse.push(single_graph);
list_bourse.push(single_graphb);
list_bourse.push(single_graphc);

function UpdateGraphByList(json) {
    var data = JSON.parse(json);
    
    if (data == null)
        return;
    for (var i = 0; i < data.length; i++) {
        create_graphical(data[i]);
    }
    
}

$(() => {
    UpdateValues(single_graph, 2);
    UpdateValues(single_graphb, 100);
    UpdateValues(single_graphc, 0.1);
    UpdateGraphByList(JSON.stringify(list_bourse));
    //create_graphical(single_graph);
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
        }
        UpdateMenu();
    });
    
    
    
    UpdateMenu();
});