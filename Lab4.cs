using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab4;

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
    class Parser
    {
        public delegate void Delegate(WebPage webpage);
        public event Delegate Notify;
        public string uri = "https://www.susu.ru/ru/alumni";
        public int lvlpage { get; set; }
        public string page { get; set; }
        public void Parsing()
        {
            uri = "https://www.susu.ru/ru/alumni";
            WebClient client = new WebClient();
            page = client.DownloadString(new Uri(uri));
            var links = Regex.Matches(page, @"<a href=[""\/\w-\.:]+>");
            List<string> matches = new List<string>();//список url всех вложенных страниц
            for (int j = 0; j < links.Count; j++)
            {
                if (links[j].Value.Contains("contact") == false)
                {
                    matches.Add(links[j].Value);
                }
            }
            int count = 1;
            int i = matches.Count();
            while (count <= i)
            {
                WebPage webpage = new WebPage();
                webpage.title = Regex.Matches(page, @"<title>\s*(.+?)\s*</title>")[0].Groups[1];
                string s = matches[count - 1].Substring(9);
                s = matches[count - 1].Substring(9);
                string curlink = s.Remove(s.Length - 2);
                lvlpage = curlink.Where(x => x == '/').Count() - 1;
                if(curlink.Contains("http")==false)
                {
                    webpage.level = lvlpage;
                    curlink = "https://www.susu.ru" + curlink;
                }
                else
                {
                    webpage.level = lvlpage - 2;
                }
                webpage.uri = curlink;
                page = client.DownloadString(new Uri(curlink));
                count += 1;
                Notify?.Invoke(webpage);
            }
            
        }
        public void IMG_URl()
        {
            WebClient client = new WebClient();
            page = client.DownloadString(new Uri(uri));
            var urls_img = Regex.Matches(page, "< *[img][^>]*[src] *= *[\"\']{0,1}([^\"\' >]*)");
            List<string> urls = new List<string>();//список url всех изображений
            for (int j = 0; j < urls_img.Count; j++)
            {
                if (urls_img[j].Value.StartsWith("<img"))
                {
                    urls.Add(urls_img[j].Value);
                }
            }
            int i = 0;
            while (i < urls.Count)
            {
                WebPage webpage = new WebPage();
                if (urls[i].StartsWith("<img alt"))
                {
                    webpage.img = urls[i].Substring(urls[i].IndexOf("src=") + 5);
                    Notify?.Invoke(webpage);
                    string a = urls[i].Substring(urls[i].IndexOf("alt=") + 4);
                    if (urls[i].Contains("class"))
                    {
                        webpage.img_label = a.Remove(a.IndexOf("class"));
                    }
                    else if (urls[i].Contains("border"))
                    {
                        webpage.img_label = a.Remove(a.IndexOf("border"));
                    }
                    else
                    {
                        webpage.img_label = a.Remove(a.IndexOf("src="));
                    }
                    Notify?.Invoke(webpage);
                }
                else if (urls[i].StartsWith("<img src") & urls[i].Contains("alt"))
                {
                    urls[i] = urls[i].Substring(urls[i].IndexOf("src=") + 5);
                    webpage.img = urls[i].Remove(urls[i].IndexOf(" alt"));
                    Notify?.Invoke(webpage);
                    string a = urls[i].Substring(urls[i].IndexOf("alt=") + 4);
                    webpage.img_label = a.Remove(a.IndexOf("class"));
                    Notify?.Invoke(webpage);
                }
                else
                {
                    webpage.img = urls[i].Substring(urls[i].IndexOf("src=") + 5);
                    Notify?.Invoke(webpage);
                    webpage.img_label = "";
                    Notify?.Invoke(webpage);
                }
                i++;
            }
        }
    }        
    internal class Lab4
    {
        private static void Main(string[] args)
        {
            File.Delete("D:\\clients.csv");
            Parser parser1 = new Parser();
            Parser parser2 = new Parser();
            parser1.Notify += DisplayMessage;
            parser1.Parsing();
            parser2.Notify += DisplayImg;
            parser2.IMG_URl();
        }
        private static void DisplayMessage(WebPage webpage)
        {
            Console.WriteLine("URl страницы:{0}", webpage.uri);
            Console.WriteLine("Заголовок:{0}", webpage.title);
            Console.WriteLine("Уровень вложенности:{0}", webpage.level);
            var file = "D:\\clients.csv";
            using (StreamWriter streamWriter = new StreamWriter(file, true, Encoding.Default))
            {
                streamWriter.WriteLine("{0}, {1}, {2};", webpage.title, webpage.uri, webpage.level);
            }
        }
        private static void DisplayImg(WebPage webpage)
        {
            var file = "D:\\clients.csv";
            if(webpage.img_label!=null)
            {
                Console.WriteLine("URl изображения:{0};Подпись к URl изображения:{1}", webpage.img,webpage.img_label);
            }
            using (StreamWriter streamWriter = new StreamWriter(file, true, Encoding.Default))
            {
                if(webpage.img_label!=null)
                {
                    streamWriter.WriteLine(webpage.img + ":" + webpage.img_label);
                } 
            }
        }
    }
}
