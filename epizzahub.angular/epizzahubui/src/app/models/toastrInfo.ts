import { GlobalVars as G } from "../services/app.global.service";

export class ToastrInfo {

    type: string;
    message: string;
    title?: string = "ePizzaHub";

    constructor(type: string, message: string) {
        this.type = type;
        this.message = message;
    }
}
