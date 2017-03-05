using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SqlTutorial.Class
{
    class SimilarityClass
    {
        private string str="";
        private int sayac      = 0;
        private string newStr = "";
        private int countStr1  = 0;
        private int countStr2  = 0;
        public string editQuery(string strQuery) {

            for (int i = 0; i < strQuery.Length; i++)
            {
                if (strQuery[i].ToString() == " ")
                {
                    sayac++;
                    if (sayac <= 1)
                    {
                        newStr += strQuery[i].ToString();
                    }

                }
                if (strQuery[i].ToString() != " ")
                {
                    newStr += strQuery[i].ToString();
                    sayac = 0;
                }
            }
           
            return newStr;
        }
        public string similar(string str1,string str2, string strQuery) {

            newStr = editQuery(strQuery);
            for (int i = 0; i < newStr.Trim().Split(' ').Length; i++)
            {
               
                if (newStr.Trim().Split(' ')[i] == "from")
                {
                    str = newStr.Trim().Split(' ')[i+2];
                    break;

                }
              
            }
            int j = 0;
            while (str1.Length>j&&str.Length>j)
            {
                if (str1[j] == str[j])
                {
                    countStr1++;
                }
                j++;
            }
            j = 0;
            while (str1.Length > j && str.Length > j)
            {
                if (str2[j] == str[j])
                {
                    countStr2++;
                }
                j++;
            }

            if (countStr1 > countStr2&&countStr1>=3)
            {
                str = str1 + " Hatası";
            }
            else if (countStr1 < countStr2 && countStr2 >= 3)
            {
                str = str2 + " Hatası";
            }
            else
            {
                str = "";
            }
            return str;
        }
    }
}
