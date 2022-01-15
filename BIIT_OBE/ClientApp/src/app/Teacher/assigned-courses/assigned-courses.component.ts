import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../../Admin/services/global.service'
import { UserService } from '../../Admin/services/user.service'
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-assigned-courses',
  templateUrl: './assigned-courses.component.html',
  styleUrls: ['./assigned-courses.component.css']
})
export class AssignedCoursesComponent implements OnInit {
  setWeightage: number;
  details: any;
  totalQuestion: any;
  totalMark: any;
  assessmentType: any;
  title: any;
  code: any;
  section: any;
  AssignCLOSDetail: any;
  SelectedCLO: any;
  HTML: any;
  SelectedCLOWeightage: any;
  spinner:boolean;
  constructor(private serv: UserService,
    private rout:Router) {
      this.spinner=true;
      if (GlobalService.role != 'Teacher') {
        this.rout.navigate(['/']);
      }
    this.setWeightage = 0;
    this.SelectedCLOWeightage = [];
    this.SelectedCLO = [];
  }
  ngOnInit() {
    setTimeout(()=>{ 
      this.spinner=false;
}, 600);
    this.getTeacherName();
    setTimeout(function () { $('#datatable').DataTable() }, 500);
  }
  getTeacherName() {
    this.serv.getTeacherName('api/Course', '/GetAllAssignedCourses', { 'Teacher': GlobalService.uname }).subscribe(response => {
      if (response) {
        this.details = response;
      }
    });
  }
  GetCourseDetails(item) {
    this.code = item.course_Code;
    this.section = item.section;
    this.title = item.course_Title;
    this.GetAssignedCLOs();
  }
  GetAssignedCLOs() {
    this.serv.GetCLOS('api/Weightage', '/GetCoursesCLOS', {
      'cloname': this.title
    }).subscribe(response => {
      if (response.length != 0) {
        this.AssignCLOSDetail = response;
      }
      else {
        this.AssignCLOSDetail = response;
        alert("No assigned CLO's found...!");
      }
    });
  }
  SelectedCLOsArray(y, x, index, checkedProp) {
    if (checkedProp) {
      $("#" + x).removeAttr('disabled');
      this.SelectedCLO.push({ id: y, checked: true })
    } else {
      this.SelectedCLO.splice(y, 1);
      $("#" + x).prop('disabled', true);
    }
  }
  getWeightageArray(x, id) {
    if (x > 100) {
      alert("Weightage range(0-100). Please enter valid weightage....!");
      return;
    }
    this.setWeightage = 100 - x;
    var value = "<h5>" + this.setWeightage + "%</h5>";
    $("#Remaining" + id).html(value);
    if (x != '' && x != 0) {
      $("#" + x).removeAttr('disabled');
      this.SelectedCLOWeightage.push({ value: x })
    } else {
      this.SelectedCLO.splice(x, 1);
      $("#" + x).prop('disabled', true);
    }
  }
  AddNewExam() {
    if (this.SelectedCLO.length != this.SelectedCLOWeightage.length) {
      alert("(Selected CLO and Set weightage) length are not same....!");
      return;
    }
    this.serv.AddNewExam('api/Weightage', '/AddNewExam',
      {
        'Teacher': GlobalService.uname,
        'Course_name': this.title,
        'assessment_Id': this.SelectedCLO,
        'assessmentType': this.assessmentType,
        'totalMark': this.totalMark,
        'totalQuestion': this.totalQuestion,
        'CLOWeightage': this.SelectedCLOWeightage,
        'Section': this.section
      })
      .subscribe(response => {
        if (response) {
          this.SelectedCLOWeightage=[];
          this.SelectedCLO=[];
          alert("Exam Assigned Successfully...!");
          this.ngOnInit();
        }
      });
  }
}
