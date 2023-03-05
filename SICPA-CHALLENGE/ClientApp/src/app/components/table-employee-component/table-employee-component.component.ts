import { Component } from '@angular/core';
import { EmployeeService } from '../../services/Employee.service';

@Component({
  selector: 'table-employee-component',
  templateUrl: './table-employee-component.component.html',
  styleUrls: ['./table-employee-component.component.css']
})
export class TableEmployeeComponentComponent {

  employees: any[]=[];
  headers: string[] = ["Status", "Age", "Email", "Name", "Position","Surname"]
  constructor(private employee: EmployeeService) {

  }
  ngOnInit() {
    this.employee.getEmployee().subscribe((data: any) => {
      this.employees = data
    });

  }
  DeleteEmployee(id: string) {
    if (confirm("Do you wish to delete")) {
      this.employee.DeleteEmployee(id).subscribe((data: any) => {
      });
    }
  }
}
