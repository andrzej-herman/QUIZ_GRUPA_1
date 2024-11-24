using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        Random _random;

        public Backend()
        {   
            _random = new Random();
            UtworzListeWszystkichPytan();
            Kategorie = ListaPytan!.Select(p => p.Kategoria).Distinct().OrderBy(p => p).ToList();
            AktualnaKategoria = Kategorie[AktualnyIndeksKategorii];
        }

        public int AktualnyIndeksKategorii { get; set; }
        public List<int> Kategorie { get; set; }
        public List<Pytanie> ListaPytan { get; set; }
        public int AktualnaKategoria { get; set; }
        public Pytanie AktualnePytanie { get; set; }

        public void UtworzListeWszystkichPytan()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\questions_pl.json";
            var text = File.ReadAllText(path);
            var jso = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            ListaPytan = JsonSerializer.Deserialize<List<Pytanie>>(text, jso)!;
        }

        public void WylosujPytanieZAktualnejKategorii()
        {
            var pytaniaZAktualnejKategorii = ListaPytan.Where(p => p.Kategoria == AktualnaKategoria).ToList();
            var index = _random.Next(0, pytaniaZAktualnejKategorii.Count);
            var wylosowaniePytanie = pytaniaZAktualnejKategorii[index];
            wylosowaniePytanie.Odpowiedzi = wylosowaniePytanie.Odpowiedzi.OrderBy(o => _random.Next()).ToList();

            int id = 1;
            foreach (var odpowiedz in wylosowaniePytanie.Odpowiedzi)
            {
                odpowiedz.Id = id;
                id++;
            }
            AktualnePytanie = wylosowaniePytanie;
        }

        public bool SprawdzOdpowiedzGracza(int cyfraGracza)
        {
            var odpowiedzGracza = AktualnePytanie.Odpowiedzi
                .FirstOrDefault(o => o.Id == cyfraGracza);


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



        public bool CzyOstatniePytanie()
        {
            int maksymalnyIndexKategorii = Kategorie.Count - 1;
            if (AktualnyIndeksKategorii == maksymalnyIndexKategorii)
                return true;
            else
                return false;
        }


        public void PodniesKategorie()
        {
            AktualnyIndeksKategorii++;
            AktualnaKategoria = Kategorie[AktualnyIndeksKategorii];
        }
    }
}
