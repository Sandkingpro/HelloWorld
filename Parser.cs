using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4
{
    class Parser
    {
        public delegate void Delegate(WebPage webpage);
        public event Delegate Notify;
        public WebClient client = new WebClient();
        public string curlink { get; set; }
        public int lvlpage { get; set; }
        public string page { get; set; }
        public int i = 1;
        public bool Parsing()
        {
            var list = Urls();
            if (curlink==null)
            {
                curlink = "https://www.susu.ru/ru/alumni";
            }
            if (i <= list.Count())
            {
                WebPage webpage = new WebPage();
                page = client.DownloadString(new Uri(curlink));
                webpage.title = Regex.Matches(page, @"<title>\s*(.+?)\s*</title>")[0].Groups[1];
                string s = list[i - 1].Substring(9);
                curlink = s.Remove(s.Length - 2);
                lvlpage = curlink.Where(x => x == '/').Count() - 1;
                if (curlink.Contains("http") == false)
                {
                    webpage.level = lvlpage;
                    curlink = "https://www.susu.ru" + curlink;
                }
                else
                {
                    webpage.level = lvlpage - 2;
                }
                webpage.uri = curlink;
                i += 1;
                Notify?.Invoke(webpage);
                return Parsing();
            }
            else
            {
                i = 0;
                return true;
            }

        }
        public bool IMG_URl()
        {
            var list = Img_urls();
            if (i < list.Count)
            {
                WebPage webpage = new WebPage();
                if (list[i].StartsWith("<img alt"))
                {
                    webpage.img = list[i].Substring(list[i].IndexOf("src=") + 5);
                    Notify?.Invoke(webpage);
                    string a = list[i].Substring(list[i].IndexOf("alt=") + 4);
                    if (list[i].Contains("class"))
                    {
                        webpage.img_label = a.Remove(a.IndexOf("class"));
                    }
                    else if (list[i].Contains("border"))
                    {
                        webpage.img_label = a.Remove(a.IndexOf("border"));
                    }
                    else
                    {
                        webpage.img_label = a.Remove(a.IndexOf("src="));
                    }
                    Notify?.Invoke(webpage);
                    i += 1;
                    return IMG_URl();
                }
                else if (list[i].StartsWith("<img src") & list[i].Contains("alt"))
                {
                    list[i] = list[i].Substring(list[i].IndexOf("src=") + 5);
                    webpage.img = Img_urls()[i].Remove(list[i].IndexOf(" alt"));
                    Notify?.Invoke(webpage);
                    string a = list[i].Substring(list[i].IndexOf("alt=") + 4);
                    webpage.img_label = a.Remove(a.IndexOf("class"));
                    Notify?.Invoke(webpage);
                    i += 1;
                    return IMG_URl();
                }
                else
                {
                    webpage.img = list[i].Substring(list[i].IndexOf("src=") + 5);
                    Notify?.Invoke(webpage);
                    webpage.img_label = "";
                    Notify?.Invoke(webpage);
                    i += 1;
                    return IMG_URl();
                }
            }
            else
            {
                return true;
            }
        }
        public List<string> Urls()
        {
            WebClient client = new WebClient();
            page = client.DownloadString(new Uri("https://www.susu.ru/ru/alumni"));
            var links = Regex.Matches(page, @"<a href=[""\/\w-\.:]+>");
            List<string> matches = new List<string>();//список url всех вложенных страниц
            for (int j = 0; j < links.Count; j++)
            {
                if (links[j].Value.Contains("contact") == false)
                {
                    matches.Add(links[j].Value);
                }
            }
            Comparer cm = new Comparer();
            matches.Sort(cm);
            return matches;
        }
        public List<string> Img_urls()
        {
            WebClient client = new WebClient();
            page = client.DownloadString(new Uri("https://www.susu.ru/ru/alumni"));
            var urls_img = Regex.Matches(page, "< *[img][^>]*[src] *= *[\"\']{0,1}([^\"\' >]*)");
            List<string> urls = new List<string>();//список url всех изображений
            for (int j = 0; j < urls_img.Count; j++)
            {
                if (urls_img[j].Value.StartsWith("<img"))
                {
                    urls.Add(urls_img[j].Value);
                }
            }
            return urls;
        }
    }
}
