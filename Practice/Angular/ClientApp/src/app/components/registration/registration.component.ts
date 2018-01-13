import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from '../../shared/services/authentication.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [AuthenticationService]
})
export class RegistrationComponent implements OnInit {

  username: string;
  password: string;
  confirmPassword: string;

  constructor(private authenticationService: AuthenticationService, private router: Router) {
  }

  ngOnInit() {
  }

  register() {
    if (this.password !== this.confirmPassword) {
      return;
    }

    this.authenticationService.register(this.username, this.password, this.confirmPassword)
      .subscribe(data => {

        this.router.navigate(['/login']);

        console.log('registration', data);
      });
  }

}
