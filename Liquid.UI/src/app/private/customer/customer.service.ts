import { Injectable } from '@angular/core';
import { ICustomer } from '@shared/models';
import { ApiService } from '@shared/services';
import { map, Observable } from 'rxjs';
import { Create, Edit } from './customer/create';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  apiUrl = 'customer';
  constructor(private apiService: ApiService) {}

  get(id: number): Observable<Create> {
    return this.apiService.get(`${this.apiUrl}/${id}`)
      .pipe(map((data) => data));
  }

  create(customer: Create): Observable<ICustomer> {
    return this.apiService.post(this.apiUrl, customer)
      .pipe(map((data) => data));
  }

  update(customer: Edit): Observable<ICustomer> {
    return this.apiService.put(`${this.apiUrl}/${customer.customerGuId}`, customer)
      .pipe(map((data) => data));
  }
}
