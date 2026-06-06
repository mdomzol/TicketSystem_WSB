using TicketSystem.Models;

namespace TicketSystem.Interfaces;

public interface ITicketService
{
    void CreateTicket(Ticket ticket);
    void AssignTicket(Guid ticketId, string assignee);
    void CloseTicket(Guid ticketId);
    IEnumerable<Ticket> GetAllTickets();
}