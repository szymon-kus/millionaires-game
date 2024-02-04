class User
{
    private string directoryPath;

    public string Name { get; private set; }
    public int Score { get; private set; }
    public DateTime Date { get; private set; }

    public User()
    {
        directoryPath = Environment.CurrentDirectory;
        TypeName();
        Date = DateTime.Now;
    }

    private void TypeName()
    {
        Console.Write("Podaj swoje imię: ");
        Name = Console.ReadLine();
    }

    public void SetScore(int score)
    {
        Score = score;
    }

    public void SaveScoreToFile()
    {
        string path = Path.Combine(directoryPath, "zwyciezcyMilionerow.txt");

        try
        {
            using (StreamWriter writer = new StreamWriter(path, true))
              
            {
                writer.WriteLine($"{Name}, {Score}, {Date.ToString("yyyy-MM-dd HH:mm:ss")}");
            }

            Console.WriteLine("Wynik został zapisany do pliku.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas zapisywania wyniku do pliku: {ex.Message}");
        }
    }
}
