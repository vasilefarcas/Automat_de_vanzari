using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_de_vanzari
{
    class Program
    {
        static void Main(string[] args)
        {
            int suma = 0;
            int pret_produs = 20;
            int[] monede = { 25, 10, 5, 1 };

            Alimentare_cu_bani(ref suma, pret_produs, monede);
            Console.ReadKey();
        }

        public static void Alimentare_cu_bani(ref int suma, int pret_produs, int[] monede)
        {
            int suma_introdusa;
            string introdus;
            while (suma < pret_produs)
            {
                Console.Clear();
                Console.WriteLine($"Suma din aparat este {suma}");
                Console.WriteLine();
                Console.WriteLine("Introduceti bani.\nMonedele acceptate sunt:");
                Afisare_monede(monede);
                introdus = Console.ReadLine();
                if (introdus == "f")
                {
                    Eliberare_rest(ref suma, monede);
                    return;
                }
                if (introdus == "r")
                    Eliberare_rest(ref suma, monede);
                else
                {
                    suma_introdusa = Convert.ToInt32(introdus);
                    while (Array.IndexOf(monede, suma_introdusa) == -1)
                    {
                        Console.WriteLine("Moneda introdusa nu este valida. Introduceti din nou.\n");
                        suma_introdusa = int.Parse(Console.ReadLine());
                    }
                    suma += suma_introdusa;
                }
            }
            if (suma >= pret_produs)
            Eliberare_produs_si_rest(ref suma, pret_produs, monede);
        }

        public static void Afisare_monede(int[] monede)
        {
            for (int i = 0; i < monede.Length; i++)
                Console.Write(monede[i] + " ");
            Console.WriteLine();
        }

        public static void Eliberare_rest(ref int suma, int[] monede)
        {
            int i = 0;
            while (suma != 0 && i <= monede.Length - 1)
            {
                while (suma - monede[i] >= 0)
                {
                    suma = suma - monede[i];
                    Console.WriteLine($"A fost eliberata o moneda de {monede[i]} centi.");
                }
                i++;
            }
            Console.WriteLine($"Suma ramasa in aparat este {suma}");
        }

        public static void Eliberare_produs_si_rest(ref int suma, int pret_produs, int[] monede)
        {
            Console.Clear();
            Console.WriteLine("A fost eliberat un produs.");
            suma -= pret_produs;
            int i = 0;
            while (suma != 0 && i <= monede.Length - 1)
            {
                while (suma - monede[i] >= 0)
                {
                    suma = suma - monede[i];
                    Console.WriteLine($"A fost eliberata o moneda de {monede[i]} centi.");
                }
                i++;
            }
            Console.WriteLine($"Suma ramasa in aparat este {suma}");
        }

    }
}

