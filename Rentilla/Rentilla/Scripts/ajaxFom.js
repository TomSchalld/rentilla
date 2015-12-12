$('#uploadSliderAjax').submit(function () {
    $.ajax({
        // use the method as defined in the <form method="POST" ... 
        type: this.method,

        // use the action as defined in <form action="/Home/AddComment?ThreadId=123"
        url: this.action,

        data: $(this).serialize(),
        dataType: 'html',
        success: function (response) {
            alert(response);
        },
        error: function (error) {
            alert(error);
        }
    });
    return false;
});