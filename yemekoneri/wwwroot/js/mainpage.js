$(function () {
    //Open page
    getPersonDetail();
    GetAllFoods();
})

function GetAllFoods() {
    //Tüm Yemekleri MainPage e Getiriyor.
    //Gelen değerler
    //isActive: true
    //kullanici: null
    //yemekAciklamasi: "En güzel çorbadır kendileri"
    //yemekAdi: "Mercimek Çorbası"
    //yemekId: 30
    //yorumlar: null
    $("#gelenYemekler").html("");
    $.ajax({
        url: "/YorumYemek/GetYemekler",
        type: "GET",
        success: function (data) {
            console.log(data);
            $(data).each(function (index, value) {
                console.log(value.yorumlar)
                if (value.isActive) {

                    $.ajax({
                        url: "/Home/GetCommentsOfFood",
                        type: "POST",
                        async: false,
                        data: { YemekId: value.yemekId },
                        success: function (data) {
                            yorumSayisi = data.length;
                        },
                        error: function () {

                        }
                    });

                    var btn = "";

                    $.ajax({
                        url: "/Home/isLikedFood",
                        type: "POST",
                        async: false,
                        data: { yemekId: value.yemekId },
                        success: function (data) {
                            btn = `<input type="hidden" class="yemeginId" value="${value.yemekId}" />
                                    <button onclick="likeFood(this)" class="btn btn-success"><i class="fas fa-thumbs-up"></i></button>
                                    <button onclick="disLikeFood(this)" class="btn btn-outline-danger"><i class="fas fa-thumbs-down"></i></button>`;
                        },
                        error: function () {
                            btn = `<input type="hidden" class="yemeginId" value="${value.yemekId}" />
                                    <button onclick="likeFood(this)" class="btn btn-outline-success"><i class="fas fa-thumbs-up"></i></button>
                                    <button onclick="disLikeFood(this)" class="btn btn-danger"><i class="fas fa-thumbs-down"></i></button>`;
                        }
                    });

                    var begeniOrani = 0;

                    $.ajax({
                        url: "/Home/countOfLikedFood",
                        type: "POST",
                        async: false,
                        data: { yemekId: value.yemekId },
                        success: function (data) {
                            begeniOrani = `Beğenen: <span class="posiveLike">${data.likeCount}</span> Beğenmeyen: <span class="negativeLike">${data.disLikeCount}</span>`
                            //if (data.likeCount == 0 && data.disLikeCount == 0) {
                            //    begeniOrani = 0;
                            //} else {
                            //    begeniOrani = data.likeCount / (data.likeCount + data.disLikeCount);
                            //}
                        },
                        error: function () {

                        }
                    });

                    


                    $("#gelenYemekler").append(`
            <div class="card mt-3">
        <div class="card-header">
            <h5 class="card-title">${value.yemekAdi}</h5>
        </div>
        <div class="card-body">

            <p class="card-text">${value.yemekAciklamasi}</p>

            <div class="row">
                <div class="col text-left">
                    <a href="/Home/FoodDetail/${value.yemekId}" class="btn btn-outline-secondary"><i class="fas fa-glasses"></i>&nbsp;Daha Fazla Oku</a>
                    <button class="btn btn-outline-primary"><i class="fas fa-comments"></i>&nbsp;${yorumSayisi}</button>
                </div>
                <div class="col text-right">
                    ${begeniOrani}
                    ${btn}
                </div>
            </div>


        </div>
    </div>

`)


                }
            })
        },
        error: function (error) {
            console.log(error);
        }
    })
}


function getPersonDetail() {
    var mail = $.cookie("User");
    var id = $.cookie("UserId");
    console.log("id :" + id + " mail:" + mail);
}


