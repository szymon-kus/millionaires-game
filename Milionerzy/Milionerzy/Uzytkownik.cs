class Uzytkownik
{
    private string directoryPath;

    public string Imie { get; private set; }
    public int Wynik { get; private set; }
    public DateTime Data { get; private set; }

    public Uzytkownik()
    {
        directoryPath = Environment.CurrentDirectory;
        WprowadzImie();
        Data = DateTime.Now;
    }

    private void WprowadzImie()
    {
        Console.Write("Podaj swoje imię: ");
        Imie = Console.ReadLine();
    }

    public void UstawWynik(int wynik)
    {
        Wynik = wynik;
    }

    public void ZapiszWynikDoPliku()
    {
        string sciezka = Path.Combine(directoryPath, "zwyciezcyMilionerow.txt");

        try
        {
            using (StreamWriter writer = new StreamWriter(sciezka, true))
              
            {
                writer.WriteLine($"{Imie}, {Wynik}, {Data.ToString("yyyy-MM-dd HH:mm:ss")}");
            }

            Console.WriteLine("Wynik został zapisany do pliku.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas zapisywania wyniku do pliku: {ex.Message}");
        }
    }
}