using System;
using OpenQA.Selenium;

namespace PocSeleniumDotnet
{
    public class Login : BasePage
    {
        private IWebElement FullNameField => Driver.FindElement(By.Id("name"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("password"));
        private IWebElement LoginBtn => Driver.FindElement(By.Id("login"));
        private IWebElement ErrorMsg => Driver.FindElement(By.ClassName("invalid-feedback"));

        public string ErrorMsgText => ErrorMsg.Text;

        public Login(IWebDriver driver) : base(driver)
        {
        }

        public Profile FillValidCredentialsAndClick(Credentials credentials)
        {
            FillCredentials(credentials);
            LoginBtn.Click();

            return new Profile(Driver);
        }

        private void FillCredentials(Credentials credentials)
        {
            FullNameField.Clear();
            FullNameField.SendKeys(credentials.FullName);
            PasswordField.Clear();
            PasswordField.SendKeys(credentials.Password);
        }

    }
}