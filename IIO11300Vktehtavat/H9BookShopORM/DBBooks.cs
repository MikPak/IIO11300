using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H9BookShopORM
{
    public class DBBooks
    {
        public static DataTable GetTestData()
        {
            // Luodaan "oikeanlainen" DataTable leikkidatasta
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("author", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("year", typeof(int));
            //Luodaan rivit
            dt.Rows.Add(11, "Pekka Lipposen seikkailut", "Outsider", "Suomi", 1946);
            dt.Rows.Add(21, "Lucky Luke", "René Coscinny", "Belgia", 1946);

            return dt;
        }
    }
}
