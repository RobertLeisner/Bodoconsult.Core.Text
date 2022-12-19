using System.IO;
using System.Reflection;

namespace Bodoconsult.Core.Text.Test.Helpers
{
    internal class FileHelper
    {

        static FileHelper()
        {
            AppPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.Parent.FullName;
            TestDataPath = Path.Combine(AppPath, "TestData");
        }

        public static string AppPath { get; }

        public static string TestDataPath { get; }
    }
}
