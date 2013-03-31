using System;
using TechTalk.SpecFlow;

namespace FitnessRecipes.WebTests.StepDefinitions
{
    [Binding]
    public class DietSteps
    {
        [When(@"I go to diet page")]
        public void WhenIGoToDietPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I want to see a list of diets")]
        public void ThenIWantToSeeAListOfDiets()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
