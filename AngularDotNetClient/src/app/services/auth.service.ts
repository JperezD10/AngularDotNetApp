import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LoginRequest } from '../interfaces/login';
import { Observable } from 'rxjs';
import { LoginApiResponse } from '../interfaces/loginApiResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authUrl: string = environment.url + 'Auth'
  constructor(private http: HttpClient) { }

  login(userLogin: LoginRequest): Observable<LoginApiResponse>{
    return this.http.post<LoginApiResponse>(this.authUrl, userLogin);
  }
}
