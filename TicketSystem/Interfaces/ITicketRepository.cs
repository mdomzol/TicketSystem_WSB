using TicketSystem.Models;

namespace TicketSystem.Interfaces;

/// <summary>
/// Interfejs definiujący kontrakt repozytorium ticketów.
/// </summary>
/// <remarks>
/// Odpowiada za operacje dostępu do danych (warstwa persystencji),
/// niezależnie od sposobu ich przechowywania.
///
/// Może być zaimplementowany np. jako:
/// - pamięć (InMemory),
/// - baza danych,
/// - plik.
/// </remarks>
public interface ITicketRepository
{
    /// <summary>
    /// Dodaje nowe zgłoszenie do repozytorium.
    /// </summary>
    /// <param name="ticket">Obiekt zgłoszenia do zapisania.</param>
    void Add(Ticket ticket);

    /// <summary>
    /// Pobiera zgłoszenie o podanym identyfikatorze.
    /// </summary>
    /// <param name="id">Identyfikator zgłoszenia.</param>
    /// <returns>
    /// Obiekt Ticket jeśli istnieje, w przeciwnym razie null.
    /// </returns>
    Ticket? GetById(Guid id);

    /// <summary>
    /// Pobiera wszystkie zgłoszenia z repozytorium.
    /// </summary>
    /// <returns>Kolekcja wszystkich zgłoszeń.</returns>
    IEnumerable<Ticket> GetAll();

    /// <summary>
    /// Usuwa zgłoszenie o podanym identyfikatorze.
    /// </summary>
    /// <param name="id">Identyfikator zgłoszenia do usunięcia.</param>
    void Remove(Guid id);
}