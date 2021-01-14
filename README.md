# What does the library

Bodoconsult.Core.Text is a simple tool to generate structured text documents in a C# project and export it finally to a HTML or ASCII plain text file.

We use Bodoconsult.Core.Text for creating unit test logfiles intended for presentation to auditors. Another usage at Bodoconsult is creating an automated documentation for an app based on unit tests.

# How to use the library

The source code contain NUnit test classes, the following source code is extracted from. The samples below show the most helpful use cases for the library.

## Export as HTML without template (HtmlTextFormatter class)

            var sr = new StructuredText();
            sr.AddHeader1("Überschrift 1 '& &&&' ");
            sr.AddParagraph(MassText, "CssTestFixture");
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");
            sr.AddParagraph("");

            sr.AddParagraph(FormattedMasstext,
                "CssTestFixture");

            sr.AddCode(MassText, "CssTestFixture");

            sr.AddParagraph(MassText);

            sr.AddListItem("Bahnhof");
            sr.AddListItem("HauptBahnhof");
            sr.AddListItem("SüdBahnhof");
            sr.AddHeader2("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);

            var f = new HtmlTextFormatter { StructuredText = sr };
            f.GetFormattedText();
			
			f.SaveAsFile(fileName);

## Export as HTML with a individual template (HtmlTextFormatter class)

			var sr = new StructuredText();
            sr.AddHeader1("Überschrift 'Databanka'");
            sr.AddParagraph(MassText);
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");
            sr.AddParagraph("");
            sr.AddParagraph(MassText);

            sr.AddListItem("Bahnhof");
            sr.AddListItem("HauptBahnhof");
            sr.AddListItem("SüdBahnhof");
            sr.AddHeader2("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);

            var f = new HtmlTextFormatter
            {
                StructuredText = sr,
                Template = "<<<Start>>>{0}<<<Ende>>>",
                AddTableOfContent = true
            };
            var result = f.GetFormattedText();
			
			f.SaveAsFile(fileName);

## Export as plain ASCII file (PlainTextFormatter class)

 var sr = new StructuredText();
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");
            sr.AddParagraph("");
            sr.AddParagraph(MassText);

            sr.AddListItem("Bahnhof");
            sr.AddListItem("HauptBahnhof");
            sr.AddListItem("SüdBahnhof");

            sr.AddHeader1("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);

            var f = new PlainTextFormatter { StructuredText = sr };
            var result = f.GetFormattedText();
			
			f.SaveAsFile(fileName);


# About us

Bodoconsult (<http://www.bodoconsult.de>) is a Munich based software company.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

