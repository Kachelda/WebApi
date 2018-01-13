import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from '../../shared/services/authentication.service';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthenticationService]
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;

  token: string;

  constructor(private authenticationService: AuthenticationService) {
  }

  login() {

    this.authenticationService.login(this.username, this.password).subscribe(data => {
      console.log(data);
      this.token = data.access_token;
    });
  }

  ngOnInit() {
  }

}
