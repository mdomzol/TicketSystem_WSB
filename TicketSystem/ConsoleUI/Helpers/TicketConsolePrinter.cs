using TicketSystem.Enums;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.ConsoleUI.Helpers;

public static class TicketConsolePrinter
{
    public static void ShowTickets(TicketService service)
    {
        ConsoleHelper.Header("LISTA ZGŁOSZEŃ");

        Console.WriteLine("==============================================================");
        Console.WriteLine("ID | Typ       | Status      | Tytuł");
        Console.WriteLine("==============================================================");

        foreach (var t in service.GetAllTickets())
        {
            Console.WriteLine($"{t.Number} | {t.GetType().Name.Replace("Ticket", ""),-9} | {t.Status,-11} | {t.Title}");
        }

        Console.WriteLine("==============================================================");

        ConsoleHelper.Pause();
    }

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

    public static void ShowDetails(TicketService service)
    {
        ConsoleHelper.Header("SZCZEGÓŁY ZGŁOSZENIA");

        var ticket = SelectTicket(service);

        if (ticket == null)
        {
            Console.WriteLine("Nie znaleziono zgłoszenia.");
            ConsoleHelper.Pause();
            return;
        }

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

    public static void ChangeStatus(TicketService service)
    {
        ConsoleHelper.Header("ZMIANA STATUSU");

        var ticket = SelectTicket(service);

        if (ticket == null)
        {
            Console.WriteLine("Nie znaleziono zgłoszenia.");
            ConsoleHelper.Pause();
            return;
        }

        Console.WriteLine($"\nWybrano: #{ticket.Number} {ticket.Title}");
        Console.WriteLine($"Aktualny status: {ticket.Status}\n");

        Console.WriteLine("Nowy status:");
        Console.WriteLine("1. Open");
        Console.WriteLine("2. InProgress");
        Console.WriteLine("3. Resolved");
        Console.WriteLine("4. Closed");
        Console.WriteLine("5. Reopened");

        var input = Console.ReadLine();

        TicketStatus newStatus = input switch
        {
            "1" => TicketStatus.Open,
            "2" => TicketStatus.InProgress,
            "3" => TicketStatus.Resolved,
            "4" => TicketStatus.Closed,
            "5" => TicketStatus.Reopened,
            _ => ticket.Status
        };

        Console.WriteLine("\nKomentarz:");
        var comment = Console.ReadLine();

        service.ChangeTicketStatus(ticket.Id, newStatus, comment ?? "");

        Console.WriteLine("\nStatus został zmieniony.");
        ConsoleHelper.Pause();
    }
}