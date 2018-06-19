using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UITests
{
    internal class HomePageSelenium
    {
        private IWebDriver driver;

        public HomePageSelenium(IWebDriver driver)
        {
            this.driver = driver;
        }
        internal ProductDetailSelenium ClickFirstProduct()
        {
            var productList = FindProductList();
            var hyperlink = FindHyperlinkForFirstProduct(productList);
            if (hyperlink != null)
                hyperlink.Click();
            else
                throw new ArgumentException("Unable to find first product on homepage");

            return new ProductDetailSelenium(driver);
        }

        private IWebElement FindHyperlinkForFirstProduct(IWebElement productList)
        {
            var productHyperlinks = productList.FindElements(By.TagName("a"));
            if (productHyperlinks.Count > 0)
                return productHyperlinks[0];
            else
                return null;
        }
        internal bool PageHasProductsListed()
        {
            var element = FindProductList();
            var productLinks = element.FindElements(By.TagName("a"));
            return productLinks.Count > 0;
        }

        private IWebElement FindProductList()
        {
            var productList = driver.FindElement(By.Id("album-list"));
            return productList;
        }
    }
}