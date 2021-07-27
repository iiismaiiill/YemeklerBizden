$(function () {
    
})

function refreshPass() {
    var mail = $('#mail').val();

    $.ajax({
        url: "/Account/RefreshPassword",
        data: {
            mail:mail
        },
        type: "POST",
        success: function () {
            alertify.success("mail gönderildi, kontrol et");
        },
        error: function() {
            alertify.success("mail gidemedi");
        }
    });

    $('#mail').val("");
}