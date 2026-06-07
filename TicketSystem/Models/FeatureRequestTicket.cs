using TicketSystem.Enums;

namespace TicketSystem.Models;

/// <summary>
/// Reprezentuje zgłoszenie typu Feature Request (prośba o nową funkcjonalność).
/// </summary>
/// <remarks>
/// Klasa dziedziczy po Ticket i definiuje specyficzne zachowanie
/// dla zgłoszeń dotyczących nowych funkcjonalności systemu.
/// </remarks>
public sealed class FeatureRequestTicket : Ticket
{
    /// <summary>
    /// Tworzy nowe zgłoszenie typu Feature Request.
    /// </summary>
    /// <param name="title">Tytuł zgłoszenia.</param>
    /// <param name="description">Opis zgłoszenia.</param>
    public FeatureRequestTicket(string title, string description)
        : base(title, description)
    {
    }

    /// <summary>
    /// Zwraca szacowany czas realizacji zgłoszenia typu Feature Request.
    /// </summary>
    /// <returns>Szacowany czas realizacji w godzinach (40h).</returns>
    public override int GetEstimatedResolutionTime()
    {
        return 40;
    }
}