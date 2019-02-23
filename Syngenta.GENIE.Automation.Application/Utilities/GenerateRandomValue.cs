using System;
using System.Text;

namespace Syngenta.GENIE.Automation.Application.Utilities
{
    public static class GenerateRandomValue
    {
        // Generate a random number below defined maximum number  
        public static int RandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(max);
        }

        // Generate a random string with a given size  
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToUpper();
        }
    }
}
