import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

type Department = {
  Status: boolean;
  Description: string;
  Name: string;
  Phone: string;
}
@Injectable(
  { providedIn: 'root' }
)
export class DepartmentService{
  urlBase: string = "";
  server: string = "https://localhost:44400/";
  constructor(private HttpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;
    console.log(baseUrl)
  }

  public getDepartment() {
    return this.HttpClient.get(this.urlBase + "api/Department/ListDepartment");
  }
  public getDepartmentEnterprise() {
    return this.HttpClient.get(this.urlBase + "api/Department/ListDepartmentEnterprise");
  }
  public SaveDepartment(department: any) {
    return this.HttpClient.post(this.urlBase + "api/Department/SaveDepartment", department)
  }
  public GetOneDepartment(id:string) {
    return this.HttpClient.get(this.urlBase + "api/Department/OneDepartment/" + id);
  }
  public UpdateDepartment(department: any,id:string) {
    return this.HttpClient.put(this.urlBase + "api/Department/EditDepartment/"+id, department)
  }
  public DeleteDepartment(id:string) {
    return this.HttpClient.delete(this.server + "api/Department/DeleteDepartment/" + id)
  }
}
