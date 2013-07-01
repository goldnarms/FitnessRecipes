var App;
(function (App) {
    'use strict';
    var Author = (function () {
        function Author(Id, Name) {
            this.Id = Id;
            this.Name = Name;
        }
        return Author;
    })();
    App.Author = Author;    
})(App || (App = {}));
