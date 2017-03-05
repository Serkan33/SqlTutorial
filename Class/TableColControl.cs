using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SqlTutorial.Class
{
    class TableColControl
    {
       
        
        ArrayList colArray = new ArrayList();
        private bool funControl;
        public string donen="";
        public string tablo="";
        private string dbTablo;
        string kolon;
        Form2 modul = new Form2();
        ArrayList cols = new ArrayList();
        AciklamaModul m=new AciklamaModul();
        //------------------------------------------------------------------------------

        public bool colControl(string query)
        {
            kolon = modul.kolonIsimleri;
            dbTablo = modul.tabloIsmi;
            query = query.Replace(","," ");
            for (int i = 0; i < kolon.Split(',').Length; i++)
            {
                cols.Add(kolon.Split(',')[i]);
            }
          
            funControl = true;
            for (int i = 1; i < query.Split(' ').Length; i++)
            {
                if (query.Split(' ')[i] != "from")
                {
                    if (query.Split(' ')[i] != "select"&& query.Split(' ')[i] !="")
                    {
                        colArray.Add(query.Split(' ')[i].Trim());
                    }
                }
                else
                {
                   if (String.IsNullOrEmpty( query.Split(' ')[i + 1]))
                    {
                        tablo = "";
                    }
                    else
                    {
                            tablo = query.Split(' ')[i + 1];
                    }
                  
                    break;
                }

            }
            foreach (string item in colArray)
            {
                if (!cols.Contains(item))
                {
                    funControl = false;
                    donen="' "+item+" '";
                    break;
                }
            }
            
            return funControl;
        }

        //----------------------------------------------------------------------------

        public bool tabControl()
        {
            bool tabCont = true;
                if (tablo!=dbTablo)
                {
                    tabCont = false;
                }
            return tabCont;
        }
    }

}
