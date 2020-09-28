using System;
using System.Collections.Generic;
using System.Linq;
// Вариант 3
namespace Lab2._0
{
    class Set
    {
        public HashSet<double> a;
        public Set CreateSet()
        {
            this.a = new HashSet<double>();
            return this;
        }
        static void PrintSet(Set set)
        {
            foreach(double s in set.a)
            {
                Console.WriteLine(s);
            }
        }
        public static Set operator ++(Set set)
        {
            Console.WriteLine("Введите вещественное число,которое хотите добавить");
            try
            {
                double value = Convert.ToDouble(Console.ReadLine());
                set.a.Add(value);
            }
            catch(FormatException)
            {
                Console.WriteLine("Ошибка!Попробуйте ещё раз.");
            }
            
            return set;
        }
        public static Set operator --(Set set)
        {
            Console.WriteLine("Введите вещественное число,которое хотите удалить");
            try
            {
                double value = Convert.ToDouble(Console.ReadLine());
                set.a.Remove(value);
            }
            catch(FormatException)
            {
                Console.WriteLine("Ошибка!Попробуйте ещё раз.");
            }
            return set;
        }
        public static Set operator +(Set set1,Set set2)
        {
            Console.WriteLine("Операция объединения множеств");
            var set = set1.a.Union(set2.a);
            foreach (double s in set)
            {
                Console.WriteLine(s);
            }
            return null;
        }
        public static Set operator *(Set set1, Set set2)
        {
            Console.WriteLine("Операция пересечения множеств");
            var set=set1.a.Intersect(set2.a);
            foreach(double s in set)
            {
                Console.WriteLine(s);
            }
            return null;
        }
        static void Main_Menu()
        {
            string a;
            while(true)
            {
                Console.WriteLine("Введите данные с экрана.");
                Console.WriteLine("1-Создать первое множество.");
                Console.WriteLine("Выход-для того, чтобы закончить программу.");
                a = Console.ReadLine();
                if (a == "1")
                {
                    Set set1 = new Set();
                    set1.CreateSet();
                    Console.WriteLine("Вы создали первое множество.");
                    while (true)
                    {
                        Console.WriteLine("Введите данные с экрана.");
                        Console.WriteLine("1-Добавить элемент в первое множество");
                        Console.WriteLine("2-Удалить элемент из первого множества");
                        Console.WriteLine("3-Вывести первое множество");
                        Console.WriteLine("4-Создать второе множество");
                        Console.WriteLine("0-вернуться в начальное меню");
                        a = Console.ReadLine();
                        if (a == "1")
                        {
                            set1++;
                        }
                        else if (a == "2")
                        {
                            set1--;
                        }
                        else if (a == "3")
                        {
                            PrintSet(set1);
                        }
                        else if (a == "4")
                        {
                            Set set2 = new Set();
                            set2.CreateSet();
                            Console.WriteLine("Вы создали второе множество.");
                            while (true)
                            {
                                Console.WriteLine("Введите данные с экрана.");
                                Console.WriteLine("1-Добавить элемент во второе множество");
                                Console.WriteLine("2-Удалить элемент из второго множества");
                                Console.WriteLine("3-Вывести второе множество");
                                Console.WriteLine("4-Перейте к операциям между множествами.");
                                Console.WriteLine("0-вернуться в предыдущее меню.");
                                a = Console.ReadLine();
                                if (a == "1")
                                {
                                    set2++;
                                }
                                else if (a == "2")
                                {
                                    set2--;
                                }
                                else if (a == "3")
                                {
                                    PrintSet(set2);
                                }
                                else if (a == "4")
                                {
                                    while(true)
                                    {
                                        Console.WriteLine("Введите данные с экрана.");
                                        Console.WriteLine("1-Объединение множеств.");
                                        Console.WriteLine("2-Пересечение множеств.");
                                        Console.WriteLine("0-вернуться в предыдущее меню.");
                                        a = Console.ReadLine();
                                        
                                        if (a=="1")
                                        {
                                            Set set_union = new Set();
                                            set_union = set1 + set2;
                                        }
                                        else if(a=="2")
                                        {
                                            Set set_intersect = new Set();
                                            set_intersect = set1 * set2;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                   
                                }
                                else if(a=="0")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Попробуйте ещё раз.");
                                }
                            }
                            
                        }
                        else if (a == "0")
                        {
                            Console.WriteLine("Вы вернулись в начальное меню");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка!Попробуйте ещё раз.");
                        }
                    }                  
                }
                else if(a=="Выход")
                {
                    Console.WriteLine("Конец программы.");
                    break;
                }
                else
                {
                    Console.WriteLine("Попробуйте ещё раз.Вы неправильно ввели данные.");
                }
            }
        }
        public void Menu()
        {
            Main_Menu();
        }
    }
    class Program
    {
        static void Main()
        {
            Set set = new Set();
            set.Menu();
        }
    }
}
