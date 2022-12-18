import { Order } from './../models/order';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private localUrl = environment.API_URL + 'orders/';

  constructor(private http: HttpClient) {

  }

  getOrderByOrderId(orderId: number): Observable<Order> {
    let htttParams = new HttpParams().set("orderId", orderId);
    let options = { params: htttParams };
    return this.http.get<Order>(this.localUrl, options);
  }

  getUserOrders(userid: number): Observable<Order[]> {
    let htttParams = new HttpParams().set("userId", userid);
    let options = { params: htttParams };
    return this.http.get<Order[]>(this.localUrl + 'userorders', options);
  }

  SaveOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(this.localUrl, order);
  }

}
