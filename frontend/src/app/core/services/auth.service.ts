import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/usuario';
import {environment as env} from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  async login(user: User){
    return await this.http.post<string>(`${env.apiUrl}/auth/login`, user).toPromise();
  }


  setCurrentUser(token: string){
    localStorage.setItem('currentUser', token);
  }

}
