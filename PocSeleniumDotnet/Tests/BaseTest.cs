using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using AutomationResources;

namespace PocSeleniumDotnet
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
        }

    }
}