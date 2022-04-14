import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersComponent } from './customers/customers.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerRoutingModule } from './customer.routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

export const modules = [
  CommonModule,
  CustomerRoutingModule,
  FormsModule,
  ReactiveFormsModule,
]
export const declarations = [
  CustomersComponent,
  CustomerComponent
]

@NgModule({
  imports: [modules],
  declarations: [declarations]
})
export class CustomerModule { }
