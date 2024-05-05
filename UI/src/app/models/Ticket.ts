import { UserDTO } from "./User";

export interface TicketBody {
    id: number;
    userid: number | null;
    title: string;
    open: boolean;
    description: string;
}

export interface TicketDTO {
    id: number;
    userid: number | null;
    title: string;
    open: boolean;
    description: string;
}
