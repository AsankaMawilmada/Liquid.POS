import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { map, distinctUntilChanged } from 'rxjs/operators';
import { Observable, BehaviorSubject, ReplaySubject } from 'rxjs';
import { JwtService } from './jwt.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private currentUserSubject = new BehaviorSubject<any>({});
  public currentUser = this.currentUserSubject
    .asObservable()
    .pipe(distinctUntilChanged());

  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private apiService: ApiService,private jwtService:JwtService) {}

  attemptAuth(credentials: any): Observable<any> {
    return this.apiService.post('account/login', credentials).pipe(
      map((userLogin: any) => {
        this.currentUserSubject.next(userLogin);
        this.isAuthenticatedSubject.next(true);
        this.jwtService.saveToken(userLogin.token);

        return userLogin;
      })
    );
  }

  logout(){
    this.currentUserSubject.next({} as any);
    this.isAuthenticatedSubject.next(false);
    this.jwtService.destroyToken();
  }

  getCurrentUser(): any {
    return this.currentUserSubject.value;
  }

}
