using System;
using System.Collections.Generic;
using System.IO;

class SlicingFile
{
    //Write a program that takes any file and slices it to n parts.
    //Use FileStreams. You are not allowed to use the File class or similar helper classes.

    const string filePath = "../../input.txt";
    const string assemblePath = "../../assembled.txt";

    private static void Main()
    {
        Console.Write("n:");
        int parts = int.Parse(Console.ReadLine());
        Slice(parts);
        for (int i = 0; i < parts; i++)
        {
            Assemble(i);
        }
    }

    private static void Slice(int parts)
    {
        using (var source = new FileStream(filePath, FileMode.Open))
        {
            long sliceSize = source.Length / parts;
            long leftOver = source.Length - sliceSize * parts;
            for (int i = 0; i < parts; i++)
            {
                using (var destination = new FileStream(string.Format("../../Part-{0}.txt", i), FileMode.Create))
                {
                    sliceSize = (i < parts - 1) ? sliceSize : sliceSize + leftOver;
                    var buffer = new byte[sliceSize];
                    source.Read(buffer, 0, buffer.Length);
                    destination.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }

    private static void Assemble(int i)
    {
        using (var source = new FileStream(string.Format("../../Part-{0}.txt", i), FileMode.Open))
        {
            using (var destination = new FileStream(assemblePath, i == 0 ? FileMode.Create : FileMode.Append))
            {
                var buffer = new byte[source.Length];
                source.Read(buffer, 0, buffer.Length);
                destination.Write(buffer, 0, buffer.Length);
            }
        }
    }
}