import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

import { EntertainmentEvent } from 'src/app/entities/database/event.type';
import { EntertainmentEventInHalls } from 'src/app/entities/jsonModels/eventsInHalls.type';


@Injectable()
export class EntertainmentEventService {
    
    private url = "http://localhost:50287/api/event";

    constructor(private http: HttpClient) {

    }    

    async getAllEvents(){
        let events: EntertainmentEvent[] = await this.http.get<EntertainmentEvent[]>(this.url + "/getAllEvents").toPromise();
        return events;
    }

    async getAllEventsWithAllInfo(){
        let events:  EntertainmentEventInHalls[] = await this.http.get<EntertainmentEventInHalls[]>(this.url + "/getAllEventsWithAllInfo").toPromise();
        return events;
    }

    async getAllInfoAboutEvent(eventId: number){
        console.log(eventId);
        let events: EntertainmentEventInHalls[] =  await this.http.get<EntertainmentEventInHalls[]>(this.url + "/" + eventId).toPromise();
        console.log(events);
        return events;
    }
}