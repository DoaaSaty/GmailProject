using Automated.Utilities.Utilities;
using Automated.Utilities.Utilities.Parsers;
using System;
using System.Configuration;
using System.Linq;

namespace Syngenta.GENIE.Automation.Application
{
    public class AppConfigs
    {
        //Automation Directory
        public static string directory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

        // Initialize long and short time
        public static int LongTime;
        public static int ShortTime;
        public static int MediumTime;
        public static string filePath;
        public static string IDFilePath;

        public static bool IsTestConfigsInitialized = false;

        /// <summary>
        /// Read the provided test configurations
        /// </summary>
        public static void ReadConfigs()
        {
            // Waiting time: long and short

            ShortTime = int.Parse(ConfigurationManager.AppSettings["ShortTime"]);
            MediumTime = int.Parse(ConfigurationManager.AppSettings["MediumTime"]);
            LongTime = int.Parse(ConfigurationManager.AppSettings["LongTime"]);

            //ImportFiles path
            filePath = directory + ConfigurationManager.AppSettings["FilePath"];
            IDFilePath = directory + ConfigurationManager.AppSettings["IdFilePath"];
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
                IsTestConfigsInitialized = true;

            }//endif

        }//end method


    }
}
