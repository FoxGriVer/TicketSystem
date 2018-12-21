import { Injectable, EventEmitter } from '@angular/core';

import { EntertainmentEventInHalls } from 'src/app/entities/jsonModels/eventsInHalls.type';

@Injectable()
export class EventShareService {

    onClick: EventEmitter<EntertainmentEventInHalls> = new EventEmitter();

    private event:EntertainmentEventInHalls = undefined;

    addSharedEvent(sharedEvent: EntertainmentEventInHalls){
        this.event = sharedEvent;
        this.onClick.emit(sharedEvent);
    }

    getSharedEvent(): EntertainmentEventInHalls{
        return this.event;
    }

}