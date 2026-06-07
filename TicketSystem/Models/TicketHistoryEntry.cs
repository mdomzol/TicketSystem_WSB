namespace TicketSystem.Models;

/// <summary>
/// Reprezentuje pojedynczy wpis w historii zgłoszenia.
/// </summary>
/// <remarks>
/// Klasa służy do przechowywania informacji o zmianach
/// i zdarzeniach związanych z Ticketem (np. zmiana statusu,
/// utworzenie zgłoszenia).
///
/// Każdy wpis jest niemutowalny po utworzeniu.
/// </remarks>
public sealed class TicketHistoryEntry
{
    /// <summary>
    /// Data i godzina utworzenia wpisu historii.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// Treść wpisu opisująca zdarzenie.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Tworzy nowy wpis historii zgłoszenia.
    /// </summary>
    /// <param name="message">Opis zdarzenia, które zostało zapisane w historii.</param>
    public TicketHistoryEntry(string message)
    {
        CreatedAt = DateTime.Now;
        Message = message;
    }
}