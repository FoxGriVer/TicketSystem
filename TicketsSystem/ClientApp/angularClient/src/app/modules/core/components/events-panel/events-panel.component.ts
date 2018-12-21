import { Component, OnInit } from '@angular/core';

import { EntertainmentEventService } from 'src/app/services/databaseServices/event.service';
import { EntertainmentEventInHalls } from 'src/app/entities/jsonModels/eventsInHalls.type';

@Component({
    selector: 'events-panel-component',
    templateUrl: './events-panel.component.html',
    styleUrls: ['./events-panel.component.css']
})
export class EventsPanelComponent implements OnInit {

    entertainmentEventsWithAllInfo: EntertainmentEventInHalls[];
    concertEvents: EntertainmentEventInHalls[];
    cinemaEvents: EntertainmentEventInHalls[];
    
    constructor(private eventService: EntertainmentEventService) {

        this.entertainmentEventsWithAllInfo = [];  
        this.concertEvents = []; 
        this.cinemaEvents = [];

        this.getEventsWithAllInfo();
    }

    ngOnInit(): void {
        
    }

    async getEventsWithAllInfo(){
        this.entertainmentEventsWithAllInfo = await this.eventService.getAllEventsWithAllInfo();
        console.log(this.entertainmentEventsWithAllInfo);
        await this.sortEventsByType();
    }

    sortEventsByType(){
        this.entertainmentEventsWithAllInfo.forEach(element => {
            if(element.buildingName == "Дворец спорта" || element.buildingName == "Большой концертный зал"){
                this.concertEvents.push(element);
            }
            else {
                if(this.cinemaEvents.map(function(e) { return e.eventName;}).indexOf(element.eventName) != -1){
                }
                else {
                    this.cinemaEvents.push(element);
                }
            }
        });
        
    }
    
}
