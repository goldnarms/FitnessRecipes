/// <reference path="../Definitions/foundation-3.2.d.ts" />
/// <reference path="../Definitions/jquery-1.8.d.ts" />

function showModal(modalid: string, idholder: string, idvalue: string) {
    $(modalid).reveal();
    $(idholder).val(idvalue);
}

function showModalWithoutId(modalid: string) {
    $(modalid).reveal();
}

function loadResult(resultholder: string, func) {
        $(resultholder).click(func);
}

function loadResultWithModal(resultholder: string, modalid: string, idholder: string, idvalue: string) {
    loadResult(resultholder, function () {
        showModal(modalid, idholder, idvalue)
    });
}