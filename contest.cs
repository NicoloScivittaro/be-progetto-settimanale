using System;
using System.Diagnostics;

namespace Contest
{
    internal class Program
    {
        /// <summary>
        /// Stampa tutti i numeri primi da <strong>2</strong> fino al numero specificato nel parametro <strong>upperBound</strong>.
        /// </summary>
        /// <param name="upperBound">Limite superiore dell'intervallo da considerare per l'estrazione dei numeri primi.</param>
        private static void Primes(int upperBound)
        {
            if (upperBound < 2) return;

            // Array booleano per marcare i numeri primi
            bool[] isPrime = new bool[upperBound + 1];
            for (int i = 2; i <= upperBound; i++)
            {
                isPrime[i] = true;
            }

            // Crivello di Eratostene L'algoritmo del Crivello di Eratostene è utilizzato per trovare tutti i numeri primi fino a upperBound.
            for (int p = 2; p * p <= upperBound; p++)
            {
                // Se isPrime[p] non è cambiato, allora è un numero primo
                if (isPrime[p])
                {
                    // Aggiorna tutti i multipli di p
                    for (int i = p * p; i <= upperBound; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            // Stampa i numeri primi
            for (int i = 2; i <= upperBound; i++)
            {
                if (isPrime[i])
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            // un cronometro
            Stopwatch sw = new Stopwatch();
            // attiva il cronometro
            sw.Start();
            // esegue il metodo da misurare
            Primes(10000);
            // ferma il cronometro
            sw.Stop();
            // stampa il tempo trascorso
            Console.WriteLine($"Execution time: {sw.ElapsedMilliseconds} ms");
        }
    }
}