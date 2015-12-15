using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace CMPE1700Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that calculates the amount of time to sort sets of 100, 500, 1000, 5000, 10000, 50000, 100000 elements
            Random n = new Random();
            ulong[] one_h = new ulong[100];
            one_h = mylist(one_h, 100);
            ulong[] five_hundred = new ulong[500];
            five_hundred = mylist(five_hundred, 500);
            ulong[] one_thousand = new ulong[1000];
            one_thousand = mylist(one_thousand, 1000);
            ulong[] five_thousand = new ulong[5000];
            five_thousand = mylist(five_thousand, 5000);
            ulong[] ten_thousand = new ulong[10000];
            ten_thousand = mylist(ten_thousand, 10000);
            ulong[] fivety_thousand = new ulong[50000];
            fivety_thousand = mylist(fivety_thousand, 50000);
            ulong[] onehundred_thousand = new ulong[100000];
            onehundred_thousand = mylist(onehundred_thousand, 100000);
            Bubblesort(one_h, 100);
            Bubblesort(five_hundred, 500);
            Bubblesort(one_thousand, 1000);
            Bubblesort(five_thousand, 5000);
            Bubblesort(ten_thousand, 10000);
            Bubblesort(fivety_thousand, 50000);
            Bubblesort(onehundred_thousand, 100000);
            InsertionSort(one_h, 100);
            InsertionSort(five_hundred, 500);
            InsertionSort(one_thousand, 1000);
            InsertionSort(five_thousand, 5000);
            InsertionSort(ten_thousand, 10000);
            InsertionSort(fivety_thousand, 50000);
            InsertionSort(onehundred_thousand, 100000);
            long a = 0;
            Console.WriteLine("This is quicksort for 100 elements in an array\n");
            a = Quicksort(one_h, 0, (ulong)one_h.Length - 1, 100);
            Console.WriteLine("It takes " + a + " milliseconds to complete\n\n");
            a = Quicksort(five_hundred, 0, (ulong)five_hundred.Length - 1, 500);
            Console.WriteLine("This is quicksort for 500 elements in an array\n");
            Console.WriteLine("It takes " + a + " milliseconds to complete\n\n");
            a = Quicksort(one_thousand, 0, (ulong)one_thousand.Length - 1, 1000);
            Console.WriteLine("This is quicksort for 1000 elements in an array\n");
            Console.WriteLine("It takes " + a + " milliseconds to complete\n\n");
            Console.WriteLine("This is quicksort for 5000 elements in an array\n");
            a = Quicksort(fivety_thousand, 0, (ulong)fivety_thousand.Length - 1, 5000);
            Console.WriteLine("It takes " + a + " milliseconds to complete\n\n");
            Console.WriteLine("This is quicksort for 10000 elements in an array\n");
            a = Quicksort(ten_thousand, 0, (ulong)ten_thousand.Length - 1, 10000);
            Console.WriteLine("It takes " + a + " milliseconds to complete");
            Console.WriteLine("This is quicksort for 50000 elements in an array\n");
            a = Quicksort(fivety_thousand, 0, (ulong)fivety_thousand.Length - 1, 50000);
            Console.WriteLine("It takes " + a + " milliseconds to complete\n\n");
            Console.WriteLine("This is quicksort for 100000 elements in an array\n");
            a = Quicksort(onehundred_thousand, 0, (ulong)onehundred_thousand.Length - 1, 100000);
            Console.WriteLine("It takes " + a + " milliseconds to complete");
            Console.ReadKey();

        }
        public static void Bubblesort(ulong[] arr, ulong num)
        {
            Console.WriteLine("Bubble sort for " + num + " elements in an array\n");
            Stopwatch sw = new Stopwatch();
            ulong temp = 0;
            sw.Start();
            for (ulong write = 0; write < (ulong)arr.Length; write++)
            {
                for (ulong sort = 0; sort < (ulong)arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("It takes " + sw.ElapsedMilliseconds + " milliseconds to complete\n");
            long x = sw.ElapsedMilliseconds;
            Console.WriteLine();
            sw.Reset();

        }
        public static void InsertionSort(ulong[] array, ulong num)
        {
            Console.WriteLine("\nInsertion sort for " + num + " elements in an array\n");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (ulong i = 0; i < (ulong)array.Length - 1; i++)
            {
                ulong j = i + 1;

                while (j > 0)
                {
                    if (array[j - 1] > array[j])
                    {
                        ulong temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;

                    }
                    j--;
                }
            }
            Console.WriteLine("It takes " + sw.ElapsedMilliseconds + " milliseconds to complete\n\n");
            sw.Reset();

        }
        public static long Quicksort(ulong[] elements, ulong left, ulong right, ulong num)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            ulong i = left, j = right;
            ulong pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    ulong tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j, num);
            }

            if (i < right)
            {
                Quicksort(elements, i, right, num);
            }
            // Console.WriteLine("It takes " +timer.ElapsedMilliseconds+" to complete");
            return sw.ElapsedMilliseconds;
        }
        public static ulong[] mylist(ulong[] List, ulong num)
        {
            // Console.WriteLine("The items in an array");
            Random gen = new Random();
            for (ulong i = 0; i < num; i++)
            {
                List[i] = (ulong)gen.Next(0, 100);
                // Console.Write(lis[i] + " ");
            }
            Console.WriteLine("\n\n");
            return List;
        }

    }


       
    }
}
