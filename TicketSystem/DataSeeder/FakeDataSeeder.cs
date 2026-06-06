using System.ComponentModel.DataAnnotations;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.DataSeeder;

public static class FakeDataSeeder
{
    public static void Seed(TicketService service)
    {
        var tickets = new List<Ticket>
        {
            new BugTicket("Blad logowania", "System crashuje po wpisaniu hasla"),
            new FeatureRequestTicket("Tryb ciemny", "Dodanie dark mode"),
            new TechnicalTicket("Wolne dzialanie", "Aplikacja laguje przy duzej liczbie ticketow")
        };

        foreach (var ticket in tickets)
        {
            service.CreateTicket(ticket);
        }
    }
}