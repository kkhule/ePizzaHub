import { Sauces } from './../models/sauces';
import { Toppings } from './../models/toppings';
import { Pizzas } from './../models/pizzas';
import { PizzaSize } from '../models/pizzaSize';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  private localUrl = environment.API_URL + 'pizzas/';

  constructor(private http: HttpClient) {

  }

  public getAllPizzas(): Observable<Pizzas[]> {

    return this.http.get<Pizzas[]>(this.localUrl + "pizzas");
  }


  public getAllToppings(): Observable<Toppings[]> {
    return this.http.get<Toppings[]>(this.localUrl + 'toppings');
  }

  public getAllSauces(): Observable<Sauces[]> {
    return this.http.get<Sauces[]>(this.localUrl + 'sauces');
  }

  public getAllPizzaSizes(): Observable<PizzaSize[]> {
    return this.http.get<PizzaSize[]>(this.localUrl + 'sizes');
  }

}
