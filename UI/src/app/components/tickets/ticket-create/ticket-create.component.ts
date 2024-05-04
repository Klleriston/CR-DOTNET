import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TicketBody } from 'src/app/models/Ticket';
import { TicketService } from 'src/app/services/tickets/ticket.service';

@Component({
  selector: 'app-ticket-create',
  templateUrl: './ticket-create.component.html',
})
export class TicketCreateComponent {
  ticket: TicketBody = {
    id: 0,
    user: 0,
    title: '',
    open: false,
    description: '',
    created: new Date(),
  };

  constructor(private ticketService: TicketService, private router: Router) { }

  createTicket() {
    this.ticketService.addTicket(this.ticket).subscribe({
      next: () => {
        this.router.navigate(['tickets']);
      },
      error: (response) => {
        console.error('Failed to create ticket:', response);
      },
    });
  }
}
