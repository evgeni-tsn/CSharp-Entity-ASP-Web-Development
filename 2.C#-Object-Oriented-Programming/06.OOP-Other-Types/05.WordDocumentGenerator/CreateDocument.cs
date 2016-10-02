using System;
using System.Diagnostics;
using Novacode;

namespace _05.WordDocumentGenerator
{
    public class CreateDocument
    {
        public static void CreateSampleDocument()
        {
            //Content parts
            string titleName = "SoftUni OOP Game Contest";
            string paragraph =
                Environment.NewLine + @"SoftUni is organizing a contest for the best role playing game from the OOP teamwork " + Environment.NewLine + "projects. The winning teams will receive a grand prize!" + Environment.NewLine + "The game should be:" + Environment.NewLine;

            // Path
            string fileName = @"..\..\test.docx";

            // Create a document in memory:
            var doc = DocX.Create(fileName);

            //Formatting
            var titleFormat = new Formatting();
            titleFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            titleFormat.Size = 18D;

            // Insert parts:
            Paragraph title = doc.InsertParagraph(titleName, false, titleFormat);
            title.Alignment = Alignment.center;

            Paragraph main = doc.InsertParagraph(paragraph, false);
            main.SpacingAfter(1.5);
            main.Alignment = Alignment.left;

            List list = doc.AddList();
            doc.AddListItem(list, "Properly structured and follow all good OOP practices");
            doc.AddListItem(list, "Awesome");
            doc.AddListItem(list, "..Very Awesome");
            doc.InsertList(list);
            // Save to the output directory:
            doc.Save();

            // Open in Word:
            Process.Start("WINWORD.EXE", fileName);
        }
    }
}