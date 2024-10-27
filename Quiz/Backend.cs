using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        public List<Pytanie> ListaPytan { get; set; }

        public void UtworzListeWszystkichPytan()
        {
            ListaPytan = new List<Pytanie>();
            var p1 = new Pytanie();
            p1.Id = 1;
            p1.Kategoria = 100;
            p1.Tresc = "Jak miał na imię Einstein?";
            p1.Odpowiedz_1 = "Albert";
            p1.Odpowiedz_2 = "Tomek";
            p1.Odpowiedz_3 = "Zenek";
            p1.Odpowiedz_4 = "Jarek";
            ListaPytan.Add(p1);


            Pytanie p2 = new Pytanie();
            p2.Id = 2;
            p2.Kategoria = 200;
            p2.Tresc = "Ile województw jest w Polsce?";
            p2.Odpowiedz_1 = "16";
            p2.Odpowiedz_2 = "25";
            p2.Odpowiedz_3 = "15";
            p2.Odpowiedz_4 = "49";
            ListaPytan.Add(p2);
        }

    }
}
