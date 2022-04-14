import { NgModule } from '@angular/core';
import { CommonModule, DatePipe, DecimalPipe } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpTokenInterceptor } from './interceptors/http.token.interceptor';
import { RxReactiveFormsModule } from '@rxweb/reactive-form-validators';
import { FormFieldErrorsComponent } from './components/form-field-errors/form-field-errors.component';


export const modules = [
  CommonModule,
  RxReactiveFormsModule
]

export const declarations = [
  FormFieldErrorsComponent
];

export const pipes = [

];

@NgModule({
  imports: [    
    modules
  ],
  declarations: [declarations],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpTokenInterceptor, multi: true },
    DatePipe,
    DecimalPipe,
    pipes
  ],
  exports:[
    modules,
    declarations,   
    pipes
  ]
})
export class SharedModule { }
