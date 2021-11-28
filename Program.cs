using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_22
{
    class Program
    {
        static int[] array;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число массива");
            int n = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write($"{array[i],3}");
            }
            Console.WriteLine();

            Func<int> fun = new Func<int>(Summa);
            Task<int> task = new Task<int>(fun);
            Func<Task, int> taskint = new Func<Task, int>(MaxN);
            Task<int> task2 = task.ContinueWith(taskint);
            task.Start();

            Console.WriteLine($"Сумма чисел массива = {task.Result}");
            Console.WriteLine($"Максимальное число в массиве - {task2.Result}");

            Console.ReadKey();
        }
        static int Summa()
        {
            int S = 0;
            for (int i = 0; i < array.Length; i++)
            {
                S += array[i];
            }
            return (S);
        }
        static int MaxN(Task task)
        {
            int max = array[0];
            foreach (int a in array)
            {
                if (a > max)
                    max = a;
            }
            return (max);
        }
    }
}
