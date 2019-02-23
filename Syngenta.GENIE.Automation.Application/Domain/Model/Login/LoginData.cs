using Automated.Utilities.Utilities.Parsers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Application.Domain.Model
{
   public class LoginData
    {
        static public string emailAddress { get; set; }
        static public string password { get; set; }


        public void FillData(string sheetToGetDataFrom, string getDataFromRow)
        {

            emailAddress = ExcelDataParser.GetValueOf(sheetToGetDataFrom, getDataFromRow, "EmailAddress");
            password = ExcelDataParser.GetValueOf(sheetToGetDataFrom, getDataFromRow, "Password");

        }
        public void Init()
        {
            ExcelDataParser.Init(ConfigurationManager.AppSettings["AutomationDirectory"] + ConfigurationManager.AppSettings["TestDataFile"]);
        }
    }
}
