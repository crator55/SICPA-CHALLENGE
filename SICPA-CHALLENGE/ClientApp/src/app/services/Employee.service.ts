import { Injectable,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable(
  { providedIn: 'root' }
)
export class EmployeeService{
  urlBase: string = "";
  constructor(private HttpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;
  }
  public getEmployee() {
    return this.HttpClient.get(this.urlBase + "api/Employee/ListEmployees");
  }

  public SaveEmployee(employee: any) {
    return this.HttpClient.post(this.urlBase + "api/Employee/SaveEmployee", employee)
  }
  public GetOneEmployee(id: string) {
    return this.HttpClient.get(this.urlBase + "api/Employee/OneEmployee/" + id);
  }
  public UpdateEmployee(employee: any, id: string) {
    return this.HttpClient.put(this.urlBase + "api/Employee/EditEmployee/" + id, employee)
  }
  public DeleteEmployee(id: string) {
    return this.HttpClient.delete(this.urlBase + "api/Employee/DeleteEmployee/" + id)
  }
}
