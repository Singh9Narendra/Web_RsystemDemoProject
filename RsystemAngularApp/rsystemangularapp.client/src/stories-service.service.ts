import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseDto } from './Interface/ResponseDto';

@Injectable({
  providedIn: 'root'
})
export class StoriesServiceService {

  constructor(private http: HttpClient) { }

  getStories() {
    return this.http.get<ResponseDto>('http://localhost:5237/api/Stories');
  }


}
