import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderTicketService } from 'src/app/Services/order-ticket.service';
import { TripServiceService } from 'src/app/Services/trip-service.service';
import { CustomerServiceService } from 'src/app/Services/user-service.service';
import { OrderTicket } from 'src/app/classes/OrderTicket';
import { Trip } from 'src/app/classes/Trip';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.css']
})
export class TripDetailsComponent implements OnInit {
  trip: Trip = new Trip();
  id: Number = 0;
  open: boolean = false;
  openSuccesOrder: boolean = false;
  openErrorOrder: boolean = false;
  numOfPlaces: number = 0;
  openErrorPlaces: boolean = false;

  constructor(public r: ActivatedRoute,
    public tripService: TripServiceService,
    public customerService: CustomerServiceService,
    public orderSer: OrderTicketService) {
  }
  today: Date = new Date();
  ngOnInit(): void {
    console.log(this.r.params);
    //שליפת קוד הטיול משורת הניתוב 
    const tripId = Number(this.r.snapshot.paramMap.get('tripId'))
    console.log(tripId);
    //שליפת הטיול 
    this.tripService.getTripById(tripId).subscribe(
      (succ => {
        console.log(succ);
        this.today = succ.date!
        // this.today=succ.date
        this.trip = succ
      })
    )

  }
  //פונקציה לפתיחת שדה להכנסת כמות כרטיסים 
  openOrder() {
    this.open = true
  }
  //פונקציה של הזמנת הכרטיסים
  order() {
    //אם כמות מקומות פנוים גדולה מהכמות שרוצה להזמין 
    if (this.trip.emptyPlaces! > this.numOfPlaces) {
      debugger
      //הגדרת הזמנה חדשה
      const newOrder: OrderTicket =
        new OrderTicket(0,
          this.customerService.currentUser.custId,
          new Date(),
          undefined,
          this.trip.tripId,
          this.numOfPlaces,
          "",
          ""
        )
      console.log(newOrder);
      //שליחה לקריאת שרת להוספת הזמנה   
      this.orderSer.addOrder(newOrder).subscribe(
        succes => {
          Swal.fire({
            title: "succes!!",
            text: "Enjoy at" + this.trip.destination,
            icon: "success"
          });
          
        },
        err => {
          console.log(err);
          this.openErrorOrder = true
        }
      )
    }
    //אם אין מספיק מקומות להזמין לטיול 
    else {
      Swal.fire({
        icon: "error",
        title: "No places enough...",
        text: "Sorry,try diffrent trip!",
      });
      this.openErrorPlaces = true
    }
  }
}
