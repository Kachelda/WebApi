import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';


import {AppComponent} from './app.component';
import {EmployeeComponent} from './components/employee/employee.component';
import {EmployeesComponent} from './components/employees/employees.component';
import {LoginComponent} from './components/login/login.component';
import {RegistrationComponent} from './components/registration/registration.component';
import {EmployeeService} from './shared/services/employee.service';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule, Routes} from '@angular/router';
import {ROUTES} from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    EmployeesComponent,
    LoginComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,

    // Routes
    RouterModule.forRoot(ROUTES)
  ],
  providers: [EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
