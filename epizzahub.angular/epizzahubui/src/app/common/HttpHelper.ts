import { HttpHeaders, HttpRequest } from "@angular/common/http";
import { GlobalVars as G } from "../services/app.global.service";

export class HttpHelper {

  public static getRequestHeader(request: HttpRequest<any>): any {
    const customHeader = new HttpHeaders({
      'userId': G.instance.userid.toString()
    });

    return request.clone({ headers: customHeader });
  }

}
