$(document).ready(function () {
    $(".jsTransition").hover(
          function () {
              $('.jsTransition').not(this)
                  .css("opacity", "0.8");
          }, function () {
              $('.jsTransition')
                  .css("opacity", "1")
          });

        
});
