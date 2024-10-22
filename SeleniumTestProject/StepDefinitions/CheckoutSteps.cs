using OpenQA.Selenium;
using GoogleSearchAutomation.Utilities;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace GoogleSearchAutomation.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private BrowserUtility browserUtility;
        private IWebDriver driver;

        [Given(@"I am on the checkout page")]
        public void GivenIAmOnTheCheckoutPage()
        {
            browserUtility = new BrowserUtility();
            driver = browserUtility.LaunchBrowser("https://example.com/checkout");
        }

        [When(@"I enter valid payment details")]
        public void WhenIEnterValidPaymentDetails()
        {
            // Simulate entering payment details
            IWebElement cardNumber = driver.FindElement(By.Id("cardNumber"));
            cardNumber.SendKeys("4111111111111111");
            IWebElement expirationDate = driver.FindElement(By.Id("expirationDate"));
            expirationDate.SendKeys("12/25");
            IWebElement cvv = driver.FindElement(By.Id("cvv"));
            cvv.SendKeys("123");
            IWebElement submitButton = driver.FindElement(By.Id("submitButton"));
            submitButton.Click();
        }

        [Then(@"the order should be placed successfully")]
        public void ThenTheOrderShouldBePlacedSuccessfully()
        {
            Assert.IsTrue(driver.PageSource.Contains("Order Confirmed"), "Order was not placed successfully.");
            browserUtility.CloseBrowser();
        }
    }
}
