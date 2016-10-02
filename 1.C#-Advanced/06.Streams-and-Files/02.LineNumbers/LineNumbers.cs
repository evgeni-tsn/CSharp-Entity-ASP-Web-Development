using System;
using System.IO;

class LineNumbers
{
    //Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file. Use StreamReader in combination with StreamWriter.
    static void Main()
    {
        StreamReader reader = new StreamReader("../../text.txt");
        StreamWriter writer = new StreamWriter("../../edtied.txt");
        using (reader)
        {
            using (writer)
            {
                int lineNumber = 1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    writer.WriteLine("Line: {0}: {1}", lineNumber, line);
                    Console.WriteLine("Line {0} added", lineNumber);
                    lineNumber++;
                    line = reader.ReadLine();
                }
                Console.WriteLine();
                Console.WriteLine("All lines are added");
            }
            
        }
    }
}