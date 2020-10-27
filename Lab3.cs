using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using Lab3;
//Variant 3
namespace Lab3
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Square))]
    [XmlInclude(typeof(Ellipse))]
    public abstract class Figure
    {
        public int x;
        public int y;
        public int radius;//радиус фигуры(если это круг)
        public int a;//сторона квадрата,прямоугольника или полуось эллипса.
        public int b;//сторона прямоугольника или полуось эллипса.
        public double thickness;
        public int Center_x = Console.WindowWidth / 2;
        public int Center_y = Console.WindowHeight / 2;
        public abstract double Area();
        public abstract string Type();
    }
    public class Circle : Figure
    {
        public Circle CreateCircle()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите радиус круга:");
                    radius = Convert.ToInt32(Console.ReadLine());
                    while (radius > Console.WindowHeight / 2 || radius > Console.WindowWidth / 2 || radius <= 1)
                    {
                        Console.WriteLine("Радиус больше размеров консоли или меньше либо равен нулю.Введите другой радиус.");
                        radius = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Введите толщину рамки:");
                    thickness = Convert.ToInt32(Console.ReadLine());
                    while (thickness <= 0)
                    {
                        Console.WriteLine("Невозможно иметь отрицательную толщину.Введите корректную толщину");
                        thickness = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод данных.");
                }
            }
            return this;

        }
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
        public override string Type()
        {
            return "Круг";
        }
        
    }
    public class Square : Figure
    {
        public Square CreateSquare()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите длину стороны квадрата:");
                    a = Convert.ToInt32(Console.ReadLine());
                    while (a > Console.WindowHeight / 2 || a > Console.WindowWidth / 2 || a <= 1)
                    {
                        Console.WriteLine("Сторона квадрата больше размеров консоли или меньше либо равен единице.Введите правильные данные.");
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Введите толщину рамки:");
                    thickness = Convert.ToInt32(Console.ReadLine());
                    while (thickness <= 0)
                    {
                        Console.WriteLine("Невозможно иметь отрицательную толщину.Введите корректную толщину");
                        thickness = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод данных.");
                }
            }
            return this;
        }
        public override double Area()
        {
            return a * a;
        }
        public override string Type()
        {
            return "Квадрат";
        }
        
    }
    public class Rectangle : Figure
    {
        public Rectangle CreateRectangle()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите ширину прямоугольника:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите высоту прямоугольнмка:");
                    b = Convert.ToInt32(Console.ReadLine());
                    while (b > Console.WindowHeight / 2 || a > Console.WindowWidth / 2 || a <= 1 || b <= 1)
                    {
                        Console.WriteLine("Стороны прямоугольника больше размеров консоли или меньше либо равен единице.Введите правильные данные.");
                        return CreateRectangle();
                    }

                    Console.WriteLine("Введите толщину рамки:");
                    thickness = Convert.ToInt32(Console.ReadLine());
                    while (thickness <= 0)
                    {
                        Console.WriteLine("Невозможно иметь отрицательную толщину.Введите корректную толщину");
                        thickness = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод данных.");
                }
            }
            return this;
        }
        public override double Area()
        {
            return a * b;
        }
        public override string Type()
        {
            return "Прямоугольник";
        }
       
    }
    public class Ellipse : Figure
    {
        public Ellipse CreateEllipse()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите большую полуось:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите малую полуось(:");
                    b = Convert.ToInt32(Console.ReadLine());
                    y = b;
                    while (b >= Console.WindowHeight / 2 || a >= Console.WindowWidth / 2 || a <= 1 || b <= 1)
                    {
                        Console.WriteLine("Полуоси больше размеров консоли или меньше либо равен единице.Введите правильные данные.");
                        return CreateEllipse();
                    }

                    Console.WriteLine("Введите толщину рамки:");
                    thickness = Convert.ToInt32(Console.ReadLine());
                    while (thickness <= 0)
                    {
                        Console.WriteLine("Невозможно иметь отрицательную толщину.Введите корректную толщину");
                        thickness = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод данных.");
                }
            }
            return this;
        }
        public override double Area()
        {
            return Math.PI * a * b;
        }
        public override string Type()
        {
            return "Эллипс";
        }
        

    }
    class SquareComparer : IComparer<Figure>
    {
        public int Compare(Figure x, Figure y)
        {
            if (x.Area() > y.Area())
            {
                return 1;
            }
            else if (x.Area() < y.Area())
            {
                return -1;
            }
            else
            {
                if (x.thickness > y.thickness)
                {
                    return 1;
                }
                else if (x.thickness < y.thickness)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    public class Figures
    {
        public List<Figure> Item = new List<Figure>();
    }
    class GraphicsEditor
    {
        static double AverageArea;
        static void Calculation(Figures figures)
        {
            double sum = 0;
            foreach (Figure s in figures.Item)
            {
                sum += s.Area();
            }
            AverageArea = sum / figures.Item.Count;
        }
        static void Main()
        {
            string a;
            Figures figures = new Figures();
            while (true)
            {
                Console.WriteLine("Введите данные с экрана:");
                Console.WriteLine("1-Создать фигуру круг.");
                Console.WriteLine("2-Создать фигуру квадрат.");
                Console.WriteLine("3-Создать фигуру прямоугольник.");
                Console.WriteLine("4-Создать фигуру эллипс.");
                Console.WriteLine("5-Exit");
                a = Console.ReadLine();
                if (a == "1")
                {
                    Circle circle1 = new Circle();
                    circle1.CreateCircle();
                    figures.Item.Add(circle1);
                    Calculation(figures);
                    Console.WriteLine("Средняя площадь:{0}", AverageArea);
                }
                if (a == "2")
                {
                    Square square1 = new Square();
                    square1.CreateSquare();
                    figures.Item.Add(square1);
                    Calculation(figures);
                    Console.WriteLine("Средняя площадь:{0}",AverageArea);
                }
                if (a == "3")
                {
                    Rectangle rectangle1 = new Rectangle();
                    rectangle1.CreateRectangle();
                    figures.Item.Add(rectangle1);
                    Calculation(figures);
                    Console.WriteLine("Средняя площадь:{0}", AverageArea);
                }
                if (a == "4")
                {
                    Ellipse ellipse1 = new Ellipse();
                    ellipse1.CreateEllipse();
                    figures.Item.Add(ellipse1);
                    Calculation(figures);
                    Console.WriteLine("Средняя площадь:{0}", AverageArea);
                }
                if (a == "5")
                {
                    if (figures.Item.Count >= 5)
                    {
                        SquareComparer sc = new SquareComparer();
                        figures.Item.Sort(sc);
                        for (int i = 0; i < figures.Item.Count; i++)
                        {
                            Console.WriteLine("Type:{0},Area:{1},Thickness:{2}", figures.Item[i].Type(), figures.Item[i].Area(), figures.Item[i].thickness);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine("Type:{0}", figures.Item[i].Type());
                        }
                        Console.ReadKey();
                        Console.Clear();
                        ToConsole(figures.Item[figures.Item.Count - 2]);
                        ToConsole(figures.Item[figures.Item.Count - 1]);
                        Xml_file(figures);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Создайте 5 фигур или больше");
                    }
                }
                else
                {
                    Console.WriteLine("Введите корректные данные");
                }
                static void Xml_file(Figures figures)
                {
                    var serializer = new XmlSerializer(typeof(List<Figure>));
                    using (FileStream fs = new FileStream(@"D://data.xml", FileMode.OpenOrCreate))
                    {
                        serializer.Serialize(fs, figures.Item);
                    }
                    using (FileStream fs = new FileStream(@"D://data.xml", FileMode.Open))
                    {
                        using var sr = new StreamReader(fs);
                        Console.WriteLine(sr.ReadToEnd());   
                    }
                }
                static void ToConsole(Figure figure)
                {
                    if (figure.Type() == "Круг")
                    {
                        figure.x = 0;
                        for (figure.y = 0; figure.y <= figure.radius; ++figure.y)
                        {
                            figure.x = (int)Math.Sqrt(Math.Pow(figure.radius, 2) - Math.Pow(figure.y, 2));
                            Console.SetCursorPosition(figure.Center_x + figure.x, figure.Center_y + figure.y);
                            Console.WriteLine("*");
                            Console.SetCursorPosition(figure.Center_x + figure.x, figure.Center_y - figure.y);
                            Console.WriteLine("*");
                            Console.SetCursorPosition(figure.Center_x - figure.x, figure.Center_y - figure.y);
                            Console.WriteLine("*");
                            Console.SetCursorPosition(figure.Center_x - figure.x, figure.Center_y + figure.y);
                            Console.WriteLine("*");
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (figure.Type() == "Квадрат")
                    {
                        string s1 = new string('*', figure.a);
                        var s = String.Join(" ", s1.ToCharArray());
                        string s2 = new string(' ', figure.a * 2 - 3);
                        Console.SetCursorPosition(figure.Center_x - figure.a, figure.Center_y + figure.a / 2);
                        Console.Write(s);
                        for (int i = 0; i < figure.a - 2; i++)
                        {
                            Console.SetCursorPosition(figure.Center_x - figure.a, figure.Center_y + (figure.a / 2) - i - 1);
                            Console.Write("*" + s2 + "*");
                        }
                        Console.WriteLine();
                        Console.SetCursorPosition(figure.Center_x - figure.a, figure.Center_y + 1 - figure.a / 2);
                        Console.Write(s);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (figure.Type() == "Прямоугольник")
                    {
                        string s1 = new string('*', figure.a);
                        var s = String.Join(" ", s1.ToCharArray());
                        string s2 = new string(' ', 2 * figure.a - 3);
                        Console.SetCursorPosition(figure.Center_x - figure.a, figure.Center_y + figure.b / 2);
                        Console.Write(s);
                        for (int i = 0; i < figure.b - 2; i++)
                        {
                            Console.SetCursorPosition(figure.Center_x - figure.a, figure.Center_y + figure.b / 2 - i - 1);
                            Console.Write("*" + s2 + "*");
                        }
                        Console.SetCursorPosition(figure.Center_x - figure.a, figure.Center_y + 1 - figure.b / 2);
                        Console.Write(s);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (figure.Type() == "Эллипс") 
                    {
                        if (figure.a > figure.b)
                        {
                            figure.x = 0;
                            figure.y = 0;
                            for (int i = 0; i < figure.a; i++)
                            {
                                figure.x = (int)Math.Sqrt((Math.Pow(figure.a, 2) * Math.Pow(figure.b, 2) - Math.Pow(figure.a, 2) * Math.Pow(figure.y, 2)) / Math.Pow(figure.b, 2));
                                if (figure.x < 0)
                                {
                                    break;
                                }
                                Console.SetCursorPosition(figure.Center_x + figure.x, figure.Center_y + i);
                                Console.WriteLine("*");
                                Console.SetCursorPosition(figure.Center_x + figure.x, figure.Center_y - i);
                                Console.WriteLine("*");
                                Console.SetCursorPosition(figure.Center_x - figure.x, figure.Center_y - i);
                                Console.WriteLine("*");
                                Console.SetCursorPosition(figure.Center_x - figure.x, figure.Center_y + i);
                                Console.WriteLine("*");
                                figure.y += 1;
                            }
                        }
                        else
                        {
                            figure.x = 0;
                            figure.y = 0;
                            for (int i = 0; i < figure.b; i++)
                            {
                                figure.x = (int)Math.Sqrt((Math.Pow(figure.a, 2) * Math.Pow(figure.b, 2) - Math.Pow(figure.a, 2) * Math.Pow(figure.y, 2)) / Math.Pow(figure.b, 2));
                                if (figure.x < 0)
                                {
                                    break;
                                }
                                Console.SetCursorPosition(figure.Center_x + figure.x, figure.Center_y + i);
                                Console.WriteLine("*");
                                Console.SetCursorPosition(figure.Center_x + figure.x, figure.Center_y - i);
                                Console.WriteLine("*");
                                Console.SetCursorPosition(figure.Center_x - figure.x, figure.Center_y - i);
                                Console.WriteLine("*");
                                Console.SetCursorPosition(figure.Center_x - figure.x, figure.Center_y + i);
                                Console.WriteLine("*");
                                figure.y += 1;
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
    }
}


