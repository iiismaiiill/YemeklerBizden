$(function () {
    //Open page
    GetPersons()
    GetFoods()
    GetComments()
})



function GetPersons() {
    
    $.ajax({
        url: "/Admin/GetPersons",
        type: "GET",
        beforeSend: function () {
            $("#kisilerTablo").html(``)
        },
        success: function (donenVeri) {
            $("#kisiletTablo").html("");
            console.log(donenVeri)
            $(donenVeri).each(function (index, value) {
                console.log(value)
                $("#kisilerTablo").append(`
                <tr>

                            <td>${value.name}</td>
                            <td>${value.surName}</td>
                            <td>${value.email}</td>
                            <td>
                                <button onclick="DeletePerson(${value.kullaniciId})" class="btn btn-outline-danger">Sil</button>
                                <button onclick="MakeAdmin(${value.kullaniciId})" class="btn btn-outline-primary">Yetki Ver</button>
                            </td>


                </tr>


    `)
            })
        },
        error: function (hata) {
            console.log(hata)
        }
    })
}

function DeletePerson(id) {
    $.ajax({
        url: "/Admin/DeletePerson/" + id,
        type: "GET",
        success: function (donenVeri) {
            GetPersons()
            console.log("kişi silindi");
        },
        error: function (hata) {
            console.log(hata)
        }
    })
}

function MakeAdmin(id) {
    $.ajax({
        url: "/Admin/MakeAdmin/" + id,
        type: "GET",
        success: function (donenVeri) {
            GetPersons();
            console.log("Kişi Admin Yapıldı")
            console.log(donenVeri)
        },
        error: function (hata) {
            console.log(hata)
        }
    })
}

function GetFoods() {
    $.ajax({
        url: "/Admin/GetFoods",
        type: "GET",
        success: function (donenVeri) {
            $("#kisiletTablo").html("");
            console.log(donenVeri)
            $(donenVeri).each(function (index, value) {
                console.log(value)
                $("#yemekler").append(`<tr>
                        <td>${value.yemekAdi}</td>
                        <td>${value.yemekAdi}</td>
                        <td><button class="btn btn-outline-primary" onclick="OkFood(${value.yemekId})">Yemeği Onayla</button></td>
                    </tr> `)
            })
        },
        error: function (hata) {
            console.log(hata)
        }
    })
}

function OkFood(id) {

    $.ajax({
        url: "/Admin/OkFood/" + id,
        type: "GET",
        success: function (donenVeri) {
            alertify.success("yemek onaylandı");
        },
        error: function (hata) {
            console.log(hata)
        }
    })

}

function GetComments() {
    $.ajax({
        url: "/Admin/GetCommentss",
        type: "GET",
        success: function (donenVeri) {
            console.log(donenVeri)
            $(donenVeri).each(function (index, value) {
                console.log(value)
                $("#yorumlar").append(`<tr>
                        <td>${value.yorumMail}</td>
                        <td>${value.yorumAciklama}</td>
                        <td><button class="btn btn-outline-primary" onclick="OkComment(${value.yorumId})">Yorumu Onayla</button></td>
                    </tr> `)
            })
        },
        error: function (hata) {
            console.log(hata)
        }
    })
}

function OkComment(id) {

    $.ajax({
        url: "/Admin/OkComment/" + id,
        type: "GET",
        success: function (donenVeri) {
            alertify.success("yorum onaylandı");
        },
        error: function (hata) {
            console.log(hata)
        }
    })

}