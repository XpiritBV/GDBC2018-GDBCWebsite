using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;

namespace UITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [TestClass]
    public class SmokeTestSelenium
    {
        string _homePageUrl = "http://localhost:26641/";
        [TestInitialize ]
        public void SmokeTestSeleniumInitialize()
        {
            var envVar = Environment.GetEnvironmentVariable("MVCHomePageUrl");
            if(!string.IsNullOrEmpty(envVar))
            {
                _homePageUrl = envVar;
            }
        }

        [TestMethod]
        public void selenium_HomepageContainsProductsSelenium()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Url = _homePageUrl;
            driver.Navigate();
            var home = new HomePageSelenium(driver);
            Assert.IsTrue( home.PageHasProductsListed(),"Expected to have products on the home page and they are not found");

            driver.Quit();
        }

        [TestMethod]
        public void selenium_CanAddProductToShoppingBasketAndCheckOutSelenium()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Url = _homePageUrl;
            driver.Navigate();
            var home = new HomePageSelenium(driver);
            
            Assert.IsTrue(
            home.ClickFirstProduct()
                .AddToChart()
                .Checkout()
                .IsCheckoutPageValid(),"Expected checkout page would be valid after adding one item to the basket and click checkout");
            driver.Quit();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
