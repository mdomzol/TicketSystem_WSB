using TicketSystem.Enums;

namespace TicketSystem.Models;

public sealed class TechnicalTicket : Ticket
{
    public TechnicalTicket(string title, string description) : base(title, description)
    {
    }
    public override int GetEstimatedResolutionTime()
    {
        return 16;
    }
}