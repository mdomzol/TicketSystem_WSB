using TicketSystem.Enums;

namespace TicketSystem.Models;

/// <summary>
/// Reprezentuje zgłoszenie techniczne (Technical Issue).
/// </summary>
/// <remarks>
/// Klasa dziedziczy po klasie bazowej Ticket i definiuje
/// specyficzne zachowanie dla zgłoszeń technicznych,
/// w tym szacowany czas realizacji.
/// </remarks>
public sealed class TechnicalTicket : Ticket
{
    /// <summary>
    /// Tworzy nowe zgłoszenie techniczne.
    /// </summary>
    /// <param name="title">Tytuł zgłoszenia.</param>
    /// <param name="description">Opis zgłoszenia.</param>
    public TechnicalTicket(string title, string description)
        : base(title, description)
    {
    }

    /// <summary>
    /// Zwraca szacowany czas realizacji zgłoszenia technicznego.
    /// </summary>
    /// <returns>Szacowany czas realizacji w godzinach (16h).</returns>
    public override int GetEstimatedResolutionTime()
    {
        return 16;
    }
}