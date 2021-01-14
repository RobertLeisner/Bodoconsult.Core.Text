using System.IO;
using System.Reflection;

namespace Bodoconsult.Core.Text.Test.Helpers
{
    internal class FileHelper
    {

        private static string _appPath;

        /// <summary>
        /// Get path of current application
        /// </summary>
        /// <returns>current application path</returns>
        public static string GetAppPath()
        {
            if (!string.IsNullOrEmpty(_appPath)) return _appPath;

            var s = Assembly.GetExecutingAssembly().Location;

            s = new FileInfo(s).DirectoryName;

            _appPath = s;
            return _appPath;
        }
    }
}
