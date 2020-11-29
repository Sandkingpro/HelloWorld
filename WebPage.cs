using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4
{
    class WebPage
    {
        public Group title { get; set; }
        public string uri { get; set; }
        public int level { get; set; }
        public string img { get; set; }
        public string img_label { get; set; }
    }
}
