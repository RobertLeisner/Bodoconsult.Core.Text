using System.Diagnostics;
using NUnit.Framework;

namespace Bodoconsult.Core.Text.Test
{
    [TestFixture]
    public class UnitTestHtmlHelper
    {
        private const string MassText =
            "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

        [Test]

        public void TestParseHtmlSimple()
        {
            var text = "<p>aafa [safasf] adasdas asdAS [Microsoft](http://microsoft.de) asfa asfas [safasf]  f Asfsaf [Microsoft2](http://microsoft2.de) blablb bala  [safasf]";

            var result = Text.Helpers.HtmlHelper.ParseHtml(text);

            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("<a href=\""));
            Assert.IsTrue(result.Contains("</a>"));
            Debug.Print(result);
        }

        [Test]
        public void TestGetContentAsHtml()
        {
            var text = "<p>ssda [safasf] adasdas \t asdAS [Microsoft](http://microsoft.de) asfa ??br??asfas f  [safasf]  Asfsaf [Microsoft2](http://microsoft2.de) blablb bala  [safasf]";

            var result = Text.Helpers.HtmlHelper.GetContentAsHtml(text);

            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("<a href=\""));
            Assert.IsTrue(result.Contains("</a>"));
            Assert.IsTrue(result.Contains("<br />"));
            Debug.Print(result);
        }
    }
}