import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { EmployeeService } from '../../services/Employee.service'
import { Router, ActivatedRoute } from '@angular/router'

@Component({
  selector: 'empoyee-form',
  templateUrl: './empoyee-form.component.html',
  styleUrls: ['./empoyee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  employee: FormGroup;
  param: string = "";
  constructor(private employeeService: EmployeeService, private activatedRoute: ActivatedRoute, private router: Router) {
    this.employee = new FormGroup(
      {
        'Status': new FormControl(true, [Validators.required]),
        'Age': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'Email': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'Name': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'Position': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'Surname': new FormControl("", [Validators.required, Validators.maxLength(100)])
      });
    this.activatedRoute.params.subscribe(param => {
      this.param = param["id"];

    })
  }

  ngOnInit() {
    if (this.param != "new") {
      this.employeeService.GetOneEmployee(this.param).subscribe((data: any) => {
        this.employee.controls["Status"].setValue(data.status);
        this.employee.controls["Age"].setValue(data.age);
        this.employee.controls["Email"].setValue(data.email);
        this.employee.controls["Name"].setValue(data.name);
        this.employee.controls["Position"].setValue(data.position);
        this.employee.controls["Surname"].setValue(data.surname);
      });
    }

  }
  Save() {
    if (this.employee.valid == true && this.param == "new") {
      this.employeeService.SaveEmployee(this.employee.value).subscribe((data: any) => {

      });
    } else {
      this.employeeService.UpdateEmployee(this.employee.value, this.param).subscribe((data: any) => {

      });
    }
  }
}
