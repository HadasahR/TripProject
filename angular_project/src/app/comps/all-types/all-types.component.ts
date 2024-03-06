import { Component, OnInit } from '@angular/core';
import { TypeService } from 'src/app/Services/type.service';
import { Type } from 'src/app/classes/Type';

@Component({
  selector: 'app-all-types',
  templateUrl: './all-types.component.html',
  styleUrls: ['./all-types.component.css']
})
export class AllTypesComponent implements OnInit {
 /**
  *
  */
  //אוסף כל סוגי הטיולים
  allTypes:Array<Type>=new Array<Type>()
 constructor(public typeService:TypeService) {
 }
  ngOnInit(): void {
   
  }

}
