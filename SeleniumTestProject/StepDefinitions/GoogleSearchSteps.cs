using OpenQA.Selenium;
using GoogleSearchAutomation.Utilities;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace GoogleSearchAutomation.StepDefinitions
{
    [Binding]
    public class GoogleSearchSteps
    {
        private BrowserUtility browserUtility;
        private IWebDriver driver;

        [Given(@"I am on the Google homepage")]
        public void GivenIAmOnTheGoogleHomepage()
        {
            browserUtility = new BrowserUtility();
            driver = browserUtility.LaunchBrowser("https://www.google.com");
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string searchTerm)
        {
            browserUtility.SearchGoogle(searchTerm);
        }

        [Then(@"I should see ""(.*)"" in the search results")]
        public void ThenIShouldSeeInTheSearchResults(string expectedText)
        {
            bool result = browserUtility.ValidateSearchResults(expectedText);
            Assert.IsTrue(result, $"Search results do not contain {expectedText}");
            browserUtility.CloseBrowser();
        }
    }
}
