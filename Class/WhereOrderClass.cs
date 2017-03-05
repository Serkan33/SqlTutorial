using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace SqlTutorial.Class
{
    class WhereOrderClass:RegexAbstract
    {
        private Regex regexWhere;
        SimilarityClass similar;
        QueryExecute qe = new QueryExecute();
        TableColControl control;
        public WhereOrderClass()
        {

            reg = @".*( where )[a-z0-9]+[='><]+[a-z0-9]+(( order by )[a-z0-9]+(( asc)|( desc))?)?$";
            regexWhere = new Regex(reg);
        }
        public override Regex getRegex()
        {

            return regexWhere;
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

                regexWhere = new Regex(@".*(where)");
                if (!regexWhere.IsMatch(query) && errorControl)
                {
                    similar = new SimilarityClass();
                    if (similar.similar("where", "order by", query) != "")
                    {
                        sendQuery = similar.similar("where", "order by", query);
                    }
                    else
                    {
                        sendQuery = "Fromdan sonra birden fazla tablo kullanılmaz;Tablo adınızı kontrol ediniz";
                    }
                    ResultClass.setResult(sendQuery);
                    errorControl = false;

                }

                regexWhere = new Regex(@".*( where )[a-z0-9='><\s]+");
                if (!regexWhere.IsMatch(query) && errorControl)
                {

                    sendQuery = "Where Şartı Eksik";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;
                }
                regexWhere = new Regex(@".*( where ).*( order by)");
                if (!regexWhere.IsMatch(query) && errorControl)
                {

                    sendQuery = "Where Şartı Eksik";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;
                }
                regexWhere = new Regex(@".*( order by ).*");
                if (!regexWhere.IsMatch(query) && errorControl)
                {

                    sendQuery = "Order By Kolon Eksik";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;
                }
                regexWhere = new Regex(@".*( order by ).*(( asc)|( desc))$");
                if (!regexWhere.IsMatch(query) && errorControl)
                {

                    sendQuery = "Asc/Desc Hatalı Kullanım ";
                    ResultClass.setResult(sendQuery);
                    errorControl = false;
                }
               
            }
        }
    }
}

