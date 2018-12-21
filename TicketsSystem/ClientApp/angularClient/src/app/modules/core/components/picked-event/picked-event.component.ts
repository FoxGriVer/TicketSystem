import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import {Subscription} from 'rxjs';

import { EntertainmentEventInHalls } from 'src/app/entities/jsonModels/eventsInHalls.type';

import { EntertainmentEventService } from 'src/app/services/databaseServices/event.service';
import { AutheticationService } from 'src/app/services/databaseServices/authetication.service';
import { EventShareService } from 'src/app/services/shareServices/event-share.service';

declare var $: any;

@Component({
    selector: 'picked-event-component',
    templateUrl: './picked-event.component.html',
    styleUrls: ['./picked-event.component.css']
})
export class PickedEventComponent implements OnInit {

    subscription: Subscription;
    cinemaType: boolean = false;

    choosedId: number;
    entertainmentEvent: EntertainmentEventInHalls = new EntertainmentEventInHalls();
    entertainmentEventWithAllSessions: EntertainmentEventInHalls[] = [];

    constructor(private activateRoute: ActivatedRoute, private eventService: EntertainmentEventService,
        private router: Router, private authService: AutheticationService, private eventShareService: EventShareService) {
        this.subscription = activateRoute.params.subscribe(params=>this.choosedId = params['id']);        
     }

    ngOnInit(): void { 
        this.getEvent();   
    }

    async getEvent(){
        this.entertainmentEventWithAllSessions = await this.eventService.getAllInfoAboutEvent(this.choosedId);
        this.entertainmentEvent = this.entertainmentEventWithAllSessions[0];
        if(this.entertainmentEvent.buildingName == "Дворец спорта" || this.entertainmentEvent.buildingName == "Большой концертный зал"){
            this.cinemaType = false;
        }
        else {
            await this.deletePastSessions();
            await this.sortEvents();
            this.cinemaType = true;   
            console.log(this.entertainmentEvent);
        }
    }

    async clickBuyTicket(eventId: number){
        if(await this.authService.checkUserToken() == null){
            this.router.navigate(['/login']);
        } else {
            this.eventShareService.addSharedEvent(this.entertainmentEvent);
            this.router.navigate(['/buyTicket', eventId]);
        }        
    }

    async deletePastSessions(){
        let nowDate = new Date();
        let validSassions: EntertainmentEventInHalls[] = [];
        
        for(let i = 0; i < this.entertainmentEventWithAllSessions.length; i++)
        {
            let timeDate = await new Date(this.entertainmentEventWithAllSessions[i].dateTime);
            if(nowDate < timeDate){
                validSassions.push(this.entertainmentEventWithAllSessions[i]);
            }            
        }
        this.entertainmentEventWithAllSessions = validSassions;
    }

    sortEvents(){
        this.entertainmentEventWithAllSessions.sort(this.sortFunction);
    }

    sortFunction(a,b){  
        var dateA = new Date(a.date).getTime();
        var dateB = new Date(b.date).getTime();
        return dateA > dateB ? 1 : -1;  
    }; 
    
}
