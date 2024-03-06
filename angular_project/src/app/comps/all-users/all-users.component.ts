import { Component, OnInit } from '@angular/core';
import { CustomerServiceService } from 'src/app/Services/user-service.service';
import { Customer } from 'src/app/classes/Customer';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.css']
})
export class AllUsersComponent implements OnInit {
 AllUsers:Array<Customer>=new Array()
  /**
   */
  constructor(public UserS:CustomerServiceService) {
    
  }
  ngOnInit(): void {
    this.UserS.getAllCustomers().subscribe(
      succ=>{
        this.AllUsers=succ
      }
    )
  }

}
