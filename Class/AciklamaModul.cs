using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlTutorial.Class
{
    class AciklamaModul : Ibaglanti
    {

        MySqlConnection connect;
        MySqlCommand command;
        string yapi;
        public string kolonlar;
        public string tablo;
        public string cevap;
        public string returnQuery(int id)
        {
            command = new MySqlCommand();
            command.Connection = dbConnection();
            command.CommandText = string.Format("SELECT Y.yapi,S.soru,S.kolonlar,S.tablo,C.cevap FROM sorular AS S INNER JOIN yapilar AS Y ON Y.yapi_id = S.yapi_id INNER JOIN cevaplar AS C ON C.soru_id=S.soru_id WHERE S.soru_id={0}", id);
            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                yapi = "Select Kullanımı: "+dr.GetString(0) + Environment.NewLine + Environment.NewLine +dr.GetString(1);
                kolonlar = dr.GetString(2);
                tablo = dr.GetString(3);
                cevap = dr.GetString(4);
            }
            dbConnection().Close();
            return yapi;
        }

        //------------------------------------------------------------------------------------------------------
        public MySqlConnection dbConnection()
        {
            connect = new MySqlConnection("Server=localhost;Database=sqltutorial-sorular;Uid=root;Pwd='';");
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
        public string getKolon()
        {

            return kolonlar;
        }
        public string getTablo()
        {

            return tablo;
        }
        public string getCevap() {
            return cevap;
        }
    }
}
