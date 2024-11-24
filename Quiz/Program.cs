using Quiz;

Test.Testuj();

// powołanie do życia obiektu backend
var backend = new Backend();


// tworzenie listy wszystkich pytań => w konstruktorze
// ustawianie kategorii na najniższą => w konstruktorze

// wyświetlenie ekranu powitalnego
Frontend.PokazEkranPowitalny();

while (true)
{
    // wylosowanie pytania z aktualnej kategorii
    backend.WylosujPytanieZAktualnejKategorii();

    // wyświetlenie pytania wraz z odpowiedziami i pobranie odpowiedzi od gracza
    var odpowiedzGracza = Frontend.WyswietlAktualnePytanieIPobierzOdpowiedzGracza(backend.AktualnePytanie);

    // walidacja odpowiedzi gracza
    var czyDobraOdpowiedz = backend.SprawdzOdpowiedzGracza(odpowiedzGracza);
    if (czyDobraOdpowiedz)
    {
        // sprawdzenie czy ostatnie pytanie
        if (backend.CzyOstatniePytanie())
        {
            Frontend.UkonczonoQuiz();
            break;
        }
        else
        {
            Frontend.DobraOdpowiedz(backend.AktualnaKategoria);
            backend.PodniesKategorie();
        }
    }
    else
    {
        Frontend.ZakonczGre();
        break;
    }
}



Console.ReadLine();
