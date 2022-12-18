import { OrderService } from './../../services/order.service';
import { Router } from '@angular/router';
import { Order } from './../../models/order';
import { Pizzas } from './../../models/pizzas';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import * as _ from 'lodash'
import { GbobalEventService } from 'src/app/services/gbobal-event.service';
import { ToastrInfo } from 'src/app/models/toastrInfo';
import { GlobalVars } from 'src/app/services/app.global.service';

@Component({
  selector: 'app-pizza-order-summary',
  templateUrl: './pizza-order-summary.component.html',
  styleUrls: ['./pizza-order-summary.component.css']
})
export class PizzaOrderSummaryComponent implements OnInit {


  @Input() myOrders$: Order[] = [];
  @Input() public isOrderConfirmation: boolean;

  constructor(private router: Router, private pizzaOrderService: OrderService, private globalEvent$: GbobalEventService, private globalVars: GlobalVars) {

  }

  ngOnInit() {

    if (!this.isOrderConfirmation) {
      this.loadMyOrders();
    }
  }

  loadMyOrders() {
    this.pizzaOrderService.getUserOrders(this.globalVars.userid).subscribe(
      {
        next: (resp: any) => {
          if (!_.isNil(resp)) {
            this.myOrders$ = resp;
          }
        },
        error: e => {
          this.globalEvent$.notification.next(new ToastrInfo('error', 'Failed to load My Orders.Please try again.'));
        },
        complete() { }
      }
    );
  }

  initOrderForm() {
  }

}
