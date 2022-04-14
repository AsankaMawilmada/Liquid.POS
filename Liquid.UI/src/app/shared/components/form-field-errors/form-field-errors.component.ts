import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-form-field-errors',
  templateUrl: './form-field-errors.component.html',
  styleUrls: ['./form-field-errors.component.scss']
})
export class FormFieldErrorsComponent  {
  @Input('errors')
  errors: any = [];
}
