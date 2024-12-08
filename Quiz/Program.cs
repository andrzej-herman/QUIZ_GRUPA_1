using Quiz;
using Quiz.Data;


// powołanie do życia obiektu backend
var backend = new GameService();


// tworzenie listy wszystkich pytań => w konstruktorze
// ustawianie kategorii na najniższą => w konstruktorze

// wyświetlenie ekranu powitalnego
Display.PokazEkranPowitalny();

while (true)
{
    // wylosowanie pytania z aktualnej kategorii
    backend.WylosujPytanieZAktualnejKategorii();

    // wyświetlenie pytania wraz z odpowiedziami i pobranie odpowiedzi od gracza
    var odpowiedzGracza = Display.WyswietlAktualnePytanieIPobierzOdpowiedzGracza(backend.AktualnePytanie);

    // walidacja odpowiedzi gracza
    var czyDobraOdpowiedz = backend.SprawdzOdpowiedzGracza(odpowiedzGracza);
    if (czyDobraOdpowiedz)
    {
        // sprawdzenie czy ostatnie pytanie
        if (backend.CzyOstatniePytanie())
        {
            Display.UkonczonoQuiz();
            break;
        }
        else
        {
            Display.DobraOdpowiedz(backend.AktualnaKategoria);
            backend.PodniesKategorie();
        }
    }
    else
    {
        Display.ZakonczGre();
        break;
    }
}



Console.ReadLine();
