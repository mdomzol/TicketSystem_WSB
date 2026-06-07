using TicketSystem.Exceptions;
using TicketSystem.Interfaces;
using TicketSystem.Models;
using TicketSystem.Enums;

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

    public void ChangeTicketStatus(Guid ticketId, TicketStatus status, string comment)
    {
        var ticket = _repository.GetById(ticketId)
            ?? throw new TicketException("Nie znaleziono zgłoszenia.");

        ticket.ChangeStatus(status, comment, "Admin");
    }

    public IEnumerable<Ticket> GetAllTickets()
    {
        return _repository.GetAll();
    }
}
