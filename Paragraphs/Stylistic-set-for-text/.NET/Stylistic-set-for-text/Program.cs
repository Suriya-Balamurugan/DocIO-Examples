﻿using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;

namespace Stylistic_set_for_text
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a new Word document.
            using (WordDocument document = new WordDocument())
            {
                //Adds new section to the document.
                IWSection section = document.AddSection();
                //Adds new paragraph to the section.
                IWParagraph paragraph = section.AddParagraph();
                //Adds new text.
                IWTextRange text = paragraph.AppendText("Text to describe stylistic sets");
                text.CharacterFormat.FontName = "Gabriola";
                //Sets stylistic set.
                text.CharacterFormat.StylisticSet = StylisticSetType.StylisticSet06;
                paragraph = section.AddParagraph();
                //Adds new text.
                text = paragraph.AppendText("Text to describe stylistic sets");
                text.CharacterFormat.FontName = "Gabriola";
                //Sets stylistic set.
                text.CharacterFormat.StylisticSet = StylisticSetType.StylisticSet15;
                //Creates file stream.
                using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Result.docx"), FileMode.Create, FileAccess.ReadWrite))
                {
                    //Saves the Word document to file stream.
                    document.Save(outputFileStream, FormatType.Docx);
                }
            }
        }
    }
}
