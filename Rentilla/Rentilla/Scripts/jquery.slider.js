$(document).ready(function () {
    animationHover(".slide_btn", "pulse");
    var deployed = 0;
    $(".slide_btn").click(function () {
        var effect = 'slide';
        var options = { direction: 'left' };
        var duration = 700;
        $(".slide_btn").hide();
        $("#panel").toggle(effect, options, function () {
            $(window).resize(function () {
                if (deployed == 1) {
                    btnSliderPosition(window.innerWidth);
                }
            });
            btnSliderPosition(window.innerWidth);
            if (deployed == 0) {
                $(".slide_btn").css("background-image", "url('/Content/img/in_button.png')");
                deployed = 1;
                $(".slide_btn").show();
            } else {
                $(".slide_btn").css("background-image", "url('/Content/img/out_button.png')");
                deployed = 0;
                $(".slide_btn").css("left", "0");
                $(".slide_btn").show();
            }
        });
    });
});

function animationHover(element, animation) {
    element = $(element);
    element.hover(
      function () {
          element.addClass('animated ' + animation);
      },
      function () {

          window.setTimeout(function () {
              element.removeClass('animated ' + animation);
          }, 2000);
      }
    );
};

function btnSliderPosition(windowWidth) {
    if (windowWidth < 480)
        $(".slide_btn").css("left", "0");
    else if (windowWidth < 768)
        $(".slide_btn").css("left", "50%");
    else if (windowWidth < 1042)
        $(".slide_btn").css("left", "30%");
    else
        $(".slide_btn").css("left", "20%");
};