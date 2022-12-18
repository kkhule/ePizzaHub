import { Order } from './../../models/order';
import { SelectedItem } from './../../models/selectedItem';
import { Nonpizzas } from './../../models/nonpizzas';
import { NonPizzaService } from './../../services/NonPizza.service';
import { Pizzas } from './../../models/pizzas';
import { Sauces } from './../../models/sauces';
import { Toppings } from './../../models/toppings';
import { PizzaSize } from './../../models/pizzaSize';
import { Router } from '@angular/router';
import { PizzaService } from './../../services/pizza.service';
import { LEADING_TRIVIA_CHARS } from '@angular/compiler/src/render3/view/template';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import * as _ from "lodash";
import { GbobalEventService } from 'src/app/services/gbobal-event.service';
import { ToastrInfo } from 'src/app/models/toastrInfo';

@Component({
  selector: 'app-customise-pizza',
  templateUrl: './customise-pizza.component.html',
  styleUrls: ['./customise-pizza.component.css']
})
export class CustomisePizzaComponent implements OnInit {
  closeResult = '';

  @Input() public selectedPizza: Pizzas;
  @Output() messageEvent = new EventEmitter<any>();

  /* #load Properties  */
  pizzaSizes$: PizzaSize[] = [];
  pizzaIngredients$: Toppings[] = [];
  pizzaToppings$: Toppings[] = [];
  pizzaSauces$: Sauces[] = [];
  nonPizzaItems$: Nonpizzas[] = [];
  NoOfQuantity: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
  /* #endregion */

  /* #filter Properties  */
  filteredToppings$: Toppings[];
  selectedCrust: any;
  basePizzaPrice: number;
  pizzaPriceBasedOnCrist: number;
  /* #endregion */

  /* #selected  Properties */
  pizzaIngredientsItems$: SelectedItem[] = [];
  pizzaToppingsItems$: SelectedItem[] = [];
  pizzaSaucesItems$: SelectedItem[] = [];
  nonPizzasItems$: SelectedItem[] = [];
  /* #endregion */

  /* #form fields  */
  totalPizzaPrice: number = 0;
  selectedNoOfQuantity: number = 1;
  /* #endregion */

  /* #Keys  */
  pizzaPriceKey: string = "PizzaPrice";
  pizzaIngredientKey: string = "PizzaIngredient";
  pizzaToppingKey: string = "PizzaTopping";
  pizzaSaucesKey: string = "PizzaSauces";
  pizzaNonItemKey: string = "PizzaNonItem";
  pizzaItemspriceDictionary: { [key: string]: number } = {};
  /* #endregion */

  constructor(private actievModal: NgbActiveModal, private pizzaService$: PizzaService, private router: Router, private nonPizzaService$: NonPizzaService, private globalEvent$: GbobalEventService) {

    this.pizzaItemspriceDictionary[this.pizzaPriceKey] = 0;
    this.pizzaItemspriceDictionary[this.pizzaIngredientKey] = 0;
    this.pizzaItemspriceDictionary[this.pizzaToppingKey] = 0;
    this.pizzaItemspriceDictionary[this.pizzaSaucesKey] = 0;
    this.pizzaItemspriceDictionary[this.pizzaNonItemKey] = 0;

  }

  ngOnInit() {

    this.getAllPizzaSizes();
    this.getAllPizzaToppings();
    this.getAllPizzaSauces();
    this.getAllNonPizzaItems();
    this.pizzaPriceBasedOnCrist = this.basePizzaPrice = this.selectedPizza.price;
    this.pizzaItemspriceDictionary[this.pizzaPriceKey] = this.basePizzaPrice;
    this.setTotalPrice();
  }

  /* # Calculate Total price methods  */
  selectedPizzaSize(pizzaSize: any) {
    this.selectedCrust = pizzaSize;
    this.pizzaPriceBasedOnCrist = Math.trunc(this.basePizzaPrice * (pizzaSize as PizzaSize).multiplier);
    this.pizzaItemspriceDictionary[this.pizzaPriceKey] = this.pizzaPriceBasedOnCrist;
    this.setTotalPrice();
  }

  selectedQuntityofPizza(qty: any) {
    this.selectedNoOfQuantity = +qty;
    this.setTotalPrice();
  }

