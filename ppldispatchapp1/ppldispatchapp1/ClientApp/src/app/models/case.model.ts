export class Case {
    constructor(id?: number, caseprice?: number, resolveddate?: string, title?: string,
        employeecomision?: number, employeename? : string) {
        this.id = id;
        this.caseprice = caseprice;
        this.roomnbr = title;
        this.resolveddate = resolveddate;
        this.employeecomision = employeecomision;
        this.employeename = employeename;

    }

    public id: number;
    public roomnbr: string;
    public caseprice: number;
    public resolveddate: string;
    public employeename: string;
    public employeecomision: number;
}
