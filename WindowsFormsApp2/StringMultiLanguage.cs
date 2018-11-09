using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class StringMultiLanguage
    {
        private string _valueUA;
        private string _valueEN;

        public StringMultiLanguage()
        {
            this._valueUA = null;
            this._valueEN = null;
        }

        public StringMultiLanguage(string valueUA, string valueEN)
        {
            this._valueUA = valueUA; 
            this._valueEN = valueEN;
        }

        public string UA
        {
            get { return _valueUA; }
            set { _valueUA = Regex.Replace(value.Trim(), @"\s+", " "); }
        }

        public string EN
        {
            get { return _valueEN; }
            set { _valueEN = Regex.Replace(value.Trim(), @"\s+", " "); }
        }
    }
}
