var mode = 0;
var username = "";

$('input[type="password"]').focus(function(){
  $('.tip').css('height','30px')
  setTimeout(function(){
    $('.tip').css('opacity','1')
  },350)
});

$('input[type="password"]').blur(function(){
  $('.tip').css('opacity','0')
  setTimeout(function(){
    $('.tip').css('height','0px')
  },350)
});


function LoadRegisterMode() {
  document.getElementById("button").value = "S'enregistrer";
  mode = 1;
}

function DeclineLoginForm() {
  $('form,.login_desc h3,.forgotten').animate({'opacity':'100'})
  setTimeout(function(){
    $('.login_profile').removeClass('bulge')
    $('.pulse').fadeOut()
    $('.login_check').fadeOut(300)
  },400);
}


function AcceptLoginForm() {
  setTimeout(function(){
    $('.login').css('transform','scale(0) translateY(-50%) rotatex(360deg) rotatey(360deg)')
    setTimeout(function(){
    $('.tick').css('transform','scale(1) translateY(-50%)')
  },50);
  },500);
  setTimeout(function(){
    mp.trigger('login_event_destroy');
  }, 1000);
}


$('form').submit(function(){
  
  var password = document.getElementById("password_v").value;
  
  if (mode == 0)
    mp.trigger('LoginEvent', password);
  else if (mode == 1)
    mp.trigger('RegisterEvent', password);  

  $('form,.login_desc h3,.forgotten').animate({'opacity':'0'})
  setTimeout(function(){
    $('.login_profile').addClass('bulge')
    $('.pulse').fadeIn()
    $('.login_check').fadeIn(300)
  },400);
  return false;
})