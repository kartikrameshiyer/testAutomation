using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleSearchAutomation.Utilities
{
    public class BrowserUtility
    {
        private IWebDriver driver;

        public IWebDriver LaunchBrowser(string url)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");  
            options.AddArguments("no-sandbox");  
            options.AddArguments("disable-dev-shm-usage");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public void SearchGoogle(string searchTerm)
        {
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchTerm);
            searchBox.Submit();
        }

        public bool ValidateSearchResults(string expectedText)
        {
            return driver.PageSource.Contains(expectedText);
        }

        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
