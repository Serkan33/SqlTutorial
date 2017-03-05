using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlTutorial.Class
{
    class UpdateClass : RegexAbstract
    {
        private Regex updateRegex;
        TableColControl control;
        public UpdateClass() {

            reg = @"^(update )[a-zA-Z0-9,()*.\s]+( set )[a-zA-Z0-9]+$";
            updateRegex = new Regex(reg);
        }
        public override Regex getRegex()
        {
           return updateRegex;
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
                updateRegex = new Regex(@"^(select ).*");

                if (!updateRegex.IsMatch(query) && errorControl)
                {

                    sendQuery = "Hatalı Select Kullanımı";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }
                updateRegex = new Regex(@".*( from)( .*)?");
                if (!updateRegex.IsMatch(query) && errorControl)
                {
                    sendQuery = "From Hatası";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }
                updateRegex = new Regex(@"^(select )[a-zA-Z0-9,.()*\s]+( from)( .*)?");
                if (!updateRegex.IsMatch(query) && errorControl)
                {

                    sendQuery = "Eksik Kolon Hatası";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }

                updateRegex = new Regex(@".*(from )[a-z0-9]+");
                if (!updateRegex.IsMatch(query) && errorControl)
                {

                    sendQuery = "Tablo Eksik";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }
            }
        }
    }
}
