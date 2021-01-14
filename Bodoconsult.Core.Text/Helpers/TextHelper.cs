﻿//using System;
//using System.IO;
//using Bodoconsult.Text.Interfaces;

//namespace Bodoconsult.Text.Helpers
//{
//    /// <summary>
//    /// Helper class for handling <see cref="IStructuredText"/>
//    /// </summary>
//    public class TextHelper
//    {

//        /// <summary>
//        /// Append text toAppend to text master
//        /// </summary>
//        /// <param name="master">text who gets text toAppend appended at the end</param>
//        /// <param name="toAppend">test to append at the end of text master</param>
//        public static void AppendText(IStructuredText master, IStructuredText toAppend)
//        {
//            foreach (var textItem in toAppend.TextItems)
//            {
//                master.TextItems.Add(textItem);
//            }
//        }



//        /// <summary>
//        /// Append an UTF8 encode plain text file to a <see cref="IStructuredText"/> text object
//        /// </summary>
//        /// <param name="master">text object the text file gets appended</param>
//        /// <param name="plainTextFileName">path to the UTF8 encoded plain text file</param>
//        public static void AppendUtf8PlainTextFile(IStructuredText master, string plainTextFileName)
//        {

//            var odir = new FileInfo(plainTextFileName).Directory;

//            if (odir == null || !odir.Exists)
//            {
//                throw new Exception("Folder for file "+ plainTextFileName + " not valid!");
//            }

//            if (!odir.Exists)
//            {
//                throw new Exception("Folder " + odir.FullName + " not existing or accessible!");
//            }

//            var dir = odir.FullName;

//            var fsIn = new FileStream(plainTextFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
//            var sr = new StreamReader(fsIn);
//            var s = sr.ReadToEnd();
//            sr.Dispose();
//            fsIn.Close();


//            var data = s.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

//            foreach (var row in data)
//            {

//                if (string.IsNullOrEmpty(row.Replace("*", "").Trim())) continue;

//                if (row.ToLower().StartsWith("h1 "))
//                {
//                    master.AddHeader1(row.Substring(3).Trim());
//                    continue;
//                }

//                if (row.ToLower().StartsWith("h2 "))
//                {
//                    master.AddHeader2(row.Substring(3).Trim());
//                    continue;
//                }

//                if (row.ToLower().StartsWith("h3 "))
//                {
//                    master.AddHeader3(row.Substring(3).Trim());
//                    continue;
//                }

//                if (row.ToLower().StartsWith("h4 "))
//                {
//                    master.AddHeader4(row.Substring(3).Trim());
//                    continue;
//                }


//                if (row.ToLower().StartsWith("code "))
//                {
//                    master.AddCode(GetText(row.Substring(5), dir));
//                    continue;
//                }

//                if (row.ToLower().StartsWith("li "))
//                {
//                    master.AddListItem(row.Substring(3).Trim());
//                    continue;
//                }

//                if (row.ToLower().StartsWith("dl "))
//                {
//                    string c1;
//                    string c2;

//                    var i = row.ToLower().IndexOf(" dd ", StringComparison.Ordinal);

//                    if (i < 0)
//                    {
//                        c1 = row.Substring(2).Trim();
//                        c2 = "";
//                    }
//                    else
//                    {
//                        c1 = row.Substring(0, i).Substring(2).Trim();
//                        c2 = row.Substring(i + 4).Trim();
//                    }

//                    master.AddDefinitionListLine(c1, c2);
//                    continue;
//                }

//                master.AddParagraph(GetText(row, dir));
//            }
//        }

//        /// <summary>
//        /// Check the text for include files
//        /// </summary>
//        /// <param name="text"></param>
//        /// <param name="dirPath"></param>
//        /// <returns></returns>
//        private static string GetText(string text, string dirPath)
//        {
//            try
//            {
//                var i = text.ToLower().IndexOf("??include:", StringComparison.Ordinal);

//                if (i < 0) return text.Trim();

//                while (i >= 0)
//                {
//                    var j = text.ToLower().IndexOf("??", i + 2, StringComparison.Ordinal);

//                    var fileName = text.Substring(i + 10, j - i - 10);

//                    if (fileName.Contains("\\"))
//                    {
//                        fileName = Path.Combine(dirPath, fileName);
//                    }

//                    string s;

//                    try
//                    {
//                        var fsIn = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
//                        var sr = new StreamReader(fsIn);
//                        s = sr.ReadToEnd();
//                        sr.Dispose();
//                        fsIn.Close();
//                    }
//                    catch
//                    {
//                        s = $"<<Error:File not found: {fileName}>>";
//                    }

//                    var vorher = i == 0 ? "" : text.Substring(0, i - 1);

//                    var nachher = j == text.Length ? "" : text.Substring(j + 2);


//                    text = vorher + s + nachher;

//                    if (j + s.Length < text.Length)
//                    {
//                        i = text.ToLower().IndexOf("??include:", j + s.Length, StringComparison.Ordinal);
//                    }
//                    else
//                    {
//                        i = -1;
//                    }
//                }
//            }
//            catch
//            {
//                // ignored
//            }
//            return text.Trim();
//        }

//    }
//}
