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
    internal class MainProgram
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
