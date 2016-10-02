using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    //Traverse a given directory for all files with the given extension. Search through the first level of the directory only and write information about each found file in report.txt.
    //The files should be grouped by their extension.Extensions should be ordered by the count of their files (from most to least). If two extensions have equal number of files, order them by name.
    //Files under an extension should be ordered by their size.
    //report.txt should be saved on the Desktop. Ensure the desktop path is always valid, regardless of the user.

    static void Main()
    {
        string pathCurrent = Directory.GetCurrentDirectory();
        string[] filePaths = Directory.GetFiles(pathCurrent);
        List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();
        var sorted =
           files.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);
        string resultPath = "../../result.txt";
        using (var writer = new StreamWriter(resultPath, false))
        {
            foreach (var extensionGroup in sorted)
            {
                writer.WriteLine(extensionGroup.Key);
                foreach (var fileInfo in extensionGroup)
                {
                    writer.WriteLine("--{0} - {1:F3}kb", fileInfo.Name, fileInfo.Length / 1024.0);
                }
            }
        }
    }
}