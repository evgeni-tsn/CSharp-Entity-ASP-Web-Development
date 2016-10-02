using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

class ZippingSlicedFiles
{
    //Modify your previous program to also compress the bytes while slicing parts and decompress them when assembling them back to the original file. Use GzipStream.
    //Tip: When getting files from directory, make sure you only get files with.gz extension(there might be hidden files).

    public static List<string> files = new List<string>();

    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        SplitAndCompressFile(@"..\..\input.avi", @"..\..\", n);
        DecompressAndAssembleFile(files, @"..\..\");

    }
    public static void SplitAndCompressFile(string inputFile, string path, int parts)
    {
        byte[] byteSource = File.ReadAllBytes(inputFile);
        FileInfo info = new FileInfo(inputFile);
        int partSize = (int)Math.Ceiling((double)(info.Length / parts));
        int fileOffset = 0;
        string currPartPath;
        FileStream fsPart;
        GZipStream csPart;
        int sizeRemaining = (int)info.Length;
        for (int i = 0; i < parts; i++)
        {
            currPartPath = path + "part-" + i + ".gz";
            files.Add(currPartPath);
            if (!File.Exists(currPartPath))
            {
                using (fsPart = new FileStream(currPartPath, FileMode.CreateNew))
                {
                    using (csPart = new GZipStream(fsPart, CompressionMode.Compress, false))
                    {
                        csPart.Write(byteSource, fileOffset, partSize);
                    }

                }

                sizeRemaining = (int)info.Length - (i * partSize);
                if (sizeRemaining < partSize)
                {
                    partSize = sizeRemaining;
                }
                fileOffset += partSize;
            }
        }
    }

    public static void DecompressAndAssembleFile(List<string> files, string destination)
    {
        string fullPath = destination + "assembled.avi";
        GZipStream csFiles;
        using (FileStream fsSource = new FileStream(fullPath, FileMode.Append))
        {
            foreach (string path in files)
            {
                using (FileStream input = new FileStream(path, FileMode.Open))
                {
                    using (csFiles = new GZipStream(input, CompressionMode.Decompress, false))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readByte = csFiles.Read(buffer, 0, buffer.Length);
                            if (readByte == 0)
                            {
                                break;
                            }
                            fsSource.Write(buffer, 0, readByte);
                        }
                    }
                }
            }
        }
    }
}