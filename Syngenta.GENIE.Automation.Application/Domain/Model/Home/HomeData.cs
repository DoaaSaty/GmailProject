using Automated.Utilities.Utilities.Parsers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Application.Domain.Model
{
   public class HomeData
    {
        static public string recipient { get; set; }
        static public string subject { get; set; }
        static public string body { get; set; }


        public void FillData(string sheetToGetDataFrom, string getDataFromRow)
        {

            recipient = ExcelDataParser.GetValueOf(sheetToGetDataFrom, getDataFromRow, "Recipient");
            subject = ExcelDataParser.GetValueOf(sheetToGetDataFrom, getDataFromRow, "Subject");
            body = ExcelDataParser.GetValueOf(sheetToGetDataFrom, getDataFromRow, "Body");
        }
        public void Init()
        {
            ExcelDataParser.Init(ConfigurationManager.AppSettings["AutomationDirectory"] + ConfigurationManager.AppSettings["TestDataFile"]);
        }
    }
}
