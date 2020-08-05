import { Component, OnInit, OnDestroy } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from 'src/app/shared/services';
import { SharedModule } from 'src/app/shared/shared.module';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  //private subscription: Subscription;
  public isSetRegistered: boolean = false;
  public isAdmin: boolean = false;
  //public email: string = null;
  //public password: string = null;
  //public fullName: string = null;
  public formGroup: FormGroup;

  constructor(
    private readonly authenticationService: AuthenticationService,
    private readonly router: Router,
    private readonly userService: UserService,
    private readonly formBuilder: FormBuilder
  ) {
    this.formGroup = this.formBuilder.group({
      email: new FormControl(null),
      password: new FormControl(null),
      fullName: new FormControl(null),
    });
    this.userService.username.next('');
  }

  setAdmin(): void {
    this.isAdmin = !this.isAdmin;
  }

  public authenticate(): void {

    const data: RegisterModel = this.formGroup.getRawValue();
    this.formGroup.removeControl('fullName');

    this.authenticationService.login(data).subscribe((logData: any) => {
      localStorage.setItem('userToken', JSON.stringify(logData.token));
      this.userService.username.next(data.email);
      this.router.navigate(['dashboard']);
    });
  }
}
