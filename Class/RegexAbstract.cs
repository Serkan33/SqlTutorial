using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SqlTutorial
{
    abstract class RegexAbstract
    {
        protected string reg;
        protected string sendQuery;
        protected bool errorControl;
        abstract public Regex getRegex();
        abstract public void regexContol(string query);
    }
}
