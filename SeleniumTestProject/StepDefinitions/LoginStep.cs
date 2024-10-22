using OpenQA.Selenium;
using GoogleSearchAutomation.Utilities;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace GoogleSearchAutomation.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private BrowserUtility browserUtility;
        private IWebDriver driver;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            browserUtility = new BrowserUtility();
            driver = browserUtility.LaunchBrowser("https://example.com/login");
        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            // Simulate entering credentials and logging in
            IWebElement username = driver.FindElement(By.Id("username"));
            username.SendKeys("valid_user");
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("valid_password");
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            Assert.IsTrue(driver.PageSource.Contains("Welcome"), "Login failed.");
            browserUtility.CloseBrowser();
        }
    }
}
