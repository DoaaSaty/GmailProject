using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syngenta.GENIE.Automation.Application
{
    public static class ApplicationConfigs
    {
        //Application Settings
        public static string directory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
        public static string ObjectRepository { get; set; } = directory + ConfigurationManager.AppSettings["ObjectRepository"];

    }//end class
}
