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
        Console.WriteLine("\n=== PANEL KLIENTA ===");

        Console.WriteLine("1. Bug");
        Console.WriteLine("2. Feature Request");
        Console.WriteLine("3. Technical Issue");
        Console.WriteLine("0. Powrót");

        var choice = Console.ReadLine();
        if (choice == "0") return;

        Console.Write("Tytuł: ");
        var title = Console.ReadLine();

        Console.Write("Opis: ");
        var desc = Console.ReadLine();

        Ticket ticket = choice switch
        {
            "1" => new BugTicket(title!, desc!),
            "2" => new FeatureRequestTicket(title!, desc!),
            "3" => new TechnicalTicket(title!, desc!),
            _ => null
        };

        if (ticket != null)
        {
            _service.CreateTicket(ticket);
            Console.WriteLine("Zgłoszenie utworzone!");
        }
    }
}