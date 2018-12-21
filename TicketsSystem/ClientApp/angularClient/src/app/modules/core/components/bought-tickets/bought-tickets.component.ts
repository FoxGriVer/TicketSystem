import { Component, OnInit } from '@angular/core';

import { TicketService } from 'src/app/services/databaseServices/ticket.service';

@Component({
    selector: 'bought-tickets-component',
    templateUrl: './bought-tickets.component.html',
    styleUrls: ['./bought-tickets.component.css']
})
export class BoughtTicketsComponent implements OnInit {

    boughtTickets;
    talbeIsEmpty: boolean = true;

    constructor(private ticketService: TicketService) { 
        this.ticketService.getTicketsHistory().subscribe(
            data => {
                this.boughtTickets = data; 
                if(this.boughtTickets.length != 0){
                    this.talbeIsEmpty = false;
                }               
            }
        );
    }

    ngOnInit(): void { }
}
