/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { OrderService } from './order.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Order } from '../models/order';
import { NULL_EXPR } from '@angular/compiler/src/output/output_ast';

export const mockOrder: Order =
{
  id: 4,
  userId: 1,
  orderDate: new Date(),
  pizza: {
    id: 1,
    name: "Margherita",
    price: 289,
    sizeId: 1,
    isVeg: true,
    imageUrl: "http://localhost:5000/images/margherita.jpg",
    description: "Cheese, Onion",
    sepcialStatus: "Most Popular",
    ingredientIds: [
      1,
      3
    ]
  },
  pizzaToppings: [
    {
      id: 1,
      name: "Cheese",
      description: "",
      price: 5,
      isVeg: true
    },
    {
      id: 3,
      name: "Onion",
      description: "",
      price: 6,
      isVeg: true
    },
    {
      id: 0,
      name: "Extra Cheese",
      description: "",
      price: 5,
      isVeg: true
    }
  ],
  pizzaSauces: [
    {
      id: 1,
      name: "Pesto",
      description: "",
      price: 5
    }
  ],
  nonPizzas: [
    {
      id: 4,
      name: "Choco Sundae",
      description: "Choco Sundae Cup (100 ml)",
      price: 29
    }
  ],
  totalPrice: 339,
  numberOfPizza: 1
};

describe('OrderService', () => {
  let httpTestingController: HttpTestingController;
  let service: OrderService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OrderService],
      imports: [HttpClientTestingModule]
    });

    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.get(OrderService);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getOrderByOrderId should return Order', () => {
    service.getOrderByOrderId(4).subscribe((order: any) => {
      expect(order).not.toBe(null);
      expect(JSON.stringify(order)).toEqual(JSON.stringify(mockOrder));
    });

    const req = httpTestingController
      .expectOne(`http://localhost:5000/api/orders/?orderId=4`);

    req.flush(mockOrder);
  });

  it('getUserOrders should return user orders', () => {
    service.getUserOrders(1).subscribe((order: any) => {
      expect(order).not.toBe(null);
      expect(JSON.stringify(order)).toEqual(JSON.stringify(mockOrder));
    });

    const req = httpTestingController
      .expectOne(`http://localhost:5000/api/orders/userorders?userId=1`);

    req.flush(mockOrder);
  });

  it('SaveOrder should return Order', () => {
    service.SaveOrder(mockOrder).subscribe((order: any) => {
      expect(order).not.toBe(null);
      expect(JSON.stringify(order)).toEqual(JSON.stringify(mockOrder));
    });

    const req = httpTestingController
      .expectOne(`http://localhost:5000/api/orders/`);

    req.flush(mockOrder);
  });

});
