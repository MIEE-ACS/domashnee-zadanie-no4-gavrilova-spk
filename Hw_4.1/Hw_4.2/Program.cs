using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_4._2
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
            int i = 0, j = 0, k = 0, neg = 0, mult = 1, neg_mult = 1;
            bool pos_rows = false;

            Console.Write("Введите размер матрицы:  ");
            string str = Console.ReadLine();
            int N = Check(ref str);
            if (N <= 0)
            {
                Console.WriteLine("Матрицы не существует");
                Console.ReadKey();
                Environment.Exit(404);
            }
            int [,] arr = new int [N, N];
            int[] diagonal_sum = new int[N+N-1];

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Целочисленная квадратная матрица:");
            Random rnd = new Random();
            for (i = 0; i < N; i++)
            {
                neg = 0; mult = 1;
                for (j = 0; j < N; j++)
                {
                    arr[i, j] = rnd.Next(-5, 5);
                    Console.Write("{0}   ", arr[i, j]);
                    mult *= arr[i, j];
                    if (arr[i, j] < 0)                   
                        neg++;
                }
                Console.WriteLine(" ");
                if (neg == 0)
                {
                    neg_mult *= mult;
                    pos_rows = true;
                }
            }

          
                // don't work
            {
                /*
                for (i = 0; i < N; i++)
                {
                    for (j = i; j < N; j++)
                    {
                        diagonal_sum[N-1-j] += arr[i, j];
                    }
                }

                for (i =(N - 1); i > 1; i--)
                {
                    for (j = 0; j < i; j++)
                    {
                        diagonal_sum[2 *N - 1 - i] += arr[i, j];
                    }
                }
                */
            }

            //суммы диагоналей ||-ых главной
            for (i = 0; i < N; i++)          
                for (k = -(N - 1); k < N; k++)
                    if ((i + k) < N && (i + k) >= 0)
                        diagonal_sum[N + k - 1] += arr[i, i + k];




            Console.WriteLine("-----------------------------------------------");
            if (pos_rows)
                Console.WriteLine("Произведение элементов, в строке которых нет отрицательных элементов:   {0}", neg_mult);
            else
                Console.WriteLine("Нет строк без отрицательных элементов.");

            
            int max_sum = diagonal_sum[0];
            for (i = 1; i < diagonal_sum.Length; i++)
                if (diagonal_sum[i] > max_sum)
                     max_sum = diagonal_sum[i];
            Console.WriteLine("Максимальная сумма элементов, лежащих на диагонале параллельной главной:  {0}", max_sum);


            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
