export class Order {
    constructor(id?: number, discount?: number, comments?: string, roomnbr?: string) {
        this.id = id;
        this.discount = discount;
        this.comments = comments;
        this.roomNbr = roomnbr;

    }

    public id: number;
    public discount: number;
    public comments: string;
    public roomNbr: string;
}
