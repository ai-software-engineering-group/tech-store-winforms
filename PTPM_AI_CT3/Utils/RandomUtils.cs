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
            string pattern = "bQ5sWak49EGPJTdw8LqBgcAFMK6fYjZznVemDhrpUHR27vS3";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(pattern[new Random().Next(0, pattern.Length)]);
            }

            return sb.ToString();
        }

    }
}
