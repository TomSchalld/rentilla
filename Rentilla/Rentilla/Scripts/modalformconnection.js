$(function () {

    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {

        // hide dropdown if any
        $(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');

        
        $('#modalLoginContent').load(this.href, function () {
            

            $('#modalLogin').modal({
                /*backdrop: 'static',*/
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
                    $('#modalLogin').modal('hide');
                    //Refresh
                    location.reload();
                } else {
                    $('#modalLoginContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}