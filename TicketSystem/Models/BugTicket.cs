using TicketSystem.Enums;

namespace TicketSystem.Models;

/// <summary>
/// Reprezentuje zgłoszenie typu Bug (błąd w systemie).
/// </summary>
/// <remarks>
/// Klasa dziedziczy po Ticket i definiuje specyficzne zachowanie
/// dla zgłoszeń typu błąd.
/// 
/// Dodatkowo ustawia wysoki priorytet zgłoszenia.
/// </remarks>
public sealed class BugTicket : Ticket
{
    /// <summary>
    /// Tworzy nowe zgłoszenie typu Bug.
    /// </summary>
    /// <param name="title">Tytuł zgłoszenia.</param>
    /// <param name="description">Opis zgłoszenia.</param>
    public BugTicket(string title, string description)
        : base(title, description)
    {
        // Błędy systemowe mają najwyższy priorytet
        Priority = TicketPriority.High;
    }

    /// <summary>
    /// Zwraca szacowany czas naprawy błędu.
    /// </summary>
    /// <returns>Szacowany czas realizacji w godzinach (8h).</returns>
    public override int GetEstimatedResolutionTime()
    {
        return 8;
    }
}