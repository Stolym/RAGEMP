
function water(v) {
  var rand = v;
	var x = document.querySelector('.progress-circle-prog');
  x.style.strokeDasharray = (rand) + ' 999';
	var el = document.querySelector('.progress-text'); 
	var from = $('.progress-text').data('progress');
	$('.progress-text').data('progress', rand);
	var start = new Date().getTime();
  
	setTimeout(function() {
	    var now = (new Date().getTime()) - start;
	    var progress = now / 700;
		var result = rand > from ? Math.floor((rand - from) * progress + from) : Math.floor(from - (from - rand) * progress);
	    el.innerHTML = progress < 1 ? result+'%' : rand+'%';
	    if (progress < 1) setTimeout(arguments.callee, 10);
	}, 10);
}


function hunger(v) {
    var rand = v;
	var x = document.querySelector('.progress3-circle-prog');
    x.style.strokeDasharray = (rand) + ' 999';
	var el = document.querySelector('.progress3-text'); 
	var from = $('.progress3-text').data('progress3');
	$('.progress3-text').data('progress3', rand);
	var start = new Date().getTime();
  
	setTimeout(function() {
	    var now = (new Date().getTime()) - start;
	    var progress = now / 700;
		var result = rand > from ? Math.floor((rand - from) * progress + from) : Math.floor(from - (from - rand) * progress);
	    el.innerHTML = progress < 1 ? result+'%' : rand+'%';
	    if (progress < 1) setTimeout(arguments.callee, 10);
	}, 10);
}

function health(v) {
  var rand = v;
	var x = document.querySelector('.progress2-circle-prog');
    x.style.strokeDasharray = (rand) + ' 999';
	var el = document.querySelector('.progress2-text'); 
	var from = $('.progress2-text').data('progress2');
	$('.progress2-text').data('progress2', rand);
	var start = new Date().getTime();
  
	setTimeout(function() {
	    var now = (new Date().getTime()) - start;
	    var progress = now / 700;
        var result = rand > from ? Math.floor((rand - from) * progress + from) : Math.floor(from - (from - rand) * progress);
	    el.innerHTML = progress < 1 ? result+'%' : rand+'%';
	    if (progress < 1) setTimeout(arguments.callee, 10);
	}, 10);
}