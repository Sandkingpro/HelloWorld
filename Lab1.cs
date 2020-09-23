using System;
using System.Linq;
using System.Xml.Linq;
//Вариант 3
namespace Array
{
    public class Array
    {
        public int size;//количество элементов
        public string[] elem;//обращение к элементу
        public Array CreateArray()
        {
            Console.WriteLine("Введите количество ячеек массива");
            try
            {
                this.size = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели не целое число");
                return CreateArray();
            }
            this.elem = new string[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Элемент{0}=", i + 1);
                this.elem[i] = Console.ReadLine();
            }
            return this;
        }
        static void PrintArray(Array array)
        {
            for (int i = 0; i < array.size; i++)
            {
                Console.WriteLine("Элемент{0}={1} ", i + 1, array.elem[i]);
            }
        }
        static Array ToIndexPrint(Array array)
        {
            try
            {
                Console.WriteLine("Введите индекс не превышающий количество ячеек в массиве");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i >= array.size)
                {
                    return ToIndexPrint(array);
                }
                Console.WriteLine("Элемент{0}={1} ", i + 1, array.elem[i]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неправильно");
                return ToIndexPrint(array);
            }
            return null;
        }
        static void TolenPrint(Array array)
        {
            Console.Write("Введите начальную комбинацию символов:");
            string len = Console.ReadLine();
            for (int i = 0; i < array.size; i++)
            {
                if (array.elem[i].StartsWith(len))
                {
                    Console.WriteLine("Элемент{0}={1} ", i + 1, array.elem[i]);
                }
            }
        }
        static void Intersection(Array array1, Array array2)
        {
            Array array = new Array();
            int t = 0 ;
            if (array1.size>=array2.size)
            {
                array.elem = new string[array2.size];
                
            }
            else
            {
                array.elem = new string[array1.size];
            }
            for (int i = 0; i < array1.size; i++)
            {
                for (int j = 0; j < array2.size; j++)
                {
                    if (array1.elem[i] == array2.elem[j] & !(array.elem.Contains(array1.elem[i])))
                    {
                        array.elem[t] = array1.elem[i];
                        t += 1;
                        continue;
                    }
                }
            }
            array.size = t ;
            Console.WriteLine("Пересечение массивов:");
            for (int i = 0; i < array.size; i++)
            {
                string s = array.elem[i];
                Console.WriteLine(s);
            }
        }
        static void Union(Array array1, Array array2)
        {
            string t;
            Array array = new Array();
            array.size = array1.size + array2.size;
            array.elem = new string[array.size];
            for(int i=0;i<array1.size;i++)
            {
                array.elem[i] = array1.elem[i];
            }
            for(int i=array1.size;i<array.size;i++)
            {
                array.elem[i] = array2.elem[i+array2.size-array.size];
            }
            for (int i=0;i<array.size;i++)
            {
                for(int j=i+1;j<array.size;j++)
                {
                    if(array.elem[i]==array.elem[j])
                    {
                        array.elem[j] = null;
                        if(j==array.size-1)
                        {
                            array.size -= 1;
                            j -= 1;
                        }
                        else
                        {
                            for(int p=j;p<array.size-1;p++)
                            {
                                t = array.elem[p];
                                array.elem[p] = array.elem[p+1];
                                array.elem[p + 1] = t;
                            }
                            array.size -= 1;
                            j -= 1;
                        }
                    }
                }
            }
            Console.WriteLine("Объединение массивов:");
            for (int i = 0; i < array.size; i++)
            {
                string s = array.elem[i];
                Console.WriteLine(s);
            }
        }
        static void Clutch(Array array1, Array array2)
        {
            Array array = new Array();
            if (array1.size >= array2.size)
            {
                array.size = array1.size;
            }
            else
            {
                array.size = array2.size;
            }
            array.elem = new string[array.size];
            if (array1.size > array2.size)
            {
                for (int i = 0; i < array2.size; i++)
                {
                    array.elem[i] = array1.elem[i] + array2.elem[i];
                }
                for (int i = array2.size; i < array1.size; i++)
                {
                    array.elem[i] = array1.elem[i];
                }
            }
            if (array1.size < array2.size)
            {
                for (int i = 0; i < array1.size; i++)
                {
                    array.elem[i] = array1.elem[i] + array2.elem[i];
                }
                for (int i = array1.size; i < array2.size; i++)
                {
                    array.elem[i] = array2.elem[i];
                }
            }
            if (array1.size == array2.size)
            {
                for (int i = 0; i < array1.size; i++)
                {
                    array.elem[i] = array1.elem[i] + array2.elem[i];
                }
            }
            Console.WriteLine("Поэлементное сцепение массивов:");
            foreach (string s in array.elem)
            {
                Console.WriteLine(s);
            }
        }
        static Array Menu1()
        {
            Array array = new Array();
            array.CreateArray();
            while (true)
            {
                Console.WriteLine("Введите данные с экрана:");
                Console.WriteLine("1-Вывести первый массив.");
                Console.WriteLine("2-Вывести элемент по его индексу у первого массива.");
                Console.WriteLine("3-Вывести элементы первого массива по начальной комбинации символов.");
                Console.WriteLine("0-перейти в следущее меню.");
                string a = Console.ReadLine();
                if (a == "1")
                {
                    PrintArray(array);
                }
                else if (a == "2")
                {
                    ToIndexPrint(array);
                }
                else if (a == "3")
                {
                    TolenPrint(array);
                }
                else if (a == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Попробуйте ещё раз.");
                }
            }
            return array;
        }
        static Array Menu2()
        {
            Array array = new Array();
            array.CreateArray();
            while (true)
            {
                Console.WriteLine("Введите данные с экрана:");
                Console.WriteLine("1-Вывести второй массив.");
                Console.WriteLine("2-Вывести элемент по его индексу у второго массива.");
                Console.WriteLine("3-Вывести элементы второго массива по начальной комбинации символов.");
                Console.WriteLine("0-перейти в следущее меню.");
                string a = Console.ReadLine();
                if (a == "1")
                {
                    PrintArray(array);
                }
                else if (a == "2")
                {
                    ToIndexPrint(array);
                }
                else if (a == "3")
                {
                    TolenPrint(array);
                }
                else if (a == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Попробуйте ещё раз.");
                }
            }
            return array;
        }
        static void Menu3(Array array1, Array array2)
        {
            while (true)
            {
                Console.WriteLine("Введите данные с экрана:");
                Console.WriteLine("1-Пересечение массивов.");
                Console.WriteLine("2-Объединение массивов.");
                Console.WriteLine("3-Поэлементное сцепление массивов.");
                Console.WriteLine("0-вернуться в начальное меню.");
                string a = Console.ReadLine();
                if (a == "1")
                {
                    Intersection(array1, array2);
                }
                else if (a == "2")
                {
                    Union(array1, array2);
                }
                else if (a == "3")
                {
                    Clutch(array1, array2);
                }
                else if (a == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Попробуйте ещё раз.");
                }
            }
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Введите данные с экрана:");
                Console.WriteLine("1-Cоздать первый массив.");
                Console.WriteLine("Выход-закончить выполнение программы.");
                string a = Console.ReadLine();
                if (a == "1")
                {
                    Array array1 = new Array();
                    array1 =Menu1();
                    Console.WriteLine("Вы создали первый массив");
                    Console.WriteLine("Введите данные с экрана:");
                    Console.WriteLine("1-Создать второй массив.");
                    Console.WriteLine("0-вернуться в начальное меню.");
                    a = Console.ReadLine();
                    if (a == "1")
                    {
                        Array array2 = new Array();
                        array2=Menu2();
                        Console.WriteLine("Вы создали второй массив.");
                        while (true)
                        {
                            Console.WriteLine("Введите данные с экрана:");
                            Console.WriteLine("1-перейти в следущее меню, для работы с обоими массивами.");
                            Console.WriteLine("0-вернуться в предыдущее меню,чтобы пересоздать второй массив.");
                            Console.WriteLine("-1-вернуться в начальное меню.");
                            a = Console.ReadLine();
                            if (a == "1")
                            {
                                Menu3(array1, array2);
                                break;
                            }
                            else if (a == "0")
                            {
                                array2=Menu2();
                                Console.WriteLine("Вы пересоздали второй массив.");
                            }
                            else if (a == "-1")
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
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте ещё раз.");
                    }
                }
                else if (a == "Выход")
                {
                    Console.WriteLine("Конец программы.");
                    break;
                }
                else
                {
                    Console.WriteLine("Попробуйте ещё раз");
                }
            }
        }
        public void Program()
        {
            Menu();
        }
    }
    public class Program
    {
        static void Main()
        {
            Array array = new Array();
            array.Program();
        }
    }    
}

        