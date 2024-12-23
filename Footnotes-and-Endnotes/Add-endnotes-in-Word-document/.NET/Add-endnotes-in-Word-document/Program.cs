﻿using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;

namespace Add_endnotes_in_Word_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a new Word document.
            using (WordDocument document = new WordDocument())
            {
				//Creates a section.
				IWSection section = document.AddSection();
				//Adds a paragraph to a section.
				IWParagraph paragraph = section.AddParagraph();
				//Appends the text to paragraph.
				paragraph.AppendText("Working with endnotes");
				//Formats the text.
				paragraph.ApplyStyle(BuiltinStyle.Heading1);
				//Adds a paragraph to a section.
				paragraph = section.AddParagraph();
				//Appends the endnotes.
				WFootnote endnote = (WFootnote)paragraph.AppendFootnote(Syncfusion.DocIO.FootnoteType.Endnote);
				//Sets the endnote character format.
				endnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;
				//Inserts the text into the paragraph.
				paragraph.AppendText("Sample content for endnotes").CharacterFormat.Bold = true;
				//Adds endnote text.
				paragraph = endnote.TextBody.AddParagraph();
				paragraph.AppendText("AdventureWorks Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company.");
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
