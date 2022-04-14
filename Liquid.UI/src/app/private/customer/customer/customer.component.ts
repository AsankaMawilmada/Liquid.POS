import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { RxFormBuilder } from '@rxweb/reactive-form-validators';
import { NotificationService } from '@shared/services';
import { first } from 'rxjs';
import { CustomerService } from '../customer.service';
import { Create } from './create';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.sass']
})
export class CustomerComponent implements OnInit {
  f: FormGroup;
  busy = false;
  constructor(  
    private router: Router,
    private service: CustomerService,
    private notificationService: NotificationService,
    private formBuilder: RxFormBuilder
  ) {
    this.f = this.formBuilder.formGroup(new Create());
  } 
  
  ngOnInit(): void {
    //throw new Error('Method not implemented.');
  }

  submitForm() {
   
    this.service.create(this.f.value)
    .pipe(first())
    .subscribe({
      next:() => this.notificationService.success('Customer saved successfully.'),
      error:() =>  this.notificationService.error('There was an error saving the customer.'),
      complete:() => this.busy = false
    });



        // (user: Create) => {
        //   this.notificationService.success('new record created successfully.');
        //   this.router.navigateByUrl(`/users/edit/${user.userId}`);
        //   this.busy = false;
        // },
     
        

    // this.busy = true;
    // this.authenticationService.attemptAuth(this.form.value)
    // .pipe(first())
    // .subscribe({
    //   next:() => this.router.navigateByUrl('dashboard'),    
    //   complete:() => this.busy = false
    // });
  }
}
