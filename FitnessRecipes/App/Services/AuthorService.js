angular.module("authorService", [
    "ngResource"
]).factory("AuthorService", function ($resource) {
    return $resource("/api/author/:id", {
        id: "@id"
    }, {
        "update": {
            method: "PUT"
        }
    });
});
