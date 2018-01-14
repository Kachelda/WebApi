import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {Employee} from '../../models/employee';
import {BaseService} from './base.service';

@Injectable()
export class EmployeeService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }


  getFullHierarchyEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + 'api/values/', this.options);
  }

}
