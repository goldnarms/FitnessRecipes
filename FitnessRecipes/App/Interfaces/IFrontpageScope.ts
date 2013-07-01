/// <reference path="../_references.ts" />
module App{
    export interface IFrontpageScope extends ng.IScope {
        diets: App.Diet[];
        meals: App.Meal[];
        authors: App.Author[];
    }
}