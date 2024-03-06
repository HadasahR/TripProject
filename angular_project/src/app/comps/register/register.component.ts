import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerServiceService } from 'src/app/Services/user-service.service';
import { Customer } from 'src/app/classes/Customer';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  //hide = true;
  newCustomer:Customer=new Customer()

constructor(public customerS:CustomerServiceService,public Routing:Router){}

   saveUser(){
    
    console.log(this.newCustomer);
    
    debugger
    this.customerS.addCustomer(this.newCustomer).subscribe
  (
    succ=>{
      debugger
      if(succ==-1)
       {
           console.log(succ);   
       }
      else
    {
        Swal.fire({
          title: "welcome!",
          text: "Your registration success!",
          icon: "success"
        });        //עדכון הלקוח הנוכחי בסרוויס 
      this.customerS.getCustomerByMailAndPassword(this.newCustomer.custEmail!,this.newCustomer.custPassword!).subscribe(
        succ=>{
          this.customerS.currentUser=succ
        }
      )
 //שליחה לדף כל הטיולים 
         this.Routing.navigate([`./AllTrips`]);
    }  
    },
    err=>{
      Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Something went wrong!",
      });
      //אם יש שגיאה נרענן את לדף ההרשמה
   // alert("נכשל נסה שוב")
   //   this.Routing.navigate([`./Register`])
    }
  )
}
myForm:FormGroup =new FormGroup({});
ngOnInit(): void {
  this.myForm = new FormGroup({
    'firstName': new FormControl(null,[this.isValidHebrewName.bind(this), Validators.required, Validators.minLength(2)]),
    'lastName':new FormControl(null, [this.isValidHebrewName.bind(this), Validators.required, Validators.minLength(2)]),
    'email': new FormControl(null,[this.isValidEmail.bind(this), Validators.required]),
    'phone':new FormControl(null, [Validators.required, Validators.minLength(9), Validators.maxLength(10)]),
    'password':new FormControl(null, [this.isValidPassword.bind(this), Validators.required, Validators.minLength(6)])
  })
}
get myPass() { return this.myForm.controls['password'] }
  get myFN() { return this.myForm.controls['firstName'] }
  get myLN() { return this.myForm.controls['lastName'] }
  get myPhone() { return this.myForm.controls['phone'] }
  get myMail() { return this.myForm.controls['email'] }

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

