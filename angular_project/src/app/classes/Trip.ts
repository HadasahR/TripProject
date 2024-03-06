import { Time } from "@angular/common";

export class Trip{
    constructor(
        public tripId?:number,
        public destination?:string,
        public typeId?:number,
        public typeName?:number,
        public date?:Date,
        public leavingHour?:Time,
        public howLong?:number,
        public emptyPlaces?:number,
        public price?:number,
        public img?:string,
        public isFirstAid?:boolean

        ){

    }
}