
export interface TicketBody {
    id: number;
    user: number;
    title: string;
    open: boolean;
    description: string;
    created: Date;
}

export interface TicketDTO {
    id: number;
    user: number;
    title: string;
    open: boolean;
    description: string;
    created: Date;
}