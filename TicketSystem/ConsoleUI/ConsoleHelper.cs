namespace TicketSystem.ConsoleUI;

/// <summary>
/// Klasa pomocnicza odpowiedzialna za formatowanie interfejsu konsolowego.
/// </summary>
/// <remarks>
/// Zapewnia spójny wygląd aplikacji poprzez ujednolicenie nagłówków
/// oraz mechanizmu zatrzymania ekranu.
/// </remarks>
public static class ConsoleHelper
{
    /// <summary>
    /// Wyświetla nagłówek sekcji w konsoli i czyści ekran.
    /// </summary>
    /// <param name="text">Tekst nagłówka do wyświetlenia.</param>
    public static void Header(string text)
    {
        Console.Clear();

        Console.WriteLine("=================================");
        Console.WriteLine($" {text}");
        Console.WriteLine("=================================\n");
    }

    /// <summary>
    /// Zatrzymuje wykonanie programu do momentu naciśnięcia klawisza.
    /// </summary>
    public static void Pause()
    {
        Console.WriteLine("\nNaciśnij dowolny klawisz...");
        Console.ReadKey();
    }
}