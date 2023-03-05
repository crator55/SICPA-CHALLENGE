import { Component } from '@angular/core';
import { DepartmentService } from '../../services/Department.service';

@Component({
  selector: 'table-departments',
  templateUrl: './table-departments.component.html',
  styleUrls: ['./table-departments.component.css']
})
export class TableDepartmentsComponent {
  departments: any[] = [];
  headers: string[] = ["Status", "Description", "Name", "Phone","Enterprise"]
  constructor(private deparment: DepartmentService) {

  }
  ngOnInit() {
    this.deparment.getDepartment().subscribe((data: any) => {
      this.departments = data
    });
    
  }
  DeleteDepartment(id: string) {
    if (confirm("Do you wish to delete")) {
      this.deparment.DeleteDepartment(id).subscribe((data: any) => {
      });
    }
  }
}
