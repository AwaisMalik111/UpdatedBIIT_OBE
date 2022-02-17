import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../services/global.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  name: any;
  detailsCourses: any;
  detailsplos: any;
  coursename: any;
  mapclodetails: any;
  ploid: any;
  ploname: any;
  spinner: boolean;
  constructor(private serv: UserService) {
    this.spinner = true;
  }

  ngOnInit() {
    setTimeout(() => {
      this.spinner = false;
    }, 400);
    this.name = GlobalService.upass;
    this.DetailsCourses();
    this.PLOSCourses();

  }
  DetailsCourses() {
    this.serv.DetailsCoursesStudent("api/UserAuth/", "DetailsCoursesStudent", {
      'remail': this.name
    }).subscribe(response => {
      if (response != null) {
        this.detailsCourses = response;
      }
    },
      error => {
        alert("Server Error");
      });
  }
  PLOSCourses() {
    this.serv.PLOSCourses("api/UserAuth/", "PLOSCourses", {
      'remail': this.name
    }).subscribe(response => {
      if (response != null) {
        this.detailsplos = response;
      }
      setTimeout(() => {
        this.spinner = false;
      }, 400);
    },
      error => {
        alert("Server Error");
      });
  }
  SelectedCourse_GetCLOS(x) {
    this.coursename = x;
    this.serv.GetCLOS('api/UserAuth', '/GetCLOSAssessment', {
      "cloname": x
    }).subscribe(response => {
      if (response.length != 0) {
        this.mapclodetails = response;

      }
      else {
        this.mapclodetails = response;
      }
      setTimeout(() => {
        this.spinner = false;
      }, 400);
    });
  }
  SelectedPLO_GetCLOS(x, y) {
    this.ploid = y;
    this.ploname = x;
    this.serv.SelectedPLO_GetCLOS('api/UserAuth', '/SelectedPLO_GetCLOS', {
      "id": y
    }).subscribe(response => {
      if (response.length != 0) {
        this.mapclodetails = response;
      }
      else {
        this.mapclodetails = response;
      }
      setTimeout(() => {
        this.spinner = false;
      }, 400);
    });
  }
}
