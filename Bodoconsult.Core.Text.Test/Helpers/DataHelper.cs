using System.Data;

namespace Bodoconsult.Core.Text.Test.Helpers
{
    internal class DataHelper
    {
        /// <summary>
        /// Get a test <see cref="DataTable"/>
        /// </summary>
        /// <returns></returns>
        public static DataTable GetData()
        {
            var dt = new DataTable();
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Rows.Add(1, "Satinder Singh", "Bsc Com Sci", "Mumbai");
            dt.Rows.Add(2, "Amit Sarna", "Mstr Com Sci", "Mumbai");
            dt.Rows.Add(3, "Andrea Ely", "Bsc Bio-Chemistry", "Queensland");
            dt.Rows.Add(4, "Leslie Mac", "MSC", "Town-ville");
            dt.Rows.Add(5, "Vaibhav Adhyapak", "MBA", "New Delhi");
            return dt;
        }



    }
}
