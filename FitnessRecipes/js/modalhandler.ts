/// <reference path="../Definitions/foundation.d.ts" />
/// <reference path="../Definitions/jquery-1.8.d.ts" />

function showModal(modalid: string, idholder: string, idvalue: string) {
    $(modalid).foundation('reveal', 'open');
    $(idholder).val(idvalue);
}

function showModalWithoutId(modalid: string) {
    $(modalid).foundation('reveal', 'open');
}

function loadResult(resultholder: string, func) {
        $(resultholder).click(func);
}

function loadResultWithModal(resultholder: string, modalid: string, idholder: string, idvalue: string) {
    loadResult(resultholder, function () {
        showModal(modalid, idholder, idvalue)
    });
}