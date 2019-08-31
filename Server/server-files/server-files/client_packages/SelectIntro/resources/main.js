var sud = document.getElementById("sud");
var nord = document.getElementById("nord");

document.addEventListener("keyup", function(event) {
	if (event.keyCode === 65) sud.focus();
	else if (event.keyCode === 69) nord.focus();
	else if (event.keyCode === 13) document.activeElement.click();
});

sud.addEventListener('mouseenter', function(e) { document.activeElement.blur(); })
nord.addEventListener('mouseenter', function(e) { document.activeElement.blur(); })

sud.addEventListener('click', function(e) {
    mp.trigger("setSelectIntroduction", "South");
})
nord.addEventListener('click', function(e) {
    mp.trigger("setSelectIntroduction", "North");
})