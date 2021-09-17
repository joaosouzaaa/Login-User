using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    class Generator
    {
        private static List<char> chars = new List<char>();
        // Creates a list of chars where each char will be stored.
        public static string Passwords()
        {
            AddChars(ref chars);
            int length = 16;
            return Counter(length);
            // Add a password with the specified length.
        }
        static string Counter(int length)
        {
            StringBuilder SB = new StringBuilder();
            Random rnd = new Random();
            int num = 0;
            while (num < length)
            {
                SB.Append(chars[rnd.Next(0, chars.Count)]);
                num++;
                // Add in your StringBuilder your random string.
            }
            return SB.ToString();
        }
        private static void AddChars(ref List<char> chars)
        {
            for (char character = 'a'; character <= 'z'; character++)
            {
                chars.Add(character);
            }
            for (char caractere = 'A'; caractere <= 'Z'; caractere++)
            {
                chars.Add(caractere);
            }
            for (char caractere = '!'; caractere <= '?'; caractere++)
            {
                chars.Add(caractere);
            }
            for (char caractere = '0'; caractere <= '9'; caractere++)
            {
                chars.Add(caractere);
            }
            // It will define each character from 'a' to 'z', and from '0' to '9', from '!' to '?'(add random symbols) and add them to your char list.
        }
    }
}
