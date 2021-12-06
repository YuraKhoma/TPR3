using System;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Прочитали всі строки з файла
            string[] s = File.ReadAllLines("Data.txt");

            string[,] num = new string[s.Length, s[0].Split(' ').Length];

            for (int i = 0; i < s.Length; i++)
            {
                string[] buff = s[i].Split(' ');
                for (int j = 0; j < buff.Length; j++)
                {
                    num[i, j] = buff[j];
                }
            }

            //Вивід масива
            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    Console.Write(num[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Bordo(num);
            Console.WriteLine();
            Kondor(num);
            Console.ReadKey();
        }

        private static void KondorCalculate(string A, string B, string[,] array)
        {
            int a = 0, b = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int count = int.Parse(array[i, 0]);
                    string temp = array[i, j];
                    string temp1 = array[i, j];

                    if (temp == A && j == 1)
                    {
                        a += count;
                    }
                    else if (temp1 == B && j == 1)
                    {
                        b += count;
                    }
                    else if (temp == A && j == 2 && array[i, 1] != B)
                    {
                        a += count;
                    }
                    else if (temp1 == B && j == 2 && array[i, 1] != A)
                    {
                        b += count;
                    }
                }
            }
            if (a > b)
            {
                Console.WriteLine("Кондорсе мiж {0} i {1}:", A, B);
                Console.WriteLine(A + ": " + a);
                Console.WriteLine(B + ": " + b);
                Console.WriteLine(A+" > "+B);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Кондорсе мiж {0} i {1}:", A, B);
                Console.WriteLine(A + ": " + a);
                Console.WriteLine(B + ": " + b);
                Console.WriteLine(B + " > " + A);
            }
        }
        private static int BordoCalculate(string A, string[,] array)
        {
            int a = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int count = int.Parse(array[i, 0]);
                    string temp = array[i, j];

                    if (temp == A && j == 1)
                    {
                        a += count * 3;
                    }
                    else if (temp == A && j == 2)
                    {
                        a += count * 2;
                    }
                    else if (temp == A && j == 3)
                    {
                        a += count;
                    }
                }
            }
            return a;
        }

        //Кондорсе
        private static void Kondor(string[,] array)
        {
            KondorCalculate("А", "Б", array);
            KondorCalculate("А", "С", array);
            KondorCalculate("С", "Б", array);
        }

        //Бордо
        private static void Bordo(string[,] array)
        {
            int A = BordoCalculate("А", array);
            int B = BordoCalculate("Б", array);
            int C = BordoCalculate("С", array);

            Console.WriteLine("Бордо:");
            Console.WriteLine("A:" + A);
            Console.WriteLine("Б:" + B);
            Console.WriteLine("С:" + C);

            if (A>B && A>C)
            {
                Console.WriteLine("Переможе кандидат А");
            }
            else if ( B > A && B > C)
            {
                Console.WriteLine("Переможе кандидат Б");
            }
            else if (C > A && C > B)
            {
                Console.WriteLine("Переможе кандидат C");
            }
        }
         
    }
}