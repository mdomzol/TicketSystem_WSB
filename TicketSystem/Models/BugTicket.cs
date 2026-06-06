using TicketSystem.Enums;
    
namespace TicketSystem.Models;

public sealed class BugTicket : Ticket
{ 
    public BugTicket(string title, string description) : base(title, description)
    {
        Priority = TicketPriority.High;
    }

    public override int GetEstimatedResolutionTime()
    {
        return 8;
    }
}
