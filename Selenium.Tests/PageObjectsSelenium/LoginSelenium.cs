using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests
{
    internal class LoginSelenium
    {
        private IWebDriver driver;

        public LoginSelenium(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal bool IsCheckoutPageValid()
        {
            
            var element = driver.FindElement(By.CssSelector("#main > form:nth-child(6) > div:nth-child(1) > fieldset:nth-child(1) > p:nth-child(7) > input:nth-child(1)"));
            return element != null;
        }
    }
}