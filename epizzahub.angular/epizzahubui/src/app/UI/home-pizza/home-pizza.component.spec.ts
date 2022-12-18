/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { GbobalEventService } from 'src/app/services/gbobal-event.service';
import { HomePizzaComponent } from './home-pizza.component';
import { PizzaService } from 'src/app/services/pizza.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { of } from 'rxjs';
import { Pizzas } from 'src/app/models/pizzas';

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

describe('HomePizzaComponent', () => {
  let component: HomePizzaComponent;
  let fixture: ComponentFixture<HomePizzaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ],
      declarations: [HomePizzaComponent],
      providers: [
        GbobalEventService,
        PizzaService,
        NgbModal
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomePizzaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call ngOnInit', () => {
    const fixture = TestBed.createComponent(HomePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    let spygetAllPizzas = spyOn(component, "getAllPizzas").and.returnValue([]);
    component.ngOnInit();
    expect(component.pizzasData$).toEqual([]);
  })

  it('should call getAllPizzas and get response as array', () => {
    const fixture = TestBed.createComponent(HomePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    const service = fixture.debugElement.injector.get(PizzaService);
    let spygetAllPizzas = spyOn(service, "getAllPizzas").and.callFake(() => {
      return of(mockPizzas);
    });
    component.getAllPizzas();
    expect(component.pizzasData$).toEqual(mockPizzas);
  });

  it('should call getAllPizzas and get response as empty array', () => {
    const fixture = TestBed.createComponent(HomePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    const service = fixture.debugElement.injector.get(PizzaService);
    let spygetAllPizzas = spyOn(service, "getAllPizzas").and.callFake(() => {
      return of([]);
    });
    component.getAllPizzas();
    expect(component.pizzasData$).toEqual([]);
  });

  // it('should call getAllPizzas and get response as empty array', () => {
  //   const fixture = TestBed.createComponent(HomePizzaComponent);
  //   const component = fixture.debugElement.componentInstance;
  //   component.pizzasData$ =mockPizzas;
  //   let spygetAllPizzas = spyOn(component,"selectedPizza").and.returnValue(mockPizzas[0]);
  //   component.selectedPizza();
  //   expect(component.pizzasData$).toEqual([]);
  // });
});
