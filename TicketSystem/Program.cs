using TicketSystem.DataSeeder;
using TicketSystem.Repositories;
using TicketSystem.Services;
using TicketSystem.ConsoleUI;

var repository = new InMemoryTicketRepository();
var service = new TicketService(repository);

FakeDataSeeder.Seed(service);

var menu = new MenuService(service);
menu.Start();