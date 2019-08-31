

var slider = {

  get_position: function() {
    var marker_pos = $('#marker').position();
    var left_pos = marker_pos.left / basePage.scale;
    var top_pos = marker_pos.top / basePage.scale;

      
    slider.position = {
      left: left_pos,
      top: top_pos,
      x: Math.round(slider.round_factor.x * (left_pos * slider.xmax / slider.width)) / slider.round_factor.x,
      y: Math.round((slider.round_factor.y * (slider.height - top_pos) * slider.ymax / slider.height)) / slider.round_factor.y,
    };
    console.log("Marker");
      console.log(marker_pos);
      
    console.log("Slider");
    console.log(this);
    //$('#marker').position = slider.position;  
    return(slider.position);
  },

  display_position: function() {
        console.log("Debug "+slider.position.x+" "+slider.position.y);
      
    //document.getElementById("range2DVertical").value = slider.position.x;
    //document.getElementById("range2DHorizontal").value = slider.position.y;
  },

  draw: function(x_size, y_size, xmax, ymax, marker_size, round_to) {

    if ((x_size === undefined) && (y_size === undefined) && (xmax === undefined) && (ymax === undefined) && (marker_size === undefined) && (round_to === undefined)) {
      x_size = 150;
      y_size = 150;
      xmax = 1;
      ymax = 1;
      marker_size = 1;
      round_to = 2;
    };
      
    slider.marker_size = marker_size;
    slider.height = y_size;
    slider.width = x_size;
    slider.xmax = xmax;
    slider.ymax = ymax;
    round_to = Math.pow(10, round_to);
    slider.round_factor = {
      x: round_to,
      y: round_to,
    };

    $("#markerbounds").css({
      "width": (x_size + marker_size).toString() + 'px',
      "height": (y_size + marker_size).toString() + 'px',
    });
    $("#box").css({
      "width": x_size.toString() + 'px',
      "height": y_size.toString() + 'px',
      "top": marker_size / 2,
      "left": marker_size / 2,
    });
    $("#marker").css({
      "width": marker_size.toString() + 'px',
      "height": marker_size.toString() + 'px',
    });

    slider.get_position();
    slider.display_position();
  },

};


//syntax for rendering is:
//  slider.render(width, height, width-range, height-range, marker size, output decimal places)

slider.draw(150 * basePage.scale,150 * basePage.scale, 1, 1,15,2);

// check to make sure the defaults work:
//slider.draw();
