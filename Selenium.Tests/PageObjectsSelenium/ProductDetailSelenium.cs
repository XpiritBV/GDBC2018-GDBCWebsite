using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests
{
    internal class ProductDetailSelenium
    {
        private IWebDriver driver;

        public ProductDetailSelenium(IWebDriver driver)
        {
            this.driver = driver;
        }


        private IWebElement FindHyperlink()
        {

            return driver.FindElement(By.PartialLinkText("Add to cart"));
       
        }

        internal ShoppingCartSelenium AddToChart()
        {
            FindHyperlink().Click();
            return new ShoppingCartSelenium(driver);
        }
    }
}