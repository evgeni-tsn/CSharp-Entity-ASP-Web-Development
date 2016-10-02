using System;
using System.Text.RegularExpressions;

class ValidUsernames
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"\b[a-zA-Z]\w{2,24}\b";
        Regex usernames = new Regex(pattern);
        MatchCollection matches = usernames.Matches(input);
        int first = 0;
        int second = 1;
        int maxSum = Int32.MinValue;
        int sum = 0;
        for (int i = 0; i < matches.Count-1; i++)
        {
            sum = matches[i].Length + matches[i + 1].Length;
            if (sum>maxSum)
            {
                maxSum = sum;
                first = i;
                second = i + 1;
            }
        }
        Console.WriteLine(matches[first]);
        Console.WriteLine(matches[second]);
    }
}
