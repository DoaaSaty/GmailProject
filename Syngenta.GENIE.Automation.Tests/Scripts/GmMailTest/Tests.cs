using Automated.Application.Domain.Model;
using Automated.Application.Pages.Home;
using Automated.Utilities.AutomationAbstractions.Components;
using NUnit.Framework;
using Syngenta.GENIE.Automation.Tests;
using System.Reflection;

namespace Automated.Tests.Scripts.SmokeTests
{
    [TestFixture]
    class Tests : TestMain
    {
        LoginPage _loginPage;
        LoginData _loginData;
        HomePage _homePage;
        HomeData _homeData;
        [SetUp]
        public new void SetupTest()
        {
            _loginPage = new LoginPage(AutomatedBrowser.WebDriverInstance);
            _loginData = new LoginData();
            _homeData = new HomeData();
            _homePage = new HomePage(AutomatedBrowser.WebDriverInstance);
        }

        [Test, Order(1)]
        [Category("LoginTests"), Retry(TestConfigs.MaxNumberOfRetries)]

        public void ShouldSendEmail()
        {
            // Get the current method name and current class name
            var testCaseName = MethodBase.GetCurrentMethod().Name;// method name 
            var worksheetName = GetType().Name;  // class name

            //enter credentials
            _loginData.FillData(worksheetName, testCaseName);
            _loginPage.EnterEmailAddress(LoginData.emailAddress);
            _loginPage.ClickOnNextBtn();
            _loginPage.EnterPassword(LoginData.password);
            _loginPage.ClickOnNextBtn();

            //Compose email
            _homeData.FillData(worksheetName, testCaseName);
            _homePage.ClickOnComposeBtn();
            _homePage.EnterEecipient(HomeData.recipient);
            _homePage.EnterSubject(HomeData.subject);
            _homePage.EnterBody(HomeData.body);
            _homePage.MarkMailAsSocial();
            _homePage.ClickOnSendBtn();

            // open received mail
            _homePage.ClickOnInbox();
            _homePage.MarkMyReceivedMailAsStarred();
            _homePage.OpenMyReceivedMail();

            //Assert the subject of my received mail
            if (_homePage.VerifyMyReceivedMailSubject().Equals(HomeData.subject))
            {
                //TestReport.test.Pass(TestContext.CurrentContext.Test.Name + " is passed");
                Assert.True(_homePage.VerifyMyReceivedMailSubject().Equals(HomeData.subject));
            }
            else
            {
                //TestReport.test.Fail(TestContext.CurrentContext.Test.Name + " is failed");
                //TestReport.Log(Status.Fail,);
                Assert.True(_homePage.VerifyMyReceivedMailSubject().Equals(HomeData.subject));
            }

        }

    }
}



