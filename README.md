# Dokumentacja
## Klasa Program
Metoda Main(string[] args)
To główna metoda programu. Tworzy instancję klasy GameLogic i rozpoczyna grę.

## Klasa Questions
Zawiera pytania i odpowiedzi.

### Właściwości
Text (string): treść pytań.
Options (string[]): przechowuje tablicę możliwych odpowiedzi.
CorrectAnswer (int): indeks poprawnej odpowiedzi w tablicy Options.
Metoda InitQuestion(): tworzy i zwraca tablicę obiektów Questions z zdefiniowanymi pytaniami, odpowiedziami i poprawnymi odpowiedziami.

## Klasa GameLogic
Zarządza logiką gry i interakcją z graczem.

### Właściwości
questions (Questions[]): tablica pytań
questionIndex (int): numer indeksu bieżącego pytania
score (int): aktualna ilość punktów 
actualOptionIndex (int): numer indeksu wybranej odpowiedzi
finance (int[]): progi finansowe
user (User): instancja gracza

Metody
InitQuestions(): inicjalizuje tablicę pytań.
PlayGame(): rozpoczyna grę, obsługując logikę rundy.
ShowQuestion(): wyświetla bieżące pytanie i opcje odpowiedzi.
ShowFinances(): wyświetla progi finansowe.
Answers(): obsługuje wejście od gracza, umożliwiając mu wybór odpowiedzi.
CheckAnswers(int odpowiedz): sprawdza poprawność odpowiedzi gracza.
EndGame(): kończy grę, wyświetlając wynik i gratulacje.
## Klasa User
Reprezentuje gracza.

### Właściwości
Name (string): imię gracza.
Score (int): ilość zdobytych punktów.
Date (DateTime): data i czas rozpoczęcia gry.

Metody
TypeName(): pozwala graczowi wprowadzić swoje imię.
SetScore(int score): ustawia ilość zdobytych punktów.
SaveScoreToFile(): zapisuje wynik gracza do pliku tekstowego.

# Opis Działania Programu
## Cel Gry
Celem gry jest zdobycie jak największej sumy pieniędzy poprzez udzielanie poprawnych odpowiedzi na serię pytań.

## Mechanika Gry
Pytania są zdefiniowane w klasie Questions w postaci obiektów zawierających treść pytania, możliwe odpowiedzi oraz indeks poprawnej odpowiedzi.

Gracz rozpoczyna grę, tworząc instancję klasy GameLogic. Inicjalizuje ona pytania, tworzy instancję gracza (User) i rozpoczyna grę.

Gracz odpowiedzialny jest za wybieranie poprawnych odpowiedzi, poruszając się po opcjach przy użyciu strzałek góra/dół. Naciśnięcie Enter zatwierdza odpowiedź.

Po wybraniu odpowiedzi, system sprawdza, czy jest ona poprawna. W przypadku poprawnej odpowiedzi, gracz zdobywa punkty.

Na bieżąco wyświetlane są progi finansowe, które gracz zdobywa wraz z kolejnymi poprawnymi odpowiedziami. Gra kończy się, gdy gracz udzieli wszystkich poprawnych odpowiedzi lub popełni błąd.

Po zakończeniu gry, graczowi przedstawiane są informacje o wyniku, ewentualnej wygranej i w przypadku wygranej zapisywane są one do pliku tekstowego.

Informacje o zwycięzcy, takie jak imię i data rozpoczęcia gry, zapisywane są do pliku tekstowego o nazwie "zwyciezcyMilionerow.txt".

