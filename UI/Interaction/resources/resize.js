var pageWidth, pageHeight;

var basePage = {
  width: 1366,
  height: 768,
  scale: 1,
  scaleX: 1,
  scaleY: 1
};

$(function(){
  var $page = $('body');

  /*getPageSize();
  scalePages($page, pageWidth, pageHeight);

  //using underscore to delay resize method till finished resizing window
  $(window).resize( function () {
    getPageSize();
    scalePages($page, pageWidth, pageHeight);
  });*/


function getPageSize() {
  pageHeight = $('body').height();
  pageWidth = $('body').width();

    console.log(pageHeight);
}

function scalePages(page, maxWidth, maxHeight) {
  var scaleX = 1, scaleY = 1;
  scaleX = (maxWidth / basePage.width);
  scaleY = (maxHeight / basePage.height);
  basePage.scaleX = scaleX;
  basePage.scaleY = scaleY;
  basePage.scale = (scaleX > scaleY) ? scaleY : scaleX;

  var newLeftPos = Math.abs(Math.floor(((basePage.width * basePage.scale) - maxWidth)/2));
  var newTopPos = Math.abs(Math.floor(((basePage.height * basePage.scale) - maxHeight)/2));


  page.attr('style', '-webkit-transform:scale(' + basePage.scale + ');left:' + newLeftPos + 'px;top:' + newTopPos + 'px;');
}
});