  setTotalPrice() {
    let totalSum = 0;
    for (let key in this.pizzaItemspriceDictionary) {
      totalSum += this.pizzaItemspriceDictionary[key];
    }
    this.totalPizzaPrice = Math.trunc(this.selectedNoOfQuantity * totalSum);
  }

  getSumPriceOfPizzaItems(items: any): number {
    const sum = items.filter((item: any) => item.isSelect == true)
      .reduce((sum: any, current: any) => sum + current.data.price, 0);
    return sum;
  }
  /* #endregion */


  /* #selected toppings, sauces, non pizza items methods  */
  CheckedUncheckedPizzaItems(checked: boolean, id: number, data: any) {
    data.forEach((element: any) => {
      if ((element.data).id == id) {
        element.isSelect = checked;
      }
    });
  }

  checkPizzaItemsIsNull(items: any): boolean {
    if (!_.isNull(items.target) && !_.isUndefined(items.target)) {
      if (!_.isNull(items.target.value) && !_.isUndefined(items.target.value)) {
        return false;
      }
    }
    return true;
  }

  selectedIngredient(ingre: any) {
    if (!this.checkPizzaItemsIsNull(ingre)) {
      let id = ingre.target.value;
      this.CheckedUncheckedPizzaItems(ingre.target.checked, id, this.pizzaIngredientsItems$);

      let sum = this.getSumPriceOfPizzaItems(this.pizzaIngredientsItems$);

      this.pizzaItemspriceDictionary[this.pizzaIngredientKey] = sum;
      this.setTotalPrice();
    }
  }

  selectedTopping(topping: any) {
    if (!this.checkPizzaItemsIsNull(topping)) {
      let id = topping.target.value;
      this.CheckedUncheckedPizzaItems(topping.target.checked, id, this.pizzaToppingsItems$);

      let sum = this.getSumPriceOfPizzaItems(this.pizzaToppingsItems$);

      this.pizzaItemspriceDictionary[this.pizzaToppingKey] = sum;
      this.setTotalPrice();
    }

  }

  selectedSauces(sauce: any) {
    if (!this.checkPizzaItemsIsNull(sauce)) {
      let id = sauce.target.value;
      this.CheckedUncheckedPizzaItems(sauce.target.checked, id, this.pizzaSaucesItems$);

      let sum = this.getSumPriceOfPizzaItems(this.pizzaSaucesItems$);

      this.pizzaItemspriceDictionary[this.pizzaSaucesKey] = sum;
      this.setTotalPrice();
    }

  }

  selectedNonPizzaItem(nonPizza: any) {
    if (!this.checkPizzaItemsIsNull(nonPizza)) {
      let id = nonPizza.target.value;
      this.CheckedUncheckedPizzaItems(nonPizza.target.checked, id, this.nonPizzasItems$);

      let sum = this.getSumPriceOfPizzaItems(this.nonPizzasItems$);

      this.pizzaItemspriceDictionary[this.pizzaNonItemKey] = sum;
      this.setTotalPrice();
    }

  }
  /* #endregion */

  /* # filtered toppings, sauces, sizes and non pizza items methods  */
  defaultPizzaCrust() {
    let id = this.selectedPizza.sizeId;
    this.selectedCrust = this.pizzaSizes$.find(t => t.id == id);
  }

  getSelectedPizzaIngredients() {
    let ids = this.selectedPizza.ingredientIds;
    this.pizzaIngredients$ = _.cloneDeep(this.pizzaToppings$.filter(t => ids.includes(t.id)));
    this.pizzaIngredients$.forEach(t => this.pizzaIngredientsItems$.push(new SelectedItem(true, t)));

    let sum = this.getSumPriceOfPizzaItems(this.pizzaIngredientsItems$);
    this.pizzaItemspriceDictionary[this.pizzaIngredientKey] = sum;
    this.setTotalPrice();

  }

  filterToppings() {
    let ids = this.selectedPizza.ingredientIds;
    let isVeg = this.selectedPizza.isVeg;
    this.filteredToppings$ = _.cloneDeep(this.pizzaToppings$.filter(t => !ids.includes(t.id) && (isVeg ? t.isVeg == true : true)));
    this.filteredToppings$.forEach(t => this.pizzaToppingsItems$.push(new SelectedItem(false, t)));
  }
  /* #endregion */

