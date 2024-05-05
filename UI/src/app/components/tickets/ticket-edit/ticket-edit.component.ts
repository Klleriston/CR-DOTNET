import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TicketBody } from 'src/app/models/Ticket';
import { TicketService } from 'src/app/services/tickets/ticket.service';

@Component({
  selector: 'app-edit-department',
  templateUrl: './ticket-edit.component.html',
})
export class TicketEditComponent implements OnInit {
  ticketDetail: TicketBody = {
    id: 0,
    userid: 0,
    title: '',
    open: false,
    description: '',
  };

  constructor(
    private route: ActivatedRoute,
    private ticketService: TicketService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id) {
          this.ticketService.getTicketById(+id).subscribe({
            next: (response) => {
              this.ticketDetail = response;
            },
          });
        }
      },
    });
  }

  updateTicket() {
    this.ticketService.updateTicket(this.ticketDetail.id, this.ticketDetail).subscribe({
      next: () => {
        this.router.navigate(['tickets']);
      },
    });
  }

  deleteTicket(id: number) {
    this.ticketService.deleteTicket(id).subscribe({
      next: () => {
        this.router.navigate(['/tickets']);
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