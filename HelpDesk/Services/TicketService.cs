using Microsoft.EntityFrameworkCore;

namespace src.Data
{
    public class TicketService
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

        public void Create(Ticket ticket)
        {
            _crDB.Tickets.Add(ticket);
            _crDB.SaveChanges();
        }

        public Ticket GetTicketByTitle(string title)
        {
            Ticket ticket = _crDB.Tickets.FirstOrDefault(t => t.Title == title);
            return ticket; 
        }

        public Ticket GetTicketById(int id)
        {
            Ticket ticket = _crDB.Tickets.FirstOrDefault(t => t.Id == id);
            return ticket;
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
            ticket.Title = ticket.Title;
            ticket.Description = ticket.Description;
            ticket.Open = ticket.Open;

            _crDB.Update(ticket);
            _crDB.SaveChanges();
        }
    }
}