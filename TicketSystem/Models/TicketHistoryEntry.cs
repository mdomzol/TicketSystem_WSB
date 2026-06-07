namespace TicketSystem.Models;

public sealed class TicketHistoryEntry
{
    public DateTime CreatedAt { get; }
    public string Message { get; }

    public TicketHistoryEntry(string message)
    {
        CreatedAt = DateTime.Now;
        Message = message;
    }
}