import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { CustomerServiceService } from './Services/user-service.service';
import { Customer } from './classes/Customer';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  user:Customer=new Customer()
  
  constructor(public UserS:CustomerServiceService) {
    this.user=UserS.currentUser
  }
  
  
  ngOnInit(): void {
    debugger
    this.user=this.UserS.currentUser
  }
  title = 'angularProject';

}
