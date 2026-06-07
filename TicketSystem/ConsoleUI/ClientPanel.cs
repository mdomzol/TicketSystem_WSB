using TicketSystem.ConsoleUI.Helpers;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.ConsoleUI;

public class ClientPanel
{
    private readonly TicketService _service;

    public ClientPanel(TicketService service)
    {
        _service = service;
    }

    public void Run()
    {
        ConsoleHelper.Header("PANEL KLIENTA");

        Console.WriteLine("1. Bug");
        Console.WriteLine("2. Feature Request");
        Console.WriteLine("3. Technical Issue");
        Console.WriteLine("0. Powrót");

        var choice = InputHelper.ReadChoice(
            "Wybierz opcję: ",
            "0", "1", "2", "3"
        );

        if (choice == "0")
            return;

        var title = InputHelper.ReadNonEmpty("Tytuł: ");
        var desc = InputHelper.ReadNonEmpty("Opis: ");

        Ticket ticket = choice switch
        {
            "1" => new BugTicket(title, desc),
            "2" => new FeatureRequestTicket(title, desc),
            "3" => new TechnicalTicket(title, desc),
            _ => throw new InvalidOperationException()
        };

        _service.CreateTicket(ticket);

        ConsoleMessages.Success("Zgłoszenie utworzone!");
    }
}