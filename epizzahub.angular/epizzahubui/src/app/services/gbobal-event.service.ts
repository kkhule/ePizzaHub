import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ToastrInfo } from '../models/toastrInfo';

@Injectable({
  providedIn: 'root'
})
export class GbobalEventService {

  spinner = new Subject<any>();
  notification = new Subject<ToastrInfo>();

  constructor() { }

}
