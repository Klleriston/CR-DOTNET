import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TicketDTO } from 'src/app/models/Ticket';
import { TicketService } from 'src/app/services/tickets/ticket.service';

@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
})
export class TicketListComponent implements OnInit {
  tickets: TicketDTO[] = [];

  constructor(private ticketService: TicketService, private router: Router) { }

  ngOnInit(): void {
    this.ticketService.getAllTickets().subscribe({
      next: (tickets) => {
        this.tickets = tickets;
      },
      error: (response) => {
        console.error('Failed to load tickets:', response);
      },
    });
  }

  addTicket() {
    this.router.navigateByUrl('tickets/create');
  }

  editTicket(ticketId: number) {
    this.router.navigate(['tickets/edit', ticketId]);
  }

  deleteTicket(ticketId: number) {
    this.ticketService.deleteTicket(ticketId).subscribe({
      next: () => {
        this.tickets = this.tickets.filter((t) => t.id !== ticketId);
        console.log('Ticket deleted successfully');
      },
      error: (response) => {
        console.error('Failed to delete ticket:', response);
      },
    });
  }


  redirectToCreateTicket() {
    this.router.navigate(['/tickets/create']);
  }

  redirectToEditTickets() {
    this.router.navigate(['/tickets']);
  }
}
