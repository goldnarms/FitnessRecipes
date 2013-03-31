/// <reference path="utilz.ts" />
/// <reference path="modalhandler.ts" />
/// <reference path="../Definitions/chosen.jquery-0.9.d.ts" />
/// <reference path="../Definitions/jquery-1.8.d.ts" />

$(document).ready(function () {
    $("#lnkAddBrand").bind("click", function () {
        showModalWithoutId("#addBrandModal");
    });
    $("#btnBrandAdd").bind("click", function () {
        var formData = $("#brandForm").serialize();
        $.post("/Ingredient/CreateBrand", formData, function (data) {
            if (data) {
                $('#addBrandModal').trigger('reveal:close');
                $.post("/Ingredient/GetBrands", function (data) {
                    bindToDropDown(data, "#ddlBrands", "Name", "Id");
                });
            }
        });
    });
});