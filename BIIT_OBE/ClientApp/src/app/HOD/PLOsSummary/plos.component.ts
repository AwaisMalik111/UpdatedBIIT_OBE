import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/Admin/services/global.service';
import { UserService } from 'src/app/Admin/services/user.service';
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-plos',
  templateUrl: './plos.component.html',
  styleUrls: ['./plos.component.css']
})
export class PlosComponent implements OnInit {
  plodetails: any;
  clodetails: any;
  programselection: any;
  programs: any;
  mainTable: boolean;
  clos: any;
  count: number;
  ploname: any;
  coursename:any;
  spinner :boolean;
  constructor(private rout: Router,
    private serv: UserService) {
      this.spinner=true;
    this.mainTable = true;
    this.count = 0;
    if (GlobalService.role != 'HOD') {
      this.rout.navigate(['/']);
    }
  }
  ngOnInit() {
    this.getAllPrograms();
    setTimeout(() => {
      $('#datatable').DataTable()
    }, 1000);
  }

  getAllPrograms() {
    this.spinner=true;
    this.serv.GetallPrograms('api/Program', '/GetAllPrograms').subscribe(response => {
      if (response) {
        this.programselection = response[0].id;
        this.programs = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
    setTimeout(() => {
      $('#datatable').DataTable()
    }, 1000);
        this.SelectedProgram_GetPLOS();
      }
    });
  }
  SelectedProgram_GetPLOS() {
    this.spinner=true;
    this.serv.GetRemainingPLOWeightage('api/Weightage', '/GetRemainingPLOWeightage', {
      'Program_Id': this.programselection
    }).subscribe(response => {
      if (response.length > 0) {
        this.plodetails = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
    setTimeout(() => {
      $('#datatable').DataTable()
    }, 1000);
      }
      else {
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        this.plodetails = response;
      }
    });
  }
  GetPLODeatils(details, y) {
    this.spinner=true;
    this.ploname = y;
    this.clos = details.ploname;
    this.coursename=details.coursename;
    this.mainTable = false;
    this.serv.GetRemainingPLOWeightage('api/Weightage', '/Get_PLOS_CLOS', {
      'Program_Id': this.programselection,
      'CLO_Id': details.course_Id
    }).subscribe(response => {
      if (response) {
        this.clodetails = response;
        this.spinner=false;
        setTimeout(() => {
          $('#datatable').DataTable()
        }, 1000);
      }
    });
  }
  back() {
    this.mainTable = true;
    this.ngOnInit();
  }
}
