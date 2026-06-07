using TicketSystem.Services;
using TicketSystem.ConsoleUI.Helpers;

namespace TicketSystem.ConsoleUI;

/// <summary>
/// Panel administratora systemu ticketów.
/// </summary>
/// <remarks>
/// Umożliwia przeglądanie zgłoszeń, podgląd szczegółów
/// oraz zmianę statusu istniejących ticketów.
/// 
/// Logika wyświetlania została przeniesiona do klasy TicketConsolePrinter,
/// dzięki czemu panel odpowiada wyłącznie za obsługę menu i przepływu użytkownika.
/// </remarks>
public class AdminPanel
{
    private readonly TicketService _service;

    /// <summary>
    /// Inicjalizuje panel administratora z dostępem do serwisu ticketów.
    /// </summary>
    /// <param name="service">Serwis obsługujący operacje na zgłoszeniach.</param>
    public AdminPanel(TicketService service)
    {
        _service = service;
    }

    /// <summary>
    /// Uruchamia panel administratora i obsługuje menu zarządzania zgłoszeniami.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            ConsoleHelper.Header("PANEL ADMINISTRATORA");

            Console.WriteLine("1. Lista zgloszen");
            Console.WriteLine("2. Szczegoly zgloszenia");
            Console.WriteLine("3. Zmien status zgloszenia");
            Console.WriteLine("0. Powrot\n");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TicketConsolePrinter.ShowTickets(_service);
                    break;

                case "2":
                    TicketConsolePrinter.ShowDetails(_service);
                    break;

                case "3":
                    TicketConsolePrinter.ChangeStatus(_service);
                    break;

                case "0":
                    return;
            }
        }
    }
}