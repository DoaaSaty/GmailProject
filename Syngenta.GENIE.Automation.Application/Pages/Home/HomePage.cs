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
   public class HomePage
    {
        private IWebDriver driver;
        Dictionary<string, AutomatedElement> PageElements;
        AutomatedElement _composeBtn, _toTextField, _subjectTextField, _body, _threeDotsBtn, _labelOptions,
            _socialCheckBox, _sendBtn, _inbox, _firstMailStarred, _myReceivedMail, _receivedMailSubject;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            AutomatedActions.NavigationActions.InitBrowser(driver);

            PageElements = ElementParser.Initialize_Page_Elements(ApplicationConfigs.ObjectRepository + "Home\\HomePage.json");
            _composeBtn = PageElements["composeBtn"];
            _toTextField = PageElements["toTextField"];
            _subjectTextField = PageElements["subjectTextField"];
            _body = PageElements["body"];
            _threeDotsBtn = PageElements["threeDotsBtn"];
            _labelOptions = PageElements["labelOptions"];
            _socialCheckBox = PageElements["socialCheckBox"];
            _sendBtn = PageElements["sendBtn"];
            _inbox = PageElements["inbox"];
            _firstMailStarred = PageElements["firstMailStarred"];
            _myReceivedMail = PageElements["myReceivedMail"];
            _receivedMailSubject = PageElements["receivedMailSubject"];
        }
        
        public void ClickOnComposeBtn()
        {
            
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_composeBtn, 120);
            AutomatedActions.ClickActions.ClickOnElement(_composeBtn);
        
        }
        public void EnterEecipient(string to)
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_toTextField, 120);
            AutomatedActions.TextActions.EnterTextInField(_toTextField, to);

        }
        public void EnterSubject(string subject)
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_subjectTextField, 120);
            AutomatedActions.TextActions.EnterTextInField(_subjectTextField, subject);

        }
        public void EnterBody(string bodyData)
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_body, 120);
            AutomatedActions.TextActions.EnterTextInField(_body, bodyData);

        }
        public void MarkMailAsSocial()
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_threeDotsBtn, 120);
            AutomatedActions.ClickActions.ClickOnElement(_threeDotsBtn);
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_labelOptions, 120);
            AutomatedActions.ClickActions.ClickOnElement(_labelOptions);
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_socialCheckBox, 120);
            AutomatedActions.SelectActions.SelectCheckBox(_socialCheckBox);

        }
        public void ClickOnSendBtn()
        {

            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_sendBtn, 120);
            AutomatedActions.ClickActions.ClickOnElement(_sendBtn);

        }
        public void ClickOnInbox()
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_inbox, 120);
            AutomatedActions.ClickActions.ClickOnElement(_inbox);
        }

        public void MarkMyReceivedMailAsStarred()
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_firstMailStarred, 120);
            AutomatedActions.ClickActions.ClickOnElement(_firstMailStarred);
        }
        public void OpenMyReceivedMail()
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_myReceivedMail, 120);
            AutomatedActions.ClickActions.ClickOnElement(_myReceivedMail);
        }
        public string VerifyMyReceivedMailSubject()
        {
            AutomatedActions.WaitActions.WaitForWebElementToBeClickable(_receivedMailSubject, 120);
            return AutomatedActions.ElementActions.GetTextOfElement(_receivedMailSubject);
        }

       
    }
}
