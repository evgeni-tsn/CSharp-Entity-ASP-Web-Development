using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class WordCount
{
    //Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file text.txt. Matching should be case-insensitive.
    //Write the results in file results.txt.Sort the words by frequency in descending order. Use StreamReader in combination with StreamWriter.

    static void Main()
    {
        using (var wordsReader = new StreamReader("../../words.txt"))
        {
            using (var textReader = new StreamReader("../../text.txt"))
            {
                using (var writer = new StreamWriter("../../result.txt"))
                {
                    var text = textReader.ReadToEnd().ToLower();
                    var result = new SortedDictionary<int, string>();
                    string word;
                    while ((word = wordsReader.ReadLine()) != null)
                    {
                        var pattern = string.Format(@"\b{0}\b", word.ToLower());
                        var match = Regex.Matches(text, pattern);
                        result.Add(match.Count, word);
                    }
                    foreach (var match in result.Reverse())
                    {
                        writer.WriteLine("{0} - {1}", match.Value, match.Key);
                    }
                }
            }
        }
    }
}