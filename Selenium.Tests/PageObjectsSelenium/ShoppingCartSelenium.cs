using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests
{
    internal class ShoppingCartSelenium
    {
        private IWebDriver driver;

        

        public ShoppingCartSelenium(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement FindHyperlink()
        {

            return driver.FindElement(By.LinkText("Checkout >>"));

        }

        internal LoginSelenium Checkout()
        {
            FindHyperlink().Click();
            return new LoginSelenium(driver);
        }
    }
}