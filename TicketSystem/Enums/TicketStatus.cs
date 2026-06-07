namespace TicketSystem.Enums;

/// <summary>
/// Określa status zgłoszenia w systemie.
/// </summary>
/// <remarks>
/// Statusy definiują aktualny etap życia zgłoszenia od momentu utworzenia
/// aż do jego zamknięcia lub ponownego otwarcia.
/// </remarks>
public enum TicketStatus
{
    /// <summary>
    /// Nowo utworzone zgłoszenie oczekujące na rozpoczęcie realizacji.
    /// </summary>
    Nowe,

    /// <summary>
    /// Zgłoszenie jest aktualnie w trakcie realizacji.
    /// </summary>
    Realizacja,

    /// <summary>
    /// Zgłoszenie zostało zamknięte i uznane za zakończone.
    /// </summary>
    Zamknięte,

    /// <summary>
    /// Zgłoszenie zostało ponownie otwarte po wcześniejszym zamknięciu.
    /// </summary>
    Otwarty_Ponownie
}