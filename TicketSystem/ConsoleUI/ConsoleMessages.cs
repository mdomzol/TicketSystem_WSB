namespace TicketSystem.ConsoleUI;

public static class ConsoleMessages
{
    public static void Error(string message)
    {
        Console.WriteLine($"\n{message}");
    }

    public static void Success(string message)
    {
        Console.WriteLine($"\n{message}");
    }

    public static void Info(string message)
    {
        Console.WriteLine($"\n{message}");
    }
}