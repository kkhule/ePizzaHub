import { Order } from './../../models/order';
import { PizzaOrderConfirmationComponent } from './../pizza-order-confirmation/pizza-order-confirmation.component';
import { CustomisePizzaComponent } from './../customise-pizza/customise-pizza.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { Pizzas } from './../../models/pizzas';
import { Component, OnInit } from '@angular/core';
import { PizzaService } from 'src/app/services/pizza.service';
import * as _ from "lodash";
import { GbobalEventService } from 'src/app/services/gbobal-event.service';
import { ToastrInfo } from 'src/app/models/toastrInfo';

@Component({
  selector: 'app-home-pizza',
  templateUrl: './home-pizza.component.html',
  styleUrls: ['./home-pizza.component.css']
})
export class HomePizzaComponent implements OnInit {

  pizzasData$: Pizzas[] = [];


  constructor(private pizzaService$: PizzaService, private router: Router, private modal$: NgbModal, private globalEvent$: GbobalEventService) { }

  ngOnInit() {
    this.getAllPizzas();

  }


  selectedPizza(id: number) {
    let selectedPizza = this.pizzasData$.filter(t => t.id == id)[0];
    this.onOpenCustmoisePizzaDialog(selectedPizza);
  }

  onOpenCustmoisePizzaDialog(selectedPizza: Pizzas) {
    const modelRef = this.modal$.open(CustomisePizzaComponent, { centered: true, windowClass: 'app-modal-window', ariaLabelledBy: 'modal-basic-title', size: 'lg' });
    modelRef.componentInstance.selectedPizza = _.cloneDeep(selectedPizza);
    modelRef.componentInstance.messageEvent.subscribe(this.customisePizzaModalCallBack)
  }

  public customisePizzaModalCallBack: (response: any) => void = (response) => {
    const modelRef = this.modal$.open(PizzaOrderConfirmationComponent, { centered: true });
    let orders: Order[] = [];
    orders.push(response);
    modelRef.componentInstance.mySummaryOrders = orders;
    modelRef.componentInstance.messageEvent.subscribe(this.pizzaOrderConfirmationModalCallBack)
  }

  public pizzaOrderConfirmationModalCallBack: (response: any) => void = (response) => {

  }


  getAllPizzas() {
    this.pizzaService$.getAllPizzas().subscribe(
      {
        next: (resp: Pizzas[]) => {
          if (!_.isNil(resp)) {
            this.pizzasData$ = resp;
          }
        },
        error: e => {
          this.globalEvent$.notification.next(new ToastrInfo('error', 'Failed to load Pizzas.Please try again.'));
        },
        complete() { }
      }
    );
  }

}
