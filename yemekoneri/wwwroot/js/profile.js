$(function () {
//Open page

    PersonDetail();
    GetComments();
    GetFoods();

})


function PersonDetail(){
    $.ajax({
        url: "/Account/GetProfile",
        type: "GET",
        success: function (data) {
            $("#Name").val(data.name);
            $("#SurName").val(data.surName);
            $("#Email").val(data.email);
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}


function GetComments() {
    $("#yorumlar").html("");
    $.ajax({
        url: "/YorumYemek/GetYorumlar",
        type: "GET",
        success: function (data) {
            $(data).each(function (indexYorum, valueYorum) {
                $('#yorumlar').append(`<tr>
                                <td>${valueYorum.yorumAciklama}</td>
                                <td>
                                    <button onclick="yorumSil(${valueYorum.yorumId})" class="btn btn-outline-danger "><i class="fas fa-trash-alt"></i>&nbsp;Sil</button>
                                    <button data-toggle="modal" onclick="yorumUpdate(${valueYorum.yorumId})" data-target="#updateComment" class="btn btn-outline-primary"><i class="fas fa-sync"></i>&nbsp;Güncelle</button>
                                </td>
                            </tr>`);
            });
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}


function GetFoods() {
    $("#yemekler").html("");
    $.ajax({
        url: "/YorumYemek/GetYemekler",
        type: "GET",
        success: function (data) {
            $(data).each(function (indexYemek, valueYemek) {
                $('#yemekler').append(`<tr>
                                <td>${valueYemek.yemekAdi}</td>
                                <td>${valueYemek.yemekAciklamasi} </td>
                                <td>
                                    <button onclick="yemekSil(${valueYemek.yemekId})" class="btn btn-outline-danger "><i class="fas fa-trash-alt"></i>&nbsp;Sil</button>
                                    <button onclick="yemekUpdate(${valueYemek.yemekId})" data-toggle="modal" data-target="#updateFood" class="btn btn-outline-primary"><i class="fas fa-sync"></i>&nbsp;Güncelle</button>
                                </td>
                            </tr>`);
            });
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}

function yorumSil(id) {
    $.ajax({
        url: "/YorumYemek/DeleteComment/"+id,
        type: "GET",
        success: function (data) {
            alertify.success("yorum silindi.")
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}

function yemekSil(id) {
    $.ajax({
        url: "/YorumYemek/DeleteFood/" + id,
        type: "GET",
        success: function (data) {
            alertify.success("yemek silindi.")
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}

function yemekUpdate(id) {
    $.ajax({
        url: "/YorumYemek/GetFood/"+id,
        type: "GET",
        success: function (data) {
            $('#foodId').val(data.yemekId);
            $('#footdTitle').val(data.yemekAdi);
            $('#foodDetail').val(data.yemekAciklamasi);
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}

function yorumUpdate(id) {
    $.ajax({
        url: "/YorumYemek/GetComment/"+id,
        type: "GET",
        success: function (data) {
            $('#commentId').val(data.yorumId);
            $('#yorum').val(data.yorumAciklama);
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}

function addFood() {

    var footdTitle = $('#YemekAdi').val();
    var foodDetail = $('#YemekAciklamasi').val();

    console.log(footdTitle);
    console.log(foodDetail);
    $.ajax({
        url: "/YorumYemek/AddFood",
        type: "POST",
        data: {
            YemekAdi : footdTitle,
            YemekAciklamasi: foodDetail
        },
        success: function (data) {
            alertify.success("yemek eklendi.")
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}

function updateYemekAjax() {

    var footdTitle = $('#footdTitle').val();
    var foodDetail = $('#foodDetail').val();
    var foodId = $('#foodId').val();

    $.ajax({
        url: "/YorumYemek/updateYorumYemek",
        type: "POST",
        data: {
            YemekId: foodId,
            YemekAdi: footdTitle,
            YemekAciklamasi: foodDetail
        },
        success: function (data) {
            alertify.success("yemek eklendi.")
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}

function updateYorumAjax() {

    var yorum = $('#yorum').val();
    var commentId = $('#commentId').val();

    $.ajax({
        url: "/YorumYemek/updateYorumYemek",
        type: "POST",
        data: {
            YorumId: commentId,
            YorumAciklama: yorum
        },
        success: function (data) {
            alertify.success("yorum eklendi.")
        },
        error: function (error) {
            console.log(error);
            alertify.error("bilgiler gelmedi.")
        }
    })
}



function updatePersonDetail() {
    var name = $("#Name").val();
    var surname = $("#SurName").val();
    var email = $("#Email").val();

    $.ajax({
        url: "/Account/GetProfile",
        type: "POST",
        data: {
            Name: name,
            SurName: surname,
            Email: email
        },
        success: function () {
            alertify.success("Bilgiler Güncellendi.");
        },
        error: function (error) {
            console.log(error);
            alertify.error("Bilgiler güncellenemedi");
        }

    })
}

function byPass() {
    $.ajax({
        url: "/Account/ByPassPerson",
        type: "GET",
        success: function () {
            alertify.success("üyeliğiniz iptal edildi, iyi günler.");
            window.location = "/Home/Index";
        },
        error: function () {

        }
    });
}


function updatePassword() {
    //Şifre yenileme fonksiyonu
    if ($('#PasswordNew').val() != $('#PasswordRe').val()) {
        alertify.error("Şifreler Uyuşmuyor.");
    } else {
        $.ajax({
            url: "/Account/UpdatePassword",
            type: "POST",
            data: {
                lastPassword: $('#Password').val(),
                newPassword: $('#PasswordNew').val()
            },
            success: function (data) {
                alertify.success("Şifreniz başarıyla değiştirildi.");
                console.log(data);
            },
            error: function () {
                alertify.error("Şifre değiştirilemedi.");
            }

        });
    }
    
}