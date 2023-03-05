import { Injectable,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable(
  { providedIn: 'root' }
)
export class EnterpriseService{
  urlBase: string = "";
  constructor(private HttpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;
  }
  public getEnterprise() {
    return this.HttpClient.get(this.urlBase + "api/Enterprise/ListEnterprise");
  }

  public SaveEnterprise(enterprise: any) {
    return this.HttpClient.post(this.urlBase + "api/Enterprise/SaveEnterprise", enterprise)
  }
  public GetOneEnterprise(id: string) {
    return this.HttpClient.get(this.urlBase + "api/Enterprise/OneEnterprise/" + id);
  }
  public UpdateEnterprise(enterprise: any, id: string) {
    return this.HttpClient.put(this.urlBase + "api/Enterprise/EditEnterprise/" + id, enterprise)
  }
  public DeleteEnterprise(id: string) {
    return this.HttpClient.delete(this.urlBase + "api/Enterprise/DeleteEnterprise/" + id)
  }
}
