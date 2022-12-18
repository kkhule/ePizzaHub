import { OrderService } from './../../services/order.service';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { GbobalEventService } from 'src/app/services/gbobal-event.service';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { GlobalVars } from 'src/app/services/app.global.service';
import { PizzaOrderConfirmationComponent } from './pizza-order-confirmation.component';
import { Order } from 'src/app/models/order';
import { of } from 'rxjs';


export const mockOrders: Order[] =
  [{
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
  }];

export const mockGlobalVars: GlobalVars = new GlobalVars();
mockGlobalVars.appName = "ePizzaHub";
mockGlobalVars.userid = 1;

describe('PizzaOrderConfirmationComponent', () => {
  let component: PizzaOrderConfirmationComponent;
  let fixture: ComponentFixture<PizzaOrderConfirmationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ],
      declarations: [PizzaOrderConfirmationComponent],
      providers: [
        GbobalEventService,
        OrderService,
        NgbActiveModal,
        { provide: GlobalVars, useValue: mockGlobalVars }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PizzaOrderConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call placeOrder and get response as Order Id', () => {
    const fixture = TestBed.createComponent(PizzaOrderConfirmationComponent);
    const component = fixture.debugElement.componentInstance;
    component.mySummaryOrders = mockOrders;
    const service = fixture.debugElement.injector.get(OrderService);
    let spyplaceOrder = spyOn(service, "SaveOrder").and.callFake(() => {
      return of(mockOrders[0]);
    });
    component.placeOrder();
    expect(component.orderId).toEqual(mockOrders[0].id);
  });

});
