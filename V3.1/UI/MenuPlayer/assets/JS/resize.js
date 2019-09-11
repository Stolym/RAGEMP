
$(window).resize(function() {
  RESIZE_DIV("body");
});
RESIZE_DIV("body");

function RESIZE_DIV(name)
{
  var data = {
      object: $(name),
      scale: 1,
      width: 0,
      height: 0,
      base_x: 3840,
      base_y: 2160,
  };
  data.width = $(window).width();
  data.height = $(window).height();
  data.scale = (data.width / data.base_x) > (data.height / data.base_y) ? (data.width / data.base_x) : (data.height / data.base_y);
  //data.scale = 0.8;
  data.object.attr('style', '-webkit-transform:scale(' + data.scale + ');left:' + data.width + 'px;top:' + data.height + 'px;');
  console.log(data.width + " "+data.height);
  //$(".environment").css("top", (data.width - data.base_x)/5);
  //$(".environment").css("left", (data.height - data.base_y)/2);
}