import { Component, OnInit } from '@angular/core';
import { Courses, GlobalService } from '../../Admin/services/global.service'
import { UserService } from '../../Admin/services/user.service'
import { Router } from '@angular/router';
import { stringify } from 'querystring';
declare const $: any;

@Component({
  selector: 'app-fcar',
  templateUrl: './fcar.component.html',
  styleUrls: ['./fcar.component.css']
})
export class FCARComponent implements OnInit {
  spinner: boolean;
  details: any;
  clodetails: any;
  cloname:any;
  coursename:any;
  constructor(private serv: UserService,
    private rout: Router) {
    this.spinner = true;
    if (GlobalService.role != 'Teacher') {
      this.rout.navigate(['/']);
    }
  }

  ngOnInit() {
    setTimeout(() => {
      this.spinner = false;
    }, 600);
    this.getTeacherName();
    setTimeout(function () { $('#datatable').DataTable() }, 500);
  }
  getTeacherName() {
    this.spinner = true;
    this.serv.getTeacherName('api/Course', '/GetAllAssignedCourses', { 'Teacher': GlobalService.uname }).subscribe(response => {
      if (response) {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 600);
      }
    });
  }
  CLOsAssessment(x) {
    this.spinner = true;
    this.serv.CLOsAssessmentFCAR('api/Weightage', '/CLOsAssessmentFCAR', { 'coursename': x }).subscribe(response => {
      if (response) {
        this.clodetails = response;
        setTimeout(() => {
          this.spinner = false;
        }, 600);
      }
    });
  }
  GetExamsDetails(x, y, z) {
    this.cloname=y;
    this.coursename=x;
    this.spinner = true;
    this.serv.GetExamsDetails('api/Weightage', '/GetExamsDetails',
      {
        'coursename': x,
        'cloname': y,
        'examtype': z
      }).subscribe(response => {
        if (response) {
          this.clodetails = response;
          setTimeout(() => {
            this.spinner = false;
          }, 600);
        }
      });
  }
}
