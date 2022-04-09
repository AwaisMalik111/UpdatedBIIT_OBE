import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/Admin/services/global.service';
import { UserService } from '../../Admin/services/user.service'
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.css']
})
export class ExamsComponent implements OnInit {
  AllExams: any;
  coursename: any;
  section: any;
  examtype: any;
  result: any;
  totalMarks: number;
  Allstudents: any;
  ObtainedMarks: any;
  assessemntId: any;
  spinner:boolean;
  constructor(private serv: UserService,
    private rout: Router) {
      this.spinner=true;
    if (sessionStorage.getItem('role') != 'Teacher') {
      this.rout.navigate(['/']);
    }
    this.ObtainedMarks = [];
  }
  ngOnInit() {
    setTimeout(()=>{ 
      this.spinner=false;
}, 600);
    this.getAllExams();
    setTimeout(function () { $('#datatable').DataTable() }, 500);
    this.GetAllStudents();
  }
  GetAllStudents() {
    this.serv.GetAllStudents("api/UserAuth/", "GetAllStudents").subscribe(response => {
      if (response != null) {
        this.Allstudents = response;
        setTimeout(function () { $('#datatable').DataTable() }, 500);
      }
    },
      error => {
        alert("Server Error");
      });
  }
  getAllExams() {
    this.serv.getAllExams('api/Weightage', '/getAllExams').subscribe(response => {
      if (response) {
        this.AllExams = response;
      }
    });
  }
  GetExamMarks(x, a, b, c,marks) {
    this.assessemntId=x;
    this.coursename = c;
    this.section = a;
    this.examtype = b;
    this.totalMarks=marks;
    // this.serv.GetExamMarks('api/Result', '/GetExamMarks', {
    //   'examid': x
    // }).subscribe(
    //   response => {
    //     if (response.length != 0) {
    //       debugger;
    //       this.result = response;
    //       this.assessemntId=response[0].assesid;
    //       this.totalMarks = response[0].examid;
    //     }
    //   });
  }
  getMraks(x, y) {
    if (y > this.totalMarks) {
      alert("Obtained marks > total marks.Please re-enter the obtained marks...!");
      return;
    }
    if (x != '' || x != "") {
      this.ObtainedMarks.push({ regno: x, totalmarks: y })
    } else {
      this.ObtainedMarks.splice(x, 1);
    }
  }
  SaveResult(){
    this.serv.SaveResult('api/Result', '/SaveResult', {
      'assessemntId':this.assessemntId,
      'ListOfMarks':this.ObtainedMarks
    }).subscribe(
      response => {
        if (response) {
          alert("Result has Saved...!");
          this.ObtainedMarks=[];
          this.rout.navigate(['/ExamsComponent']);
        } 
        else{
          alert("Server Error...!");
        }
      });
  }
}
