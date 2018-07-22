import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { Order } from '../../models/order.model';
export const ORDERS: Order[] = [
    { Id: '11', RoomNbr: '111', Discount: '1.25', Comments: 'no comment' },
    { Id: '22', RoomNbr: '112', Discount: '1.12', Comments: 'no comment' },
    { Id: '33', RoomNbr: '112', Discount: '1.12', Comments: 'no comment' }
]
@Component({
    selector: 'orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.css'],
    animations: [fadeInOut]
})
export class OrdersComponent implements OnInit{
    orders = ORDERS;
    constructor() {
    }
    ngOnInit() {

    }
}
