export class TicketsEvents {
    constructor(        
        public EventInHallId?: number,
        public UserId?: number,
        public HallName?: string,
        public Row?: number,
        public Coll?: number,      
        public SitId?: number,  
        public OrderId?: number,
        public EventInHallTakenSitsId?: number,
        public dateTime: Date = new Date(Date.now())
    ) {}
}