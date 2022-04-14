import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { RxFormBuilder } from '@rxweb/reactive-form-validators';
import { NotificationService } from '@shared/services';
import { AuthenticationService } from '@shared/services/authentication.service';
import { first } from 'rxjs/operators';
import { LoginForm } from './login.form';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  form: FormGroup;
  busy = false;
  constructor(  
    private router: Router,
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
    private formBuilder: RxFormBuilder
  ) {
    this.form = this.formBuilder.formGroup(new LoginForm());
  } 

  submitForm() {
    this.busy = true;
    this.authenticationService.attemptAuth(this.form.value)
    .pipe(first())
    .subscribe({
      next:() => this.router.navigateByUrl('dashboard'),    
      complete:() => this.busy = false
    });
  }
}
