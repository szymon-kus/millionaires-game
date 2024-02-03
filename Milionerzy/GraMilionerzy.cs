using System.Reflection.Metadata;

class GameLogic
{
    private Questions[] questions;
    private int questionIndex;
    private int score;
    private int actualOptionIndex;
    private int[] finance = { 1000, 10000, 100000, 250000, 500000, 1000000 };
    private User user;

    public GameLogic()
    {
        InitQuestions();
        user = new User();
    }

    private void InitQuestions()
    {
        questions = Questions.InitQuestion();
    }

    public void PlayGame()
    {
        questionIndex = 0;
        score = 0;
        actualOptionIndex= 0;

        while (questionIndex < questions.Length)
        {
            ShowQuestion();
            Answers();
            questionIndex++;
        }

        user.SetScore(score);
        user.SaveScoreToFile();
        EndGame();
    }

    private void ShowQuestion()
    {
        Console.Clear();
        if (questionIndex < questions.Length)
        {
            Console.WriteLine(questions[questionIndex].Text);
            for (int i = 0; i < questions[questionIndex].Options.Length; i++)
            {
                Console.ForegroundColor = (i == actualOptionIndex) ? ConsoleColor.Black : ConsoleColor.Gray;
                Console.BackgroundColor = (i == actualOptionIndex) ? ConsoleColor.Gray : ConsoleColor.Black;
                Console.WriteLine($"{i + 1}. {questions[questionIndex].Options[i]}");
                Console.ResetColor();
            }

            Console.WriteLine();
            ShowFinances();
        }
    }

    private void ShowFinances()
    {
        Console.WriteLine("\nProgi finansowe:");

        for (int i = 0; i < finance.Length; i++)
        {
            if (i == score)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"{finance[i]:C}");

            Console.ResetColor();
        }
        Console.WriteLine();
    }

    private void Answers()
    {
        ConsoleKeyInfo klawisz;
        do
        {
            klawisz = Console.ReadKey(true);
            switch (klawisz.Key)
            {
                case ConsoleKey.UpArrow:
                    actualOptionIndex = (actualOptionIndex - 1 + questions[questionIndex].Options.Length) % questions[questionIndex].Options.Length;
                    break;
                case ConsoleKey.DownArrow:
                    actualOptionIndex = (actualOptionIndex + 1) % questions[questionIndex].Options.Length;
                    break;
                case ConsoleKey.Enter:
                    if (actualOptionIndex >= 0 && actualOptionIndex < questions[questionIndex].Options.Length)
                    {
                        checkAnswers(actualOptionIndex + 1);
                    }
                    else
                    {
                        Console.WriteLine("Nie wybrano odpowiedzi. Wybierz odpowiedź i naciśnij Enter.");
                    }
                    break;
            }

            ShowQuestion();
        } while (klawisz.Key != ConsoleKey.Enter);
    }

    private void checkAnswers(int odpowiedz)
    {
        if (odpowiedz == questions[questionIndex].CorrectAnswer + 1)
        {
            Console.WriteLine("Poprawna odpowiedź!");
            score++;

            if (score == finance.Length)
            {
                EndGame();
            }
        }
        else
        {
            if (score == 0)
            {
                Console.WriteLine("Dziś nie wygrałeś niczego.");
                Environment.Exit(0);
            }
            else if (score < finance.Length)
            {
                Console.WriteLine($"Błędna odpowiedź. Koniec gry. Niestety nie udało Ci się zgarnąć pełnej puli. Dziś wygrałeś {finance[score - 1]:C}.");
            }
            else
            {
                Console.WriteLine("Błędna odpowiedź. Koniec gry.");
            }
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

    private void EndGame()
    {
        Console.WriteLine($"Gratulacje! Ukończyłeś grę.");

        if (score > 0 && score <= finance.Length)
        {
            Console.WriteLine($"Dziś wygrałeś {finance[score - 1]:C}.");
        }
        else
        {
            Console.WriteLine("Dziękujemy za udział w grze. Może następnym razem uda Ci się zgarnąć pełną pulę!");
        }

        user.SetScore(score);
        user.SaveScoreToFile();
        Console.ReadLine();
        Environment.Exit(0);
    }
}
