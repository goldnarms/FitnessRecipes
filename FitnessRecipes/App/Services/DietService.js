angular.module("dietService", [
    "ngResource"
]).factory("DietService", function ($resource) {
    return $resource("/api/diet/:id", {
        id: "@id"
    }, {
        "update": {
            method: "PUT"
        }
    });
});
