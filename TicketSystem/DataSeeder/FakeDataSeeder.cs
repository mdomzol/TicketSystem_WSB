using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.DataSeeder;

/// <summary>
/// Klasa odpowiedzialna za generowanie danych testowych (seed danych).
/// </summary>
/// <remarks>
/// Używana wyłącznie w celach demonstracyjnych i testowych.
/// Tworzy przykładowe zgłoszenia i zapisuje je w systemie
/// poprzez warstwę serwisową.
/// </remarks>
public static class FakeDataSeeder
{
    /// <summary>
    /// Wypełnia system przykładowymi zgłoszeniami testowymi.
    /// </summary>
    /// <param name="service">Serwis odpowiedzialny za zarządzanie ticketami.</param>
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