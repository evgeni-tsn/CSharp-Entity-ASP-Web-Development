namespace Problem3
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SoftuniNumerals
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            string pattern = @"(aa)|(aba)|(bcc)|(cc)|(cdc)";

            MatchCollection matches = Regex.Matches(line, pattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in matches)
            {
                if (match.Groups[1].Value != string.Empty)
                {
                    sb.Append("0");
                }

            }

            string number = sb.ToString();
            string elements = "01234";

            BigInteger input = BigInteger.Parse(number);
            int convertToBase = 5;
            BigInteger results = 0;

            foreach (char digit in input.ToString().ToArray())
            {
                results = (convertToBase * results) + elements.ToUpper().IndexOf(digit);
            }

            Console.WriteLine(results);
        }
    }
}
