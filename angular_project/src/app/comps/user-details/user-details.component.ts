import { Component } from '@angular/core';
import { Type } from 'src/app/classes/Type';
import {  OnInit } from '@angular/core';
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
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent {
  constructor(public customerS: CustomerServiceService,
    public Routing: Router,
    public tripSer: TripServiceService,
    public typeSer: TypeService,
    public orderS: OrderTicketService,

  ) { }
  
  //פונקציה לשמירת עדכונים של פרטי המשתמש
  updateUser() {
    this.customerS.updateCustomer(this.customerS.currentUser).subscribe(
      succes => {
        if (succes == true) {
          Swal.fire({
            title: "Update-success!!!!!!!!",
            text: "go visit more trips",
            icon: "success",
            width:"500px",
          });
          this.Routing.navigate([`./AllTrips`]);
        }
      },
      error => {
        console.log(error);
      }
    )


  }
  myForm: FormGroup = new FormGroup({
    'firstName': new FormControl(null, [this.isValidHebrewName.bind(this), Validators.required, Validators.minLength(2)]),
    'lastName': new FormControl(null, [this.isValidHebrewName.bind(this), Validators.required, Validators.minLength(2)]),
    'email': new FormControl(null, [this.isValidEmail.bind(this), Validators.required]),
    'phone': new FormControl(null, [Validators.required, Validators.minLength(9), Validators.maxLength(10)]),
    'password': new FormControl(null, [this.isValidPassword.bind(this), Validators.required, Validators.minLength(6)])
  });
  get myPass() { return this.myForm.controls['password'] }
  get myFN() { return this.myForm.controls['firstName'] }
  get myLN() { return this.myForm.controls['lastName'] }
  get myPhone() { return this.myForm.controls['phone'] }
  get myMail() { return this.myForm.controls['email'] }
  //פונקציה לפתיחת הטופס לעריכת פרטי משתמש
  editYou() {
    console.log(this.customerS.currentUser);
  }
  //תקינות לשם
  isValidHebrewName(name: AbstractControl) {
    if (!/^[א-ת\s]+$/.test(name.value)) {
      return { 'notvalid': true };
    }
    return null;
  }

  //תקינות מייל
  isValidEmail(email: AbstractControl) {
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.value)) {
      return { 'notvalid': true };
    }
    return null;
  }

  //תקינות סיסמה
  isValidPassword(password: AbstractControl) {
    if (!/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/.test(password.value)) {
      return { 'notvalid': true };
    }
    return null;
  }
}
