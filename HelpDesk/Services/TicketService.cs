using Microsoft.EntityFrameworkCore;

namespace src.Data
{
    public class TicketService : ITicketRepository
    {
        private readonly CrDB _crDB;

        public TicketService(CrDB crdb)
        {
            _crDB = crdb;
        }

        public ICollection<Ticket> GetAllTickets()
        {
            var nRegisters = 10;
            var nPages = 1;
            return _crDB.Tickets.AsNoTracking().Skip(nRegisters * nPages - 1).Take(nRegisters).ToList();
        }

        public Ticket Create(Ticket ticket)
        {
            _crDB.Tickets.Add(ticket);
            _crDB.SaveChanges();
            return ticket;
        }

        public Ticket GetTicketByTitle(string title)
        {
            return _crDB.Tickets.FirstOrDefault(t => t.Title == title);
        }

        public Ticket GetTicketById(int id)
        {
            return _crDB.Tickets.FirstOrDefault(t => t.Id == id);
        }

        public void DeleteTicket(int id)
        {
            var ticket = _crDB.Tickets.Find(id);
            if (ticket != null)
            {
                _crDB.Remove(ticket);
                _crDB.SaveChanges();
            }
        }

        public void UpdateTicket(Ticket ticket)
        {
            _crDB.Entry(ticket).State = EntityState.Modified;
            _crDB.SaveChanges();
        }
    }
}