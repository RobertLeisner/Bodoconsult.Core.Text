using System.Diagnostics;
using System.IO;
using Bodoconsult.Core.Text.Formatter;
using Bodoconsult.Core.Text.Model;
using Bodoconsult.Core.Text.Test.Helpers;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Text.Test
{
    [TestFixture]
    public class UnitTestHtmlTextFormatter
    {
        private const string MassText = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

        private const string FormattedMasstext =
            "??pa??Task to take a documentation for all SQL databases on a Microsoft(R) SqlServer with exception of databases Master, Msdb, Model and TempDb.??pe??" +
            "??pa??Task to take a documentation for all SQL databases on a Microsoft(R) SqlServer with exception of databases Master, Msdb, Model and TempDb.??pe??";

        [Test]
        
        public void TestGetFormattedText_NoTemplate()
        {

            var sr = new StructuredText();
            sr.AddHeader1("�berschrift 1 '& &&&' ");
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
            sr.AddListItem("S�dBahnhof");
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);

            var f = new HtmlTextFormatter { StructuredText = sr };
            var result = f.GetFormattedText();


            Debug.Print(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("<h1"));
            Assert.IsTrue(result.Contains("<h2"));

        }

        [Test]
        public void TestGetFormattedText_MoveHeaderlevel1_NoTemplate()
        {

            var sr = new StructuredText();
            sr.AddHeader1("�berschrift 1 '& &&&' ");

            sr.AddParagraph("??pa??Task to take a documentation for all SQL databases on a Microsoft(R) SqlServer with exception of databases Master, Msdb, Model and TempDb.??pe??");

            sr.AddParagraph(MassText);
            sr.AddParagraph("??pa??Test paragraph PaPe 1??pe????pa??Test paragraph PaPe 2??pe??");

            sr.AddParagraph("<para>Task to take a documentation for all SQL databases on a MSSqlServer with exception of databases Master, Msdb, Model and TempDb.</para><para>A database may contain stored procs under the schema dbo and names beginning with spDbDocu_ for adding database specific " +
                            "content to the docmentation.</para><para>For parts of the documentation the user running the job needs certain permissions." +
                            "To give least possible permissions, this user should be part of a user defined server role on the SqlServer with the permissions VIEW ANY DEFINITION and GRANT VIEW SERVER STATE." +
                            "You should avoid making the user a sysadmin for security reasons. User must have access to each database with least possible permissions!</para>");

            sr.AddDefinitionListLine("Test para", "<para>Task to take a documentation for all SQL databases on a MSSqlServer with exception of databases Master, Msdb, Model and TempDb.</para><para>A database may contain stored procs under the schema dbo and names beginning with spDbDocu_ for adding database specific "+
                                                  "content to the docmentation.</para><para>For parts of the documentation the user running the job needs certain permissions."+
                                                    "To give least possible permissions, this user should be part of a user defined server role on the SqlServer with the permissions VIEW ANY DEFINITION and GRANT VIEW SERVER STATE."+
                "You should avoid making the user a sysadmin for security reasons. User must have access to each database with least possible permissions!</para>");
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");
            sr.AddParagraph("");
            sr.AddParagraph(MassText);

            sr.AddListItem("Bahnhof");
            sr.AddListItem("HauptBahnhof");
            sr.AddListItem("S�dBahnhof");
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);

            var f = new HtmlTextFormatter { StructuredText = sr, MoveHeaderLevel = 1};
            var result = f.GetFormattedText();


            Debug.Print(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result));
            Assert.IsFalse(result.Contains("<h1"));
            Assert.IsTrue(result.Contains("<h2"));
            Assert.IsTrue(result.Contains("<h3"));

        }



        [Test]
        public void TestGetFormattedText_MoveHeaderlevel1_NoTemplateSynthaxHighLighting()
        {

            var sr = new StructuredText();
            sr.AddHeader1("�berschrift 1 '& &&&' ");

            sr.AddParagraph("??pa??Task to take a documentation for all SQL databases on a Microsoft(R) SqlServer with exception of databases Master, Msdb, Model and TempDb.??pe??");

            sr.AddCode("public void test()\r\n{{\r\nMessageBox.Show(\"Test\");\r\n}};");

            sr.AddParagraph(MassText);
            sr.AddParagraph("??pa??Test paragraph PaPe 1??pe????pa??Test paragraph PaPe 2??pe??");

            sr.AddParagraph("<para>Task to take a documentation for all SQL databases on a MSSqlServer with exception of databases Master, Msdb, Model and TempDb.</para><para>A database may contain stored procs under the schema dbo and names beginning with spDbDocu_ for adding database specific " +
                            "content to the docmentation.</para><para>For parts of the documentation the user running the job needs certain permissions." +
                            "To give least possible permissions, this user should be part of a user defined server role on the SqlServer with the permissions VIEW ANY DEFINITION and GRANT VIEW SERVER STATE." +
                            "You should avoid making the user a sysadmin for security reasons. User must have access to each database with least possible permissions!</para>");

            sr.AddDefinitionListLine("Test para", "<para>Task to take a documentation for all SQL databases on a MSSqlServer with exception of databases Master, Msdb, Model and TempDb.</para><para>A database may contain stored procs under the schema dbo and names beginning with spDbDocu_ for adding database specific " +
                                                  "content to the docmentation.</para><para>For parts of the documentation the user running the job needs certain permissions." +
                                                    "To give least possible permissions, this user should be part of a user defined server role on the SqlServer with the permissions VIEW ANY DEFINITION and GRANT VIEW SERVER STATE." +
                "You should avoid making the user a sysadmin for security reasons. User must have access to each database with least possible permissions!</para>");
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");
            sr.AddParagraph("");
            sr.AddParagraph(MassText);

            sr.AddListItem("Bahnhof");
            sr.AddListItem("HauptBahnhof");
            sr.AddListItem("S�dBahnhof");
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);

            var f = new HtmlTextFormatter { StructuredText = sr, MoveHeaderLevel = 1, CssCode = "prettyprint" };
            var result = f.GetFormattedText();


            Debug.Print(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result));
            Assert.IsFalse(result.Contains("<h1"));
            Assert.IsTrue(result.Contains("<h2"));
            Assert.IsTrue(result.Contains("<h3"));

        }



        [Test]
        public void TestGetFormattedText_WithTemplate()
        {


            var sr = new StructuredText();
            sr.AddHeader1("�berschrift 'Databanka'");
            sr.AddParagraph(MassText);
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");
            sr.AddParagraph("");
            sr.AddParagraph(MassText);

            sr.AddListItem("Bahnhof");
            sr.AddListItem("HauptBahnhof");
            sr.AddListItem("S�dBahnhof");
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
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
        public void TestGetFormattedText_WithTable()
        {
            var sr = new StructuredText();
            sr.AddHeader1("�berschrift 1");

            sr.AddTable("Tabellentitel", DataHelper.GetData());

            sr.AddParagraph(MassText);
            sr.AddDefinitionListLine("Def1", "Value1");
            sr.AddDefinitionListLine("Definition 2", "Value1234");
            sr.AddDefinitionListLine("Defini 3", "Value234556666");
            sr.AddParagraph("");
            sr.AddParagraph(MassText);

            sr.AddListItem("Bahnhof");
            sr.AddListItem("HauptBahnhof");
            sr.AddListItem("S�dBahnhof");
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddParagraph(MassText);
            sr.AddHeader2("�berschrift 2");
            sr.AddParagraph(MassText);
            sr.AddHeader1("�berschrift 1");
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
        public void RealLifeGetFormattedText()
        {
            var fileName = Path.Combine(FileHelper.TestDataPath, "StructuredText.json");

            var sr = JsonHelper.LoadJsonFile<StructuredText>(fileName);

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

    }



}