import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { DepartmentService } from '../../services/Department.service'
import { EnterpriseService } from '../../services/Enterprise.service'
import { Router, ActivatedRoute } from '@angular/router'
@Component({
  selector: 'app-department-form',
  templateUrl: './department-form.component.html',
  styleUrls: ['./department-form.component.css']
})
export class DepartmentFormComponent implements OnInit {
  department: FormGroup;
  param: string = "";
  enterprises: any;
  constructor(private departmentService: DepartmentService, private activatedRoute: ActivatedRoute, private router: Router, private enterpriseService: EnterpriseService) {
    this.department = new FormGroup(
      {
        'Status': new FormControl(true, [Validators.required]),
        'Description': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'Name': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'Phone': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'EnterpriseName': new FormControl("", [Validators.required]),
      });
    this.activatedRoute.params.subscribe(param => {
      this.param = param["id"];
      
    })
  }
  
  ngOnInit() {
    if (this.param != "new") {
      this.departmentService.GetOneDepartment(this.param).subscribe((data: any) => {
        this.department.controls["Status"].setValue(data.status);
        this.department.controls["Description"].setValue(data.description);
        this.department.controls["Name"].setValue(data.name);
        this.department.controls["Phone"].setValue(data.phone);
        this.department.controls["EnterpriseName"].setValue(data.enterpriseName);
        });
    }
    this.enterpriseService.getEnterprise().subscribe((data: any) => { 
      this.enterprises = data
    });
  }
  Save() {
    if (this.department.valid == true && this.param=="new") {
      this.departmentService.SaveDepartment(this.department.value).subscribe((data: any) => {
       
      });
    } else {
      this.departmentService.UpdateDepartment(this.department.value,this.param).subscribe((data: any) => {

      });
    }
  }
}
