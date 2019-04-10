using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace algorytmy01
{
    class Program
    {
        private static int iter = 10;
        private static int counter;
        public static int BinarySearchPesymistic(int[] vector, int search)
        {
            int left = 0;
            int right = vector.Length - 1;

            while (left <= right)
            {
                int currentPosition = left + (right - left) / 2;

                if (vector[currentPosition] == search)
                {
                    return currentPosition;
                }

                if (vector[currentPosition] < search)
                {
                    left = currentPosition + 1;
                }

                if (vector[currentPosition] > search)
                {
                    right = currentPosition - 1;
                }
            }
            return -1;
        }
        public static int BinarySearchPesymisticOptions(int[] vector, int search)
        {
            int left = 0;
            int right = vector.Length - 1;
            counter = 0;
            while (left <= right)
            {
                counter++;
                int currentPosition = left + (right - left) / 2;

                if (vector[currentPosition] == search)
                {
                    
                    return currentPosition;
                }

                if (vector[currentPosition] < search)
                {
                    counter++;
                    left = currentPosition + 1;
                }

                if (vector[currentPosition] > search)
                {
                    right = currentPosition - 1;
                    counter++;
                }
            }

            return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("size;lookupvalue;result;time;oper_count");
            int result = 0;
            long min = long.MaxValue;
            long max = long.MinValue;
            long timeElapsed = 0;
            long iterTimeElapsed;
            int lookUpValue;
            double ElapsedSeconds;
            //for (int i = 2000000; i < Math.Pow(2, 28); i += 100000)
            for (int i = 26843545; i <= 268435450; i += 26843545)
            {

                int[] tab = new int[i];
                for (int k = 0; k < tab.Length; k++)
                {
                    tab[k] = k + 1;
                }
                Array.Sort(tab); // sortowanie tablicy rozsnąco
                lookUpValue = (tab.Length + 2); // wartość szukana
                for (int j = 0; j < iter + 2; ++j)
                {
                    long start = Stopwatch.GetTimestamp(); // start czasu
                    result = BinarySearchPesymistic(tab, lookUpValue); // pomiar czasu dla binarnego tutaj robimy bez instrumentacji
                    long stop = Stopwatch.GetTimestamp();   // stop czas
                    iterTimeElapsed = stop - start;
                    timeElapsed += iterTimeElapsed;
                    if (iterTimeElapsed < min) min = iterTimeElapsed;
                    if (iterTimeElapsed > max) max = iterTimeElapsed;
                    result = BinarySearchPesymisticOptions(tab, lookUpValue); // wynik instrumentacji
                }
                timeElapsed = (min + max);
                ElapsedSeconds = timeElapsed * (1.0 / (iter * Stopwatch.Frequency));
                Console.WriteLine(i + ";" + lookUpValue + ";" + result + ";" + (ElapsedSeconds.ToString("F0")) + ";" + counter); // tablica; szukana; index; czas; za którym razem
            }
        }
    }
}
