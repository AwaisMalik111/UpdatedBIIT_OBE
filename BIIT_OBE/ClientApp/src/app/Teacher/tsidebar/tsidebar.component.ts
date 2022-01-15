import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-tsidebar',
  templateUrl: './tsidebar.component.html',
  styleUrls: ['./tsidebar.component.css']
})
export class TsidebarComponent implements OnInit {
  active: any;
  click: number;
  constructor(private route: Router) {
    this.click = 1;
  }
  ngOnInit() {
    if (this.route.url.endsWith('AssignedCoursesComponent')) this.AssignedCoursesComponent();
    if (this.route.url.endsWith('TeacherViewResult')) this.ClosComponent();
    if (this.route.url.endsWith('ExamsComponent')) this.ExamsComponent();
  }

  AssignedCoursesComponent() {
    this.active = "AssignedCoursesComponent";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/AssignedCoursesComponent"]);
  }
  ClosComponent() {
    this.active = "ClosComponent";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/TeacherViewResult"]);
  }
  ExamsComponent() {
    this.active = "ExamsComponent";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/ExamsComponent"]);
  }


}
