import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../services/global.service';
import{UserService} from '../services/user.service';
import {Router} from '@angular/router';
declare const $:any;
@Component({
  selector: 'app-brief-transcript',
  templateUrl: './brief-transcript.component.html',
  styleUrls: ['./brief-transcript.component.css']
})
export class BriefTranscriptComponent implements OnInit {
  spinner: boolean;
  AllStudent:any;
  constructor(private rout:Router,
    private serv:UserService) {
    this.spinner = true;
    this.AllStudent=[];
  }

  ngOnInit() {
    setTimeout(() => {
      this.spinner = false;
    }, 800);
    this.GetAllStudents();  
    setTimeout(()=>{ 
      $('#datatable').DataTable() }, 1000); 
  }
  GetAllStudents(){
    this.serv.GetAllStudents("api/UserAuth/","GetAllStudents").subscribe(response => {
      if (response!=null) {
           this.AllStudent=response;
        setTimeout(function(){$('#datatable').DataTable()}, 500);
      }
    },
      error => {
        alert("Server Error");
      });
  }  
  GetStudentCoursePlos(reg){
    GlobalService.upass=reg;
    this.rout.navigate(['studentDetails']);
  }
}
