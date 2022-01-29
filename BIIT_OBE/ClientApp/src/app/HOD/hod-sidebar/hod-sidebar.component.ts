import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Admin/services/user.service';
declare const $: any;
@Component({
  selector: 'app-hod-sidebar',
  templateUrl: './hod-sidebar.component.html',
  styleUrls: ['./hod-sidebar.component.css']
})
export class HODSidebarComponent implements OnInit {
  active: any;
  click: number;
  constructor(private route: Router,
    private serv: UserService) {
    this.click = 1;
  }
  ngOnInit() {
    if (this.route.url.endsWith('HodViewResult')) this.Result();
    if (this.route.url.endsWith('Approved')) this.Approved();
    if (this.route.url.endsWith('clos')) this.clos();
    if (this.route.url.endsWith('plos')) this.plos();
    if (this.route.url.endsWith('allocation')) this.allocation();
    if (this.route.url.endsWith('course')) this.cour();
    if (this.route.url.endsWith('program')) this.prog();
    if (this.route.url.endsWith('Cloweightage')) this.SetCLOWeightage();
  }

  allocation() {
    this.active = "dash";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/allocation"]);
  }
  cour() {
      this.active = "cour";
      $("#" + this.active).addClass("active");
      this.route.navigate(["/course"]);
     
  }
  prog() {
    this.active = "prog";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/program"]);
  }
  SetCLOWeightage(){
    this.active = "SetCLOWeightage";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/Cloweightage"]);  
  }
  plos(){
    this.active = "plos";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/plos"]);  
  }
  clos(){
    this.active = "clos";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/clos"]);  
  }
  Result(){
    this.active = "Result";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/HodViewResult"]);  
  }
  Notify(){
    this.active = "Notify";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/Notify"]);  
  }
  Approved(){
    this.active = "Approved";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/Approved"]);  
  }
}
