/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NonPizzaService } from './NonPizza.service';
import { Nonpizzas } from '../models/nonpizzas';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';


export const mockNonPizzas: Nonpizzas[] =

  [
    {
      id: 1,
      name: "Pepsi",
      description: "Contains Caffeine",
      price: 67
    }
    ,
    {
      id: 2,
      name: "Mirinda",
      description: "Contains Caffeine",
      price: 80,
    }
  ];


describe('NonPizzaService', () => {
  let httpTestingController: HttpTestingController;
  let service: NonPizzaService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NonPizzaService],
      imports: [HttpClientTestingModule]
    });

    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.get(NonPizzaService);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getAllNonPizzaItems should provide Non Pizza Items', () => {
    service.getAllNonPizzaItems().subscribe((nonPizza: Nonpizzas[]) => {
      expect(nonPizza).not.toBe([]);
      expect(JSON.stringify(nonPizza)).toEqual(JSON.stringify(mockNonPizzas));
    });

    const req = httpTestingController
      .expectOne(`http://localhost:5000/api/nonpizzas/nonpizzas`);

    req.flush(mockNonPizzas);
  });
});
