using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        public Backend()
        {
            UtworzListeWszystkichPytan();
            AktualnaKategoria = 100;
        }


        public List<Pytanie> ListaPytan { get; set; }
        public int AktualnaKategoria { get; set; }
        public Pytanie AktualnePytanie { get; set; }

        public void UtworzListeWszystkichPytan()
        {
            ListaPytan = new List<Pytanie>();
            var p1 = new Pytanie();
            p1.Id = 1;
            p1.Kategoria = 100;
            p1.Tresc = "Jak miał na imię Einstein?";      
            p1.Odpowiedzi = new List<Odpowiedz>();
            
            var o1 = new Odpowiedz();
            o1.Numer = 1;
            o1.Tresc = "Albert";
            o1.CzyPoprawna = true;
            p1.Odpowiedzi.Add(o1);

            var o2 = new Odpowiedz();
            o2.Numer = 2;
            o2.Tresc = "Aaron";
            p1.Odpowiedzi.Add(o2);

            var o3 = new Odpowiedz();
            o3.Numer = 3;
            o3.Tresc = "Stefan";
            p1.Odpowiedzi.Add(o3);

            var o4 = new Odpowiedz();
            o4.Numer = 4;
            o4.Tresc = "Jarek";
            p1.Odpowiedzi.Add(o4);

            ListaPytan.Add(p1);


            //Pytanie p2 = new Pytanie();
            //p2.Id = 2;
            //p2.Kategoria = 200;
            //p2.Tresc = "Ile województw jest w Polsce?";
            //p2.Odpowiedz_1 = "16";
            //p2.Odpowiedz_2 = "25";
            //p2.Odpowiedz_3 = "15";
            //p2.Odpowiedz_4 = "49";
            //ListaPytan.Add(p2);
        }

        public void WylosujPytanieZAktualnejKategorii()
        {
            // zasymulujemy sobie losowanie
            AktualnePytanie = ListaPytan[0];
        }

        public bool SprawdzOdpowiedzGracza(int cyfraGracza)
        {
            //var odpowiedzGracza = AktualnePytanie.Odpowiedzi[0];
            var odpowiedzGracza = AktualnePytanie.Odpowiedzi
                .FirstOrDefault(o => o.Numer == cyfraGracza);


            if (odpowiedzGracza != null)
            {
                return odpowiedzGracza.CzyPoprawna;
            }
            else
            {
                return false;
            }

            

            // wersja z pętlą
            //bool rezultat = false;
            //foreach (var odpowiedz in AktualnePytanie.Odpowiedzi)
            //{
            //    if (odpowiedz.Numer == cyfraGracza)
            //    {
            //        rezultat = odpowiedz.CzyPoprawna;
            //        break;
            //    }
            //}

            //return rezultat;
        }
    }
}
