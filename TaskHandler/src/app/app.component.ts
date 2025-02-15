import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit  {
  
  private accountService = inject(AccountService);

 // This is where you make your http calls
  ngOnInit(): void {
    this.setCurrentUser();
  }

  //Read the user from local storage and set the current user
  //This is so that when the page is refreshed the user is still logged in
setCurrentUser() {
  const userString = localStorage.getItem('user');
  if (!userString) return;  
  const user = JSON.parse(userString);
  this.accountService.currentUser.set(user);
}

}
