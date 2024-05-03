
namespace src.Data
{
    public interface ITicketRepository
    {
        Ticket Create(Ticket ticket);
        Ticket GetTicketByTitle(string title);
        Ticket GetTicketById(int id);
        ICollection<Ticket> GetAllTickets();
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
    }
}