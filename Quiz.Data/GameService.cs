using Quiz.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz.Data
{
    public class GameService
    {
        private Random _random;
        private List<Pytanie> _listaPytan;
        private List<int> _kategorie;
        private int _aktualnyIndeksKategorii;

        public GameService()
        {
            _random = new Random();
            UtworzListeWszystkichPytan();
            PobierzKategorie();
            AktualnaKategoria = _kategorie![_aktualnyIndeksKategorii];
        }

        public int AktualnaKategoria { get; set; }
        public Pytanie AktualnePytanie { get; set; }

        public void WylosujPytanieZAktualnejKategorii()
        {
            var pytaniaZAktualnejKategorii = _listaPytan.Where(p => p.Kategoria == AktualnaKategoria).ToList();
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
            int maksymalnyIndexKategorii = _kategorie.Count - 1;
            if (_aktualnyIndeksKategorii == maksymalnyIndexKategorii)
                return true;
            else
                return false;
        }

        public void PodniesKategorie()
        {
            _aktualnyIndeksKategorii++;
            AktualnaKategoria = _kategorie[_aktualnyIndeksKategorii];
        }


        private void UtworzListeWszystkichPytan()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\questions_pl.json";
            var text = File.ReadAllText(path);
            var jso = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _listaPytan = JsonSerializer.Deserialize<List<Pytanie>>(text, jso)!;
        }

        private void PobierzKategorie()
        {
            _kategorie = _listaPytan!.Select(p => p.Kategoria).Distinct().OrderBy(p => p).ToList();
        }

    }
}
