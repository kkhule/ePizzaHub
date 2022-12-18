import { Nonpizzas } from './nonpizzas';
import { Sauces } from './sauces';
import { Pizzas } from "./pizzas";
import { Toppings } from './toppings';

export class Order {

    public id: number;
    public userId: number;
    public totalPrice: number;
    public numberOfPizza: number;
    public orderDate: Date;

    public pizza: Pizzas;
    public pizzaToppings: Toppings[];
    public pizzaSauces: Sauces[];
    public nonPizzas: Nonpizzas[];

    constructor() {
        this.nonPizzas = [];
        this.pizzaSauces = [];
        this.pizzaToppings = [];
    }
}
