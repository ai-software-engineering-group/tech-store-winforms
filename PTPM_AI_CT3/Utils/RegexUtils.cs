using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPM_AI_CT3.Utils
{
    public static class RegexUtils
    {
        public static bool ContainsSpecialCharacters(string input)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9-_]*$");
        }
    }
}
