import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './layout/header/header.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  baseUrl = 'https://localhost:5000/api/'
  private http = inject(HttpClient);

  title = 'Skinet';

  ngOnInit(): void {

    this.http.get(this.baseUrl +'products').subscribe({
      next: data => console.log(data),
      error: error => console.log(error),
      complete: () => console.log('complete')
    })
  
  }

}
