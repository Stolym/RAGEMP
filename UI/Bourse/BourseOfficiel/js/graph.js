
var single_grapha = {
    name:"Lost",
    sum: 53000,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}

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

var data_list = [ single_grapha, single_graphb, single_graphc ]


/*
 Make graphical
*/



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

function UpdateListGraphJson(json) {
    var data = JSON.parse(json);
 
    for (var i = 0; i < data.length; i++) {
        CreateGraph(data[i]);
    }
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

function CreateGraph(graph) {
    $(".sinteract").append("<div data-id='0' class='bourse_tab'><div data-id='0' class='bourse_graph'><canvas data-id='0' class='chart'></canvas></div><p data-id='0' class='btext'>Part : "+"16660"+"$</p><input class='binput' placeholder='Nbr' type='text'><button data-id='0' class='usage'>Acheter</button></div>");
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

$(function() {
    UpdateValues(data_list[0], 2);
    UpdateValues(data_list[1], 100);
    UpdateValues(data_list[2], 0.1);
    UpdateListGraphJson(JSON.stringify(data_list));
});