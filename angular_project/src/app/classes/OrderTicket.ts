import { Time } from "@angular/common";

export class OrderTicket{
    [x: string]: any;
    constructor(
        public ordId?:number,
        public custId?:number,
        public ordDate?:Date,
        public ordTime?:Time,
        public tripId?:number,
        public countPlaces?:number,
        public customerFullName?:string,
        public destination?:string,
        public tripDate?:Date   
        ){

    }
}