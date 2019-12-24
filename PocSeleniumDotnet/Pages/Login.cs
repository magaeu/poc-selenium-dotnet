using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace PocSeleniumDotnet
{
    public class Login : BasePage
    {
        private IWebElement FullNameField => Driver.FindElement(By.Id("name"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("password"));
        private IWebElement LoginBtn => Driver.FindElement(By.Id("login"));
        private IList<IWebElement> ErrorMessages => Driver.FindElements(By.ClassName("invalid-feedback"));

        public string ErrorMsgText => ErrorElement()?.Text;

        public List<string> ErrorMsgTexts
        {
            get
            {
                var elements = ErrorMessages.Where(e => e.Displayed);
                List<string> errorTexts = new List<string>{};
                foreach (var item in elements)
                {
                    HighlightElementUsingJavaScript(item);
                    errorTexts.Add(item.Text);
                }

                return errorTexts;
            }
        }

        public Login(IWebDriver driver) : base(driver) { }

        public Profile FillValidCredentialsAndClick(Credentials credentials)
        {
            FillCredentials(credentials);
            LoginBtn.Click();

            return new Profile(Driver);
        }

        public Login FillCredentialsWithoutRequiredFieldAndClick(Credentials credentials)
        {
            FillCredentials(credentials);
            LoginBtn.Click();

            return new Login(Driver);
        }

        private void FillCredentials(Credentials credentials)
        {
            FullNameField.Clear();
            FullNameField.SendKeys(credentials.FullName);
            PasswordField.Clear();
            PasswordField.SendKeys(credentials.Password);
        }

        private IWebElement ErrorElement()
        {
            var element = ErrorMessages.FirstOrDefault(e => e.Displayed);
            if (element != null)
            {
                HighlightElementUsingJavaScript(element);
                return element;
            }

            return null;
        }

    }
}