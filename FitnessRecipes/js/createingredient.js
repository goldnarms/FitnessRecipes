$(document).ready(function () {
    $("#lnkAddBrand").bind("click", function () {
        showModalWithoutId("#addBrandModal");
    });
    $("#btnBrandAdd").bind("click", function () {
        var formData = $("#brandForm").serialize();
        $.post("/Ingredient/CreateBrand", formData, function (data) {
            if(data) {
                $('#addBrandModal').trigger('reveal:close');
                $.post("/Ingredient/GetBrands", function (data) {
                    bindToDropDown(data, "#ddlBrands", "Name", "Id");
                });
            }
        });
    });
});
