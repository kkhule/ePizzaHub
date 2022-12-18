import { Component, OnInit } from '@angular/core';
import { GbobalEventService } from './services/gbobal-event.service';
import { ToastrInfo } from './models/toastrInfo';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ePizza Hub';

  constructor(private globalEvent$: GbobalEventService, private toastr: ToastrService,
    private router: Router, private ngxSpinner$: NgxSpinnerService) {
  }

  ngOnInit() {

    this.router.navigate(['/app-home-pizza']);

    this.globalEvent$.spinner.subscribe(x => {
      if (x.toUpperCase() == 'SHOW') {
        this.ngxSpinner$.show();
      }
      else if (x.toUpperCase() == 'HIDE') {
        this.ngxSpinner$.hide();
      }
    })

    this.globalEvent$.notification.subscribe(x => {

      let toastrInfo = (x as ToastrInfo);

      switch (toastrInfo.type.toUpperCase()) {
        case 'INFO':
          this.toastr.info(toastrInfo.message, toastrInfo.title);
          break;

        case 'SUCCESS':
          this.toastr.success(toastrInfo.message, toastrInfo.title);
          break;

        case 'ERROR':
          this.toastr.error(toastrInfo.message, toastrInfo.title);
          break;

        case 'WARNING':
          this.toastr.warning(toastrInfo.message, toastrInfo.title);
          break;
      }
    });

  }

}
