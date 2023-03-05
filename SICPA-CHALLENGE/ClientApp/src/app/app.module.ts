import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
//Components
import { TableEmployeeComponentComponent } from './components/table-employee-component/table-employee-component.component'
import { TableDepartmentsComponent } from './components/table-departments/table-departments.component'
import { TableEnterpriseComponent } from './components/table-enterprise/table-enterprise.component'
import { DepartmentFormComponent } from './components/department-form/department-form.component'
import { EmployeeFormComponent } from './components/empoyee-form/empoyee-form.component'
import { EnterpriseFormComponent } from './components/enterprise-form/enterprise-form.component'
//Services
import { EmployeeService } from './services/Employee.service'
import { DepartmentService } from './services/Department.service'
import { EnterpriseService } from './services/Enterprise.service'
// Forms
import { ReactiveFormsModule } from '@angular/forms'
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TableEmployeeComponentComponent,
    TableDepartmentsComponent,
    TableEnterpriseComponent,
    DepartmentFormComponent,
    EnterpriseFormComponent,
    EmployeeFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'employees', component: TableEmployeeComponentComponent, canActivate: [AuthorizeGuard] },
      { path: 'departments', component: TableDepartmentsComponent, canActivate: [AuthorizeGuard] },
      { path: 'enterprises', component: TableEnterpriseComponent, canActivate: [AuthorizeGuard] },
      { path: 'employees/:id', component: EmployeeFormComponent, canActivate: [AuthorizeGuard] },
      { path: 'departments/:id', component: DepartmentFormComponent, canActivate: [AuthorizeGuard] },
      { path: 'enterprises/:id', component: EnterpriseFormComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true, },
    EmployeeService, DepartmentService, EnterpriseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
