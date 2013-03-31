using System;
using System.Collections.Generic;
using Should;
using TechTalk.SpecFlow;

namespace FitnessRecipes.WebTests.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        [BeforeScenario()]
        public static void SeedDatabase()
        {           
 
        }

        [AfterScenario()]
        public static void ClearDatabase()
        {

        }

        [When(@"I press add new")]
        public void WhenIPressAddNew()
        {
            Browser.ClickLinkWithId("lnkAddNew");
        }

        [Given("I am not authenticated")]
        public void IAmNotAuthenticated()
        {
            Browser.NavigateTo("");
            Browser.LogOut();
        }

        [When(@"I press save")]
        public void IPressSave()
        {
            Browser.ClickButtonWithValue("Create");
        }

        [When(@"I press cancel")]
        public void IPressCancel()
        {
            Browser.ClickLinkWithId("lnkReset");
        }

        [Then(@"a success message should be displayed")]
        public void ASuccessMessageShouldBeDisplayed()
        {
            Browser.DivWithIdIsShown("divSuccess").ShouldBeTrue();
        }

        [Then(@"an error message should be displayed")]
        public void AErrorMessageShouldBeDisplayed()
        {
            Browser.SpanWithClassIsShown("error field-validation-error").ShouldBeTrue();
        }

        [Then(@"an error modal should be displayed")]
        public void AErrorModalShouldBeDisplayed()
        {
            Browser.DivWithIdIsShown("error").ShouldBeTrue();
        }

        [Given("I have logged in as an admin")]
        public void IHaveLoggedInAsAnAdmin()
        {
            Browser.NavigateTo("Account/Login");
            Browser.SetElementValue("UserName", "admin@icon.no");
            Browser.SetElementValue("Password", "passord");
            Browser.ClickButtonWithValue("Logg inn");
        }

        [Given("I have logged in as a venuemanager")]
        public void IHaveLoggedInAsAVenuemanager()
        {
            Browser.NavigateTo("Account/Login");
            Browser.SetElementValue("UserName", "venuemanager@icon.no");
            Browser.SetElementValue("Password", "passord");
            Browser.ClickButtonWithValue("Logg inn");
        }

        [Given("I have logged in as a venuemanager with venues")]
        public void IHaveLoggedInAsAVenuemanagerWithConnectedVenue()
        {
            Browser.NavigateTo("Account/Login");
            Browser.SetElementValue("UserName", "venuemanagervenue@icon.no");
            Browser.SetElementValue("Password", "passord");
            Browser.ClickButtonWithValue("Logg inn");
        }

        [Given("I have logged in as a conferencemanager")]
        public void IHaveLoggedInAsAConferencemanager()
        {
            Browser.NavigateTo("Account/Login");
            Browser.SetElementValue("UserName", "conferencemanager@icon.no");
            Browser.SetElementValue("Password", "passord");
            Browser.ClickButtonWithValue("Logg inn");
        }


        [Then(@"the save button should be disabled")]
        public void ThenTheSaveButtonShouldBeDisabled()
        {
            Browser.ButtonIsEnabled("btnCreate").ShouldBeFalse();
        }

        [Given(@"I have selected a conference")]
        public void IHaveSelectedAConference()
        {
            Browser.SelectItemInDropdownByName("ddlConference", "TestName");
        }

        [Then(@"a succesfull delete message should be displayed")]
        public void ThenASuccesfullDeleteMessageShouldBeDisplayed()
        {
            Browser.DivWithIdIsShown("divDeleteSuccessfull").ShouldBeTrue();
        }

        [When(@"I press delete")]
        public void WhenIPressDelete()
        {
            Browser.ClickLinkWithId("lnkDelete");
        }

    }
}
