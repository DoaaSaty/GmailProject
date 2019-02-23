using Automated.Utilities.AutomationAbstractions.Components;
using Automated.Utilities.AutomationAbstractions.CoreActions;
using Automated.Utilities.Utilities.Parsers;
using OpenQA.Selenium;
using Syngenta.GENIE.Automation.Application;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Application.Pages.Home
{
   public class LoginPage
    {
        private IWebDriver driver;
        Dictionary<string, AutomatedElement> PageElements;
        AutomatedElement _emailTextfield, _nextBtn, _passwordTextField, _nextBtn2;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            AutomatedActions.NavigationActions.InitBrowser(driver);

            PageElements = ElementParser.Initialize_Page_Elements(ApplicationConfigs.ObjectRepository + "Login\\LoginPage.json");
            _emailTextfield = PageElements["emailTextfield"];
            _nextBtn = PageElements["nextBtn"];
            _passwordTextField = PageElements["passwordTextField"];
            _nextBtn2 = PageElements["nextBtn2"];
           
        }
        
        public void EnterEmailAddress(string emailAddress)
        {
            
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_emailTextfield, 120);
            AutomatedActions.TextActions.EnterTextInField(_emailTextfield, emailAddress);
        
        }
        public void EnterPassword(string passWord)
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_passwordTextField, 120);
            AutomatedActions.TextActions.EnterTextInField(_passwordTextField, passWord);

        }
        public void ClickOnNextBtn()
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_nextBtn, 120);
            AutomatedActions.ClickActions.ClickOnElement(_nextBtn);

        }

       
    }
}
