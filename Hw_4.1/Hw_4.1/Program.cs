using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_4._1
{
    class Program
    {
        static int Check(ref string str)  //Проверка на десятичное число, замена точки на запятую
        {
            int num;
            
            if (!int.TryParse(str, out num))
            {
                Console.WriteLine("Вводить надо число. Конец программы.");
                Console.WriteLine("Для выхода нажмите любую кнопку...");
                Console.ReadKey();
                Environment.Exit(37707);
            }
            return num;
        }

        static void Main(string[] args)
        {
            int i = 0, j = 0, k = 0, neg = 0, low = 0; 
            double[] arr = new double[1];
            double odd_sum = 0, neg_sum = 0;

            Console.WriteLine("Введите количество элементов массива:");
            string str = Console.ReadLine();
            int N = Check(ref str);
            if (N <= 0)
            {
                Console.WriteLine("Массива не существует");
                Console.ReadKey();
                Environment.Exit(404);
            }
            Array.Resize(ref arr, N);


                Console.WriteLine("-------------------------------------");
            Console.WriteLine("Массив вещественных чисел:");
            Random rnd = new Random();
            for ( i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-10, 10) + rnd.NextDouble();
                Console.WriteLine("{0:N2}",arr[i]);

                if ((i + 1) % 2 == 1)       // сумма нечетных элементов
                    odd_sum += arr[i];

                if (arr[i] < 0)   //кол-во отрицательных чисел
                    neg++;

                if (Math.Abs(arr[i]) < 1)   //кол-во чисел меньше модуля 1
                    low++;
            }
            
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Сумма элементов нечетных номеров:   {0:N2}", odd_sum);

            if (neg >= 2)   // сумма между(!) отрицательными
            {
                i--;
                while (arr[i] >= 0)    //номер последнего отрицательного элемента
                    i--;
                while (arr[j] >= 0)    //номер первого отрицательного элемента
                    j++;

                
                for (j += 1; j < i; j++)       // сумма элементов между первым и последним отрецательными элементами
                    neg_sum += arr[j];
                Console.WriteLine("Сумма элементов между первым и последним отрецательными элементами:   {0:N2}", neg_sum);
            }
            else
                Console.WriteLine("В массиве менее двух отрицательных элементов, посчитать сумму элементов между первым и последним отрицательными элементами невозможно");


            Console.WriteLine("-----------------------------------------------");
            if (low != 0)   //элементов меньше модуля 1
            {
                Console.WriteLine("Новый массив вещественных чисел без элементов меньше модуля 1:");
                for (i = 0; i < N; i++)   // do(n't) work
                {
                    if (Math.Abs(arr[i]) < 1)
                        arr[i] = 0;

                    if (arr[i] == 0)
                    {
                        for (j = i; j < N; j++)        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            for (k = j + 1; k < N; k++)
                            {
                                arr[j] = arr[k];
                                arr[k] = 0;
                                break;
                            }
                    }
                    Console.WriteLine("{0:N2}", arr[i]);
                }
            }
            else
                Console.WriteLine("В массиве нет элементов меньше модуля 1");

            Console.WriteLine("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
