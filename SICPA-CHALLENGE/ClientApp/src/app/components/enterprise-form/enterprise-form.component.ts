import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { EnterpriseService } from '../../services/Enterprise.service'
import { Router, ActivatedRoute } from '@angular/router'
@Component({
  selector: 'app-enterprise-form',
  templateUrl: './enterprise-form.component.html',
  styleUrls: ['./enterprise-form.component.css']
})
export class EnterpriseFormComponent implements OnInit {
  enterprise: FormGroup;
  param: string = "";
  constructor(private activatedRoute: ActivatedRoute, private router: Router, private enterpriseService: EnterpriseService) {
    this.enterprise = new FormGroup(
      {
        'Status': new FormControl(true, [Validators.required]),
        'Address': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'Name': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'Phone': new FormControl("", [Validators.required, Validators.maxLength(100)]),
      });
    this.activatedRoute.params.subscribe(param => {
      this.param = param["id"];

    })
  }

  ngOnInit() {
    if (this.param != "new") {
      this.enterpriseService.GetOneEnterprise(this.param).subscribe((data: any) => {
        this.enterprise.controls["Status"].setValue(data.status);
        this.enterprise.controls["Address"].setValue(data.address);
        this.enterprise.controls["Name"].setValue(data.name);
        this.enterprise.controls["Phone"].setValue(data.phone);
      });
    }
  }
  Save() {
    if (this.enterprise.valid == true && this.param == "new") {
      this.enterpriseService.SaveEnterprise(this.enterprise.value).subscribe((data: any) => {

      });
    } else {
      this.enterpriseService.UpdateEnterprise(this.enterprise.value, this.param).subscribe((data: any) => {

      });
    }
  }
}
