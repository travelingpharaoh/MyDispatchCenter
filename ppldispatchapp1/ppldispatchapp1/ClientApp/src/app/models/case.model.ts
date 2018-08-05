export class Case {
    constructor(id?: number, caseprice?: number,description?:string, resolveddate?: string, title?: string,
        employeename?: string, employeecomision?: number,) {
        this.id = id;
        this.casePrice = caseprice;
        this.title = title;
        this.resolvedDate = resolveddate;
        this.employeeComision = employeecomision;
        this.employeeName = employeename;
    }

    public id: number;
    public casePrice: number;
    public description: string;
    public resolvedDate: string;
    public title: string;
    public employeeName: string;
    public employeeComision: number;
}
