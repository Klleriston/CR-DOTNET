import {TicketDTO} from "./Ticket"

export interface UserBody {
    id: number;
    name: string;
    email: string;
    password: string;
    tickets: TicketDTO[];
}

export interface UserDTO {
    id: number;
    name: string;
    email: string;
    password: string;
    tickets: TicketDTO[];
}