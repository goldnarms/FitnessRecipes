var App;
(function (App) {
    'use strict';
    var Meal = (function () {
        function Meal(Id, Name) {
            this.Id = Id;
            this.Name = Name;
        }
        return Meal;
    })();
    App.Meal = Meal;    
})(App || (App = {}));
