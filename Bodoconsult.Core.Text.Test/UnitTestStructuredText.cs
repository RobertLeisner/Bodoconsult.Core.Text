using System.IO;
using System.Linq;
using Bodoconsult.Core.Text.Enums;
using Bodoconsult.Core.Text.Model;
using Bodoconsult.Core.Text.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Core.Text.Test
{
    [TestFixture]
    public class UnitTestStructuredText
    {
        private const string MassText =
            "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

        [Test]
        public void TestDataTable()
        {

            const string h1 = "T1 Überschrift 1";

            var masterText = new StructuredText();
            masterText.AddHeader1(h1);
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 2");
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 2");
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 1");
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 2");


            masterText.AddTable("Tabellentitel", DataHelper.GetData());

            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 2");
            masterText.AddParagraph(MassText);
            masterText.AddHeader1("Überschrift 1");
            masterText.AddParagraph(MassText);
            masterText.AddParagraph(MassText);

            var fileName = @"D:\temp\datatable.json";
            if (File.Exists(fileName)) File.Delete(fileName);

            JsonHelper.SaveAsFile(fileName, masterText);

            var sr = JsonHelper.LoadJsonFile<StructuredText>(fileName);

            var sourceItem =
                (TableTextItem) masterText.TextItems.FirstOrDefault(x => x.LogicalType == TextItemType.Table);
            var item = (TableTextItem)sr.TextItems.FirstOrDefault(x => x.LogicalType == TextItemType.Table);

            Assert.IsTrue(File.Exists(fileName));
            Assert.IsTrue(masterText.TextItems.Count==sr.TextItems.Count);
            Assert.IsTrue(item.DataTableXml!=null);
            Assert.IsTrue(item.DataTableXml == sourceItem.DataTableXml);
        }

    }
}