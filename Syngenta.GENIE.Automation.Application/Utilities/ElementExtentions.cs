using System;
using Automated.Utilities.AutomationAbstractions.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Syngenta.GENIE.Automation.Application.Utilities
{
    public static class ElementExtentions
    {

        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            for (int i = 0; i < text.Length; i++)
            {
                element.SendKeys(text[i].ToString());
            }
        }

        public static void EnterTextUsingJs(this IWebElement element, string text)
        {
            element.Clear();
            ((IJavaScriptExecutor)AutomatedBrowser.WebDriverInstance).ExecuteScript("arguments[0].value='" + text + "';", element);
        }

        public static void ClickUsingJavaScript(this IWebElement element)
        {
            ((IJavaScriptExecutor)AutomatedBrowser.WebDriverInstance).ExecuteScript("arguments[0].click();", element);
        }


        public static string ExecuteScriptUsingJs(this IWebDriver driver, string script)
        {
            var x = ((IJavaScriptExecutor)driver).ExecuteScript(script);
            return x?.ToString();
        }

        public static IWebElement ScrollToElement(this IWebDriver driver, By elementLocator, int timeOutInSeconds)
        {

            WebDriverWait wait = GetWebDriverWait(timeOutInSeconds);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            // presence in DOM
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator)); //FIXME: was: presenceOfElementLocated
            IWebElement element = driver.FindElement(elementLocator);
            // scrolling
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            return element;
        }

        public static WebDriverWait GetWebDriverWait(int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(AutomatedBrowser.WebDriverInstance, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait;
        }
    }
}
