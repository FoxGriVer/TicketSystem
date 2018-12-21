export class EntertainmentEventInHalls {
    constructor(
        public eventInHallId?: number,
        public eventId?: number,
        public eventName?: string,
        public poster?: string,
        public description?: string,
        public dateTime?: Date,
        public price?: number,
        public hallName?: string,
        public buildingName?: string,
        public address?: string
    ) {}
}