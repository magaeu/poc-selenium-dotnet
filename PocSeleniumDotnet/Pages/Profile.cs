using System;
using OpenQA.Selenium;

namespace PocSeleniumDotnet
{
    public class Profile : BasePage
    {
        public Profile(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        {
            get
            {
                try
                {
                    return Driver.FindElement(By.Id("pageProfile")).Displayed;
                }
                catch (NoSuchElementException)
                {
                    throw new ArgumentNullException("No such item exists");
                }
            }
        }
    }
}