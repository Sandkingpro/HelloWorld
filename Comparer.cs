using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    class Comparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (Extractor(Converter(x)).Where(x => x == '/').Count() > Extractor(Converter(y)).Where(x => x == '/').Count())
            {
                return 1;
            }
            else if (Extractor(Converter(x)).Where(x => x == '/').Count() < Extractor(Converter(y)).Where(x => x == '/').Count())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        static string Extractor(string a)
        {
            if (a.Contains("http") == false)
            {
                a = "https://www.susu.ru" + a;
            }
            return a;
        }
        static string Converter(string a)
        {
            string s = a.Substring(9);
            string curlink = s.Remove(s.Length - 2);
            return curlink;
        }
    }
}
