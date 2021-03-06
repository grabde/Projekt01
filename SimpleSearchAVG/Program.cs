﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace projekt01AlgorytmyIStrukturyDanych
{
    class Program
    {
        private static int iter = 10;
        private static int counter; // zmienna globalna wykorzystywana do iteracji instrumentacji
        private static long suma;

        private static int SimpleSearch(int[] tab, int lookUpValue) //Wyszukiwanie Liniowe przed instrumentacją
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == lookUpValue)
                {
                    return i;
                }
            }
            return -1;
        }

        private static int SimpleSearchOptions(int[] tab, int lookUpValue) //Wyszukiwanie Liniowe po instrumentacją
        {
            counter = 0;
            suma = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                counter++;
                suma += (long)tab[i];
                if (tab[i] == lookUpValue)
                {
                    return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Random random = new Random();

            int result = 0; //zmienna ktora przechowuje index liczby znalezionej
            long min = long.MaxValue;
            long max = long.MinValue;
            long timeElapsed = 0;
            long iterTimeElapsed;
            double ElapsedSeconds;
            Console.WriteLine("size;lookupvalue;result;time;oper_count");
            for (int i = 26843545; i <= 268435450; i += 26843545)
            {
                int[] tab = new int[i];
                for (int k = 0; k < tab.Length; k++)
                {
                    tab[k] = k + 1;
                }
                Array.Sort(tab); // sortowanie tablicy rozsnąco
                int lookUpValue = tab.Length; // wartość szukana
                for (int j = 0; j < iter + 2; ++j)
                {
                    long start = Stopwatch.GetTimestamp(); // start czasu
                    result = SimpleSearch(tab, lookUpValue); // pomiar czasu dla liniowego tutaj robimy bez instrumentacji
                    long stop = Stopwatch.GetTimestamp();   // stop czas
                    iterTimeElapsed = stop - start;
                    timeElapsed += iterTimeElapsed;
                    if (iterTimeElapsed < min) min = iterTimeElapsed;
                    if (iterTimeElapsed > max) max = iterTimeElapsed;
                    result = SimpleSearchOptions(tab, lookUpValue); // wynik instrumentacji
                    timeElapsed = (min + max);
                }
                long wynik = suma / counter;
                ElapsedSeconds = timeElapsed * (1.0 / (iter * Stopwatch.Frequency));
                Console.WriteLine(i + ";" + lookUpValue + ";" + result + ";" + (ElapsedSeconds.ToString("F4")) + ";" + wynik); // tablica; szukana; index; czas; za którym razem
            }
        }
    }
}
