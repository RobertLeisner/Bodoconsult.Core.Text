using System.Diagnostics;
using Bodoconsult.Core.Text.Formatter;
using Bodoconsult.Core.Text.Model;
using Bodoconsult.Core.Text.Test.Helpers;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Text.Test
{
    [TestFixture]
    public class UnitTestPlainTextFormatter
    {
        private const string MassText = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

        [Test]
        public void TestGetFormattedText_NoTemplate()
        {

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

            Debug.Print(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result));

        }

        [Test]
        public void TestGetFormattedText_WithTemplate()
        {

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

            var f = new PlainTextFormatter
            {
                StructuredText = sr,
                Template = "<<<Start>>>{0}<<<Ende>>>"
            };
            var result = f.GetFormattedText();

            Debug.Print(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result));

        }


        [Test]
        public void TestGetFormattedText_WithTable()
        {

            var sr = new StructuredText();
            sr.AddHeader1("Überschrift 1");

            sr.AddTable("Tabellentitel", DataHelper.GetData());

            sr.AddHeader1("Überschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);

            
            
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

            sr.AddTable("Tabellentitel", DataHelper.GetData());

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

            var f = new PlainTextFormatter
            {
                StructuredText = sr,
                Template = "<<<Start>>>{0}<<<Ende>>>"
            };
            var result = f.GetFormattedText();

            Debug.Print(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result));

        }
    }
}
