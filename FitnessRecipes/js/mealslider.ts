/// <reference path="../Definitions/foundation-3.2.d.ts" />
/// <reference path="../Definitions/jquery-1.8.d.ts" />

$(document).ready(function () {
    //var jqxhr = $.get("/meal/SetupMealSlider", function (data) {
    //    $("#mealSlider").html(data);
    //})
    //    .success(function () {
    //        $("#mealSlider").orbit({});
    //    }); 
    $("#mealSlider").orbit({ directionalNav: false, fluid: true});
});