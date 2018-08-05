import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { AppTranslationService } from "../../services/app-translation.service";
import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { Utilities } from '../../services/utilities';
import { CaseService } from '../../services/case.services';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { fadeInOut } from '../../services/animations';
import { Case } from '../../models/case.model';



@Component({
    selector: 'cases',
    templateUrl: './cases.component.html',
    styleUrls: ['./cases.component.css'],
    animations: [fadeInOut]
})
export class CasesComponent implements OnInit {
    cases: Case[];
    columns: any[] = [];
    rows: Case[] = [];
    rowsCache: Case[] = [];
    @ViewChild('indexTemplate') indexTemplate: TemplateRef<any>;
    @ViewChild('RoomTemplate') RoomTemplate: TemplateRef<any>;
    @ViewChild('DateTemplate') DateTemplate: TemplateRef<any>;
    @ViewChild('PriceTemplate') PriceTemplate: TemplateRef<any>;
    constructor(private alertService: AlertService, private translationService: AppTranslationService,
                private caseService: CaseService) {
    }
    ngOnInit() {
        let gT = (key: string) => this.translationService.getTranslation(key);

        this.columns = [
            { prop: 'index', name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
            { prop: 'title', name: gT('Case.Roomnbr'), width: 20, cellTemplate: this.RoomTemplate },
            { prop: 'employeeName', name: gT('Case.employeename'), width: 50 },
            { prop: 'employeeComision', name: gT('Case.employeecomisions'), cellTemplate: this.PriceTemplate, width: 20 },
            { prop: 'resolvedDate', name: gT('Case.resolveddate'), cellTemplate: this.DateTemplate , width: 50 },
            { prop: 'casePrice', name: gT('Case.caseprice'), width: 20, cellTemplate: this.PriceTemplate },
        ];
        this.loadData();
    }
    loadData() {
        this.alertService.startLoadingMessage();
        this.caseService.getCases().
            subscribe(
                cases => this.onDataLoadSuccessful(cases),
                error => this.onDataLoadFailed(error)
            );
    }

    onDataLoadSuccessful(arrcases: Case[]) {
        this.alertService.stopLoadingMessage();
        arrcases.forEach((acase, index, arrcases) => {
            (<any>acase).index = index + 1;
        });
        this.cases = arrcases;
        this.rows = this.cases;
    }
    onDataLoadFailed(error: any) {
        this.alertService.stopLoadingMessage();
        this.alertService.showStickyMessage('Load Error',
                `Unable to retrieve users from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
            MessageSeverity.error, error);
    }
}
