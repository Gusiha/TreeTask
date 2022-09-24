using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTree
{
    internal static class AutoGeneration
    {
        //ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789
        const string chars = "abcdefghijklmnopqrstuvwxyz";
        static char[] stringChars = new char[1];
        static Random random = new Random();

        public static string Generation()
        {
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
            
        }
    }
}