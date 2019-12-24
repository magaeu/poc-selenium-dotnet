using System;
using System.Threading;
using OpenQA.Selenium;

namespace PocSeleniumDotnet
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void HighlightElementUsingJavaScript(By locationStrategy, int duration = 2)
        {
            var element = Driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");
            var appliedStyle = "border: 7px solid yellow; border-style: dashed;";

            ModifyElementStyle(duration, element, originalStyle, appliedStyle);
        }

        public void HighlightElementUsingJavaScript(IWebElement element, int duration = 2)
        {
            var originalStyle = element.GetAttribute("style");
            var appliedStyle = "border: 7px solid yellow; border-style: dashed;";

            ModifyElementStyle(duration, element, originalStyle, appliedStyle);
        }

        private void ModifyElementStyle(int duration, IWebElement element, string originalStyle, string appliedStyle)
        {
            IJavaScriptExecutor JavaScriptExecutor = Driver as IJavaScriptExecutor;
            JSExcuteScript(element, JavaScriptExecutor, appliedStyle);

            if (duration <= 0) return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));

            appliedStyle = originalStyle;
            JSExcuteScript(element, JavaScriptExecutor, appliedStyle);
        }
        
        private static void JSExcuteScript(IWebElement element, IJavaScriptExecutor JavaScriptExecutor, string appliedStyle)
        {
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                            element,
                            "style",
                            appliedStyle);
        }
    }
}