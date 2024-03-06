import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Type } from '../classes/Type';

@Injectable({
  providedIn: 'root'
})
export class TypeService {

  constructor(public http:HttpClient) { }
  getAllTypes():Observable<Array<Type>>
  {
    return this.http.get<Array<Type>>("https://localhost:7118/api/Type")
  }
}
