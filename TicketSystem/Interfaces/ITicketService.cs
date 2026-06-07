using TicketSystem.Models;
using TicketSystem.Enums;

namespace TicketSystem.Interfaces;

/// <summary>
/// Interfejs definiujący kontrakt dla serwisu obsługującego zgłoszenia (Ticket).
/// </summary>
/// <remarks>
/// Odpowiada za operacje biznesowe wykonywane na zgłoszeniach,
/// takie jak tworzenie, zmiana statusu oraz pobieranie listy ticketów.
/// 
/// Implementacja interfejsu znajduje się w klasie TicketService.
/// </remarks>
public interface ITicketService
{
    /// <summary>
    /// Tworzy nowe zgłoszenie w systemie.
    /// </summary>
    /// <param name="ticket">Obiekt zgłoszenia do zapisania.</param>
    void CreateTicket(Ticket ticket);

    /// <summary>
    /// Zmienia status istniejącego zgłoszenia.
    /// </summary>
    /// <param name="ticketId">Identyfikator zgłoszenia.</param>
    /// <param name="status">Nowy status zgłoszenia.</param>
    /// <param name="comment">Komentarz opisujący zmianę statusu.</param>
    void ChangeTicketStatus(Guid ticketId, TicketStatus status, string comment);

    /// <summary>
    /// Pobiera wszystkie zgłoszenia z systemu.
    /// </summary>
    /// <returns>Kolekcja wszystkich zgłoszeń.</returns>
    IEnumerable<Ticket> GetAllTickets();
}