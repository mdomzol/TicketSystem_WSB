namespace TicketSystem.Exceptions;

/// <summary>
/// Wyjątek domenowy systemu ticketów.
/// </summary>
/// <remarks>
/// Używany do sygnalizowania błędów związanych z operacjami
/// na zgłoszeniach, np. brak znalezionego ticketa.
/// 
/// Rozszerza klasę System.Exception, dzięki czemu może być
/// obsługiwany w standardowy sposób przez mechanizm wyjątków .NET.
/// </remarks>
public class TicketException : Exception
{
    /// <summary>
    /// Tworzy nowy wyjątek TicketException z podanym komunikatem.
    /// </summary>
    /// <param name="message">Opis błędu.</param>
    public TicketException(string message)
        : base(message)
    {
    }
}