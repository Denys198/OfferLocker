import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from 'src/app/shared/services/user.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { UserModel } from 'src/app/shared/user-models/user.model';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css'],
  providers: [AuthenticationService],
})
export class AuthenticationComponent {

  private routeSub: Subscription;
  //private subscription: Subscription;
  public isSetRegistered: boolean = false;
  public formGroup: FormGroup;
  public user: UserModel;
  public userEmail: string;
  public userId: string;

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

  setRegister(): void {
    this.isSetRegistered = !this.isSetRegistered;
  }

  public authenticate(): void {
    if (this.isSetRegistered) {
      const data: RegisterModel = this.formGroup.getRawValue();

      this.authenticationService.register(data).subscribe(() => {
        this.userService.username.next(data.email);
        this.router.navigate(['user']);
      });
    } else {
      const data: LoginModel = this.formGroup.getRawValue();
      this.formGroup.removeControl('fullName');

      this.authenticationService.login(data).subscribe((logData: any) => {

        console.log(`logdata email: ${logData.email}`);

        localStorage.setItem('userToken', JSON.stringify(logData.token));
        localStorage.setItem('userEmail', JSON.stringify(logData.email));
        localStorage.setItem('userFullName', JSON.stringify(logData.fullName));
        localStorage.setItem('userId', JSON.stringify(logData.id));

        this.userId = JSON.parse(localStorage.getItem('userId'));

        this.userService.username.next(data.email);
        this.router.navigate([`user/${this.userId}`]);
      });
    }
  }
}
