using TicketSystem.Enums;

namespace TicketSystem.Models;

public abstract class Ticket
{
    private static int _counter = 1;
    public Guid Id { get; }
    public int Number { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TicketStatus Status { get; private set; }
    public TicketPriority Priority { get; protected set; }
    public DateTime CreatedAt { get; }
    public string LastActionBy { get; private set; } = "System";
    public List<TicketHistoryEntry> History { get; } = [];
    protected Ticket(string title, string description)
    {
        Id = Guid.NewGuid();
        Number = _counter++;

        Title = title;
        Description = description;
        Status = TicketStatus.Open;
        CreatedAt = DateTime.Now;

        History.Add(new TicketHistoryEntry("Zgloszenie utworzone"));
    }

    public void ChangeStatus(TicketStatus newStatus, string comment, string performedBy = "Admin")
    {
        var oldStatus = Status;

        Status = newStatus;
        LastActionBy = performedBy;

        History.Add(
            new TicketHistoryEntry(
                $"Status: {oldStatus} -> {newStatus}. " +
                $"Wykonane przez: {performedBy}. " +
                $"Komentarz: {comment}"
            )
        );
    }

    public abstract int GetEstimatedResolutionTime();
}