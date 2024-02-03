class Questions
{
    public string Text { get; set; }
    public string[] Options { get; set; }
    public int CorrectAnswer { get; set; }

    public static Questions[] InitQuestion()
    {
        return new Questions[]
        {
                    new Questions
                    {
                        Text = "Jaki jest kolor nieba?",
                        Options = new string[] { "Czerwony", "Niebieski", "Zielony", "Żółty" },
                        CorrectAnswer = 1
                    },
                    new Questions
                    {
                        Text = "Ile kontynentów jest na ziemi?",
                        Options = new string[] { "4", "6", "7", "10" },
                        CorrectAnswer = 2
                    },
                    new Questions
                    {
                        Text = "Czym jest marchewka?",
                        Options = new string[] { "Warzywem", "Owocem", "Pieczywem", "Słodyczem" },
                        CorrectAnswer = 0
                    },
                    new Questions
                    {
                        Text = "W jakim języku napisany jest ten kod?",
                        Options = new string[] { "Java", "JavaScript", "C++", "C#" },
                        CorrectAnswer = 3
                    },
                    new Questions
                    {
                        Text = "W C#, do czego służy słowo kluczowe var?",
                        Options = new string[] { "Deklaracja zmiennych", "Tworzenie obiektów", "Wywoływanie funkcji", "Obsługa błędów" },
                        CorrectAnswer = 0
                    },
                    new Questions
                    {
                        Text = "Na jaki przedmiot został tworzony ten projekt?",
                        Options = new string[] { "Podstawy programowania obiektowego", "Systemy operacyjne", "Sieci", "AI" },
                        CorrectAnswer = 0
                    },
        };
    }
}