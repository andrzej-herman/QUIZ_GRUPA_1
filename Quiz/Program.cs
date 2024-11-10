using Quiz;

Test.Testuj();

// powołanie do życia obiektu backend
var backend = new Backend();


// tworzenie listy wszystkich pytań => w konstruktorze
// ustawianie kategorii na najniższą => w konstruktorze

// wyświetlenie ekranu powitalnego
Frontend.PokazEkranPowitalny();


// wylosowanie pytania z aktualnej kategorii
backend.WylosujPytanieZAktualnejKategorii();

// wyświetlenie pytania wraz z odpowiedziami i pobranie odpowiedzi od gracza
var odpowiedzGracza = Frontend.WyswietlAktualnePytanieIPobierzOdpowiedzGracza(backend.AktualnePytanie);

var czyDobraOdpowiedz = backend.SprawdzOdpowiedzGracza(odpowiedzGracza);
if (czyDobraOdpowiedz)
{
    Frontend.DobraOdpowiedz(backend.AktualnaKategoria);
}
else
{
    Frontend.ZakonczGre();
}



Console.WriteLine();



// walidacja odpowiedzi gracza (czy dobra czy zła)

Console.ReadLine();
