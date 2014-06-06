using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RockPaperScissors
{
    class StringHelpers
    {
        public static string Seperate(string input)
        {
            const string replace = " ";
            string output = Regex.Replace(input, "(?=[A-Z][^A-Z])", replace);
            output = output.Substring(1, output.Length - 1);
            return output;

        }
    }
}
