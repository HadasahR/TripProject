import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginComponent } from '../comps/login/login.component';
import { Customer } from '../classes/Customer';
import { Trip } from '../classes/Trip';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {
  //הלקוח הנוכחי
currentUser:Customer=new Customer()
//האם מדובר במנהל
isManager:boolean=false;
  constructor(public http:HttpClient) {
   }
   //שליפת כל המשתמשים 
   getAllCustomers():Observable<Array<Customer>>
   {
    return this.http.get<Array<Customer>>("https://localhost:7118/api/Customer")
    
   }
   //שליפת משתמש לפי מייל וסיסמא
   getCustomerByMailAndPassword(mail:string,password:string):Observable<Customer>
   {
    debugger
    return this.http.get<Customer>(`https://localhost:7118/${mail}/${password}`)
    
   }
   //הוספת משתמש
   addCustomer(cust:Customer):Observable<number>
   {
    return this.http.post<number>(`https://localhost:7118/api/Customer`,cust)
    
   }
   //הסרת משתמש
   deleteCustomer(custId:number):Observable<boolean>
   {
    debugger
    return this.http.delete<boolean>(`https://localhost:7118/api/Customer/${custId}`)
    
   }
   //id שליפת הטיולים של משתמש מסוים לפי 
   getTripsByCust(custId:number):Observable<Array<Trip>>
  {
    return this.http.get<Array<Trip>>(`https://localhost:7118/GetTripsByCust/${custId}`)
  }
  //פונקציה לעדכון פרטי הלקוח
  updateCustomer(cust:Customer):Observable<boolean>{
    debugger
    return this.http.put<boolean>("https://localhost:7118/api/Customer",cust)
  }

  }