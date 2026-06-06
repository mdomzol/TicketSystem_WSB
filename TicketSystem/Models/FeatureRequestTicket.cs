using System.Diagnostics.Contracts;
using TicketSystem.Enums;

namespace TicketSystem.Models;

public sealed class FeatureRequestTicket : Ticket
{
    public FeatureRequestTicket(string title, string description) : base(title, description)
    {
    }

    public override int GetEstimatedResolutionTime()
    {
        return 40;
    }
}