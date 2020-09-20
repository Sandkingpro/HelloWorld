using System;
using System.Linq;

namespace massiv
{
    public class massivs
    {

        public int k;//количество элементов
        public string[] elem;//обращение к элементу
        public massivs createmassiv()
        {
            Console.WriteLine("Введите количество ячеек массива");
            try
            {
                this.k = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Вы ввели не целое число");
                return createmassiv();
            }
            this.elem = new string[k];
            for (int i = 0; i < k; i++)
            {
                Console.Write("Элемент{0}=", i+1);
                this.elem[i] = Console.ReadLine();
            }
            return this;

        }
        static void printmassiv(massivs Massiv)
        {
            for(int i=0;i<Massiv.k;i++)
            {
                Console.WriteLine("Элемент{0}={1} ", i + 1, Massiv.elem[i]);
            }
        }
        static massivs toindexprint(massivs Massiv)
        {
            try
            {
                Console.WriteLine("Введите индекс не превышающий количество ячеек в массиве");
                int i = Convert.ToInt32(Console.ReadLine());
                if(i>=Massiv.k)
                {
                    return toindexprint(Massiv);
                }
                Console.WriteLine("Элемент{0}={1} ", i + 1, Massiv.elem[i]);
            }
            catch(FormatException)
            {
                Console.WriteLine("Вы ввели неправильно");
                return toindexprint(Massiv);
            }
            return null;
            
        }
        static void tolenprint(massivs Massiv)
        {
            Console.Write("Введите начальную комбинацию символов:");
            string len = Console.ReadLine();
            int j = len.Length;
            for (int i=0;i<Massiv.k;i++)
            {
                if (Massiv.elem[i].StartsWith(len))
                {
                    Console.WriteLine("Элемент{0}={1} ", i + 1, Massiv.elem[i]);
                }
            }
               
        }
        static void intersection(massivs Massiv1,massivs Massiv2)
        {
            var Massiv = Massiv1.elem.Intersect(Massiv2.elem);
            Console.WriteLine("Пересечение массивов:");
            foreach (string s in Massiv)
            {
                
                Console.WriteLine( s);
                
            }
                
        }
        static void union(massivs Massiv1,massivs Massiv2)
        {
            var Massiv = Massiv1.elem.Union(Massiv2.elem);
            Console.WriteLine("Объединение массивов массивов:");
            foreach (string s in Massiv)
            {
                
                Console.WriteLine(s);
            }
        }
        static void clutch(massivs Massiv1,massivs Massiv2)
        {
            massivs Massiv = new massivs();
            if( Massiv1.k>=Massiv2.k)
            {
                Massiv.k = Massiv1.k;
            }
            else
            {
                Massiv.k = Massiv2.k;
            }
            Massiv.elem = new string[Massiv.k];
            if(Massiv1.k>Massiv2.k)
            {
                for(int i=0;i<Massiv2.k;i++)
                {
                    Massiv.elem[i] = Massiv1.elem[i] + Massiv2.elem[i];
                }
                for(int i=Massiv2.k;i<Massiv1.k;i++)
                {
                    Massiv.elem[i] = Massiv1.elem[i];
                }
            }
            if(Massiv1.k<Massiv2.k)
            {
                for (int i = 0; i < Massiv1.k; i++)
                {
                    Massiv.elem[i] = Massiv1.elem[i] + Massiv2.elem[i];
                }
                for (int i = Massiv1.k; i < Massiv2.k; i++)
                {
                    Massiv.elem[i] = Massiv2.elem[i];
                }
            }
            if(Massiv1.k==Massiv2.k)
            {
                for (int i = 0; i < Massiv1.k; i++)
                {
                    Massiv.elem[i] = Massiv1.elem[i] + Massiv2.elem[i];
                }
            }
            Console.WriteLine("Поэлементное сцепение массивов:");
            foreach(string s in Massiv.elem)
            {
                Console.WriteLine(s);
            }
        }
        static massivs massiv1()
        {
           
            try
            {
                Console.WriteLine("Нужно вводить числа с экрана");
                Console.WriteLine("Введите:");
                Console.WriteLine("1-Создать массив");
                Console.WriteLine("0-для выхода из программы");
                int a = Convert.ToInt32(Console.ReadLine());

                if (a == 1)
                {
                    massivs Massiv1 = new massivs();
                    Massiv1.createmassiv();
                    Console.WriteLine("Вы создали первый массив");
                    massiv1_print(Massiv1);
                    return Massiv1;
                }
                if (a == 0)
                {
                    return null;
                }
                if (a!=0 & a!=1)
                {
                    return massiv1();
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Нужно вводить числа с экрана");
                Console.WriteLine("Введите:");
                Console.WriteLine("1-Создать массив");
                Console.WriteLine("0-для выхода из программы");
                return massiv1();
            }
            return null;
        }
        static massivs massiv1_print(massivs Massiv1)
        {
            try
            {
                Console.WriteLine("Нужно вводить числа с экрана");
                Console.WriteLine("Введите:");
                Console.WriteLine("1-Вывести весь массив");
                Console.WriteLine("2-Вывести элемент массива по его индексу");
                Console.WriteLine("3-Вывести элементы массива по начальной комбинации");
                Console.WriteLine("4-Создать второй массив");
                Console.WriteLine("0-возвращение в предыдущее меню");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a==1)
                {
                    printmassiv(Massiv1);
                    return massiv1_print(Massiv1);
                }
                if (a==2)
                {
                    toindexprint(Massiv1);
                    return massiv1_print(Massiv1);
                }
                if (a==3)
                {
                    tolenprint(Massiv1);
                    return massiv1_print(Massiv1);
                }
                if (a==4)
                {
                    massivs Massiv2 = new massivs();
                    Massiv2.createmassiv();
                    Console.WriteLine("Вы создали второй массив");
                    Massiv12(Massiv1,Massiv2);
                    return Massiv2;
                }
                if(a<0||a>4)
                {
                    return massiv1_print(Massiv1);
                }
                if(a==0)
                {
                    return massiv1();
                }
            }
            catch(FormatException)
            { 
                Console.WriteLine("Нужно вводить числа с экрана");
                Console.WriteLine("Введите:");
                Console.WriteLine("1-Вывести весь массив");
                Console.WriteLine("2-Вывести элемент массива по его индексу");
                Console.WriteLine("3-Вывести элементы массива по начальной комбинации");
                Console.WriteLine("4-Создать второй массив");
                Console.WriteLine("0-возвращение в предыдущее меню");
                return massiv1_print(Massiv1);
            }
            return null;
            
        }
        static massivs Massiv12(massivs Massiv1,massivs Massiv2)
        {
            try
            {
                Console.WriteLine("Нужно вводить числа с экрана");
                Console.WriteLine("Введите:");
                Console.WriteLine("1-Вывести весь первый массив");
                Console.WriteLine("2-Вывести элемент первого массива по его индексу");
                Console.WriteLine("3-Вывести элементы первого массива по начальной комбинации");
                Console.WriteLine("4-Вывести весь второй массив");
                Console.WriteLine("5-Вывести элемент второго массива по его индексу");
                Console.WriteLine("6-Вывести элементы второго массива по начальной комбинации");
                Console.WriteLine("7-пересечение двух массивов");
                Console.WriteLine("8-объединение двух массивов");
                Console.WriteLine("9-поэлементное сцепление двух массивов");
                Console.WriteLine("0-возвращение в предыдущее меню");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a == 1)
                {
                    printmassiv(Massiv1);
                    return Massiv12(Massiv1, Massiv2);
                }
                if (a == 2)
                {
                    toindexprint(Massiv1);
                    return Massiv12(Massiv1, Massiv2);
                }
                if (a == 3)
                {
                    tolenprint(Massiv1);
                    return Massiv12(Massiv1, Massiv2);
                }
                if (a == 4)
                {
                    printmassiv(Massiv2);
                    return Massiv12( Massiv1, Massiv2);
                }
                if (a == 5)
                {
                    toindexprint(Massiv2);
                    return Massiv12(Massiv1, Massiv2);
                }
                if (a == 6)
                {
                    tolenprint(Massiv2);
                    return Massiv12( Massiv1, Massiv2);
                }
                if(a==7)
                {
                    intersection(Massiv1, Massiv2);
                    return Massiv12(Massiv1, Massiv2);
                }
                if(a==8)
                {
                    union(Massiv1, Massiv2);
                    return Massiv12(Massiv1, Massiv2);
                }
                if (a==9)
                {
                    clutch(Massiv1, Massiv2);
                    return Massiv12(Massiv1, Massiv2);
                }
                if(a<0||a>9)
                {
                    return Massiv12(Massiv1, Massiv2);
                }
                if (a == 0)
                {
                    return massiv1_print(Massiv1);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Нужно вводить числа с экрана");
                Console.WriteLine("Введите:");
                Console.WriteLine("1-Вывести весь первый массив");
                Console.WriteLine("2-Вывести элемент первого массива по его индексу");
                Console.WriteLine("3-Вывести элементы первого массива по начальной комбинации");
                Console.WriteLine("4-Вывести весь второй массив");
                Console.WriteLine("5-Вывести элемент второго массива по его индексу");
                Console.WriteLine("6-Вывести элементы второго массива по начальной комбинации");
                Console.WriteLine("7-пересечение двух массивов");
                Console.WriteLine("8-объединение двух массивов");
                Console.WriteLine("9-поэлементное сцепление двух массивов");
                Console.WriteLine("0-возвращение в предыдущее меню");
                return Massiv12(Massiv1, Massiv2);
            }
            return null;
        }
        public string menu()
        {
            massiv1();
            return null;
        }
    }
    public class program
    {

        static void Main()
        {
            massivs Massiv = new massivs();
            Massiv.menu();
        }
        
    }
}
