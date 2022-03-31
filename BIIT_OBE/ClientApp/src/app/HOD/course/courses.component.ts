import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Admin/services/user.service';
import { GlobalService } from '../../Admin/services/global.service';
import { Courses } from '../../Admin/services/global.service';
import { Programs } from '../../Admin/services/global.service';
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {
  courseId: number;
  name: string;
  code: string;
  credithour: string;
  coursetype: any;
  uname: string;
  ucode: string;
  ucredithour: string;
  programs: any;
  SelectedPrograms: any;
  allcourses: any;
  programselection: any;
  ALLplos: any;
  spinner: boolean;
  constructor(private serv: UserService,
    private rout: Router) {
    if (GlobalService.role != 'HOD') {
      this.rout.navigate(['/']);
    }
    this.spinner = true;
    this.name = "";
    this.courseId = 0;
    this.code = "";
    this.credithour = "";
    this.SelectedPrograms = [];
  }
  ngOnInit() {
    this.getAllPrograms();
    setTimeout(function () { $('#datatable').DataTable() }, 500);
  }
  AllPlo() {
    this.serv.GetallPLOs('api/Program', '/GetAllPLOs', { 'Programid': Programs.ProgramId }).subscribe(response => {
      if (response.length != 0) {
        this.ALLplos = response;
      }
      else {
        this.ALLplos = response;
      }
    });
  }
  getAllPrograms() {
    this.spinner = true;
    this.serv.GetallPrograms('api/Program', '/GetAllPrograms').subscribe(response => {
      if (response.length != 0) {
        this.programselection = response[0].id;
        Programs.ProgramId = this.programselection;
        this.AllPlo();
        this.programs = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
        this.SelectedProgram_GetCourse();
      }
      else {
        setTimeout(() => {
          this.spinner = false;
        }, 400);
      }
    });
  }
  SelectedProgram_GetCourse() {
    this.spinner = true;
    Programs.ProgramId = this.programselection;
    this.AllPlo();
    this.serv.GetAllCourses('api/Course', '/GetAllCourses', { 'id': this.programselection }).subscribe(response => {
      if (response.length != 0) {
        this.allcourses = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
        setTimeout(function () { $('#datatable').DataTable() }, 500);
      }
    });
  }
  //Courses
  AddNewCourses() {
    this.spinner = true;
    if (this.name === "" || this.code === "" || this.credithour === "") {
      alert("Please fill are the required Information....!");
      setTimeout(() => {
        this.spinner = false;
      }, 400);
      return;
    }
    this.serv.AddNewCourse('api/Course', '/AddNewCourses', {
      'name': this.name, 'code': this.code, 'coursetype': this.coursetype,
      'CreditHours': this.credithour, 'createdBy': GlobalService.uname,
      'programs': this.SelectedPrograms
    }).subscribe(response => {
      if (response.length != 0) {
        alert("Course added successfully.");
        this.SelectedPrograms = [];
        this.name = "";
        // this.code = "";
        // this.credithour = "";
        setTimeout(() => {
          this.spinner = false;
        }, 400);
        this.ngOnInit();
      }
    });
  }
  EditCourse(course) {
    this.spinner = true;
    this.courseId = course.id;
    this.uname = course.name;
    this.ucode = course.code;
    this.ucredithour = course.creditHours;
    this.spinner = false;
  }
  UpdateCourses() {
    this.spinner = true;
    if (this.uname === "" || this.ucode === "" || this.ucredithour === "") {
      alert("Please fill are the required Information....!");
      setTimeout(() => {
        this.spinner = false;
      }, 400);
      return;
    }
    this.serv.UpdateCourses('api/Course', '/UpdateCourses', {
      'id': this.courseId, 'name': this.uname, 'code': this.ucode,
      'coursetype': this.coursetype,
      'CreditHours': this.ucredithour, 'createdBy': GlobalService.uname,
    }).subscribe(response => {
      if (response.length != 0) {
        alert("Course has updated successfully.");
        this.uname = "";
        this.ucode = "";
        this.ucredithour = "";
        setTimeout(() => {
          this.spinner = false;
        }, 400);
        this.ngOnInit();
      }
    });
  }
  DeleteCourse() {
    if (confirm("Are you sure to delete? ")) {
      this.serv.DeleteUser("api/Course/", "DeleteCourse", { 'id': this.courseId, 'CreatedBy': GlobalService.uname }).subscribe(response => {
        if (response.length != 0) {
          alert("Course has Deleted Successfully.");
          setTimeout(() => {
            this.spinner = false;
          }, 400);
          this.ngOnInit();
        }
      },
        error => {
          this.spinner = false;
          alert("Server Error");
        });
    }
  }
  // CLOS
  AllPlos(item) {
    this.spinner = true;
    Courses.coursename = item.name;
    Courses.coursecode = item.code;
    Courses.coursecredithours = item.creditHours;
    Courses.courseId = item.id;
    this.spinner = false;
    this.rout.navigate(["/CLOAssessment"]);
  }
  //Arrays
  SelectedProgramName(x, index, checkedProp) {
    if (checkedProp) {
      this.SelectedPrograms.push({ id: x, checked: true })
    } else {
      this.SelectedPrograms.splice(x, 1);
    }
  }
}
