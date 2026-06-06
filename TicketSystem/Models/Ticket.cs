using TicketSystem.Enums;

namespace TicketSystem.Models;

public abstract class Ticket
{
    public Guid Id { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TicketStatus Status { get; private set; }
    public TicketPriority Priority { get; protected set; }
    public DateTime CreatedAt { get; }
    public string? AssignedTo { get; private set; }
    protected Ticket(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = TicketStatus.Open;
        CreatedAt = DateTime.Now;
    }

    public void Assign(string assignee)
    {
        AssignedTo = assignee;
    }

    public void Start()
    {
        Status = TicketStatus.InProgress;
    }

    public void Close()
    {
        Status = TicketStatus.Closed;
    }

    public abstract int GetEstimatedResolutionTime();
}