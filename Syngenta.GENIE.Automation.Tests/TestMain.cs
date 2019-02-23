using Automated.Utilities.AutomationAbstractions.Components;
using Automated.Utilities.Utilities;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;
using Syngenta.GENIE.Automation.Tests;
using Syngenta.GENIE.Automation.Application;
using Syngenta.GENIE.Automation.Test.Report;

namespace Syngenta.GENIE.Automation.Tests
{
    public class TestMain : TestCommons
    {
        AppCommons _applicationCommons;
        protected ExtentReports _extent;
        //private ExtentTest _test;


        [SetUp]
        public void SetupTest()
        {
            AutomatedLogger.Log("Main Test: Setup Tests");
            Common_Setup();
            _applicationCommons = new AppCommons();
            _applicationCommons.Common_Setup();


        }

        [OneTimeSetUp]
        public void RunBeforeAnyTestsInEntireAssembly()
        {
            _extent = ExtentManager.GetExtent();
            Console.WriteLine(@"!!!!! Before any tests in entire assembly!!!!!");
        }

        [OneTimeTearDown]
        public void RunAfterAnyTestsInInEntireAssembly()
        {
            Console.WriteLine(@"!!!!! After all tests in entire assembly!!!!!");
            _extent.Flush();
        }

        [TearDown]
        public void TeardownTest()
        {
            //Close the Browser : EndTest
            AutomatedBrowser.TearDown();

            AutomatedLogger.Log("Main Test: Teardown Tests");
        }

    }//end class

}//namespace
