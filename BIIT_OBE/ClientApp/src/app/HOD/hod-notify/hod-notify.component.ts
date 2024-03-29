import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GlobalService } from 'src/app/Admin/services/global.service';
import { UserService } from 'src/app/Admin/services/user.service';
declare const $: any;

@Component({
  selector: 'app-hod-notify',
  templateUrl: './hod-notify.component.html',
  styleUrls: ['./hod-notify.component.css']
})
export class HodNotifyComponent implements OnInit {
  details: any;
  assessmentDetails: any;
  weightage: any;
  quiz: any;
  lab: any;
  project: any;
  mid: any;
  final: any;
  assignment: any;
  maintable: boolean;
  spinner: boolean;
  assessment: boolean;
  constructor(private serv: UserService,
    private rout: Router) {
    if (sessionStorage.getItem('role') != 'HOD') {
      this.rout.navigate(['/']);
    }
    this.spinner = true;
    this.maintable = true;
    this.assessment = true;
  }
  ngOnInit() {
    this.GetAllPloNotify();
    setTimeout(() => {
      $('#datatable').DataTable()
    }, 1000);
  }
  GetAllPloNotify() {
    this.maintable = true;
    this.assessment = true;
    this.spinner = true;
    this.serv.GetAllPloNotify('api/Weightage', '/GetAllPloNotify').subscribe(response => {
      if (response.length != 0) {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
      } else {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
      }
    });
  }
  GetAllAssessmentNotify(){
    setTimeout(() => {
      this.spinner = false;
    }, 400);
    this.assessment = true;
  }
  ApproveAssessment(coursename, clO_Name) {
    this.spinner = true;
    var total = this.assignment + this.final + this.lab + this.mid + this.quiz + this.project;
    if (total > 100 || total <= 0) {
      alert("Total weightage Range(0-100).Please assign again....!");
      setTimeout(() => {
        this.spinner = false;
      }, 400);
      return;
    }
    this.serv.ApproveAssessment('api/Weightage', '/ApproveAssessment',
      {
        'coursename': coursename, 'cloname': clO_Name,
        'quiz': this.quiz, 'assignment': this.assignment,
        'lab': this.lab, 'mid': this.mid,
        'final': this.final, 'project': this.project
      }).subscribe(response => {
        if (response) {
          this.details = response;
          setTimeout(() => {
            this.spinner = false;
          }, 400);
          this.GetAllPloNotify();
        }
      });
  }
  PLOMap() {
    this.assessment = false;
    this.spinner = true;
    this.serv.GetAllPloNotifing('api/Weightage', '/GetAllPloNotifing').subscribe(response => {
      if (response.length != 0) {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
      } else {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
      }
    });
  }
  setWeightage(x) {
    this.weightage = x;
  }
  Approvemapping(course_name, cloname, id,x) {
    this.spinner = true;
    this.serv.Approvemapping('api/Weightage', '/Approvemapping',
      { 'coursename': course_name, 'CLO_Name': cloname, 'id': id, 'weightage': this.weightage }).subscribe(response => {
        if (response) {
          this.details = response;
          setTimeout(() => {
            this.spinner = false;
          }, 400);
          this.PLOMap();
        }
      });
  }
  GetDetails(x) {
    for (let i = 0; i < this.details.length; i++) {
      if (x === this.details[i].coursename) {
        this.assessmentDetails = this.details[i];
        this.quiz = this.details[i].quiz;
        this.assignment = this.details[i].assignment;
        this.lab = this.details[i].lab;
        this.project = this.details[i].project;
        this.mid = this.details[i].mid;
        this.final = this.details[i].final;
        break;
      }
    }
    this.maintable = false;
  }
}
