import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
      this.user.TokenAuth('api/UserAuth/', 'UserAuthorize', { 'remail': this.remail, 'rpassword': this.rpassword }).subscribe(
        response => {
          if (response[0].status === "Admin") {
            GlobalService.role = "Admin";
            GlobalService.uname = response[0].name;
            GlobalService.uemail = response[0].remail;
            this.rout.navigate(["/teacher"]);
          }
          else if (response[0].status === "HOD") {
            GlobalService.role = "HOD";
            GlobalService.uname = response[0].name;
            GlobalService.uemail = response[0].remail;
            this.rout.navigate(["/program"]);
          }
          else if (response[0].status === "Teacher") {
            GlobalService.role = "Teacher";
            GlobalService.uname = response[0].name;
            GlobalService.uemail = response[0].remail;
            this.rout.navigate(["/AssignedCoursesComponent"]);
          }
          else if (response[0].status === "Student") {
            GlobalService.role = "Student";
            GlobalService.uname = response[0].name;
            GlobalService.uemail = response[0].remail;
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
