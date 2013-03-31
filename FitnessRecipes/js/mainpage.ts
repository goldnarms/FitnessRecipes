/// <reference path="../Definitions/chosen.jquery-0.9.d.ts" />
/// <reference path="../Definitions/jquery-1.8.d.ts" />

(function() {
  var onAfterSlide, onBeforeSlide;

  onAfterSlide = function(prevSlide, currentSlide) {
    $("#" + $(currentSlide).attr("id") + "_content").fadeIn();
    $(".slider_navigation .more").css("display", "none");
    return $("#" + $(currentSlide).attr("id") + "_url").css("display", "block");
  };

  onBeforeSlide = function() {
    return $(".slider_content").fadeOut();
  };

  $(document).ready(function() {
    var IngredientsHave, btnAddIngredient;
    IngredientsHave = [];
    btnAddIngredient = $("#btnAddIngredient");
    btnAddIngredient.bind("click", function(e) {
      var IngredientId;
      IngredientId = $("#ddlIngredientsHave").val();
      IngredientsHave.push(IngredientId);
      $.ajax({
        type: "GET",
        url: "/Home/AddIngredient?ingredientId=" + IngredientId,
        dataType: "html",
        success: function(evt) {
          return $("#ulIngredientsHave").html(evt);
        },
        error: function(req, status, error) {
          return alert("Error!Occured");
        }
      });
      return $.ajax({
        type: "GET",
        url: "/Home/RefreshMatchingRecepies?ingredientsHave=" + IngredientsHave,
        dataType: "html",
        success: function(evt) {
          return $("#ulMatchingRecipes").html(evt);
        },
        error: function(req, status, error) {
          return alert("Error!Occured");
        }
      });
    });
    //$("#slider").carouFredSel({
    //  responsive: true,
    //  items: {
    //    visible: 1,
    //    height: 620,
    //    width: 1900
    //  },
    //  prev: {
    //    button: '#prev',
    //    onAfter: onAfterSlide,
    //    onBefore: onBeforeSlide
    //  },
    //  next: {
    //    button: '#next',
    //    onAfter: onAfterSlide,
    //    onBefore: onBeforeSlide
    //  },
    //  auto: {
    //    play: true,
    //    pauseDuration: 5000,
    //    onAfter: onAfterSlide,
    //    onBefore: onBeforeSlide
    //  }
    //}, {
    //  wrapper: {
    //    classname: "caroufredsel_wrapper caroufredsel_wrapper_slider"
    //  }
    //});
    return $("#ddlIngredientsHave").chosen();
  });

}).call(this);
