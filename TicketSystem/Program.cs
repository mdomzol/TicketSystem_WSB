using TicketSystem.DataSeeder;
using TicketSystem.Repositories;
using TicketSystem.Services;
using TicketSystem.ConsoleUI;

/// <summary>
/// Główna klasa startowa aplikacji.
/// Odpowiada za konfigurację zależności oraz uruchomienie systemu.
/// </summary>
/// <remarks>
/// W tym miejscu tworzona jest warstwa:
/// - repozytorium danych (InMemoryTicketRepository),
/// - serwis logiki biznesowej (TicketService),
/// - dane testowe (FakeDataSeeder),
/// - interfejs użytkownika (MenuService).
/// </remarks>
internal class Program
{
    /// <summary>
    /// Punkt wejścia aplikacji.
    /// Inicjalizuje wszystkie komponenty systemu i uruchamia menu główne.
    /// </summary>
    public static void Main(string[] args)
    {
        // Warstwa danych (repozytorium w pamięci)
        var repository = new InMemoryTicketRepository();

        // Warstwa logiki biznesowej
        var service = new TicketService(repository);

        // Dane testowe (seed)
        FakeDataSeeder.Seed(service);

        // Warstwa UI (menu główne aplikacji)
        var menu = new MenuService(service);
        menu.Start();
    }
}