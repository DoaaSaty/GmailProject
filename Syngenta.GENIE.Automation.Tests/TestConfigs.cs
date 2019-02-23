using Automated.Utilities.Utilities;
using System.Configuration;
using System.IO;
using System;
using Automated.Utilities.Utilities.Parsers;

namespace Syngenta.GENIE.Automation.Tests
{
    class TestConfigs
    {

        //Automation Root Directory
        public static string AutomationDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

        //Application Settings
        public static string Url;
        public static string Browser;

        
        // Reporting Path URL
        public static string ReportUrl = AutomationDirectory + ConfigurationManager.AppSettings["ReportUrl"];
        public static string ReportName = ConfigurationManager.AppSettings["ReportName"];

       

        //Files
        public static string TestDataFile;
       // public static string myConnectionString;

        //Logs
        public static string LogFile;
        
        //Maximum number of retries if the test failed
        public const int MaxNumberOfRetries = 3;

        public static bool IsTestConfigsInitialized = false;

        /// <summary>
        /// Read the provided test configurations
        /// </summary>
        public static void ReadConfigs()
        {
            ////Application Settings
            //Application Settings
            //AutomationDirectory = ConfigurationManager.AppSettings["AutomationDirectory"];

            Url = ConfigurationManager.AppSettings["Url"];
            Browser = ConfigurationManager.AppSettings["Browser"];
            //AppDomain.CurrentDomain.BaseDirectory
            //Files: Test Data, Messages, ...
            TestDataFile = Path.Combine(AutomationDirectory, ConfigurationManager.AppSettings["TestDataFile"]);
            LogFile = AutomationDirectory + @"Logs\AutomatedTests.log";


            // Connection string
            //ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            // myConnectionString = connections["FadaConnection"].ConnectionString;

        }//end method ReadConfigs

        /// <summary>
        /// Initialize the test configurations
        /// </summary>
        public static void Init()
        {
            if (!IsTestConfigsInitialized)
            {
                //Read the automated app configs
                ReadConfigs();

                //Initialize your configs: messages, test data, logger, ...

                ExcelDataParser.Init(TestConfigs.TestDataFile);
                //ExcelFileParser.Init(Resource1.RIMSTestData);
                AutomatedLogger.Init(LogFile);

                IsTestConfigsInitialized = true;

            }//endif

        }//end method
        
        /// <summary>
        /// Check if you are testing remotely or on a localhost
        /// </summary>
        /// <returns></returns>
        public static bool IsRemoteTesting()
        {
            bool isRemote = !Url.Contains("localhost");
            return isRemote;
        }

    }
}
