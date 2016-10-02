using System;
using System.IO;

class CopyBinary
{
    //Write a program that copies the contents of a binary file (e.g. image, video, etc.) to another using FileStream. You are not allowed to use the File class or similar helper classes.
    static void Main()
    {
        const string filePath = "../../source.jpg";
        const string copiedPath = "../../copied.txt";

        using (var source = new FileStream(filePath, FileMode.Open))
        {
            using (var destination = new FileStream(copiedPath, FileMode.Create))
            {
                var buffer = new byte[4096];
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    destination.Write(buffer, 0, readBytes);
                }
                Console.WriteLine("Done");
            }
        }
    }
}