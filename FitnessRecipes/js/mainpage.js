(function () {
    var onAfterSlide, onBeforeSlide;
    onAfterSlide = function (prevSlide, currentSlide) {
        $("#" + $(currentSlide).attr("id") + "_content").fadeIn();
        $(".slider_navigation .more").css("display", "none");
        return $("#" + $(currentSlide).attr("id") + "_url").css("display", "block");
    };
    onBeforeSlide = function () {
        return $(".slider_content").fadeOut();
    };
    $(document).ready(function () {
        var IngredientsHave, btnAddIngredient;
        IngredientsHave = [];
        btnAddIngredient = $("#btnAddIngredient");
        btnAddIngredient.bind("click", function (e) {
            var IngredientId;
            IngredientId = $("#ddlIngredientsHave").val();
            IngredientsHave.push(IngredientId);
            $.ajax({
                type: "GET",
                url: "/Home/AddIngredient?ingredientId=" + IngredientId,
                dataType: "html",
                success: function (evt) {
                    return $("#ulIngredientsHave").html(evt);
                },
                error: function (req, status, error) {
                    return alert("Error!Occured");
                }
            });
            return $.ajax({
                type: "GET",
                url: "/Home/RefreshMatchingRecepies?ingredientsHave=" + IngredientsHave,
                dataType: "html",
                success: function (evt) {
                    return $("#ulMatchingRecipes").html(evt);
                },
                error: function (req, status, error) {
                    return alert("Error!Occured");
                }
            });
        });
        return $("#ddlIngredientsHave").chosen();
    });
}).call(this);
