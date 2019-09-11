
$(window).resize(function() {
  RESIZE_DIV("body");
});

function RESIZE_DIV(name)
{
  var data = {
      object: $(name),
      scale: 1,
      width: 0,
      height: 0,
      base_x: 1920,
      base_y: 1080,
  };
  data.width = $(window).width();
  data.height = $(window).height();
  data.scale = (data.width / data.base_x) > (data.height / data.base_y) ? (data.width / data.base_x) : (data.height / data.base_y);
  data.object.attr('style', '-webkit-transform:scale(' + data.scale + ');left:' + data.width + 'px;top:' + data.height + 'px;');
  console.log(data.width + " "+data.height);
}