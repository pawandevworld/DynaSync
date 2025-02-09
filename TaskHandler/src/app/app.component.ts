import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit  {
  //Set ability to make http requests to this components
  http = inject(HttpClient);
  title = 'CT Task Handler';
  users: any;//this is used for the ngOnInit step to cors in ts file

 // This is where you make your http calls
  ngOnInit(): void {
    this.http.get('http://localhost:5083/devpulse/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () =>console.log('Request has completed')
      //once the complete is reached the http request always completes so we do not need to unsubscribe
    })
  }
}
