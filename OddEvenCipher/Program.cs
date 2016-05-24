using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenCipher
{
    class Program
    {
        public static string alphaTable = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string oddTable = "DOZYXWVUTSRQPNMLKJECBAIHGF";
        public static string evenTable = "ZYXWUTSRQPMONLKJIHGFDCBAVE";

        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to encrypt: ");
            string toEncrypt = Console.ReadLine();
            string encrpyted = Encrypt(toEncrypt);
            string decrypted = Decrypt(encrpyted);

            Console.WriteLine();
            Console.WriteLine("String before encryption: " + toEncrypt);
            Console.WriteLine();
            Console.WriteLine("String after encryption: " + encrpyted);
            Console.WriteLine();
            Console.WriteLine("String after decryption: " + decrypted);

        }

        public static string Decrypt(string inputEncrypt)
        {
            char[] input = inputEncrypt.ToUpper().ToCharArray();
            StringBuilder output = new StringBuilder();
            int position = 1;

            foreach (char charac in input)
            {
                if (Char.IsWhiteSpace(charac) || Char.IsPunctuation(charac))
                {
                    output.Append(charac.ToString());
                }
                else
                {
                    if (position % 2 == 0)
                    {
                        // Find even position
                        int even = FindPosition(charac, evenTable);

                        // Append character from alpha table
                        output.Append(alphaTable.Substring(even, 1));
                    }
                    else
                    {
                        // Find odd position
                        int odd = FindPosition(charac, oddTable);

                        // Append character from alpha
                        output.Append(alphaTable.Substring(odd, 1));
                    }
                }

                position++;
            }

            return output.ToString();
        }

        public static string Encrypt(string inputString)
        {
            char[] input = inputString.ToUpper().ToCharArray();
            StringBuilder output = new StringBuilder();
            int position = 1;
            int alpha = 0;

            foreach (char charac in input)
            {
                if (Char.IsWhiteSpace(charac) || Char.IsPunctuation(charac))
                {
                    output.Append(charac.ToString());
                }
                else
                {
                    // Find alpha position
                    alpha = FindPosition(charac, alphaTable);

                    if (position % 2 == 0)
                    {
                        // Append character from even table
                        output.Append(evenTable.Substring(alpha, 1));
                    }
                    else
                    {
                        // Append character from odd table
                        output.Append(oddTable.Substring(alpha, 1));
                    }
                }

                position++;
            }

            return output.ToString();
        }

        public static int FindPosition(char character, string table)
        {
            char[] charTable = table.ToCharArray();
            int pos = 0;

            foreach (char chara in charTable)
            {
                if (chara == character)
                {
                    return pos;
                }
                pos++;
            }

            return pos;
        }
    }
}
