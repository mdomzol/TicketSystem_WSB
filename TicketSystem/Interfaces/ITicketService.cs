using TicketSystem.Models;
using TicketSystem.Enums;

namespace TicketSystem.Interfaces;

public interface ITicketService
{
    void CreateTicket(Ticket ticket);
    void ChangeTicketStatus(Guid ticketId, TicketStatus status, string comment);
    IEnumerable<Ticket> GetAllTickets();
}