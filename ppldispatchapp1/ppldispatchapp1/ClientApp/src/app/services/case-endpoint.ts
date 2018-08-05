import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { CaseSearch } from "../models/CaseSearch.model"
import { Case} from '../models/case.model'
import 'rxjs/add/operator/map';

import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';
export const CASES: Case[] = [
    { id: 11,  title: '111', caseprice: 1.11, employeename: 'no name', resolveddate: '2018-05-01', employeecomision: 1.12, description:'' },
    { id: 22, title: '112', caseprice: 1.12, employeename: 'no name', resolveddate: '2018-05-01', employeecomision: 1.12, description: ''},
    { id: 33, title: '113', caseprice: 1.13, employeename: 'no name', resolveddate: '2018-05-01', employeecomision: 1.12, description: '' }
]
@Injectable()
export class CaseEndpoint extends EndpointFactory {
    private readonly _ordersUrl: string = "/api/case";
    get ordersUrl() { return this.configurations.baseUrl + this._ordersUrl; }


    constructor(http: HttpClient, configurations: ConfigurationService, injector: Injector) {

        super(http, configurations, injector);
    }

    getCasesEndpoint<T>(caseSearch:CaseSearch,page?: number, pageSize?: number): Observable<T> {
        //let endpointUrl = page && pageSize ? `${this.OrdersUrl}/${page}/${pageSize}` : this.OrdersUrl;
        
        let endpointUrl = this.ordersUrl + "/" + caseSearch.BeginDate;

        //return of(CASES);
        return this.http.get<T>(endpointUrl, this.getRequestHeaders());
           // .catch(error => {
             //   return this.handleError(error, () => this.getCasesEndpoint(caseSearch,page, pageSize ));
            //});
    }
}
