import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GlobalService } from 'src/app/Admin/services/global.service';
import { UserService } from 'src/app/Admin/services/user.service';
declare const $: any;

@Component({
  selector: 'app-approved',
  templateUrl: './approved.component.html',
  styleUrls: ['./approved.component.css']
})
export class ApprovedComponent implements OnInit {
  details: any;
  spinner: boolean;
  assessment: boolean;
  constructor(private serv: UserService,
    private rout: Router) {
    if (sessionStorage.getItem('role') != 'HOD') {
      this.rout.navigate(['/']);
    }
    this.spinner = true;
    this.assessment = true;
  }
  ngOnInit() {
    this.GetAllAssessmentNotify();
    this.spinner = false;
    setTimeout(() => {
      $('#datatable').DataTable()
    }, 1000);
  }
  GetAllPloNotify() {
    this.assessment=true;
    this.spinner = true;
    this.serv.GetAllPloNotify('api/Weightage', '/GetAllPloNotify').subscribe(response => {
      if (response.length != 0) {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
        setTimeout(() => {
          $('#datatable').DataTable()
        }, 1000);
      } else {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
      }
    });
  }
  TeachPLOMapNotify(){
    this.assessment=false;
    this.spinner = true;
    this.serv.TeachPLOMapNotify('api/Weightage', '/TeachPLOMapNotify').subscribe(response => {
      if (response.length != 0) {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
        setTimeout(() => {
          $('#datatable').DataTable()
        }, 1000);
      } else {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
      }
    });
  }
  GetAllAssessmentNotify(){
    this.assessment=true;
    this.spinner = true;
    this.serv.GetAllAssessmentNotify('api/Weightage', '/GetAllAssessmentNotify').subscribe(response => {
      if (response.length != 0) {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
        setTimeout(() => {
          $('#datatable').DataTable()
        }, 1000);
      } else {
        this.details = response;
        setTimeout(() => {
          this.spinner = false;
        }, 400);
      }
    });
  }

}
