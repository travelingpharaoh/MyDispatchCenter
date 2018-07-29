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
import { Case } from '../models/case.model';
import { CaseEndpoint } from './case-endpoint';
import { Permission, PermissionNames, PermissionValues } from '../models/permission.model';
export const CASES: Case[] = [
    { id: 11, roomnbr: '111', caseprice: 1.25, employeename: 'no name', resolveddate: '2018-05-01', employeecomision: 1.12 },
    { id: 22, roomnbr: '112', caseprice: 1.12, employeename: 'no name', resolveddate: '2018-05-01', employeecomision: 1.12},
    { id: 33, roomnbr: '112', caseprice: 1.12, employeename: 'no name', resolveddate: '2018-05-01', employeecomision: 1.12}
]
@Injectable()
export class CaseService {
    constructor(private router: Router, private http: HttpClient, private authService: AuthService,
        private caseEndpoint: CaseEndpoint) {

    }

    getCases() {

        return of(CASES);
        //return this.caseEndpoint.getCases <Case[]>();
    }
}
