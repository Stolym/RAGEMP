
var single_grapha = {
    name: "Immobilier",
    hashcode: 0,
    sum: 124000,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}

var single_graphb = {
    name: "Benny's Custom",
    hashcode: 1,
    sum: 103000,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}


var single_graphc = {
    name: "Los Santos Express",
    hashcode: 2,
    sum: 25000,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}


var single_graphd = {
    name: "Weazel New's",
    hashcode: 3,
    sum: 50000,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}


var single_graphe = {
    name: "D&C",
    hashcode: 4,
    sum: 423000,
    part:1,
    part_limit: 490,
    values: [],
    labels: [],
    colors: [],
}

var data_list = [ single_grapha, single_graphb, single_graphc, single_graphd, single_graphe ]


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
    graph.values = [];
    graph.labels = [];
    
    for (var i = 0; i < 50; i++) {
        graph.sum += Math.random() * (1000 * mod - -1000 * mod) + -1000 * mod + 1000;   
        var part = (graph.sum/49).toFixed(1);//get_price_part(graph.sum, graph.part);
        graph.values.push(part);
        graph.labels.push((graph.labels.length + i));
        
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
    $(".sinteract").append("<div data-id='"+graph.hashcode+"' class='bourse_tab'><div data-id='"+graph.hashcode+"' class='bourse_graph'><canvas height='135' data-id='"+graph.hashcode+"' class='chart'></canvas></div><p data-id='"+graph.hashcode+"' class='btext'>Action : "+(graph.sum/49).toFixed(0)+" $</p><input class='binput' data-id='"+graph.hashcode+"' maxlength='3' placeholder='Qtn' type='text'><button data-id='"+graph.hashcode+"' class='usage'>Acheter</button></div>");
    var ctx = $("canvas").last()[0].getContext('2d');
    //var ctx = document.getElementById('chart').getContext('2d');
    
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {

            fontColor: "red",
            labels: graph.labels,
            datasets: [{
                label: "# Action de l'entreprise: "+graph.name,
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
    
    $("#rand").click(function() {
        $(".bourse_tab").remove();
        UpdateValues(data_list[0], 2);
        UpdateValues(data_list[1], 100);
        UpdateValues(data_list[2], 1);
        UpdateListGraphJson(JSON.stringify(data_list));
        $(".usage").click(BuyAction);
        GainPotential(array);
        UpdateActionCEF(JSON.stringify(array));
    });
    UpdateValues(data_list[0], 2);
    UpdateValues(data_list[1], 100);
    UpdateValues(data_list[2], 0.1);
    UpdateValues(data_list[3], 8);
    UpdateValues(data_list[4], 200);
    UpdateListGraphJson(JSON.stringify(data_list));
});