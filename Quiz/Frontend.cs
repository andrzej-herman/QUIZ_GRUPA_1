using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public static class Frontend
    {
        public static void PokazEkranPowitalny()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(" Witaj w Quzie Wiedzy");
            Console.WriteLine(" Spróbuj odpowiedzieć na 7 pytań");
            Console.WriteLine(" Powodzenia !!!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij ENTER, aby rozpoczać grę ... ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static int WyswietlAktualnePytanieIPobierzOdpowiedzGracza(Pytanie pytanie)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($" Pytanie za {pytanie.Kategoria} pkt.");
            Console.WriteLine();
            Console.WriteLine($" {pytanie.Tresc}");
            Console.WriteLine();
            foreach (var odpowiedz in pytanie.Odpowiedzi)
            {
                Console.WriteLine($" {odpowiedz.Numer}. {odpowiedz.Tresc}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij 1, 2, 3 lub 4, aby wybrać odpowiedź ... ");
            Console.ForegroundColor = ConsoleColor.White;
            return int.Parse(Console.ReadLine());
        }

        public static void ZakonczGre()
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($" Nietety, ale to nie jest prawidłowa odpowiedź.");
            Console.WriteLine();
            Console.WriteLine($" KONIEC GRY");
        }

        public static void DobraOdpowiedz(int kategoria)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(" Brawo, to poprawna odpowiedź !!!");
            Console.WriteLine($" Zdobywasz {kategoria} pkt.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij ENTER, zobaczyć następne pytanie ... ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
    }
}
