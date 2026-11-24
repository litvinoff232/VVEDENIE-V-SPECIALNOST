using System;
using System.Globalization;
using System.IO.Pipelines;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Threading.Tasks.Dataflow;
using System.Runtime.ExceptionServices;
namespace LubC
{
    class Func
    {
        public double checkString(string menu)
        {
            double num;
            bool check = double.TryParse(menu, out num);

            while (!check)
            {
                Console.WriteLine("ошибка ввода, попробуйте снова");
                string input = Console.ReadLine() ?? "";
                check = double.TryParse(input, out num);
            }

            return num;
        }

        public void menu()
        {
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Сортировка массива");
            Console.WriteLine("4. Выход");
        }

        public double findFunc(double a)
        {
            a *= Math.PI / 180;
            double result = (Math.Sin(a) + Math.Tan(2 * a)) / Math.Sqrt(Math.Log(Math.Pow(Math.E, 2), 3));
            return result;
        }

        public void gameOne(double result)
        {
            double usResult;
            Console.WriteLine("(sin(a) + tg(2a)) / sqrt(log3 e^2) = ?");
            int i = 2;
            bool k = true;
            while (i >= 0 && k)
            {
                usResult = checkString(Console.ReadLine() ?? "");
                if (usResult == Math.Round(result, 2))
                {
                    Console.WriteLine("Верно, вы выиграли!");
                    k = false;
                }
                else
                {
                    Console.WriteLine("Неверно, попробуйте еще раз, оставшихся попыток {0}", i);
                    i--;
                    if (i == -1)
                    {
                        Console.WriteLine("Вы проиграли, правильный ответ - {0}", Math.Round(result,2));
                    }
                }
            }
        }


        public void gameTwo()
        {
            Console.Write("Литвинов Денис Филиппович\nГруппа: 6106-09.03.01D\n");
            Console.WriteLine("Нажмите enter для выхода в меню");
            Console.ReadKey();
        }


        public bool doExit()
        {
            bool flg = true;
            while (flg)
            {
                Console.WriteLine("д - выйти из программы, при нажатии н – остаться в программе");
                string ex = Console.ReadLine() ?? "";
                if (ex == "д")
                {
                    Console.WriteLine("Выход из программы");
                    flg = false;
                    return false;
                }
                else if (ex == "н")
                {
                    flg = false;
                    return true;
                                
                }
                else
                {
                    Console.WriteLine("Неправильный ввод");
                }
            }
                return false;

        }
        

        public void printArr(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
        }
        public int[] CreateArr(int n)
        {
            Random rnd = new Random();
            int[] mass = new int[n];
            for(int i = 0; i < n; i++)
            {
                mass[i] = rnd.Next(-25, 26);
            }

            return mass;
        }

        public int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int k = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = k;
                    }
                }
            }

            return arr;
        }
        public void CopyArr(int[] arr, int[] mass)
        {
            Array.Copy(arr, mass, arr.Length);
           // return mass;

        }
       
        public int[] ViborSort(int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                int min  = i;
                for(int j = i + 1; j < mass.Length; j++)
                {
                    if (mass[j]< mass[min])
                    {
                        min = j;
                    
                    }
                }
                if(min != i)
                {
                    int n;
                    n = mass[i];
                    mass[i] = mass[min];
                    mass[min] = n;
                    
                }
            }

            return mass;
        }




        public void caseOne()
        {
                            Console.WriteLine("Вы должны угадать ответ f((sin(a) + tg(2a)) / sqrt(log3 e^2))\nна это вам дается 3 попытки, ответ должен быть округлен до 2 знаков после запятой");
                            Console.WriteLine("Введите число а: ");
                            double a = checkString(Console.ReadLine() ?? "");
                            bool flg = true;
                            while(flg){
                                a = ((a % 360) + 360) % 360;

                                if(Math.Abs(Math.Cos(2 * a * Math.PI / 180)) < 1e-10)
                                {
                                    Console.WriteLine("Недопустимое значение для тангенса (cos(2a) = 0)");
                                    Console.Write("Введите число а: ");
                                    a = checkString(Console.ReadLine() ?? "");
                                }
                                else
                                {
                                    flg = false;
                                }
                            }
                            double result = findFunc(a);
                            gameOne(result);
        }
        static string Format(TimeSpan t)
        {
            long totalUs = t.Ticks / 10;

            long hours   = totalUs / 3_600_000_000;
            long minutes = (totalUs / 60_000_000) % 60;
            long seconds = (totalUs / 1_000_000) % 60;
            long micros  = totalUs % 1_000_000;

            return $"{hours:00}:{minutes:00}:{seconds:00}.{micros:000000}";
        }



        public void caseThree()
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Введите размер массива: ");
            int n = (int)checkString(Console.ReadLine() ?? "");
            Console.WriteLine("Bubble:");
            while (n <= 0)
            {
                Console.WriteLine("Значение не может быть отрицательным и быть равным нулю!");
                Console.WriteLine("Введите размер массива: ");
                n = (int)checkString(Console.ReadLine() ?? "");
            }

            int[] arr = CreateArr(n);
            
            if(n < 10)
            {
                printArr(arr);
            }
            int[] mass = new int[n];
            CopyArr(arr, mass);

            sw.Start();
            arr = BubbleSort(arr);
            sw.Stop();
            Console.WriteLine($"Сортировка пузырьком - Время выполнения: {Format(sw.Elapsed)}");

            if (n > 10)
            {
                Console.WriteLine("Нельзя вывести отсортированный массив, из-за большой длины\nЧтобы вывести массив, длина должна быть меньше 10\n");
            }
            else
            {
                
                printArr(arr);
            }

            Console.Write("\n");

            sw.Reset();

            if(n < 10)
            {
               printArr(mass);
            }
            


            Console.WriteLine("Select: ");
            sw.Start();
            mass = ViborSort(mass);
            sw.Stop();
            Console.WriteLine($"Сортировка выбором - Время выполнения: {Format(sw.Elapsed)}");
            if (n > 10)
            {
                Console.WriteLine("Нельзя вывести отсортированный массив, из-за большой длины\nЧтобы вывести массив, длина должна быть меньше 10\n");
            }
            else
            {
                
                printArr(mass);
            }
            Console.Write("\n");
        }


    }
}