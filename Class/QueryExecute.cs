using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SqlTutorial.Class
{
    class QueryExecute
    {
        DbConnect isConnect = new DbConnect();
        MySqlDataAdapter dataAdapter;
        
        public MySqlDataAdapter executeAdapter(string query)
        {

            return dataAdapter = new MySqlDataAdapter(query, isConnect.dbConnection());
        }
        public  bool AreTablesTheSame(DataTable tbl1, DataTable tbl2)
        {
            if (tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
                return false;


            for (int i = 0; i < tbl1.Rows.Count; i++)
            {
                for (int c = 0; c < tbl1.Columns.Count; c++)
                {
                    if (!Equals(tbl1.Rows[i][c], tbl2.Rows[i][c]))
                        return false;
                }
            }
            return true;
        }
    }
}