function getFilteredFoods() {
    //Gelen Veri
    //isActive: true
    //kullanici: null
    //yemekAciklamasi: "En güzel çorbadır kendileri"
    //yemekAdi: "Mercimek Çorbası"
    //yemekId: 30
    //yorumlar: null
    var tarif = $("#searchFood").val();
    $("#gelenYemekler").html("");
    $.ajax({
        url: "/YorumYemek/GetFilteredFoods",
        type: "POST",
        data: {
            YemekAciklamasi: tarif
        },
        success: function (data) {
            console.log(data);
            $(data).each(function (index, value) {
                if (value.isActive) {
                    $("#gelenYemekler").append(`
            <div class="card mt-3">
        <div class="card-header">
            <h5 class="card-title">${value.yemekAdi}</h5>
        </div>
        <div class="card-body">

            <p class="card-text">${value.yemekAciklamasi}</p>

            <div class="row">
                <div class="col text-left">
                    <a asp-action="FoodDetail" class="btn btn-outline-secondary"><i class="fas fa-glasses"></i>&nbsp;Daha Fazla Oku</a>
                    <button class="btn btn-outline-primary"><i class="fas fa-comments"></i>&nbsp;44</button>
                </div>
                <div class="col text-right">
                    <button class="btn btn-outline-success"><i class="fas fa-thumbs-up"></i></button>
                    <button class="btn btn-outline-danger"><i class="fas fa-thumbs-down"></i></button>
                </div>
            </div>


        </div>
    </div>

`)
                }
            })
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function GetComments(id) {


    $.ajax({
        url: "/Home/GetCommentsOfFood",
        type: "POST",
        data: { YemekId: id },
        success: function (data) {
            return data.length;
        },
        error: function () {

        }
    });
}

function likeFood(element) {

    var YemekId = $(element).parent().find('.yemeginId').val();

    if ($(element).hasClass('btn-outline-success')) {
        $.ajax({
            url: "/Home/likeFoodOrDisLike",
            type: "POST",
            async: false,
            data: { like: true, yemekId: YemekId },
            success: function (data) {
                $(element).addClass('btn-success');
                $(element).removeClass('btn-outline-success');

                console.log($(element).parent().find('.btn-danger'));
                var len = $(element).parent().find('.btn-danger').length;
                if (len > 0) {
                    $(element).parent().find('.btn-danger').addClass('btn-outline-danger')
                    $(element).parent().find('.btn-outline-danger').removeClass('btn-danger')
                    var pos = $(element).parent().find('.posiveLike').text();
                    var neg = $(element).parent().find('.negativeLike').text();

                    $(element).parent().find('.posiveLike').text(parseInt(pos) + 1);
                    $(element).parent().find('.negativeLike').text(parseInt(neg) - 1);
                }
                alertify.success('begendin.');

            },
            error: function () {
                alertify.success('begenme işlemi başarısız.');
            }
        });


    } else {
        alertify.success('zaten beğenilmiş.');
    }
    
}

function disLikeFood(element) {

    var YemekId = $(element).parent().find('.yemeginId').val();

    if ($(element).hasClass('btn-outline-danger')) {
        $.ajax({
            url: "/Home/likeFoodOrDisLike",
            type: "POST",
            async: false,
            data: { like: false, yemekId: YemekId },
            success: function (data) {
                $(element).addClass('btn-danger');
                $(element).removeClass('btn-outline-danger');

                var len = $(element).parent().find('.btn-success').length;
                if (len > 0) {
                    $(element).parent().parent().find('.btn-success').addClass('btn-outline-success');
                    $(element).parent().parent().find('.btn-outline-success').removeClass('btn-success');

                    var pos = $(element).parent().parent().find('.posiveLike').text();
                    var neg = $(element).parent().parent().find('.negativeLike').text();

                    $(element).parent().parent().find('.posiveLike').text(parseInt(pos) - 1);
                    $(element).parent().parent().find('.negativeLike').text(parseInt(neg) + 1);
                }
                alertify.success('begenmedin.');
            },
            error: function () {
                alertify.success('begenmeme işlemi başarısız.');
            }
        });


    } else {
        alertify.success('zaten beğenilmemiş.');
    }
}