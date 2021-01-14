using System.Diagnostics;
using System.IO;
using Bodoconsult.Core.Text.Formatter;
using Bodoconsult.Core.Text.Helpers;
using Bodoconsult.Core.Text.Model;
using Bodoconsult.Core.Text.Test.Helpers;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Text.Test
{
    [TestFixture]
    public class UnitTestTextHelper
    {
        private const string MassText =
            "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

        [Test]

        public void TestAppendText()
        {

            const string h1 = "T1 Überschrift 1";
            const string h2 = "Ende T2";

            var masterText = new StructuredText();
            masterText.AddHeader1(h1);
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 2");
            masterText.AddParagraph(MassText);

            masterText.AddCode(MassText);

            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 2");
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 1");
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 2");
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 2");
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 1");
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);


            var toAppendText = new StructuredText();
            toAppendText.AddHeader1("T2 Überschrift 1");
            toAppendText.AddParagraph(MassText);
            toAppendText.AddHeader1("Überschrift 2");
            toAppendText.AddParagraph(MassText);
            toAppendText.AddParagraph(MassText);
            toAppendText.AddHeader1("Überschrift 2");
            toAppendText.AddParagraph(MassText);
            toAppendText.AddHeader1("Überschrift 1");
            toAppendText.AddParagraph(MassText);
            toAppendText.AddParagraph(MassText);
            toAppendText.AddParagraph(MassText);
            toAppendText.AddHeader1("Überschrift 2");
            toAppendText.AddParagraph(MassText);
            toAppendText.AddParagraph(MassText);
            toAppendText.AddParagraph(MassText);
            toAppendText.AddParagraph(MassText);
            toAppendText.AddHeader1("Überschrift 2");
            toAppendText.AddParagraph(MassText);
            toAppendText.AddHeader1("Überschrift 1");
            toAppendText.AddParagraph(MassText);
            toAppendText.AddParagraph(h2);


            var masterCount = masterText.TextItems.Count;
            var toAppendCount = toAppendText.TextItems.Count;

            masterText.AppendText(toAppendText);

            Assert.IsTrue(masterText.TextItems.Count == masterCount + toAppendCount);
            Assert.IsTrue(masterText.TextItems[0].Content == h1);
            Assert.IsTrue(masterText.TextItems[masterText.TextItems.Count-1].Content == h2);
        }


        [Test]
        public void TestAppendUtf8PlainTextFile_Html()
        {

            var fileName = Path.Combine(FileHelper.GetAppPath(), "Resources\\HelpFile.txt");

            var sr = new StructuredText();
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");

            sr.AppendUtf8PlainTextFile(fileName);


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

            Debug.Print(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result));

        }

        [Test]
        public void TestAppendUtf8PlainTextFile_Text()
        {

            var fileName = Path.Combine(FileHelper.GetAppPath(), "Resources\\HelpFile.txt");

            var sr = new StructuredText();
            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");
            sr.AddDefinitionListLine("Defini 4", null);

            sr.AppendUtf8PlainTextFile(fileName);

            sr.AddHeader1("Überschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);

            var f = new PlainTextFormatter
            {
                StructuredText = sr,
            };
            var result = f.GetFormattedText();

            Debug.Print(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result));

        }
    }
}