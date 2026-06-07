namespace TicketSystem.Enums;

/// <summary>
/// Określa priorytet zgłoszenia w systemie.
/// </summary>
/// <remarks>
/// Priorytet wpływa na ważność oraz kolejność realizacji zgłoszeń.
/// Im wyższy priorytet, tym większa pilność wykonania.
/// </remarks>
public enum TicketPriority
{
    /// <summary>
    /// Niski priorytet – zgłoszenie o niskim znaczeniu, może być realizowane w dalszej kolejności.
    /// </summary>
    Low,

    /// <summary>
    /// Średni priorytet – standardowe zgłoszenie wymagające normalnej obsługi.
    /// </summary>
    Medium,

    /// <summary>
    /// Wysoki priorytet – zgłoszenie wymagające szybkiej reakcji.
    /// </summary>
    High,

    /// <summary>
    /// Krytyczny priorytet – zgłoszenie wymagające natychmiastowej interwencji.
    /// </summary>
    Emergency
}