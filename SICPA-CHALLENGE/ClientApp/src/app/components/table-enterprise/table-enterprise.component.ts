import { Component } from '@angular/core';
import { EnterpriseService } from '../../services/Enterprise.service';
@Component({
  selector: 'table-enterprise',
  templateUrl: './table-enterprise.component.html',
  styleUrls: ['./table-enterprise.component.css']
})
export class TableEnterpriseComponent {
  enterprises: any[] = [];
  headers: string[] = ["Status", "Address", "Name", "Phone"]
  constructor(private enterprise: EnterpriseService) {

  }
  ngOnInit() {
    this.enterprise.getEnterprise().subscribe((data: any) => {
      this.enterprises = data
    });

  }
  DeleteEnterprise(id: string) {
    if (confirm("Do you wish to delete")) {
      this.enterprise.DeleteEnterprise(id).subscribe((data: any) => {
      });
    }
  }
}
