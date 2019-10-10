using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPA_HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i, j, k;
            Console.WriteLine("Введите размерность: ");
            n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            Graph graph = new Graph();

            Console.WriteLine("Задайте числа");
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                {
                    Console.Write("matrix[" + i + "][" + j + "]= ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }

            for (k = 0; k < n; ++k)
                for (i = 0; i < n; ++i)
                    for (j = 0; j <n; ++j)
                        if (matrix[i, k] + matrix[k, j] < matrix[i, j])
                        {
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                            Console.WriteLine("Самый короткий путь =" + matrix[i, j]);
                        }
            Console.ReadKey();
        }
    }
}
