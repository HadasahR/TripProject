import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AllTripsComponent } from '../comps/all-trips/all-trips.component';
import { Trip } from '../classes/Trip';

@Injectable({
  providedIn: 'root'
})
export class TripServiceService {

  constructor(public http:HttpClient) {
  
   }
   getAllTrips():Observable<Array<Trip>>
   {
        debugger
    return this.http.get<Array<Trip>>("https://localhost:7118/api/Trips")
    
   }
   getTripById(id:Number):Observable<Trip>
   {
    return this.http.get<Trip>(`https://localhost:7118/${id}`)
   }
   
}
