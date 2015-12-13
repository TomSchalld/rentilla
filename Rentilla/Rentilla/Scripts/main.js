$(document).ready(function () {
    heigtWrap = $('#wrap').css('height');
    $(".body-content").css("min-height", heigtWrap);
    $('#summernote').summernote();

    $.ajaxSetup({ cache: false });

    $("#forgottenPassword").on("click", function () {
        $("#forgottenPasswordMessage").removeClass("hidden");
    });

$(window).resize(function () {
    $(".body-content").css("min-height", 0);
    heigtWrap = $('#wrap').css('height');
    $(".body-content").css("min-height", heigtWrap);
});
});

