import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { AppTranslationService } from "../../services/app-translation.service";
import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { Utilities } from '../../services/utilities';
import { OrderService } from '../../services/order.service';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { fadeInOut } from '../../services/animations';
import { Order } from '../../models/order.model';



@Component({
    selector: 'orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.css'],
    animations: [fadeInOut]
})
export class OrdersComponent implements OnInit{
    orders : Order[];
    columns: any[] = [];
    rows: Order[] = [];
    rowsCache: Order[] = [];
    @ViewChild('indexTemplate')
    indexTemplate: TemplateRef<any>;

    @ViewChild('RoomTemplate')
    RoomTemplate: TemplateRef<any>;

    constructor(private alertService: AlertService, private translationService: AppTranslationService,
                private orderService: OrderService) {
    }
    ngOnInit() {
        let gT = (key: string) => this.translationService.getTranslation(key);

        this.columns = [
            { prop: "index", name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
            { prop: 'discount', name: gT('Order.Discount'), width: 50 },
            { prop: 'roomNbr', name: gT('Order.Roomnbr'), width: 90, cellTemplate: this.RoomTemplate },
        ];
        this.loadData();
    }
    loadData() {
        this.alertService.startLoadingMessage();
        this.orderService.getOrders().
            subscribe(
                orders => this.onDataLoadSuccessful(orders),
                error => this.onDataLoadFailed(error)
            );
    }

    onDataLoadSuccessful(orders: Order[]) {
        this.alertService.stopLoadingMessage();
        orders.forEach((order, index, orders) => {
            (<any>order).index = index + 1;
        });
        this.rows = this.orders=orders;
        
    }
    onDataLoadFailed(error: any) {
        this.alertService.stopLoadingMessage();
        this.alertService.showStickyMessage("Load Error", `Unable to retrieve users from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
            MessageSeverity.error, error);
    }
}
