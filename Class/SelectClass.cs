using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SqlTutorial.Class
{
    class SelectClass : RegexAbstract
    {

        private Regex regexSelect;
        WhereOrderClass nextReg;
        TableColControl control;
      
        public SelectClass()
        {

            reg = @"^(select )[a-zA-Z0-9,()*.\s]+( from )[a-zA-Z0-9]+$";
            regexSelect = new Regex(reg);
        }
        public override Regex getRegex()
        {

            return regexSelect;
        }
        public override void regexContol(string query)
        {
            errorControl = true;
            if (getRegex().IsMatch(query))
            {
                control = new TableColControl();
                if (!control.colControl(query) && errorControl)
                {
                    sendQuery = "Hatalı Kolon Adı Kullanımı " + control.donen;
                    ResultClass.setResult(sendQuery);
                    errorControl = false;
                }
                else if (!control.tabControl() && errorControl)
                {
                    sendQuery = "Hatalı Tablo Adı Kullanımı " + control.tablo;
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }
                else
                {
                    ResultClass.setResult(query);
                }
               

            }

            else
            {
                regexSelect = new Regex(@"^(select ).*");

                if (!regexSelect.IsMatch(query) && errorControl)
                {

                    sendQuery = "Hatalı Select Kullanımı";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }
                regexSelect = new Regex(@".*( from)( .*)?");
                if (!regexSelect.IsMatch(query) && errorControl)
                {
                    sendQuery = "From Hatası";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }
                regexSelect = new Regex(@"^(select )[a-zA-Z0-9,.()*\s]+( from)( .*)?");
                if (!regexSelect.IsMatch(query) && errorControl)
                {

                    sendQuery = "Eksik Kolon Hatası";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }

                regexSelect = new Regex(@".*(from )[a-z0-9]+");
                if (!regexSelect.IsMatch(query) && errorControl)
                {

                    sendQuery = "Tablo Eksik";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }
                regexSelect = new Regex(@"^(select )[a-zA-Z0-9,()*.]+( from )[a-zA-Z0-9]+$");
                if (!regexSelect.IsMatch(query) && errorControl)
                {
                    nextReg = new WhereOrderClass();
                    nextReg.regexContol(query);
                }


            }

        }

    }
}
