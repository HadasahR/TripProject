import { Component } from '@angular/core';
import { Type } from 'src/app/classes/Type';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TripServiceService } from 'src/app/Services/trip-service.service';
import { TypeService } from 'src/app/Services/type.service';
import { CustomerServiceService } from 'src/app/Services/user-service.service';
import { Customer } from 'src/app/classes/Customer';
import { Trip } from 'src/app/classes/Trip';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { OrderTicket } from 'src/app/classes/OrderTicket';
import { OrderTicketService } from 'src/app/Services/order-ticket.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-user-trip',
  templateUrl: './user-trip.component.html',
  styleUrls: ['./user-trip.component.css']
})
export class UserTripComponent implements OnInit {
  constructor(public customerS: CustomerServiceService,
    public Routing: Router,
    public tripSer: TripServiceService,
    public typeSer: TypeService,
    public orderS: OrderTicketService,

  ) { }
  //פתיחת כפתור לצפיה בטיולים של המשתמש
  openMyTrip: boolean = false;
  //מערך של כל הטיולים 
  myTrips: Array<OrderTicket> = new Array<OrderTicket>();
  //הגדרת המשתמש הנוכחי 
  newCustomer: Customer = new Customer();
  //מערך של סוגי טיולים
  allTypes: Array<Type> = new Array<Type>();
  //אוסף מסונן של כל הטיולים
  filterTrips: Array<OrderTicket> = new Array<OrderTicket>();
  //אוסף של סוגי הטיולים
  typesTrip: Array<Type> = new Array<Type>();
  //אינדקס לסינון לפי סוג הטיול
  selectedType: number = 0;
  //משתנה לפתיחת עריכת פרטי משתמש
  openEditUserDeatails: boolean = false
  ngOnInit(): void {
    //קריאה לקבלת כל ההזמנות של המשתמש 
    this.customerS.getTripsByCust(this.customerS.currentUser.custId!).subscribe(
      succ => {
        this.myTrips = succ;
        this.filterTrips = succ
        //שליפת כל סוגי הטיולים 
        this.typeSer.getAllTypes().subscribe(
          succ => {
            this.typesTrip = succ

            console.log(succ);
          }
          , err => {
            console.log(err);
          })
        //שליפת כל הטיולים
        this.tripSer.getAllTrips().subscribe(
          succ => {

          },
          err => {
            console.log(err);

          }
        )
      }
      , error => {
        console.log(error);

      }
    )


  }
  //פונקציה לסינון לפי סוג הטיול
  filterByType(selectedType: Number | undefined) {
    debugger
    this.filterTrips = this.myTrips.filter(o => o.tripId == selectedType)
    console.log(this.filterTrips);
  }
  //פונקציה לסינון לטיולים שהתקימו בעבר וטיולים בעתיד
  filterByDate(selectedIndex: Number | undefined) {
    debugger
    console.log(selectedIndex);
    if (selectedIndex == 0)
      // מסננת את הטיולים שכבר התרחשו
      this.filterTrips = this.myTrips.filter(
        trip => new Date(trip.tripDate!).getTime() < Date.now());
    else
      //טיולים שעוד יהיו 
      this.filterTrips = this.myTrips.filter(trip => new Date(trip.tripDate!).getTime() >= Date.now());

  }
  //מחיקת הזמנה
  deleteOrder(ordId: number) {
    this.orderS.deleteOrder(ordId).subscribe
      (
        succ => {
          debugger
          if (succ == false) {
            Swal.fire({
              title: "Error!",
              text: "try again!",
              icon: "error",
              width: "500px",
            });
          }
          else {
            Swal.fire({
              title: "You delete !!",
              text: "if you want order trips go to register!!",
              icon: "warning",
              width: "500px",
            });
            this.Routing.navigate([`./EditUser`]);
          }
        },
        err => {
          console.log(err);
          Swal.fire({
            title: "Error!",
            text: "try again!!",
            icon: "error",
            width: "500px",
          });
        }
      )
  }
}
