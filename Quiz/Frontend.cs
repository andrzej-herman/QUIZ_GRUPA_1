using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public static class Frontend
    {
        private static List<string> akceptowaleKlawisze = ["1", "2", "3", "4"];

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
            var odpowiedzGracza = WyswietlPytanie(pytanie);
            while (!akceptowaleKlawisze.Contains(odpowiedzGracza))
            {
                odpowiedzGracza = WyswietlPytanie(pytanie);
            }

            return int.Parse(odpowiedzGracza);
        }

        public static void UkonczonoQuiz()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Brawo, to prawidłowa odpowiedź");
            Console.WriteLine();
            Console.WriteLine(" Udało Ci się ukończyć cały quiz.");
            Console.WriteLine();
            Console.WriteLine(" GRATULACJE !!!");
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

        private static string WyswietlPytanie(Pytanie pytanie)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($" Pytanie za {pytanie.Kategoria} pkt.");
            Console.WriteLine();
            Console.WriteLine($" {pytanie.Tresc}");
            Console.WriteLine();
            foreach (var odpowiedz in pytanie.Odpowiedzi)
            {
                Console.WriteLine($" {odpowiedz.Id}. {odpowiedz.Tresc}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij 1, 2, 3 lub 4, aby wybrać odpowiedź ... ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
    }
}
