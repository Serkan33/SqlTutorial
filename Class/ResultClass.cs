using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SqlTutorial.Class
{
    class ResultClass
    {
        private static string value;
        private static string query;
        public static void setResult(string val)
        {
            value = val;

        }
        public static string getResult()
        {
            return value;
        }
        public static void setQuery(string querys)
        {
            query = querys;

        }
        public static string getQuery()
        {
            return query;
        }
    }
}

