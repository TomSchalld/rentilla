$(document).ready(function () {

    var url = '/Content/konami'; // url dossier image + mp3/ogg

    var animationDuration = 8000; // durée animation en miliseconde

    $('body').append('<img src="' + url + '/nyancat.gif" id="image1" class="hidden" width="100" style="position:fixed;z-index:9999;left:-100px;top:100px;"/>');
    var nyan = $("img#image1"); // image nyan cat

    $('body').append('<img src="' + url + '/tacnayn.gif" id="image2" class="hidden" width="100" style="position:fixed;z-index:9998;left:' + window.innerWidth + 'px;top:100px;"/>');
    var nayn = $("img#image2"); // image tac nayn

    $('body').append('<audio id="sound" preload="auto"><source src="' + url + '/nyancat.ogg" type="audio/ogg"/><source src="' + url + '/nyancat.mp3" type="audio/mp3" /></audio>');
    var sound = $("#sound").get(0); // son chrome + firefox + ie

    var nyancat_reset = function () {
        nyan.addClass("hidden").removeClass("show"); // cacher nyan-cat
        nyan.css("left", "-100px"); // revient à sa position initiale
        if (sound.volume != undefined) {
            sound.pause();
            sound.currentTime = 0;
            sound.volume = 1;
        } else {
            $("#sound-ie").remove();
        }
    };

    var tacnayn_reset = function () {
        nayn.addClass("hidden").removeClass("show"); // cacher tac-nayn
        nayn.css("left", window.innerWidth + "px"); // revient à sa position initiale
        if (sound.volume != undefined) {
            sound.pause();
            sound.currentTime = 0;
            sound.volume = 1;
        } else {
            $("#sound-ie").remove();
        }
    };

    function nyancat_start() {
        if (sound.volume != undefined) {
            sound.play();
        }
        else {
            $('body').append('<embed id="sound-ie" src="' + url + '/nyancat.mp3" type="application/x-mplayer2" autostart="true" playcount="true" loop="false" height="0" width="0">');
        }
        nyan.removeClass("hidden").addClass("show");
        nyan.show().animate({ "left": "+=" + parseInt($("body").width() + 100) + "px" }, animationDuration, nyancat_reset);
    };

    function tacnayn_start() {
        if (sound.volume != undefined) {
            sound.play();
        }
        else {
            $('body').append('<embed id="sound-ie" src="' + url + '/nyancat.mp3" type="application/x-mplayer2" autostart="true" playcount="true" loop="false" height="0" width="0">');
        }
        nayn.css("left", window.innerWidth);
        nayn.removeClass("hidden").addClass("show");
        nayn.show().animate({ "left": "-=" + parseInt($("body").width() + 100) + "px" }, animationDuration, tacnayn_reset);
    }

    $("#sound").on('timeupdate', function () {
        var vol = 1,
        interval = 200;
        if (Math.floor(sound.currentTime) == 6) {
            if (sound.volume == 1) {
                var intervalID = setInterval(function () {
                    if (vol > 0) {
                        vol -= 0.10;
                        if (vol >= 0.10)
                            sound.volume = vol.toFixed(1);
                    } else {
                        clearInterval(intervalID);
                    }
                },
                interval);
            }
        }
    });

    // Haut, haut, bas, bas, gauche, droite, gauche, droite, B, A
    var k = [38, 38, 40, 40, 37, 39, 37, 39, 66, 65];
    // A, B, gauche, gauche, droite, droite, haut, bas, haut, bas
    var j = [65, 66, 37, 37, 39, 39, 38, 40, 38, 40];

    n = 0; // nième touche appuyée
    p = 0; // La première touche appuyée est-elle [HAUT] ou [A] ?

    $(document).keydown(function (e) {
        if (p == 0) {
            if (e.keyCode == 38)
                p = 1;
            else if (e.keyCode == 65)
                p = 2;
            else
                p = 0;
        }
        if (p == 1) {
            if (e.keyCode == k[n++]) {
                if (n == k.length) {
                    nyancat_start(); // lancer nyan cat
                    n = 0;
                    p = 0;
                }
            } else n = 0;
        } else if (p == 2) {
            if (e.keyCode == j[n++]) {
                if (n == j.length) {
                    tacnayn_start(); // lancer tac nayn
                    n = 0;
                    p = 0;
                }
            } else n = 0;
        } else {
            p = 0;
            n = 0;
        }
    });
});