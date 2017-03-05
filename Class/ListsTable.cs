using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
namespace SqlTutorial.Class
{
    class ListsTable
    {
        DbConnect connection;
        MySqlDataReader dReader;
        MySqlCommand command;
        DataTable table;
        List<DataRow> list;
        string sorgu;
        ArrayList tablolar;
        ArrayList kolonlar;

        public ArrayList tabloListele() {
            list = new List<DataRow>();
            tablolar = new ArrayList();
            sorgu = "SELECT table_name as \'Tablolar\' FROM information_schema.tables where table_schema=\'sqltutorial\'\r\n";
            connection = new DbConnect();
            command = new MySqlCommand(sorgu,connection.dbConnection());
            table = new DataTable();
            table.Load(command.ExecuteReader());
            list = new List<DataRow>(table.AsEnumerable().ToArray());
            for (int i = 0; i < list.Count; i++)
            {
                tablolar.Add(list[i]["Tablolar"]);
            }
           return tablolar;
        }

        public ArrayList kolonListele(string secilen)
        {
            list = new List<DataRow>();
            kolonlar = new ArrayList();
            sorgu = "SELECT column_name AS Kolonlar\r\nFROM information_schema.columns\r\nWHERE table_name=\'" + secilen +
                    "\';";
            connection = new DbConnect();
            command = new MySqlCommand(sorgu, connection.dbConnection());
            table = new DataTable();
            table.Load(command.ExecuteReader());
            list = new List<DataRow>(table.AsEnumerable().ToArray());
            for (int i = 0; i < list.Count; i++)
            {
                kolonlar.Add(list[i]["Kolonlar"]);
            }
            return kolonlar;
        }


    }
}
