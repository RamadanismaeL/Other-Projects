import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
/**
 ** @author Ramadan Ismael
 */
@Injectable({
  providedIn: 'root'
})
export class GithubService {
  url: string = 'https://api.github.com/';
  constructor(private http: HttpClient)
  {}

  getUsers()
  {
    return this.http.get<any>(this.url+'users').pipe(map((response) => {
      return response;
    }));
  }
}
