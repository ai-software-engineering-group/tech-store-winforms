using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPM_AI_CT3.Utils
{
    public static class RandomUtils
    {
        public static string GenerateRandomString(int length)
        {
            const string pattern = "bQ5sWak49EGPJTdw8LqBgcAFMK6fYjZznVemDhrpUHR27vS3";
            HashSet<char> usedChars = new HashSet<char>();
            StringBuilder sb = new StringBuilder();

            Random random = new Random();
            while (sb.Length < length)
            {
                char randomChar = pattern[random.Next(pattern.Length)];
                if (!usedChars.Contains(randomChar))
                {
                    usedChars.Add(randomChar);
                    sb.Append(randomChar);
                }
            }

            return sb.ToString();
        }

    }
}
