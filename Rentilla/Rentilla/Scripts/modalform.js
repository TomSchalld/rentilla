$(function () {

    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {

        $('#ModalContent').load(this.href, function () {

            $('#Modal').modal({
                keyboard: true
            }, 'show');

            bindForm(this);
        });

        return false;
    });


});

function bindForm(dialog) {
    
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#Modal').modal('hide');
                    //Refresh
                    location.reload();
                } else {
                    $('#ModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });

}