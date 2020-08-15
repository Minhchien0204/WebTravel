import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { Observable, from } from 'rxjs';
import { Users } from './../Models/users.class';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  public API: string = '';
  public API_register: string = '';


  constructor(
    private http: HttpClient,
  ) 
  { }

  

// get all users
  getAllUsers(): Observable<Users[]>
  {
    return this.http.get<Users[]>(this.API)
  }


  // get user
  getUser(IdUser: number): Observable<Users>
  {
    return this.http.get<Users>(this.API + IdUser)
  }

  // add user
  getAdd(user: Users): Observable<Users>
  {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }

    return this.http.post<Users>(this.API_register, user, httpOptions)
  }

  // delete user
  deleteUser(IdUser: number): Observable<Users>
  {
    return this.http.delete<Users>(this.API + IdUser)
  }
  handleError(err){
    if(err.error instanceof Error){
      console.log('client-side error : ${err.error.message}');
    }
    else{
      console.log('Server-side error : ${err.status} - ${err.error}');
    }
  }
}
