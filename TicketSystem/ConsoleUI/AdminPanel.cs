using TicketSystem.Services;

namespace TicketSystem.ConsoleUI;

public class AdminPanel
{
    private readonly TicketService _service;

    public AdminPanel(TicketService service)
    {
        _service = service;
    }

    public void Run()
    {
        Console.WriteLine("\n=== PANEL ADMINA ===");

        var tickets = _service.GetAllTickets();

        foreach (var t in tickets)
        {
            Console.WriteLine($"{t.Id} | {t.Title} | {t.Status}");
        }

        Console.WriteLine("\n(rozszerzymy: zmiana statusu, assign, szczegóły)");
        Console.ReadLine();
    }
}