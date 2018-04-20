$(document).ready(function () {
    $("#frmsSubCategories").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        var id = $("#hdn_food_id").val();
        var url;
        if (id != null && id != "") {
            url = "/Panel/AltKategoriDuzenle";
        }
        else {
            url = "/Panel/AltKategoriYeni";
        }
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            mimeType: "multipart/form-data",
            dataType: 'json',
            contentType: false,
            cache: false,
            processData: false,
            success: function (data, textStatus, jqXHR) {
                var jsonResult = data;
                var jsonModel = jsonResult.resultObject;

            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 403) {
                    window.location = jqXHR.responseJSON.LogOnUrl + "?ReturnUrl=" + window.location.pathname;
                }
            }
        });
        $("#hdn_food_id").val("");
    });
    $("#tblSubCategoriesList").delegate("#AltKategoriDuzenle", "click", function () {

        $("#hdn_food_id").val("");
        $("#food_name").val("");

        var id = $(this).attr("data-id");
        $("#hdn_food_id").val(id);

        $.ajax({
            url: "/Panel/AltKategoriBilgisiYukle",
            type: 'GET',
            data: 'id=' + id,
            contentType: false,
            cache: false,
            processData: false,
            success: function (data, textStatus, jqXHR) {
                $('#slc_food_catagory_id').val(data.food_catagory_id);
                $("#txt_food_name").val(data.food_name);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 403) {
                    window.location = jqXHR.responseJSON.LogOnUrl + "?ReturnUrl=" + window.location.pathname;
                }
            }
        });
    });
    $("#tblSubCategoriesList").delegate("#AltKategoriSil", "click", function () {

        var id = $(this).attr("data-id");
        var confirmDelete = confirm("Seçili kaydı silmek istediğinizden emin misiniz ?");
        if (confirmDelete) {
            $.ajax({
                url: "/Panel/AltKategoriSil",
                type: 'GET',
                data: 'id=' + id,
                contentType: false,
                cache: false,
                processData: false,
                success: function (data, textStatus, jqXHR) {
                    var tr = $("#tblSubCategoriesList").find('tr[data-id="' + id + '"]');
                    if (tr.length > 0) {
                        tr.fadeOut(500, function () {
                            $(tr).remove();
                        });
                    }

                },
                error: function (jqXHR, textStatus, errorThrown) {
                    if (jqXHR.status == 403) {
                        window.location = jqXHR.responseJSON.LogOnUrl + "?ReturnUrl=" + window.location.pathname;
                    }
                }
            });
        }
    });
    $("#btnYeniKayit").on("click", function () {
        $("#hdn_food_id").val("");
        $("#txt_food_name").val("");
    });
});