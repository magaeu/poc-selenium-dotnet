using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PocSeleniumDotnet
{
    public class HomePage : BasePage
    {
        private string pageTitle => "TestProject Demo";

        public Login Login { get; private set; }
        
        
        public HomePage(IWebDriver driver) : base(driver)
        {
            Login = new Login(driver);
        }

        public void GoTo()
        {
            var url = "https://example.testproject.io/web/";
            Driver.Navigate().GoToUrl(url);
            Assert.IsTrue(Driver.Title.Contains(pageTitle));
        }
    }
}