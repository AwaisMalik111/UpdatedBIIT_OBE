import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../services/global.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  uname: string;
  uemail: String;

  constructor(private rout: Router) {
    this.uname = GlobalService.uname;
    this.uemail = GlobalService.uemail;
  }

  ngOnInit() {
  }
  Logout() {
    GlobalService.role = "logout";
    this.rout.navigate(['/']);
  }
}
