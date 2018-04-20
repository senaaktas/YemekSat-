$(document).ready(function () {
    $("#frmProfile").submit(function (e) {     
        e.preventDefault();
        var formData = new FormData(this);
        var url;
        url = "/Panel/ProfilBilgileriDuzenle";

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
    });
});