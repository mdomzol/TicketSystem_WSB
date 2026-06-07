using TicketSystem.Enums;

namespace TicketSystem.Models;

/// <summary>
/// Abstrakcyjna klasa bazowa reprezentująca zgłoszenie (Ticket) w systemie.
/// </summary>
/// <remarks>
/// Klasa definiuje wspólne właściwości i zachowania wszystkich typów zgłoszeń.
/// Stanowi podstawę dla klas dziedziczących takich jak BugTicket,
/// FeatureRequestTicket czy TechnicalTicket.
///
/// Zawiera mechanizmy:
/// - zarządzania statusem zgłoszenia,
/// - historii zmian,
/// - identyfikacji zgłoszeń (GUID + numer),
/// - śledzenia ostatniej akcji.
/// </remarks>
public abstract class Ticket
{
    /// <summary>
    /// Licznik używany do nadawania unikalnych numerów zgłoszeń.
    /// </summary>
    private static int _counter = 1;

    /// <summary>
    /// Unikalny identyfikator zgłoszenia (GUID).
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Czytelny numer zgłoszenia używany w interfejsie użytkownika.
    /// </summary>
    public int Number { get; }

    /// <summary>
    /// Tytuł zgłoszenia.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Szczegółowy opis zgłoszenia.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Aktualny status zgłoszenia.
    /// </summary>
    public TicketStatus Status { get; private set; }

    /// <summary>
    /// Priorytet zgłoszenia (ustalany przez klasy pochodne).
    /// </summary>
    public TicketPriority Priority { get; protected set; }

    /// <summary>
    /// Data utworzenia zgłoszenia.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// Informacja o ostatniej wykonanej akcji na zgłoszeniu.
    /// </summary>
    public string LastActionBy { get; private set; } = "System";

    /// <summary>
    /// Historia zmian i zdarzeń związanych ze zgłoszeniem.
    /// </summary>
    public List<TicketHistoryEntry> History { get; } = [];

    /// <summary>
    /// Konstruktor klasy bazowej Ticket.
    /// Inicjalizuje podstawowe dane zgłoszenia oraz zapisuje wpis w historii.
    /// </summary>
    /// <param name="title">Tytuł zgłoszenia.</param>
    /// <param name="description">Opis zgłoszenia.</param>
    protected Ticket(string title, string description)
    {
        Id = Guid.NewGuid();
        Number = _counter++;

        Title = title;
        Description = description;
        Status = TicketStatus.Nowe;
        CreatedAt = DateTime.Now;

        History.Add(new TicketHistoryEntry("Zgłoszenie utworzone"));
    }

    /// <summary>
    /// Zmienia status zgłoszenia i zapisuje tę operację w historii.
    /// </summary>
    /// <param name="newStatus">Nowy status zgłoszenia.</param>
    /// <param name="comment">Komentarz opisujący zmianę.</param>
    /// <param name="performedBy">Osoba/system wykonujący zmianę.</param>
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

    /// <summary>
    /// Zwraca szacowany czas realizacji zgłoszenia.
    /// Implementacja zależy od konkretnego typu zgłoszenia.
    /// </summary>
    /// <returns>Szacowany czas realizacji w godzinach.</returns>
    public abstract int GetEstimatedResolutionTime();
}