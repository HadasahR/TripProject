import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderTicket } from '../classes/OrderTicket';

@Injectable({
  providedIn: 'root'
})
export class OrderTicketService {

  constructor(public http:HttpClient) { }
  /*
   addCustomer(cust:Customer):Observable<number>
   {
    return this.http.post<number>(`https://localhost:7118/api/Customer`,cust)
    
   }
  */
  addOrder(order:OrderTicket):Observable<number>
  {
    debugger
    return this.http.post<number>(`https://localhost:7118/api/Order`,order)
  }
  //מחיקת הזמנה
  deleteOrder(ordId:number):Observable<boolean>
  {
    return this.http.delete<boolean>(`https://localhost:7118/api/Order/${ordId}`)
  }
}
