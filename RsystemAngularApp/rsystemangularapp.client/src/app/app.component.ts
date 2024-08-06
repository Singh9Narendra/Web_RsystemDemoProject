import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ResponseDto } from '../Interface/ResponseDto';
import { Stories } from '../Interface/Stories';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public stories: Stories[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getStories();
  }

  getStories() {
    this.http.get<ResponseDto[]>('http://localhost:5237/api/Stories').subscribe(
      (result) => {
        ///  this.stories = result;
        console.log("", result)
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'rsystemangularapp.client';
}
