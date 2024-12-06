using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PTPM_AI_CT3.Utils
{
    public static class FormatString
    {
        public static string RemoveVietnameseSigns(string str)
        {
            string regex = "\\p{IsCombiningDiacriticalMarks}+";

            string temp = str.Normalize(NormalizationForm.FormD);
            return Regex.Replace(temp, regex, String.Empty);
        }

        public static string ToSlug(string str)
        {
            string strToLower = str.Trim().ToLower();
            return RemoveVietnameseSigns(strToLower.Replace(" ", "-"));
        }

    }
}
