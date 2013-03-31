/// <reference path="../Definitions/knockout-2.2.d.ts" />
/// <reference path="../Definitions/knockback-0.16.d.ts" />
/// <reference path="../Definitions/backbone-0.9.d.ts" />
/// <reference path="../Definitions/jquery-1.8.d.ts" />

(function() {
    /*
  $(document).ready(function() {
    var btnRemoveIngredient;
    btnRemoveIngredient = $("#btnRemoveIngredient");
    return btnRemoveIngredient.bind("click", function(e) {
      var IngredientId;
      IngredientId = $("#ddlIngredientsHave").val();
      IngredientsHave.prototype.remove = function(IngredientId) {
        return $.grep(this, function(e) {
          return e !== IngredientId;
        });
      };
      return $.ajax({
        type: "DELETE",
        url: "/Home/RemoveIngredient?ingredientId=" + IngredientId,
        dataType: "html",
        success: function(evt) {
          return $("#ulIngredientsHave").html(evt);
        },
        error: function(req, status, error) {
          return alert("Error!Occured");
        }
      });
    });
  });
    */
}).call(this);