namespace TicketSystem.ConsoleUI;

public static class ConsoleHelper
{
    public static void Header(string text)
    {
        Console.Clear();

        Console.WriteLine("=================================");
        Console.WriteLine($" {text}");
        Console.WriteLine("=================================\n");
    }

    public static void Pause()
    {
        Console.WriteLine("\nNaciśnij dowolny klawisz...");
        Console.ReadKey();
    }
}