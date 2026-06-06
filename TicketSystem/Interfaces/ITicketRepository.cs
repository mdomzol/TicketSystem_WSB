using TicketSystem.Models;

namespace TicketSystem.Interfaces;

public interface ITicketRepository
{
    void Add(Ticket ticket);
    Ticket? GetById(Guid id);
    IEnumerable<Ticket> GetAll();
    void Remove(Guid id);
}