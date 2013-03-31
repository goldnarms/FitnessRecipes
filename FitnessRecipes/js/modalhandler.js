function showModal(modalid, idholder, idvalue) {
    $(modalid).reveal();
    $(idholder).val(idvalue);
}
function showModalWithoutId(modalid) {
    $(modalid).reveal();
}
function loadResult(resultholder, func) {
    $(resultholder).click(func);
}
function loadResultWithModal(resultholder, modalid, idholder, idvalue) {
    loadResult(resultholder, function () {
        showModal(modalid, idholder, idvalue);
    });
}
