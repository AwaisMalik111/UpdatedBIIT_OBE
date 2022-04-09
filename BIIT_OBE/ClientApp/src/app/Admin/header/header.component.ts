import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../services/global.service';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
declare const $: any;
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  uname: string;
  uemail: String;

  constructor(private route: Router,
    private serv: UserService) {
    this.uname = GlobalService.uname;
    this.uemail = GlobalService.uemail;
  }

  ngOnInit() {
    if (sessionStorage.getItem('role') != 'Admin' && 
    sessionStorage.getItem('role') != 'Student'
     && sessionStorage.getItem('role') != 'Teacher') {
      this.getAllPrograms();
    }
    else {
      $("#notify").hide();
      $("#bell").hide();
    }
  }
  Logout() {
    sessionStorage.setItem('role',"logout");
    this.route.navigate(['/']);
  }
  getAllPrograms() {
    this.serv.GetallNotification('api/Program', '/GetallNotification').subscribe(response => {
      if (response > 0) {
        $("#notify").text(response);
      }
      else {
        $("#notify").text(0);
      }
    });
  }
  GotoNotify() {
    this.route.navigate(['Notify']);
  }
}
