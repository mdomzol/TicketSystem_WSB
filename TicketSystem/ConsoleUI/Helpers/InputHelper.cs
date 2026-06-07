namespace TicketSystem.ConsoleUI.Helpers;

/// <summary>
/// Klasa pomocnicza odpowiedzialna za walidację i obsługę wejścia użytkownika w konsoli.
/// </summary>
/// <remarks>
/// Zapewnia spójny sposób pobierania danych od użytkownika
/// oraz eliminuje powielanie logiki walidacyjnej w panelach UI.
/// </remarks>
public static class InputHelper
{
    /// <summary>
    /// Odczytuje niepustą wartość tekstową od użytkownika.
    /// </summary>
    /// <param name="prompt">Tekst wyświetlany użytkownikowi.</param>
    /// <returns>Niepusty ciąg znaków.</returns>
    public static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            ConsoleMessages.Error("Pole nie może być puste!");
        }
    }

    /// <summary>
    /// Odczytuje wybór użytkownika spośród dozwolonych wartości.
    /// </summary>
    /// <param name="prompt">Tekst wyświetlany użytkownikowi.</param>
    /// <param name="allowed">Dozwolone wartości wejściowe.</param>
    /// <returns>Poprawny wybór użytkownika.</returns>
    public static string ReadChoice(string prompt, params string[] allowed)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (allowed.Contains(input))
                return input;

            ConsoleMessages.Error("Niepoprawny wybór.");
        }
    }

    /// <summary>
    /// Odczytuje liczbę całkowitą od użytkownika.
    /// </summary>
    /// <param name="prompt">Tekst wyświetlany użytkownikowi.</param>
    /// <returns>Poprawna liczba całkowita.</returns>
    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value))
                return value;

            ConsoleMessages.Error("Wpisz poprawną liczbę.");
        }
    }
}