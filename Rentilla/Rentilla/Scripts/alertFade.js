$(document).ready(function () {

    setTimeout(function () { showAlert() }, 200);

    //affichage fondu & down
    function showAlert() {
        $("#myAlert").animate({ top: 10, opacity: 1 }, 500);
    }

    //disparition fondu & down
    setTimeout(function () {
        $('.alert').animate({ top: 30, opacity: 0 }, 500, function () { $('.alert').alert('close') });

    }, 3000);

    //Disparition Fondu 
    /*setTimeout(function () {
        $('.alert').fadeTo("fast", 0.1, function () { $('.alert').alert('close') });
    
    }, 5000)*/
});