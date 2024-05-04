import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserBody, UserDTO } from 'src/app/models/User';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  url: string = environment.baseAPIurl;
  constructor(private http: HttpClient) { }

  home(): Observable<UserDTO[]> {
    return this.http.get<UserDTO[]>(this.url);
  }

  getUserById(id: number): Observable<UserDTO> {
    return this.http.get<UserDTO>(`${this.url}/${id}`);
  }

  addUser(user: UserBody): Observable<UserBody> {
    return this.http.post<UserBody>(this.url, user);
  }

  updateUser(id: number, user: UserBody): Observable<UserBody> {
    return this.http.put<UserBody>(`${this.url}/${id}`, user);
  }

  deleteUser(id: number): Observable<UserBody> {
    return this.http.delete<UserBody>(`${this.url}/${id}`);
  }
}
