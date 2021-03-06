import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';

@Injectable()
export class OrderEndpoint extends EndpointFactory {
    private readonly _ordersUrl: string = "/api/order";
    get ordersUrl() { return this.configurations.baseUrl + this._ordersUrl; }


    constructor(http: HttpClient, configurations: ConfigurationService, injector: Injector) {

        super(http, configurations, injector);
    }

    getOrdersEndpoint<T>(page?: number, pageSize?: number): Observable<T> {
        //let endpointUrl = page && pageSize ? `${this.OrdersUrl}/${page}/${pageSize}` : this.OrdersUrl;

        let endpointUrl = this.ordersUrl;
        return this.http.get<T>(endpointUrl, this.getRequestHeaders())
            .catch(error => {
                return this.handleError(error, () => this.getOrdersEndpoint(page, pageSize));
            });
    }
}
