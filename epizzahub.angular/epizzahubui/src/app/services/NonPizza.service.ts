import { Observable } from 'rxjs';
import { Nonpizzas } from './../models/nonpizzas';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NonPizzaService {

  private localUrl = environment.API_URL + 'nonpizzas/';

  constructor(private http:HttpClient) {
  
   }

   getAllNonPizzaItems():Observable<Nonpizzas[]> {
    return this.http.get<Nonpizzas[]>(this.localUrl + 'nonpizzas');
  } 

}
