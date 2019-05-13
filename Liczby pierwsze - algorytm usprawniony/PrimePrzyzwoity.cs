using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrimePrzyzwoity
{
    class Program
    {
        public static int repeat = 10;
        public static ulong counter;
        public static bool IsPrimeFasterWithCounter(BigInteger Num)
        {
            counter = 0;
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
            {
                counter++;
                for (BigInteger u = 3; u * u <= Num; u += 2)
                {
                    counter++;
                    if (Num % u == 0)
                    {

                        return false;
                    }
                }

            }
            return true;
        }
        public static bool IsPrimeFaster(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u * u <= Num; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }
        static void Main(string[] args)
        {
            bool prime;
            Stopwatch sw = new Stopwatch();
            BigInteger[] tab = new BigInteger[] { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };
            Console.WriteLine("Usprawniony algorytm sprawdzania liczb pierwszych + czas");
            Console.WriteLine("liczba;prime;czas");
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < repeat + 2; ++j)//pętla powtarzająca każdy pomiar czasu 12 razy
                {
                    sw.Start();
                    prime = IsPrimeFaster(tab[i]);
                    sw.Stop();
                    Console.WriteLine(tab[i] + "; " + prime + "; " + sw.Elapsed.TotalMilliseconds);
                    sw.Reset();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Usprawniony algorytm sprawdzania liczb pierwszych z wyliczaniem modulo");
            Console.WriteLine("liczba;prime;modulo");
            for (int k = 0; k < tab.Length; k++)
            {
                Console.WriteLine(tab[k] + "; " + IsPrimeFasterWithCounter(tab[k]) + "; " + counter);
            }
        }
    }
}

