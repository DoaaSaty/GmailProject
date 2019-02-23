using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Syngenta.GENIE.Automation.Application.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// This function is used to copy any value to the clipboard
        /// </summary>
        /// <param name="value">value to be copied</param>

        public static void CopyToClipBoard(string value)
        {
            Thread thread = new Thread(() => Clipboard.SetText(value));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join();

        }
        /// <summary>
        /// this funtion to combine 2 strings
        /// </summary>

        /// <returns></returns>
        public static string CombineWithNewLine(this string stringA,string stringB)
        {
            return $"{stringA}\n{stringB}";
        }

        /// <summary>
        /// this function to cobmine list of strings 
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static string CombineWithNewLine(this IEnumerable<string> stringList)
        {
            string returnValue = string.Empty;
            foreach(var str in stringList)
            {
                returnValue += $"{str}\n";
            }
            return returnValue.TrimEnd();
        }

        // Split string separated with commas  
        public static List<string> SplitStringSeparatedWithCommas(this string stringTobeSplited)
        {
            return new List<string>(stringTobeSplited.Split(','));
        }

       public static List<string> SplitStringSeparatedwithDot(this string stringtobeSplited)
        {
            var splittedwithDot = stringtobeSplited.Split('.');
            return new List< string >(splittedwithDot);
        }
        public static List<string> SplitStringSeparatedwithSpace(this string stringtobeSplited)
        {
            var splittedwithDot = stringtobeSplited.Split(' ');
            return new List<string>(splittedwithDot);
        }

        public static string SubstringTextWithChars(this string statement, char split1, char split2)
        {
            var startIndex = statement.IndexOf( split1 )+2;
            var endIndex = statement.IndexOf( split2 )-1;
            var length = endIndex - startIndex;
            var text = statement.Substring(startIndex, length);

            return text;
        }

    }
}
