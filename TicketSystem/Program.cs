using TicketSystem.Models;
using TicketSystem.Repositories;
using TicketSystem.Services;

var repository = new InMemoryTicketRepository();
var service = new TicketService(repository);

var ticket = new BugTicket("Blad logowania", "Uzytkownik nie moze się zalogowac.");

service.CreateTicket(ticket);

foreach(var t in service.GetAllTickets())
{
    Console.WriteLine($"{t.Id} | {t.Title} | {t.Status}");
}