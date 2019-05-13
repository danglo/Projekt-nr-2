using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrimePrzyklad
{
    class Program
    {
        public static ulong counter;
        public static bool IsPrime(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }
        public static bool IsPrimeWithCounter(BigInteger Num)
        {
            counter = 0;
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
            {
                counter++;
                for (BigInteger u = 3; u < Num / 2; u += 2)
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
        static void Main(string[] args)
        {
            bool prime;
            Stopwatch sw = new Stopwatch();
            BigInteger[] tab = new BigInteger[] { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };
            Console.WriteLine("Algorytm sprawdzania liczb pierwszych z wyliczaniem modulo");
            Console.WriteLine("liczba;prime;modulo");
            for (int k = 0; k < tab.Length; k++)
            {
                Console.WriteLine(tab[k] + "; " + IsPrimeWithCounter(tab[k]) + "; " + counter);

            }
            Console.WriteLine();
            Console.WriteLine("Algorytm sprawdzania liczb pierwszych + czas");
            Console.WriteLine("liczba;prime;czas");
            for (int l = 0; l < tab.Length; l++)
            {
                sw.Start();
                prime = IsPrime(tab[l]);
                sw.Stop();
                Console.WriteLine(tab[l] + "; " + prime + "; " + sw.Elapsed.TotalMilliseconds);
                sw.Reset();
            }
        }
    }
}
