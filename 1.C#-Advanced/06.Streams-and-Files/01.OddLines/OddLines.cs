using System;
using System.IO;

class OddLines
{
    //Write a program that reads a text file and prints on the console its odd lines. Line numbers starts from 0. Use StreamReader.
    static void Main()
    {
        StreamReader reader = new StreamReader("../../text.txt");
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine("{0}", line);
                    line = reader.ReadLine();
                }
            }
        }

    }
}
