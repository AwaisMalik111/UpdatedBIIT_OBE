import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../services/global.service';
import{UserService} from '../services/user.service';
import {Router} from '@angular/router';
import { isTemplateExpression } from 'typescript';
declare const $:any;
@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {
fname:string;
lname:string;
email:string;
password:string;
cpassword:string;
role:string;
ufname:string;
id:string;
ulname:string;
uemail:string;
upassword:string;
ucpassword:string;
urole:string;
Allteacher:any;
spinner:boolean;
  constructor(private rout:Router,
    private serv:UserService) {
    this.fname="";
    this.lname="";
    this.email="";
    this.password="";
    this.cpassword="";
    this.role="";
    this.ufname="";
    this.ulname="";
    this.uemail="";
    this.upassword="";
    this.ucpassword="";
    this.urole="";
    this.spinner=true;
    if(GlobalService.role!='Admin'){
      this.rout.navigate(['/']);
    }
   }

  ngOnInit() {
    setTimeout(()=>{ 
      this.spinner=false;
}, 800);
    this.GetAllTeachers();  
  }
  AddNewUser(){
    if(this.password!=this.cpassword){
      alert("Passwords are not matched..!");
      return;
    }else{
      this.serv.AddNewMember("api/UserAuth/","AddNewMember",{'fname':this.fname,'lname':this.lname,
      'email':this.email,'password':this.password,'role':this.role ,'CreatedBy':GlobalService.uname}).subscribe(response => {
        if (response) {
          this.fname="";
          this.lname="";
          this.email="";
          this.password="";
          this.cpassword="";
          this.role="";
          this.GetAllTeachers();
          alert("User created Successfully.");
          
        }
        else {
          alert("Invalid Information please try again.");
        }
      },
        error => {
          alert("Server Error");
        });
    }  
  }
  GetAllTeachers(){
      this.serv.GetallTeachers("api/UserAuth/","GetallTeachers").subscribe(response => {
        if (response!=null) {
          this.Allteacher=response;
          setTimeout(function(){$('#datatable').DataTable()}, 500);
        }
      },
        error => {
          alert("Server Error");
        });
    }  
    UserDetails(item){
      GlobalService.uname=item.name;
      GlobalService.uemail=item.remail;
      GlobalService.upass=item.rpassword;
      GlobalService.role=item.status;
      GlobalService.createdBy=item.createdBy;
      GlobalService.createdDate=item.createdDate;
      GlobalService.modifiedBy=item.modifiedBy;
      GlobalService.modifiedDate=item.modifiedDate;
      this.rout.navigate(["/userdetails"]);
    }
    UpdateDetails(item){
      this.id=item.id;
      this.ufname=item.name;
      this.ulname=item.lname;
      this.uemail=item.remail;
      this.upassword=item.rpassword;
      this.ucpassword=item.rpassword;
      this.urole=item.status;
    }
    UpdateUser(){
      if(this.upassword!=this.ucpassword){
        alert("Passwords are not matched..!");
        return;
      }else{
        this.serv.UpdateUser("api/UserAuth/","UpdateUser",{'id':this.id,'fname':this.ufname,'lname':this.ulname,
        'email':this.uemail,'password':this.upassword,'role':this.urole ,'CreatedBy':GlobalService.uname}).subscribe(response => {
          if (response) {
            this.ufname="";
            this.ulname="";
            this.uemail="";
            this.upassword="";
            this.ucpassword="";
            this.urole="";
            this.GetAllTeachers();
            alert("User Updated Successfully.");
            
          }
          else {
            alert("Invalid Information please try again.");
          }
        },
          error => {
            alert("Server Error");
          });
    }
  }
  DeleteUser(){
    if(confirm("Are you sure to delete? ")){
      this.serv.DeleteUser("api/UserAuth/","DeleteUser",{'id':this.id,'CreatedBy':GlobalService.uname}).subscribe(response => {
        if (response) {
          alert("User suspended Successfully.");
          this.GetAllTeachers();
        }
        else {
          alert("Invalid User please try again.");
        }
      },
        error => {
          alert("Server Error");
        });
    }
  }
}
