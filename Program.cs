using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InsertionShellSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int[] arr = new int[10000];
            Random randNum = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randNum.Next(0, 10000);
                //Console.Write(arr[i] + " ");
            }
            
            int[] arr2 = arr.Clone() as int[];
            if (arr2 == null)
            {
                throw new InvalidOperationException("Cloning the array failed.");
            }

            Console.WriteLine();

            Console.WriteLine("--------------------");
            Console.WriteLine("\n\nInsertion Sort");
          
            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();

            Console.WriteLine("Time elapsed on Insertion Sort: {0}", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\n\nShell Sort");
            stopwatch.Restart();
            ShellSort(arr2);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed on Shell Sort: {0}", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("--------------------");
            Console.WriteLine();

            /*Console.WriteLine("Array after Insertion sorting: ");
            for (int i = 0; i < arr.Length; i++)
            {
               Console.Write(arr[i] + " ");
            }

            Console.WriteLine("Array after Shell sorting: ");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }*/

        }

        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0 && arr[j] > arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                    j--;
                }
            }
        }

        public static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] < temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
                }
            }
        }
    }
}
