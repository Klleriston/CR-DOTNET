import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TicketBody, TicketDTO } from 'src/app/models/Ticket';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  url: string = environment.baseAPIurl + '/api/tickets';
  constructor(private http: HttpClient) { }

  getAllTickets(): Observable<TicketDTO[]> {
    return this.http.get<TicketDTO[]>(this.url);
  }

  getTicketById(id: number): Observable<TicketDTO> {
    return this.http.get<TicketDTO>(`${this.url}/${id}`);
  }

  addTicket(ticket: TicketBody): Observable<TicketBody> {
    return this.http.post<TicketBody>(this.url, ticket);
  }

  updateTicket(id: number, ticket: TicketBody): Observable<TicketBody> {
    return this.http.put<TicketBody>(`${this.url}/${id}`, ticket);
  }

  deleteTicket(id: number): Observable<TicketBody> {
    return this.http.delete<TicketBody>(`${this.url}/${id}`);
  }
}
