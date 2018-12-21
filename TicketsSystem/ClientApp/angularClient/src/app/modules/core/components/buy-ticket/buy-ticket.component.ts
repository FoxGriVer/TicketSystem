import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import {Subscription} from 'rxjs';

import { EventShareService } from 'src/app/services/shareServices/event-share.service';
import { UserService } from 'src/app/services/databaseServices/user.service';
import { TicketService } from 'src/app/services/databaseServices/ticket.service';

import { EntertainmentEventInHalls } from 'src/app/entities/jsonModels/eventsInHalls.type';
import { User } from 'src/app/entities/database/user.types';
import { TicketsEvents } from 'src/app/entities/jsonModels/ticketsEvents.type';
import { tick } from '@angular/core/src/render3';

@Component({
    selector: 'buy-ticket-component',
    templateUrl: './buy-ticket.component.html',
    styleUrls: ['./buy-ticket.component.css']
})
export class BuyTicketComponent implements OnInit {

    subscription: Subscription;

    numberOfTickets: number = 1;
    sumAmmount: number;
    rulesAccepted: boolean = false;
    choosedEventId: number;

    tickets: TicketsEvents[] = [];
    event: EntertainmentEventInHalls = new EntertainmentEventInHalls();
    userInformation: User = new User();

    constructor(private activateRoute: ActivatedRoute, private userService: UserService,
        private router: Router, private eventShareService: EventShareService, private ticketService: TicketService ) { 

        this.subscription = activateRoute.params.subscribe(params=>this.choosedEventId = params['id']);
        this.getPersonalInformation();
    }

    ngOnInit(): void { 
        this.event = this.eventShareService.getSharedEvent();
        this.countPrice();
    }

    async getPersonalInformation(){
        await this.userService.getPersonalInformation().subscribe(
            data => {
                this.userInformation = data;
            }
        );
    }

    buyTickets(){
        for(let i = 0; i < this.numberOfTickets; i++){
            let ticket: TicketsEvents = new TicketsEvents(this.choosedEventId,
                this.userInformation.userId, this.event.hallName, 0, 1 );     
            this.ticketService.buyTicket(ticket).subscribe();
        }        
    }    

    countPrice(){
        if(this.numberOfTickets > 0 || this.numberOfTickets == undefined ){
            this.sumAmmount = this.numberOfTickets * this.event.price;
        }
        else{            
            this.numberOfTickets = 1;
            alert("Введите корректное число билетов");
        }
    }
}
