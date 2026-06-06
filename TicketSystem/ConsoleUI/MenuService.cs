using TicketSystem.Services;

namespace TicketSystem.ConsoleUI;

public class MenuService
{
    private readonly TicketService _service;

    public MenuService(TicketService service)
    {
        _service = service;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n=== SYSTEM TICKETÓW ===");
            Console.WriteLine("1. Panel klienta");
            Console.WriteLine("2. Panel administratora");
            Console.WriteLine("0. Wyjście");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new ClientPanel(_service).Run();
                    break;

                case "2":
                    new AdminPanel(_service).Run();
                    break;

                case "0":
                    return;
            }
        }
    }
}