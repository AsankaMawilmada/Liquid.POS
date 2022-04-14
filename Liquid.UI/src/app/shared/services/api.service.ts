import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import {
  HttpClient,
  HttpParams,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) {}

  private formatErrors(error: HttpErrorResponse) {  
    const notificationService = new NotificationService();    
    switch (error.status) {
      case 0:
        notificationService.error('There was an error encountered while establishing the connection to server, please check if server is running or application pointing to correct server.');
        break;
      case 500:
        notificationService.error('There was an error processing your request please try again later or contact support.');
        break;
      case 400:
        notificationService.error('Validation errors occurred please confirm the fields and submit it again.');
        break;
      case 422:
        notificationService.error('Validation errors occurred please confirm the fields and submit it again.');
        break;
      case 401:
        notificationService.error('Your session expired, please login again.');
        break;
      default:
        break;
    }

    return throwError(error.error);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http
      .get(`${environment.api_url}${path}`, { params })
      .pipe(catchError(this.formatErrors));
  }

  put(path: string, body: Object = {}): Observable<any> {
    return this.http
      .put(`${environment.api_url}${path}`, JSON.stringify(body))
      .pipe(catchError(this.formatErrors));
  }

  patch(path: string, body: Object = {}): Observable<any> {
    return this.http
      .patch(`${environment.api_url}${path}`, JSON.stringify(body))
      .pipe(catchError(this.formatErrors));
  }

  post(path: string, body: Object = {}): Observable<any> {
    return this.http
      .post(`${environment.api_url}${path}`, JSON.stringify(body))
      .pipe(catchError(this.formatErrors));
  }

  delete(path: string): Observable<any> {
    return this.http
      .delete(`${environment.api_url}${path}`)
      .pipe(catchError(this.formatErrors));
  }

  downloadCsv(path: string): Observable<any> {
    return this.http
      .get(`${environment.api_url}${path}`, {
        observe: 'response',
        responseType: 'text' as 'json'
      })
  }

  downloadTxt(path: string): Observable<any> {
    return this.http
      .get(`${environment.api_url}${path}`, {
        observe: 'response',
        responseType: 'text' as 'json'
      })
  }

  downloadPdf(path: string): Observable<any> {
    return this.http
      .get(`${environment.api_url}${path}`, {
        observe: 'response',
        responseType  : 'arraybuffer' as 'json'
      })
  }

  download(path: string): Observable<any> {
    return this.http
      .get(`${environment.api_url}${path}`, {
        observe: 'response',
        responseType  : 'arraybuffer' as 'json'
      })
  }
}
