/// <reference path="utilz.ts" />
/// <reference path="modalhandler.ts" />
/// <reference path="../Definitions/jquery-1.8.d.ts" />
/// <reference path="../Definitions/foundation-3.2.d.ts" />

(function() {
    $(document).ready(function() {
        $("#tbSearchField").focus();
        var btnSearch = $("#btnSearch");
        var divAddedMeals = $("#addedMeals");
        var divAddedIngredients = $("#addedIngredients");
        var dietId = $("#hiDietId").val();  

        $("#ingredientCategories").load("/meal/GetIngredientCategories", function () {
            $(".categoryIngredient").bind("click", function () {
                $("#searchResult").load("/ingredient/Categories?id=" + $(this).data("categoryid"), function () {
                    loadResult(".ingredientPopup", function () {
                        showModal("#addModal", "#hiIngredientId", $(this).data("ingredientid"))
                    });
                    $(".superIngredient").click(function() {
                        $(this).parent().siblings(".subIngredient").toggle();
                        $("#hiIngredientId").val($(this).data("ingredientid"));
                    });
                });
            });
        });

        $("#mealCategories").load("/meal/GetMealCategories", function () {
            $(".categoryMeal").bind("click", function () {
                $("#searchResultMeals").load("/meal/Categories?id=" + $(this).data("mealcategoryid"), function () {
                    loadResult(".mealPopup", function () { 
                        showModal("#addMealModal", "#hiMealId", $(this).data("mealid")) 
                    });
                });
            });
        });
    
        divAddedIngredients.load("/diet/GetIngredientsForDiet?id=" + dietId, function(){
            $(".removeIngredient").bind("click", function () {
                $.post("/diet/RemoveIngredientFromDiet?dietId=" + dietId + "&ingredientId=" + $(this).data("ingredientid"), function () {
                    divAddedIngredients.load("/diet/GetIngredientsForDiet?id=" + dietId);
                });
            });
        });

        $("#btnIngredientAdd").click(function () {
            $.post("/diet/AddIngredientToDiet?dietId=" + dietId + "&ingredientId=" + $("#hiIngredientId").val() + "&quantity=" + $("#tbQuantity").val() + "&quantityId=" + $("#ddlQuantityType").val() + "&day=" + toIntArray(new Array("#cbMonday", "#cbTuesday","#cbWednesday", "#cbThursday","#cbFriday", "#cbSaturday","#cbSunday")) + "&time=" + $("#ddlTime").val(), function() {
                $('#addModal').trigger('reveal:close');
                divAddedIngredients.load("/diet/GetIngredientsForDiet?id=" + dietId, function () {
                    $(".removeIngredient").bind("click", function () {
                        $.post("/diet/RemoveIngredientFromDiet?dietId=" + dietId + "&ingredientId=" + $(this).data("ingredientid"), function () {
                            divAddedIngredients.load("/diet/GetIngredientsForDiet?id=" + dietId);
                        });
                    });
                });
            });
        });
    
        divAddedMeals.load("/diet/GetMealsForDiet?id=" + dietId, function(){
            $(".removeMeal").bind("click", function () {
                $.post("/diet/RemoveMealFromDiet?dietId=" + dietId + "&mealId=" + $(this).data("mealid"), function () {
                    divAddedMeals.load("/diet/GetMealsForDiet?id=" + dietId);
                });
            });
        });

        $("#btnMealAdd").click(function () {
            $.post("/diet/AddMealToDiet?dietId=" + dietId + "&mealId=" + $("#hiMealId").val() + "&day=" + toIntArray(new Array("#cbMealMonday", "#cbMealTuesday","#cbMealWednesday", "#cbMealThursday","#cbMealFriday", "#cbMealSaturday","#cbMealSunday")) + "&time=" + $("#ddlMealTime").val(), function() {
                $('#addMealModal').trigger('reveal:close');
                divAddedMeals.load("/diet/GetMealsForDiet?id=" + dietId, function () {
                    $(".removeMeal").bind("click", function () {
                        $.post("/diet/RemoveMealFromDiet?dietId=" + dietId + "&mealId=" + $(this).data("mealid"), function () {
                            divAddedMeals.load("/diet/GetMealsForDiet?id=" + dietId);
                        });
                    });
                });
            });
        });


        btnSearch.bind("click", function() {
            $("#searchResult").load("/ingredient/SearchResult?searchString=" + $("#tbSearchField").val(), function(){
                loadResult(".ingredientPopup", function () {
                    showModal("#addModal", "#hiIngredientId", $(this).data("ingredientid"))
                });
                $(".superIngredient").click(function() {
                    $(this).parent().siblings(".subIngredient").toggle();
                    $("#hiIngredientId").val($(this).data("ingredientid"));
                });
            });
            $("#searchResultMeals").load("/meal/SearchResultForDiet?searchString=" + $("#tbSearchField").val(), function(){
                loadResult(".mealPopup", function () { 
                    showModal("#addMealModal", "#hiMealId", $(this).data("mealid")) 
                });
            });
        });
    });
}).call(this);
