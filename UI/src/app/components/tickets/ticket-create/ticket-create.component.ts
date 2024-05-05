import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TicketBody } from 'src/app/models/Ticket';
import { TicketService } from 'src/app/services/tickets/ticket.service';

@Component({
  selector: 'app-ticket-create',
  templateUrl: './ticket-create.component.html',
})
export class TicketCreateComponent implements OnInit{

  ticket: TicketBody = {
    id: 0,
    userid: null,
    title: '',
    open: false,
    description: '',
};
  constructor(private ticketService: TicketService, private router: Router) { }
  ngOnInit(): void {}

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
