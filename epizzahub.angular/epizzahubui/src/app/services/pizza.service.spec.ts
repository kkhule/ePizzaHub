import { PizzaSize } from './../models/pizzaSize';
import { Sauces } from './../models/sauces';
import { Toppings } from './../models/toppings';
import { Pizzas } from './../models/pizzas';
/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PizzaService } from './pizza.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';


export const mockPizzas: Pizzas[] =

  [
    {
      id: 1,
      name: "Margherita",
      description: "Cheese, Onion",
      price: 289,
      imageUrl: "images/margherita.jpg",
      sizeId: 1,
      isVeg: false,
      sepcialStatus: "Most Popular",
      ingredientIds: [1, 3]
    }
    ,
    {
      id: 2,
      name: "Tandoori Paneer",
      description: "Spiced paneer, Onion, Green Capsicum & Red Paprika in Tandoori Sauce",
      price: 539,
      imageUrl: "images/tandoori-paneer.jpg",
      sizeId: 1,
      isVeg: false,
      sepcialStatus: "Most Popular",
      ingredientIds: [2, 3, 4, 11]

    }
  ];

export const mockToppings: Toppings[] =
  [
    {
      id: 1,
      name: "Cheeze",
      description: "",
      price: 5,
      isVeg: false
    }
    ,
    {
      id: 2,
      name: "Spinced Panner",
      description: "",
      price: 10,
      isVeg: false
    }
  ];

export const mockSauces: Sauces[] =
  [
    {
      id: 1,
      name: "Pesto",
      description: "",
      price: 10
    }
    ,
    {
      id: 2,
      name: "Garlic Ranch Sauce",
      description: "",
      price: 13
    }
  ];

export const mockSizes: PizzaSize[] =
  [
    {
      id: 1,
      name: "Small",
      multiplier: 1
    }
    ,
    {
      id: 2,
      name: "Medium",
      multiplier: 1.5
    }
  ];

describe('PizzaService', () => {
  let httpTestingController: HttpTestingController;
  let service: PizzaService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PizzaService],
      imports: [HttpClientTestingModule]
    });

    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.get(PizzaService);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getAllPizzas should provide Pizza data', () => {
    service.getAllPizzas().subscribe((pizza: Pizzas[]) => {
      expect(pizza).not.toBe([]);
      expect(JSON.stringify(pizza)).toEqual(JSON.stringify(mockPizzas));
    });

    const req = httpTestingController
      .expectOne(`http://localhost:5000/api/pizzas/pizzas`);

    req.flush(mockPizzas);
  });

  it('getAllToppings should provide Topping data', () => {
    service.getAllToppings().subscribe((toppings: Toppings[]) => {
      expect(toppings).not.toBe([]);
      expect(JSON.stringify(toppings)).toEqual(JSON.stringify(mockToppings));
    });

    const req = httpTestingController
      .expectOne(`http://localhost:5000/api/pizzas/toppings`);

    req.flush(mockToppings);
  });

  it('getAllSauces should provide Sauces data', () => {
    service.getAllSauces().subscribe((sauces: Sauces[]) => {
      expect(sauces).not.toBe([]);
      expect(JSON.stringify(sauces)).toEqual(JSON.stringify(mockSauces));
    });

    const req = httpTestingController
      .expectOne(`http://localhost:5000/api/pizzas/sauces`);

    req.flush(mockSauces);
  });

  it('getAllPizzaSizes should provide Pizza Size data', () => {
    service.getAllPizzaSizes().subscribe((sizes: PizzaSize[]) => {
      expect(sizes).not.toBe([]);
      expect(JSON.stringify(sizes)).toEqual(JSON.stringify(mockSizes));
    });

    const req = httpTestingController
      .expectOne(`http://localhost:5000/api/pizzas/sizes`);

    req.flush(mockSizes);
  });

});

