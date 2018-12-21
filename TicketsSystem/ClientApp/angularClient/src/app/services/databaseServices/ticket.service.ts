import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';

import { TicketsEvents } from 'src/app/entities/jsonModels/ticketsEvents.type';

@Injectable()
export class TicketService {

    private url = "http://localhost:50287/api/ticket";

    tickets: TicketsEvents[] = [];

    constructor(private http: HttpClient) {

    }    

    buyTicket(tickets: TicketsEvents){
        return this.http.post(this.url + "/buyTickets", tickets, {
            headers: new HttpHeaders().set('Authorization',"Bearer " + sessionStorage.getItem("userToken"))
        });
    }

    getTicketsHistory(){
        return this.http.get(this.url + "/getAllTicketsByUser", {
            headers: new HttpHeaders().set('Authorization',"Bearer " + sessionStorage.getItem("userToken"))
        });
    }
}