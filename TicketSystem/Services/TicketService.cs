using System.Security.Cryptography.X509Certificates;
using TicketSystem.Exceptions;
using TicketSystem.Interfaces;
using TicketSystem.Models;

namespace TicketSystem.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _repository;

    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }
    public void CreateTicket(Ticket ticket)
    {
        _repository.Add(ticket);
    }

    public void AssignTicket(Guid ticketId, string assignee)
    {
        var ticket = _repository.GetById(ticketId) ?? throw new TicketException("Nie znaleziono takiego ticketa.");

        ticket.Assign(assignee);
    }

    public void CloseTicket(Guid ticketId)
    {
        var ticket = _repository.GetById(ticketId) ?? throw new TicketException("Nie znaleiono takiego ticketa.");

        ticket.Close();
    }

    public IEnumerable<Ticket> GetAllTickets()
    {
        return _repository.GetAll();
    }
}
