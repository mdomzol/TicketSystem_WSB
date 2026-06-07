using TicketSystem.Services;

namespace TicketSystem.ConsoleUI;

/// <summary>
/// Główne menu aplikacji konsolowej.
/// </summary>
/// <remarks>
/// Klasa odpowiada za sterowanie przepływem aplikacji
/// i umożliwia wybór pomiędzy panelem klienta i administratorem.
/// 
/// Stanowi punkt wejścia do warstwy UI.
/// </remarks>
public class MenuService
{
    private readonly TicketService _service;

    /// <summary>
    /// Inicjalizuje menu główne z dostępem do serwisu ticketów.
    /// </summary>
    /// <param name="service">Serwis obsługujący logikę biznesową zgłoszeń.</param>
    public MenuService(TicketService service)
    {
        _service = service;
    }

    /// <summary>
    /// Uruchamia główne menu aplikacji i obsługuje nawigację użytkownika.
    /// </summary>
    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n=== SYSTEM TICKETÓW ===");
            Console.WriteLine("1. Panel klienta");
            Console.WriteLine("2. Panel administratora");
            Console.WriteLine("0. Wyjście");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new ClientPanel(_service).Run();
                    break;

                case "2":
                    new AdminPanel(_service).Run();
                    break;

                case "0":
                    return;
            }
        }
    }
}