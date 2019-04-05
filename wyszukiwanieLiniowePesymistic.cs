using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace projekt01AlgorytmyIStrukturyDanych
{
    class Program
    {
        private static int counter; // zmienna globalna wykorzystywana do iteracji instrumentacji

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
            for (int i = 0; i < tab.Length; i++)
            {
                counter++;
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
            int lookUpValue = 1001; // wartość szukana
            int result; //zmienna ktora przechowuje index liczby znalezionej
            //Generate tables with random value
            Console.WriteLine("size;lookupvalue;result;time;oper_count");
            for (int i = 2000000; i < Math.Pow(2,28); i += 100000)
            {
                int[] tab = new int[i];
                for (int k = 0; k < tab.Length; k++)
                {
                    tab[k] = random.Next(1,1000);
                }
                Array.Sort(tab);
            long start = Stopwatch.GetTimestamp(); // start czasu
            result = SimpleSearch(tab, lookUpValue); // pomiar czasu dla liniowego tutaj robimy bez instrumentacji
            long stop = Stopwatch.GetTimestamp();   // stop czas
            result = SimpleSearchOptions(tab, lookUpValue); // wynik instrumentacji
            Console.WriteLine(i + ";" + lookUpValue + ";" + result + ";" + (stop - start) + ";" + counter); // tablica; szukana; index; czas; za którym razem
            }
        }
    }
}
