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
                    left = currentPosition + 1;
                }

                if (vector[currentPosition] > search)
                {
                    right = currentPosition - 1;
                }
            }

            return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("size;lookupvalue;result;time;oper_count");
            int result;

            for (int i = 2000000; i < Math.Pow(2, 28); i += 100000)
            {
                
                int[] tab = new int[i];
                for (int k = 0; k < tab.Length; k++)
                {
                    tab[k] = k+1;
                }
                Array.Sort(tab); // sortowanie tablicy rozsnąco
                int lookUpValue = tab.Length+2; // wartość szukana
                long start = Stopwatch.GetTimestamp(); // start czasu
                result = BinarySearchPesymistic(tab, lookUpValue); // pomiar czasu dla liniowego tutaj robimy bez instrumentacji
                long stop = Stopwatch.GetTimestamp();   // stop czas
                result = BinarySearchPesymisticOptions(tab, lookUpValue); // wynik instrumentacji
                Console.WriteLine(i + ";" + lookUpValue + ";" + result + ";" + (stop - start) + ";" + counter); // tablica; szukana; index; czas; za którym razem
            }
        }
    }
}
