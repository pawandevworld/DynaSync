import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import { User } from '../_models/user';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private http = inject(HttpClient);
  baseurl = 'http://localhost:5083/devpulse/';
  //Setting signal. basically signal is a way to send data from one component to another
  currentUser = signal<User | null>(null);
  

  //On login set the current user to the user that is logged in
  //Also store the user in local storage on users browser
  //Can be verified by going to the application tab in the dev tools 
  //and looking at local storage => Go to Inspect => Application => Local Storage
  login(model: any) {
    return this.http.post<User>(this.baseurl + 'account/login', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })  
    )
  }


  register(model: any) {
    return this.http.post<User>(this.baseurl + 'account/register', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
        return user;
      })  
    )
  }


//On logout remove the user from local storage and set the current user to null
  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}