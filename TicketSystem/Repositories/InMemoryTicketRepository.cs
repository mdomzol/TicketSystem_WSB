using TicketSystem.Interfaces;
using TicketSystem.Models;

namespace TicketSystem.Repositories;

/// <summary>
/// Implementacja repozytorium ticketów przechowująca dane w pamięci.
/// </summary>
/// <remarks>
/// Klasa realizuje wzorzec Repository.
/// Dane przechowywane są w liście w pamięci RAM, bez użycia bazy danych.
/// Odpowiada wyłącznie za operacje CRUD na obiektach Ticket.
/// </remarks>
public class InMemoryTicketRepository : ITicketRepository
{
    /// <summary>
    /// Lokalna kolekcja przechowująca wszystkie zgłoszenia.
    /// </summary>
    private readonly List<Ticket> _tickets = [];

    /// <summary>
    /// Dodaje nowe zgłoszenie do repozytorium.
    /// </summary>
    /// <param name="ticket">Obiekt zgłoszenia do dodania.</param>
    public void Add(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    /// <summary>
    /// Pobiera zgłoszenie o podanym identyfikatorze.
    /// </summary>
    /// <param name="id">Identyfikator zgłoszenia.</param>
    /// <returns>
    /// Obiekt Ticket jeśli istnieje, w przeciwnym razie null.
    /// </returns>
    public Ticket? GetById(Guid id)
    {
        return _tickets.FirstOrDefault(t => t.Id == id);
    }

    /// <summary>
    /// Zwraca wszystkie zgłoszenia znajdujące się w repozytorium.
    /// </summary>
    /// <returns>Kolekcja wszystkich ticketów.</returns>
    public IEnumerable<Ticket> GetAll()
    {
        return _tickets;
    }

    /// <summary>
    /// Usuwa zgłoszenie o podanym identyfikatorze, jeśli istnieje.
    /// </summary>
    /// <param name="id">Identyfikator zgłoszenia do usunięcia.</param>
    public void Remove(Guid id)
    {
        var ticket = GetById(id);

        if (ticket != null)
        {
            _tickets.Remove(ticket);
        }
    }
}