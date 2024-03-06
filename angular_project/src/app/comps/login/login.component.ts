import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { CustomerServiceService } from 'src/app/Services/user-service.service';
import { Customer } from 'src/app/classes/Customer';
import {FormControl, Validators, FormsModule, ReactiveFormsModule} from '@angular/forms';

import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
//  standalone: true,
  //imports: [MatFormFieldModule, MatInputModule, FormsModule, ReactiveFormsModule,MatSelectModule,MatIconModule,MatButtonModule],
})
export class LoginComponent {
  hide = true;
 
currentCustomer:Customer=new Customer()

constructor(public customerS:CustomerServiceService,public Routing:Router){
  
}
checkUser(){
  const mail=this.currentCustomer.custEmail
  const password=this.currentCustomer.custPassword
  window.localStorage.clear()
  const m=new Customer(
    151,"מנהל","pr","0533190406","cd@gmail.com","1478"
  )
  debugger
  //localStorage שליפת המנהל מה
  let man:string=window.localStorage.getItem("manager")!;
   //בשביל הפעם הראשונה שישים ערך מנהל 
   if(man==null)
   window.localStorage.setItem("manager",JSON.stringify(m))
      //המרה של מנהל לאוביקט 
  // let manager:Customer=JSON.parse(man)
 
  //בדיקה אם מדובר במנהל 
  if(mail==m.custEmail&&password==m.custPassword)
   { this.customerS.currentUser=m;
     this.customerS.isManager=true;
  }
  else
  this.customerS.getCustomerByMailAndPassword(mail!,password!).subscribe
  (
    succ=>{
      debugger
      //את הלקוח הנוכחי שהתחבר Service אם הצליח למצוא את הלקוח נעדכן ב
      this.customerS.currentUser=succ;
      console.log(this.customerS.currentUser);
      Swal.fire({
        title: "Welcome"+this.customerS.currentUser.custFname+"!",
        text: "Let's go to trip!!",
        icon: "success",
        width:"500px",
      });
      //שליחה לדף כל הטיולים 
      this.Routing.navigate([`./AllTrips`]);
   // console.log(this);
    
    },
    err=>{
   //אם יש שגיאה נשלח לדף ההרשמה
   Swal.fire({
    icon: "error",
    title: "Oops...",
    text: "We dont found you !",
    footer: '<a href="./Register">please go register</a>'
  });
      this.Routing.navigate([`./Register`])
      //  this.myRouter.navigate([‘./pay‘])

    }
  )
}
email = new FormControl('', [Validators.required, Validators.email]);
password= new FormControl('',[Validators.required,Validators.min(2)]);
getErrorMessage() {
  if (this.email.hasError('required')) {
    return 'You must enter a value';
  }
  return this.email.hasError('email') ? 'Not a valid email' : '';
}
}
