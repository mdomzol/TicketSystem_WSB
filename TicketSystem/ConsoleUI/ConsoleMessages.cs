namespace TicketSystem.ConsoleUI;

/// <summary>
/// Klasa pomocnicza odpowiedzialna za wyświetlanie komunikatów w konsoli.
/// </summary>
/// <remarks>
/// Ujednolica sposób prezentacji informacji, błędów i komunikatów
/// w warstwie interfejsu użytkownika (ConsoleUI).
/// </remarks>
public static class ConsoleMessages
{
    /// <summary>
    /// Wyświetla komunikat błędu.
    /// </summary>
    /// <param name="message">Treść komunikatu błędu.</param>
    public static void Error(string message)
    {
        Console.WriteLine($"\n{message}");
    }

    /// <summary>
    /// Wyświetla komunikat sukcesu.
    /// </summary>
    /// <param name="message">Treść komunikatu sukcesu.</param>
    public static void Success(string message)
    {
        Console.WriteLine($"\n{message}");
    }

    /// <summary>
    /// Wyświetla komunikat informacyjny.
    /// </summary>
    /// <param name="message">Treść komunikatu informacyjnego.</param>
    public static void Info(string message)
    {
        Console.WriteLine($"\n{message}");
    }
}