  /* # load all toppngs, sauces, sizes and non pizza items methods */
  getAllPizzaSizes() {
    this.pizzaService$.getAllPizzaSizes().subscribe(
      {
        next: (resp: PizzaSize[]) => {
          if (!_.isNil(resp)) {
            this.pizzaSizes$ = _.cloneDeep(resp);
            this.defaultPizzaCrust();
          }
        },
        error: e => {

          this.globalEvent$.notification.next(new ToastrInfo('error', 'Failed to load Pizza Crusts.Please try again.'));

        },
        complete() { }
      }
    );
  }

  getAllPizzaToppings() {
    this.pizzaService$.getAllToppings().subscribe(
      {
        next: (resp: Toppings[]) => {
          if (!_.isNil(resp)) {
            this.pizzaToppings$ = _.cloneDeep(resp);
            this.filterToppings();
            this.getSelectedPizzaIngredients();
          }
        },
        error: e => {
          this.globalEvent$.notification.next(new ToastrInfo('error', 'Failed to load Pizza Toppings.Please try again.'));
        },
        complete() { }
      }
    );
  }

  getAllPizzaSauces() {
    this.pizzaService$.getAllSauces().subscribe(
      {
        next: (resp: any[]) => {
          if (!_.isNil(resp)) {
            this.pizzaSauces$ = _.cloneDeep(resp);
            this.pizzaSauces$.forEach(t => this.pizzaSaucesItems$.push(new SelectedItem(false, t)));
          }
        },
        error: e => {
          this.globalEvent$.notification.next(new ToastrInfo('error', 'Failed to load Sauces.Please try again.'));
        },
        complete() { }
      }
    );
  }

  getAllNonPizzaItems() {
    this.nonPizzaService$.getAllNonPizzaItems().subscribe(
      {
        next: (resp: Nonpizzas[]) => {
          if (!_.isNil(resp)) {
            this.nonPizzaItems$ = _.cloneDeep(resp);
            this.nonPizzaItems$.forEach(t => this.nonPizzasItems$.push(new SelectedItem(false, t)));
          }
        },
        error: e => {
          this.globalEvent$.notification.next(new ToastrInfo('error', 'Failed to load Beverages and Desserts.Please try again.'));
        },
        complete() { }
      }
    );
  }
  /* #endregion */

  /* # get selected toppings, size, sauces and non pizza items and call save api  */
  getAllSelectedToppings(): Toppings[] {
    let toppings: Toppings[] = [];

    let ingere = this.pizzaIngredientsItems$.filter(t => t.isSelect);

    ingere.forEach(element => {
      toppings.push(element.data)
    });

    let topping = this.pizzaToppingsItems$.filter(t => t.isSelect);

    topping.forEach(element => {
      toppings.push(element.data)
    });

    return toppings;
  }

  getAllSelectedSauces(): Sauces[] {
    let sauces: Sauces[] = [];
    let saucesl = this.pizzaSaucesItems$.filter(t => t.isSelect);

    saucesl.forEach(element => {
      sauces.push(element.data)
    });

    return sauces;
  }

  getAllSelectedNonPizzaItems(): Nonpizzas[] {
    let nonPizzas: Nonpizzas[] = [];
    let nonPizzaItems = this.nonPizzasItems$.filter(t => t.isSelect);

    nonPizzaItems.forEach(element => {
      nonPizzas.push(element.data)
    });
    return nonPizzas;
  }

  onCheckout() {
    let pizzaOrder = new Order();
    pizzaOrder.totalPrice = this.totalPizzaPrice;
    pizzaOrder.userId = 1;
    pizzaOrder.numberOfPizza = this.selectedNoOfQuantity;
    pizzaOrder.pizza = _.cloneDeep(this.selectedPizza);
    pizzaOrder.pizza.sizeId = this.selectedCrust.id;
    pizzaOrder.orderDate = new Date();

    pizzaOrder.pizzaToppings = _.cloneDeep(this.getAllSelectedToppings());
    pizzaOrder.pizzaSauces = _.cloneDeep(this.getAllSelectedSauces());
    pizzaOrder.nonPizzas = _.cloneDeep(this.getAllSelectedNonPizzaItems());

    this.messageEvent.emit(pizzaOrder);
    this.actievModal.close();

  }

  onClose() {
    this.actievModal.close();
  }
  /* #endregion */
}
