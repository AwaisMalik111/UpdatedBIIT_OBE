import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Alert } from 'selenium-webdriver';
import { GlobalService } from '../Admin/services/global.service';
import { UserService } from '../Admin/services/user.service';
declare const $: any;
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  LoginForm: FormGroup;
  remail: any;
  rpassword: any;
  admin: any;
  teacher: any;
  student: any;
  warning: boolean;
  danger: boolean;
  constructor(
    private user: UserService,
    private rout: Router,
    private formbuilder: FormBuilder,) {
      GlobalService.role = ''
    this.warning = false;
    this.danger = false;
    this.remail = "";
    this.rpassword = "";
    this.admin = "";
    this.teacher = "";
    this.student = "";
  }
  ngOnInit(): void {
    GlobalService.role='';
    $("#remail").focus();
    this.LoginForm = this.formbuilder.group({
      remail: ['', [Validators.required, Validators.minLength(3)]],
      rpassword: ['', [Validators.required, Validators.minLength(3)]],
    });
  }
  onSubmit() {
    this.warning = true;
    if (this.LoginForm.invalid) {
      this.warning = false;
      this.danger = true;
    } else {
      this.user.TokenAuth('api/UserAuth/', 'UserAuthorize',
       { 'remail': this.remail, 'rpassword': this.rpassword }).subscribe(
        response => {
          if (response[0].status === "Admin") {
            sessionStorage.setItem('role',"Admin");
            sessionStorage.setItem('uname',response[0].name);
            sessionStorage.setItem('uemail',response[0].remail);
            this.rout.navigate(["/teacher"]);
          }
          else if (response[0].status === "HOD") {
            sessionStorage.setItem('role', "HOD");
            sessionStorage.setItem('uname',response[0].name);
            sessionStorage.setItem('uemail',response[0].remail);
            this.rout.navigate(["/program"]);
          }
          else if (response[0].status === "Teacher") {
            sessionStorage.setItem('role',"Teacher");
            sessionStorage.setItem('uname',response[0].name);
            sessionStorage.setItem('uemail',response[0].remail);
            this.rout.navigate(["/AssignedCoursesComponent"]);
          }
          else if (response[0].status === "Student") {
            sessionStorage.setItem('role',"Student");
            sessionStorage.setItem('uname',response[0].name);
            sessionStorage.setItem('uemail',response[0].remail);
            this.rout.navigate(["/StudentViewResult"]);
          }
          else if (response[0].status === "false") {
            this.warning = false;
            this.danger = true;
          }
          error => {
            alert("Server Error, Please try again.");
          }
        });
    }
  }
}
