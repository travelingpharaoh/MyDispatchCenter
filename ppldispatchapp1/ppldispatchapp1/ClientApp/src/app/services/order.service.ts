import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { AuthService } from './auth.service';
import { User } from '../models/user.model';
import { Role } from '../models/role.model';
import { Order } from '../models/order.model';
import { OrderEndpoint } from './order-endpoint.service';
import { Permission, PermissionNames, PermissionValues } from '../models/permission.model';
export const ORDERS: Order[] = [
    { id: 11, roomNbr: '111', discount: 1.25, comments: 'no comment' },
    { id: 22, roomNbr: '112', discount: 1.12, comments: 'no comment' },
    { id: 33, roomNbr: '112', discount: 1.12, comments: 'no comment' }
]
@Injectable()
export class OrderService {
    constructor(private router: Router, private http: HttpClient, private authService: AuthService,
        private orderEndPoint: OrderEndpoint) {

    }

    getOrders() {

        //return of(ORDERS);
        return this.orderEndPoint.getOrdersEndpoint<Order[]>();
    }
}
