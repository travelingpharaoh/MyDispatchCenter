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
    @ViewChild('indexTemplate')
    indexTemplate: TemplateRef<any>;

    @ViewChild('RoomTemplate')
    RoomTemplate: TemplateRef<any>;

    constructor(private alertService: AlertService, private translationService: AppTranslationService,
                private caseService: CaseService) {
    }
    ngOnInit() {
        let gT = (key: string) => this.translationService.getTranslation(key);

        this.columns = [
            { prop: 'index', name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
            { prop: 'caseprice', name: gT('Case.caseprice'), width: 50 },
            { prop: 'roomnbr', name: gT('Case.Roomnbr'), width: 20, cellTemplate: this.RoomTemplate },
            { prop: 'employeefee', name: gT('Case.employee fee'), width: 50 },
            { prop: 'employeename', name: gT('Case.employee name'), width: 50 },
            { prop: 'employeecomision', name: gT('Case.employee comisions'), width: 50 },
            { prop: 'resolveddate', name: gT('Case.completeddate'), width: 50 },
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

    onDataLoadSuccessful(cases: Case[]) {
        this.alertService.stopLoadingMessage();
       /* cases.forEach((case, index, cases) => {
            (<any>case).index = index + 1;
        });*/
        this.rows = this.cases = cases;
    }
    onDataLoadFailed(error: any) {
        this.alertService.stopLoadingMessage();
        this.alertService.showStickyMessage('Load Error',
                `Unable to retrieve users from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
            MessageSeverity.error, error);
    }
}
