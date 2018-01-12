import {Component, OnInit} from '@angular/core';
import {EmployeeService} from "../../shared/services/employee.service";
import {Employee} from "../../models/employee";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  providers: [EmployeeService]
})
export class EmployeesComponent implements OnInit {

  employees: Employee[];

  constructor(private employeeService: EmployeeService) {
  }

  ngOnInit() {
    this.employeeService.getFullHierarchyEmployees().subscribe(data => {
      this.employees = data;
      console.log('Employees', this.employees);
    });
  }

}
