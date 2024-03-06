import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TripServiceService } from 'src/app/Services/trip-service.service';
import { TypeService } from 'src/app/Services/type.service';
import { CustomerServiceService } from 'src/app/Services/user-service.service';
import { Trip } from 'src/app/classes/Trip';
import { Type } from 'src/app/classes/Type';
@Component({
  selector: 'app-all-trips',
  templateUrl: './all-trips.component.html',
  styleUrls: ['./all-trips.component.css']
})
export class AllTripsComponent implements OnInit {
  //אוסף כל הטיולים
  allTrips:Array<Trip>=new Array<Trip>();
  //אוסף מסונן של כל הטיולים
  filterTrips:Array<Trip>=new Array<Trip>();
 
constructor(
  public tripsService:TripServiceService,
  public typeService:TypeService,
  public routing:Router,
  public userService:CustomerServiceService){
 
}
//אוסף כל סוגי הטיולים
allTypes:Array<Type>=new Array<Type>()
  ngOnInit(): void {
    this.tripsService.getAllTrips().subscribe
    (
      succ=>{
        //שליפת כל הטיולים
        this.allTrips=succ;
        this.allTrips=this.allTrips.filter(trip => new Date(trip.date!).getTime() >= Date.now())
        this.filterTrips=this.allTrips
      console.log(this.allTrips);
      //שליפת כל סוגי הטיולים 
      this.typeService.getAllTypes().subscribe(
      succ=>
      {this.allTypes=succ
      console.log(succ);
      }
      ,err=>{console.log(err);
      }
    )
      },
      err=>{
        console.log(err);
        
      }
    )
  }
  selectedType: number = 0;
  //פונקציה לסינון לפי סוג הטיול
  filter(selectedType:Number|undefined){
    debugger
      this.filterTrips=this.allTrips.filter(o=>o.typeId==selectedType)
      console.log(this.filterTrips);
      
  }
  //פונקציה לשליחה לקומפוננטה של הצגת כל הפרטים
  deatils(tripId:Number|undefined){
   this. routing.navigate([`./deatails/${tripId}`])
  }
}
