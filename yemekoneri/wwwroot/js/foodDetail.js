$(function () {
    //Open page
    GetComments();
})

function SendComment() {
    var YorumMail = $('#YorumMail').val();
    var YorumAciklama = $('#YorumAciklama').val();
    var yemekId = $('#yemekId').val();

    $.ajax({
        url: "/Home/SendComment",
        type: "POST",
        data: {
            YorumMail: YorumMail,
            YorumAciklama: YorumAciklama,
            YemekId: yemekId
        },
        success: function (data) {
            alertify.success("yorum eklendi");

            var exampleComment = $('#commentExample').clone();
            $(exampleComment).removeClass('d-none');
            $(exampleComment)[0].id = "commentExample" + index;
            $(exampleComment).find('.yorumKisi').text(YorumMail);
            $(exampleComment).find('.yorumAciklama').text(YorumAciklama);

            $('#topContainer').append(exampleComment);
        },
        error: function () {

        }
    });



    $('#YorumMail').val("");
    $('#YorumAciklama').val("");
}

function GetComments() {

    var yemekId = $('#yemekId').val();

    $.ajax({
        url: "/Home/GetCommentsOfFood",
        type: "POST",
        data: { YemekId: yemekId},
        success: function (data) {

            $(data).each(function (index, value) {
                var exampleComment = $('#commentExample').clone();
                $(exampleComment).removeClass('d-none');
                $(exampleComment)[0].id = "commentExample" + index;
                $(exampleComment).find('.yorumKisi').text(value.yorumMail);
                $(exampleComment).find('.yorumAciklama').text(value.yorumAciklama);

                $('#topContainer').append(exampleComment);
            })
        },
        error: function () {

        }
    });
}