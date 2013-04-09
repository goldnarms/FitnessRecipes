function showModal(modalid, idholder, idvalue) {
    $(modalid).foundation('reveal', 'open');
    $(idholder).val(idvalue);
}
function showModalWithoutId(modalid) {
    $(modalid).foundation('reveal', 'open');
}
function loadResult(resultholder, func) {
    $(resultholder).click(func);
}
function loadResultWithModal(resultholder, modalid, idholder, idvalue) {
    loadResult(resultholder, function () {
        showModal(modalid, idholder, idvalue);
    });
}
