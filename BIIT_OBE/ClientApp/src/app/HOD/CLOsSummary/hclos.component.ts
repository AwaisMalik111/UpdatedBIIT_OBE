import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/Admin/services/global.service';
import { UserService } from 'src/app/Admin/services/user.service';
import { Router } from '@angular/router';
declare const $: any;

@Component({
  selector: 'app-hclos',
  templateUrl: './hclos.component.html',
  styleUrls: ['./hclos.component.css']
})
export class HclosComponent implements OnInit {
  programs: any;
  programselection: number;
  allcourses: any;
  Courseselection: number;
  mapclodetails: any;
  spinner:boolean;
  constructor(private rout: Router,
    private serv: UserService) {
    if (GlobalService.role != 'HOD') {
      this.rout.navigate(['/']);
    }
    this.spinner=true;
  }

  ngOnInit() {
    this.getAllPrograms();
  }
  getAllPrograms() {
    this.spinner=true;
    this.serv.GetallPrograms('api/Program', '/GetAllPrograms').subscribe(response => {
      if (response) {
        this.programselection=response[0].id;
        this.programs = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        this.SelectedProgram_GetCourse();
      }
    });
  }
  SelectedProgram_GetCourse() {
    this.spinner=true;
    this.serv.GetAllCourses('api/Course', '/GetAllCourses', { 'id': this.programselection }).subscribe(response => {
      if (response) {
        this.Courseselection=response[0].id;
        this.allcourses = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        this. SelectedCourse_GetCLOS();
      }
    });
  }
  SelectedCourse_GetCLOS() {
    this.spinner=true;
    $('#datatable').DataTable().destroy();
    this.serv.GetCLOS('api/Weightage', '/GetCLOSAssessment', {
      'Program_Id': this.programselection,
      "course_ID": this.Courseselection
    }).subscribe(response => {
      if (response.length!=0) {
        this.mapclodetails = response;
        setTimeout(function(){$('#datatable').DataTable()}, 500);
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
      }
      else{
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        this.mapclodetails=response;
      }
    });
  }
}
