/// <reference path="../_references.ts" />

module App {
    'use strict';
    export class FrontpageController {
    public injection(): any[]{
        return [
            '$scope',
            'mealService',
            FrontpageController
        ]
    }
    constructor(
        private $scope: IFrontpageScope,
        private mealService: IMealService
        ) {
            $scope.meals = mealService.query();
    }
    }
}