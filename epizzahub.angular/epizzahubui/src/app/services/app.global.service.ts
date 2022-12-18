import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable()
export class GlobalVars {

  static instance: GlobalVars;

  userid: number = environment.UserId;
  appName: string = environment.AppName;

  constructor() { }

}
