using TicketSystem.Services;
using TicketSystem.ConsoleUI.Helpers;

namespace TicketSystem.ConsoleUI;

public class AdminPanel
{
    private readonly TicketService _service;

    public AdminPanel(TicketService service)
    {
        _service = service;
    }

    public void Run()
    {
        while (true)
        {
            ConsoleHelper.Header("PANEL ADMINISTRATORA");

            Console.WriteLine("1. Lista zgloszen");
            Console.WriteLine("2. Szczegoly zgloszenia");
            Console.WriteLine("3. Zmien status zgloszenia");
            Console.WriteLine("0. Powrot\n");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TicketConsolePrinter.ShowTickets(_service);
                    break;

                case "2":
                    TicketConsolePrinter.ShowDetails(_service);
                    break;

                case "3":
                    TicketConsolePrinter.ChangeStatus(_service);
                    break;

                case "0":
                    return;
            }
        }
    }
}