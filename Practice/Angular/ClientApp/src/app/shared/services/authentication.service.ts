import {Injectable} from '@angular/core';
import {BaseService} from './base.service';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {JwtToken} from '../../models/jwttoken';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class AuthenticationService extends BaseService {

  private authenticationOptions = {
    headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
  };


  constructor(private http: HttpClient) {
    super();
  }

  getFormUrlEncoded(toConvert) {
    const formBody = [];
    for (const property in toConvert) {
      const encodedKey = encodeURIComponent(property);
      const encodedValue = encodeURIComponent(toConvert[property]);
      formBody.push(encodedKey + '=' + encodedValue);
    }
    return formBody.join('&');
  }

  login(username: string, password: string): Observable<JwtToken> {


    const request = {
      grant_type: 'password',
      username: username,
      password: password
    };

    return this.http.post<JwtToken>(this.baseUrl + 'Token', this.getFormUrlEncoded(request), this.authenticationOptions);
  }

  register(username: string, password: string, confirmPassword: string): Observable<Object> {
    const request = {
      email: username,
      password: password,
      confirmPassword: confirmPassword
    };

    console.log('register request', request);

    return this.http.post<Object>(this.baseUrl + 'api/Account/register', this.getFormUrlEncoded(request), this.authenticationOptions);
  }

}
