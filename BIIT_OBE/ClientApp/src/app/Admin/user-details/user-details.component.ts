import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { GlobalService } from '../services/global.service';
@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  name:string;
  email:string;
  password:string;
  role:string;
  createdBy:string;
  createdDate:string;
  modifiedBy:string;
  modifiedDate:string;
  constructor(private rout:Router) {
    this.name=GlobalService.uname;
    this.email=GlobalService.uemail;
    this.password=GlobalService.upass;
    this.createdBy=GlobalService.createdBy;
    this.createdDate=GlobalService.createdDate;
    this.modifiedBy=GlobalService.modifiedBy;
    this.modifiedDate=GlobalService.modifiedDate;
    this.role=GlobalService.role;
   }

  ngOnInit() {
  }
  Role(){
    GlobalService.role="Admin";
    this.rout.navigate(['/teacher']);
  }
}
