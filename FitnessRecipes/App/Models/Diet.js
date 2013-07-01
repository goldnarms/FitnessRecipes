var App;
(function (App) {
    'use strict';
    var Diet = (function () {
        function Diet(Id, Name) {
            this.Id = Id;
            this.Name = Name;
        }
        return Diet;
    })();
    App.Diet = Diet;    
})(App || (App = {}));
