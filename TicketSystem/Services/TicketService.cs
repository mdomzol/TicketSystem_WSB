using TicketSystem.Exceptions;
using TicketSystem.Interfaces;
using TicketSystem.Models;
using TicketSystem.Enums;

namespace TicketSystem.Services;

/// <summary>
/// Warstwa logiki biznesowej systemu ticketów.
/// Odpowiada za operacje na zgłoszeniach, takie jak tworzenie,
/// zmiana statusu oraz pobieranie listy ticketów.
/// </summary>
/// <remarks>
/// Klasa działa jako pośrednik pomiędzy warstwą UI a repozytorium danych.
/// Nie przechowuje danych bezpośrednio — deleguje operacje do ITicketRepository.
/// </remarks>
public class TicketService : ITicketService
{
    private readonly ITicketRepository _repository;

    /// <summary>
    /// Inicjalizuje serwis ticketów z przekazanym repozytorium danych.
    /// </summary>
    /// <param name="repository">Implementacja repozytorium ticketów.</param>
    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Tworzy nowe zgłoszenie i zapisuje je w repozytorium.
    /// </summary>
    /// <param name="ticket">Obiekt zgłoszenia do zapisania.</param>
    public void CreateTicket(Ticket ticket)
    {
        _repository.Add(ticket);
    }

    /// <summary>
    /// Zmienia status istniejącego zgłoszenia.
    /// </summary>
    /// <param name="ticketId">Identyfikator zgłoszenia.</param>
    /// <param name="status">Nowy status zgłoszenia.</param>
    /// <param name="comment">Komentarz opisujący zmianę statusu.</param>
    /// <exception cref="TicketException">
    /// Rzucany gdy zgłoszenie o podanym identyfikatorze nie istnieje.
    /// </exception>
    public void ChangeTicketStatus(Guid ticketId, TicketStatus status, string comment)
    {
        var ticket = _repository.GetById(ticketId)
            ?? throw new TicketException("Nie znaleziono zgłoszenia.");

        ticket.ChangeStatus(status, comment, "Admin");
    }

    /// <summary>
    /// Zwraca wszystkie zgłoszenia znajdujące się w systemie.
    /// </summary>
    /// <returns>Kolekcja wszystkich ticketów.</returns>
    public IEnumerable<Ticket> GetAllTickets()
    {
        return _repository.GetAll();
    }
}