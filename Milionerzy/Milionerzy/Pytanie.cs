class Pytanie
{
    public string Tresc { get; set; }
    public string[] Opcje { get; set; }
    public int PoprawnaOdpowiedz { get; set; }

    public static Pytanie[] InicjalizujPytania()
    {
        return new Pytanie[]
        {
                    new Pytanie
                    {
                        Tresc = "Jaki jest kolor nieba?",
                        Opcje = new string[] { "Czerwony", "Niebieski", "Zielony", "Żółty" },
                        PoprawnaOdpowiedz = 1
                    },
                    new Pytanie
                    {
                        Tresc = "Ile kontynentów jest na ziemi?",
                        Opcje = new string[] { "4", "6", "7", "10" },
                        PoprawnaOdpowiedz = 2
                    },
                    new Pytanie
                    {
                        Tresc = "Czym jest marchewka?",
                        Opcje = new string[] { "Warzywem", "Owocem", "Pieczywem", "Słodyczem" },
                        PoprawnaOdpowiedz = 0
                    },
                    new Pytanie
                    {
                        Tresc = "W jakim języku napisany jest ten kod?",
                        Opcje = new string[] { "Java", "JavaScript", "C++", "C#" },
                        PoprawnaOdpowiedz = 3
                    },
                    new Pytanie
                    {
                        Tresc = "W C#, do czego służy słowo kluczowe var?",
                        Opcje = new string[] { "Deklaracja zmiennych", "Tworzenie obiektów", "Wywoływanie funkcji", "Obsługa błędów" },
                        PoprawnaOdpowiedz = 0
                    },
                    new Pytanie
                    {
                        Tresc = "Na jaki przedmiot został tworzony ten projekt?",
                        Opcje = new string[] { "Podstawy programowania obiektowego", "Systemy operacyjne", "Sieci", "AI" },
                        PoprawnaOdpowiedz = 0
                    },
        };
    }
}