﻿/// <reference path="../Definitions/jquery-1.8.d.ts" />

$(function () {
    $("#lnkChangeImage").bind("click", function () {
        $("#divHideImageUpload").show();
    });
});
function toIntArray(checkBoxIds) {
    var intArray: string;
    intArray = "";
    for (var i = 0; i < checkBoxIds.length; i++) {
        if ($(checkBoxIds[i]).is(':checked')) {
            intArray = intArray + i + ",";
        }
    }
    if (intArray.length > 0) {
        intArray = intArray.substring(0, intArray.length - 1);
    }
    return intArray;
}

function bindToDropDown(data, dropdownId: string, dataTextField: string, dataValueField: string) {
    var listItems= "";
    var largest: number = 0;
    $.each(data, function () {
        if (this.Id > largest) {
            largest = this.Id;
        }
        listItems += "<option value='" + this.Id + "'>" + this.Name + "</option>";
    });
    $(dropdownId).html(listItems);
    $(dropdownId).val(largest);
}