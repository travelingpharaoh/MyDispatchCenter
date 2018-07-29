export class CaseSearch {
    constructor(beginDate: string, EndDate?: string, Employee?: number, Customer?: number) {
        this.BeginDate = beginDate;
        this.EndDate = EndDate;
        this.Employee = Employee;
        this.Customer = Customer;

    }

    public BeginDate: string;
    public EndDate: string;
    public Employee: number;
    public Customer: number;
}
