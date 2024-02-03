class GraMilionerzy
{
    private Pytanie[] pytania;
    private int obecnePytanieIndex;
    private int wynik;
    private int wybranaOpcjaIndex;
    private int[] progiFinansowe = { 1000, 10000, 100000, 250000, 500000, 1000000 };
    private Uzytkownik uzytkownik;

    public GraMilionerzy()
    {
        InicjalizujPytania();
        uzytkownik = new Uzytkownik();
    }

    private void InicjalizujPytania()
    {
        pytania = Pytanie.InicjalizujPytania();
    }

    public void RozpocznijGre()
    {
        obecnePytanieIndex = 0;
        wynik = 0;
        wybranaOpcjaIndex = 0;

        while (obecnePytanieIndex < pytania.Length)
        {
            WyswietlPytanie();
            ObslugaOdpowiedzi();
            obecnePytanieIndex++;
        }

        uzytkownik.UstawWynik(wynik);
        uzytkownik.ZapiszWynikDoPliku();
        ZakonczGre();
    }

    private void WyswietlPytanie()
    {
        Console.Clear();
        if (obecnePytanieIndex < pytania.Length)
        {
            Console.WriteLine(pytania[obecnePytanieIndex].Tresc);
            for (int i = 0; i < pytania[obecnePytanieIndex].Opcje.Length; i++)
            {
                Console.ForegroundColor = (i == wybranaOpcjaIndex) ? ConsoleColor.Black : ConsoleColor.Gray;
                Console.BackgroundColor = (i == wybranaOpcjaIndex) ? ConsoleColor.Gray : ConsoleColor.Black;
                Console.WriteLine($"{i + 1}. {pytania[obecnePytanieIndex].Opcje[i]}");
                Console.ResetColor();
            }

            Console.WriteLine();
            WyswietlProgiFinansowe();
        }
    }

    private void WyswietlProgiFinansowe()
    {
        Console.WriteLine("\nProgi finansowe:");

        for (int i = 0; i < progiFinansowe.Length; i++)
        {
            if (i == wynik)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"{progiFinansowe[i]:C}");

            Console.ResetColor();
        }
        Console.WriteLine();
    }

    private void ObslugaOdpowiedzi()
    {
        ConsoleKeyInfo klawisz;
        do
        {
            klawisz = Console.ReadKey(true);
            switch (klawisz.Key)
            {
                case ConsoleKey.UpArrow:
                    wybranaOpcjaIndex = (wybranaOpcjaIndex - 1 + pytania[obecnePytanieIndex].Opcje.Length) % pytania[obecnePytanieIndex].Opcje.Length;
                    break;
                case ConsoleKey.DownArrow:
                    wybranaOpcjaIndex = (wybranaOpcjaIndex + 1) % pytania[obecnePytanieIndex].Opcje.Length;
                    break;
                case ConsoleKey.Enter:
                    if (wybranaOpcjaIndex >= 0 && wybranaOpcjaIndex < pytania[obecnePytanieIndex].Opcje.Length)
                    {
                        SprawdzOdpowiedz(wybranaOpcjaIndex + 1);
                    }
                    else
                    {
                        Console.WriteLine("Nie wybrano odpowiedzi. Wybierz odpowiedź i naciśnij Enter.");
                    }
                    break;
            }

            WyswietlPytanie();
        } while (klawisz.Key != ConsoleKey.Enter);
    }

    private void SprawdzOdpowiedz(int odpowiedz)
    {
        if (odpowiedz == pytania[obecnePytanieIndex].PoprawnaOdpowiedz + 1)
        {
            Console.WriteLine("Poprawna odpowiedź!");
            wynik++;

            if (wynik == progiFinansowe.Length)
            {
                ZakonczGre();
            }
        }
        else
        {
            if (wynik == 0)
            {
                Console.WriteLine("Dziś nie wygrałeś niczego.");
                Environment.Exit(0);
            }
            else if (wynik < progiFinansowe.Length)
            {
                Console.WriteLine($"Błędna odpowiedź. Koniec gry. Niestety nie udało Ci się zgarnąć pełnej puli. Dziś wygrałeś {progiFinansowe[wynik - 1]:C}.");
            }
            else
            {
                Console.WriteLine("Błędna odpowiedź. Koniec gry.");
            }
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

    private void ZakonczGre()
    {
        Console.WriteLine($"Gratulacje! Ukończyłeś grę.");

        if (wynik > 0 && wynik <= progiFinansowe.Length)
        {
            Console.WriteLine($"Dziś wygrałeś {progiFinansowe[wynik - 1]:C}.");
        }
        else
        {
            Console.WriteLine("Dziękujemy za udział w grze. Może następnym razem uda Ci się zgarnąć pełną pulę!");
        }

        uzytkownik.UstawWynik(wynik);
        uzytkownik.ZapiszWynikDoPliku(); // Dodane wywołanie metody
        Console.ReadLine();
        Environment.Exit(0);
    }
}
