$(document).ready(function () {
    $("#frmsDetails").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        var id = $("#hdn_id").val();
        var url;
        if (id != null && id != "") {
            url = "/Panel/DetayDuzenle";
        }
        else {
            url = "/Panel/DetayYeni";
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
        $("#hdn_id").val("");
    });
    $("#tblDetailsList").delegate("#DetayDuzenle", "click", function () {

        $("#hdn_id").val("");
        $("#Details").val("");

        var id = $(this).attr("data-id");
        $("#hdn_id").val(id);

        $.ajax({
            url: "/Panel/DetayBilgisiYukle",
            type: 'GET',
            data: 'id=' + id,
            contentType: false,
            cache: false,
            processData: false,
            success: function (data, textStatus, jqXHR) {
                $('#slc_food_id').val(data.AltKategoriID);
                $("#txt_Details").val(data.Details1);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 403) {
                    window.location = jqXHR.responseJSON.LogOnUrl + "?ReturnUrl=" + window.location.pathname;
                }
            }
        });
    });
    $("#tblDetailsList").delegate("#DetaySil", "click", function () {

        var id = $(this).attr("data-id");
        var confirmDelete = confirm("Seçili kaydı silmek istediğinizden emin misiniz ?");
        if (confirmDelete) {
            $.ajax({
                url: "/Panel/DetaySil",
                type: 'GET',
                data: 'id=' + id,
                contentType: false,
                cache: false,
                processData: false,
                success: function (data, textStatus, jqXHR) {
                    var tr = $("#tblDetailsList").find('tr[data-id="' + id + '"]');
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
        $("#hdn_id").val("");
        $("#slc_food_id").val("");
        $("#txt_Details").val("");
    });
});