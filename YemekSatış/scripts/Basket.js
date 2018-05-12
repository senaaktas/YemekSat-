$(document).ready(function () {
    $("#tblBasketList").delegate("#BasketSil", "click", function () {

        var id = $(this).attr("data-id");
        var confirmDelete = confirm("Seçili kaydı silmek istediğinizden emin misiniz ?");
        if (confirmDelete) {
            $.ajax({
                url: "/Home/SepetSil",
                type: 'GET',
                data: 'id=' + id,
                contentType: false,
                cache: false,
                processData: false,
                success: function (data, textStatus, jqXHR) {
                    var tr = $("#tblBasketList").find('tr[data-id="' + id + '"]');
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
});