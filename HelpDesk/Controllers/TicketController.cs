using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Data;

namespace src.Controller
{
    [ApiController]
    [Route("api/[controller]")]	
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;
        private readonly CrDB _crDB;

        public TicketController(TicketService ticketService, CrDB crDB)
        {
            _ticketService = ticketService;
            _crDB = crDB;
        }   

        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTickets()
        {
            IEnumerable<Ticket> tickets = _ticketService.GetAllTickets();
            if (!tickets.Any()) return NotFound("No tickets found.");
            return Ok(tickets);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Ticket> GetTicket(int id)
        {
            var existTicket = _crDB.Tickets.FindAsync(id);
            return Ok(existTicket);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutTicket(int id, Ticket ticket)
        {
            if (id!= ticket.Id) return BadRequest("Id mismatch.");
            _ticketService.UpdateTicket(ticket);
            return Ok("Ticket updated."); 
        }

        [HttpPost("create")]
        public IActionResult CreateTicket(Ticket ticket)
        {
            _ticketService.Create(ticket);
            return Ok("Ticket created.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTicket(int id)
        {
            _ticketService.DeleteTicket(id);
            return Ok("Ticket deleted.");
        }

    }
}