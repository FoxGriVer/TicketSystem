export class User {
    constructor(
        public userId?: number,
        public email?: string,
        public password?: string,
        public role?: string,
        public firstName?: string,
        public secondName?: string,
        public cardNumber?: string,
        public phone?: string,
    ) {}
}