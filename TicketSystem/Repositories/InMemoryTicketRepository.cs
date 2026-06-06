using TicketSystem.Interfaces;
using TicketSystem.Models;

namespace TicketSystem.Repositories;

public class InMemoryTicketRepository : ITicketRepository
{
    private readonly List<Ticket> _tickets = [];

    public void Add(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public Ticket? GetById(Guid id)
    {
        return _tickets.FirstOrDefault(t => t.Id == id);
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _tickets;
    }

    public void Remove(Guid id)
    {
        var ticket = GetById(id);

        if(ticket != null)
        {
            _tickets.Remove(ticket);
        }
    }
}