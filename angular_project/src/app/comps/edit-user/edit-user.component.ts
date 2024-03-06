import { Type } from 'src/app/classes/Type';
import { Component, OnInit } from '@angular/core';
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
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
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
  typesTrip:Array<Type>=new Array<Type>();
  //אינדקס לסינון לפי סוג הטיול
  selectedType: number = 0;
  //משתנה לפתיחת עריכת פרטי משתמש
  openEditUserDeatails: boolean = false
  ngOnInit(): void {
  }
  //הסרת משתמש
  deleteUser() {
    this.customerS.deleteCustomer(this.customerS.currentUser.custId!).subscribe
      (
        succ => {
          debugger
          if (succ == false)
          {
            Swal.fire({
              title: "Error!!",
              text: "something wrong!",
              icon: "error",
              width:"500px",
            });     
          }
          else {

            Swal.fire({
              title: "Bye-Bye "+this.customerS.currentUser.custFname,
              text: "You can't order tickets!!",
              icon: "warning",
              width:"500px",
            });            // this.Routing.navigate([`./AllTrips`]);
            window.location.reload()
          }
          // this.Routing.navigate([`./AllTrips`]);
        },
        err => {
          debugger
          console.log(err);
          alert("נכשל נסה שוב")
          // this.Routing.navigate([`./Register`])
        }
      )
  }
  //לצפיה בכל הטיולים שלי 
  seeMyTrips() {
    this.Routing.navigate([`./EditUser/userTrip`])
  }
  //פונקציה לפתיחת הטופס לעריכת פרטי משתמש
  editYou() {
    console.log(this.customerS.currentUser);
    this.Routing.navigate([`./EditUser/userDetails`])
  }

}


