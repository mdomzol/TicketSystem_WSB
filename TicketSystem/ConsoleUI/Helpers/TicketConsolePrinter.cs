using TicketSystem.Enums;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.ConsoleUI.Helpers;

/// <summary>
/// Klasa pomocnicza odpowiedzialna za wyświetlanie i obsługę zgłoszeń w konsoli.
/// </summary>
/// <remarks>
/// Zawiera logikę prezentacji danych oraz interakcji użytkownika
/// związanych z wyborem, podglądem i zmianą statusu ticketów.
/// 
/// Klasa stanowi warstwę UI Helper i współpracuje z TicketService.
/// </remarks>
public static class TicketConsolePrinter
{
    /// <summary>
    /// Wyświetla listę wszystkich zgłoszeń w systemie.
    /// </summary>
    /// <param name="service">Serwis obsługujący zgłoszenia.</param>
    public static void ShowTickets(TicketService service)
    {
        ConsoleHelper.Header("LISTA ZGŁOSZEŃ");

        Console.WriteLine("==============================================================");
        Console.WriteLine("ID | Typ       | Status      | Tytuł");
        Console.WriteLine("==============================================================");

        foreach (var t in service.GetAllTickets())
        {
            Console.WriteLine(
                $"{t.Number} | {t.GetType().Name.Replace("Ticket", ""),-9} | {t.Priority,-11} | {t.Status,-11} | {t.Title}"
            );
        }

        Console.WriteLine("==============================================================");

        ConsoleHelper.Pause();
    }

    /// <summary>
    /// Pozwala użytkownikowi wybrać zgłoszenie na podstawie numeru.
    /// </summary>
    /// <param name="service">Serwis obsługujący zgłoszenia.</param>
    /// <returns>Wybrane zgłoszenie Ticket.</returns>
    public static Ticket SelectTicket(TicketService service)
    {
        while (true)
        {
            ShowTickets(service);

            Console.Write("\nPodaj numer zgłoszenia: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Błędny format. Wpisz liczbę.");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey();
                continue;
            }

            var ticket = service.GetAllTickets()
                .FirstOrDefault(t => t.Number == number);

            if (ticket == null)
            {
                Console.WriteLine("Nie znaleziono zgłoszenia o takim numerze.");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey();
                continue;
            }

            return ticket;
        }
    }

    /// <summary>
    /// Wyświetla szczegóły wybranego zgłoszenia wraz z historią zmian.
    /// </summary>
    /// <param name="service">Serwis obsługujący zgłoszenia.</param>
    public static void ShowDetails(TicketService service)
    {
        ConsoleHelper.Header("SZCZEGÓŁY ZGŁOSZENIA");

        var ticket = SelectTicket(service);

        Console.WriteLine($"Ticket #{ticket.Number}");
        Console.WriteLine($"Typ: {ticket.GetType().Name}");
        Console.WriteLine($"Tytuł: {ticket.Title}");
        Console.WriteLine($"Opis: {ticket.Description}");
        Console.WriteLine($"Status: {ticket.Status}\n");

        Console.WriteLine("HISTORIA:");
        Console.WriteLine("---------------------------------");

        foreach (var h in ticket.History)
        {
            Console.WriteLine($"{h.CreatedAt}");
            Console.WriteLine($"{h.Message}\n");
        }

        ConsoleHelper.Pause();
    }

    /// <summary>
    /// Umożliwia zmianę statusu zgłoszenia wraz z dodaniem komentarza.
    /// </summary>
    /// <param name="service">Serwis obsługujący zgłoszenia.</param>
    public static void ChangeStatus(TicketService service)
    {
        ConsoleHelper.Header("ZMIANA STATUSU");

        var ticket = SelectTicket(service);

        Console.WriteLine($"\nWybrano: #{ticket.Number} {ticket.Title}");
        Console.WriteLine($"Aktualny status: {ticket.Status}\n");

        Console.WriteLine("Nowy status:");
        Console.WriteLine("1. Nowe");
        Console.WriteLine("2. Realizacja");
        Console.WriteLine("3. Zamknięte");
        Console.WriteLine("4. Otwarty Ponownie");

        var input = Console.ReadLine();

        TicketStatus newStatus = input switch
        {
            "1" => TicketStatus.Nowe,
            "2" => TicketStatus.Realizacja,
            "3" => TicketStatus.Zamknięte,
            "4" => TicketStatus.Otwarty_Ponownie,
            _ => ticket.Status
        };

        Console.WriteLine("\nKomentarz:");
        var comment = Console.ReadLine();

        service.ChangeTicketStatus(ticket.Id, newStatus, comment ?? "");

        Console.WriteLine("\nStatus został zmieniony.");
        ConsoleHelper.Pause();
    }
}