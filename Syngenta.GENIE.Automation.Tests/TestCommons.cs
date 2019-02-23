using Automated.Utilities.AutomationAbstractions.Components;
using Automated.Utilities.AutomationAbstractions.CoreActions;
using Automated.Utilities.Utilities;
using OpenQA.Selenium;
using Syngenta.GENIE.Automation.Test;

namespace Syngenta.GENIE.Automation.Tests
{
    public class TestCommons
    {
        public IWebDriver _driver;

        public void Common_Setup()
        {
            AutomatedLogger.Log("Entering the Common Setup method");

            //Read the Test Configs (including the ones in app.config)            
            TestConfigs.Init();

            //Start a new Browser : Initialize
            _driver = AutomatedBrowser.Initialize(TestConfigs.Browser);

            //Open Website in the browser started by Selenium
            AutomatedActions.NavigationActions.NavigateToUrl(TestConfigs.Url);

            AutomatedBrowser.WebDriverInstance.Manage().Window.Maximize();

            AutomatedLogger.Log("Exiting Common Setup method");

        }//end method Common Setup

    }//end class TestCommons

}//end namespace Automated.Tests
