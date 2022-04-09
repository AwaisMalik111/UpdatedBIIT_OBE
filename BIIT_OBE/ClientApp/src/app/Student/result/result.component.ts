import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Admin/services/user.service';
import { GlobalService } from '../../Admin/services/global.service';
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
  allResult: any;
  clos: any;
  plos: any;
  reg:any;
  clo:any
  plo:any;
  spinner:boolean;
  constructor(private serv: UserService,
    private rout: Router) {
      this.spinner=true;
    if (sessionStorage.getItem('role') != 'Student') {
      this.rout.navigate(['/']);
    }
  }
  ngOnInit() {
    setTimeout(()=>{ 
      this.spinner=false;
}, 800);
    this.ViewStudentPlo();
    setTimeout(function () { $('#datatable').DataTable() }, 500);
  }
  ViewCourse(a,b,x,y){
    this.clo=b+ " : "+a
    this.serv.ViewCLO('api/Result', '/ViewCourse',{
      'assesid':x,
      'regno':y
    }).subscribe(response => {
      if (response) {
        this.allResult = response;
        setTimeout(function () { $('#datatable').DataTable() }, 500);
      }
    });
  }
  ViewCLO(a,b,x,y) {
    this.plo=a+" : "+b;
    this.reg=y;
    this.serv.ViewCLO('api/Result', '/ViewCLO',{
      'ploid':x,
      'regno':y
    }).subscribe(response => {
      if (response) {
        this.clos = response;
        setTimeout(function () { $('#datatable').DataTable() }, 500);
      }
    });
  }
  ViewStudentPlo(){
    this.serv.ViewStudentPlo('api/Result', '/getAllStudentResult',{'regno':sessionStorage.getItem('uemail')}
    ).subscribe(response => {
      if (response!=0) {
        this.plos = response;
        setTimeout(function () { $('#datatable').DataTable() }, 500);
      }
    });
  }

}
