using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.DTO;

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
        public ActionResult GetTickets()
        {
            IEnumerable<Ticket> tickets = _ticketService.GetAllTickets();
            if (!tickets.Any()) return NoContent();
            return Ok(tickets);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetTicket(int id)
        {
            Ticket ticket = _ticketService.GetTicketById(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutTicket(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.Id) return BadRequest("Id mismatch.");
            _ticketService.UpdateTicket(ticket);
            return Ok("Ticket updated.");
        }

        [HttpPost]
        public IActionResult CreateTicket([FromBody] Ticket request)
        {
            try
            {
                var ticket = new Ticket
                {
                    Title = request.Title,
                    Description = request.Description,
                    Open = request.Open,
                    UserId = request.User.Id,
                };

                _ticketService.Create(ticket);

                return Ok("Ticket created successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTicket(int id)
        {
            _ticketService.DeleteTicket(id);
            return NoContent();
        }

    }
}
