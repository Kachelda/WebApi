import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from 'rxjs/Observable';
import {Employee} from "../../models/employee";
import "rxjs";

@Injectable()
export class EmployeeService {

  private baseUrl = "http://localhost:1966/";
  private urlPath = this.baseUrl + "api/values/";

  private options = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };


  constructor(private http: HttpClient) {
  }


  getFullHierarchyEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.urlPath, this.options);
  }

}
