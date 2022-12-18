import { OrderService } from './../../services/order.service';
import { Router } from '@angular/router';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal, ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Order } from 'src/app/models/order';
import * as _ from 'lodash'
import { GbobalEventService } from 'src/app/services/gbobal-event.service';
import { ToastrInfo } from 'src/app/models/toastrInfo';
import { GlobalVars } from 'src/app/services/app.global.service';
import { Content } from '@angular/compiler/src/render3/r3_ast';

@Component({
  selector: 'app-pizza-order-confirmation',
  templateUrl: './pizza-order-confirmation.component.html',
  styleUrls: ['./pizza-order-confirmation.component.css']
})
export class PizzaOrderConfirmationComponent implements OnInit {

  @Input() public mySummaryOrders: Order[];
  @Output() messageEvent = new EventEmitter<any>();
  orderId: number;

  constructor(private actievModal: NgbActiveModal, private modalService: NgbModal, private router: Router, private pizzaOrderService: OrderService, private globalEvent$: GbobalEventService, private globalVars: GlobalVars) {

  }

  ngOnInit() {
  }

  editOrder() {
  }

  placeOrder() {
    this.mySummaryOrders[0].userId = this.globalVars.userid;
    this.pizzaOrderService.SaveOrder(this.mySummaryOrders[0]).subscribe(
      {
        next: (resp: any) => {
          if (!_.isNil(resp)) {
            this.orderId = resp.id;
            this.globalEvent$.notification.next(new ToastrInfo('success', `Your order is placed. \nOrder Id: ${this.orderId}`))
            this.actievModal.close();
          }
        },
        error: e => {
          this.globalEvent$.notification.next(new ToastrInfo('error', 'Failed to save order.Please try again.'));
        },
        complete() { }
      }
    );
  }

  onClose() {
    this.actievModal.close();
  }


  // open(content: any) {
  // 	this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
  // 		(result) => {
  // 			this.closeResult = `Closed with: ${result}`;
  // 		},
  // 		(reason) => {
  // 			this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
  // 		},
  // 	);
  // }


  // private getDismissReason(reason: any): string {
  // 	if (reason === ModalDismissReasons.ESC) {
  // 		return 'by pressing ESC';
  // 	} else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
  // 		return 'by clicking on a backdrop';
  // 	} else {
  // 		return `with: ${reason}`;
  // 	}
  // }

}
