import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = `${environment.apiUrl}auth/`;
  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(`${this.baseUrl}login`, model).pipe(
      map((response: any) => {
        const user = response;
        if (user.token) {
          localStorage.setItem('token', user.token);
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(`${this.baseUrl}register`, model);
  }

  loggedIn() {
    return this.getUsername();
  }

  getTokenFromLocalStorage() {
    return localStorage.getItem('token');
  }

  getUsername() {
    const token = this.getTokenFromLocalStorage();

    if (token) {
      const { unique_name } = token && this.jwtHelper.decodeToken(token);
      return unique_name;
    }
  }

  getUserId() {
    const token = this.getTokenFromLocalStorage();

    if (token) {
      const { nameid } = this.jwtHelper.decodeToken(token);
      return nameid;
    }
  }
}
