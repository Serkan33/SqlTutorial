using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlTutorial.Class
{
    class DbConnect:Ibaglanti
    {
        public MySqlConnection connect;
        public MySqlConnection dbConnection()
        {
            connect = new MySqlConnection("Server=localhost;Database=sqltutorial;Uid=root;Pwd='';");
            try
            {
                connect.Open();
            }
            catch (Exception)
            {

                Console.Write("vwvverregetrg");
            }
            return connect;
        }
        


    }
}
