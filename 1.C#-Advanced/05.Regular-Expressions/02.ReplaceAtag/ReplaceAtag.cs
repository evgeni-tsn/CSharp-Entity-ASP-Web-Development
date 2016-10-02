using System;
using System.Text.RegularExpressions;

class ReplaceAtag
{
    //Write a program that replaces in a HTML document given as string all the tags <a href=…>…</a> with corresponding tags [URL href=…]…[/URL]. Print the result on the console. 
    //The value of the href attribute can be enclosed in single or double quotes.The opening quotes must be the same as the closing closed (e.g. this is invalid: href= 'softuni.bg").

    private static void Main()
    {
        string input = @"<ul><li><a href=""http://softuni.bg"">SoftUni</a></li></ul>";
        var pattern = @"<a(\shref=)""(.+)"">(.+)<\/a>";
        Regex regex = new Regex(pattern);
        Console.WriteLine(regex.Replace(input, @"[URL$1$2]$3[/URL]"));
    } 
}

