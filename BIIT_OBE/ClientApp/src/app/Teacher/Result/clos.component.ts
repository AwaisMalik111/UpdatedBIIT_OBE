import { Component, DebugEventListener, OnInit } from '@angular/core';
import { UserService } from '../../Admin/services/user.service';
import { GlobalService } from '../../Admin/services/global.service';
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-clos',
  templateUrl: './clos.component.html',
  styleUrls: ['./clos.component.css']
})
export class ClosComponent implements OnInit {
  allResult: any;
  clos:any;
  plos:any;
  spinner:boolean;
  reg:any;
  clo:any
  plo:any;
  constructor(private serv: UserService,
    private rout: Router) {
      this.spinner=true;
    if (sessionStorage.getItem('role') != 'Teacher') {
      this.rout.navigate(['/']);

    }
  }
  ngOnInit() {
    this.ViewPlo();
    setTimeout(()=>{ 
      this.spinner=false;
}, 600);
    setTimeout(function () { $('#datatable').DataTable() }, 800);
  }
  ViewCourse(a,b,x,y){
    this.clo=b+ " : "+a
    this.serv.ViewCLO('api/Result', '/ViewCourse',{
      'assesid':x,
      'regno':y
    }).subscribe(response => {
      if (response) {
        this.allResult = response;
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
      }
    });
  }
  ViewPlo(){
    this.serv.ViewPLO('api/Result', '/ViewPLO',
    ).subscribe(response => {
      if (response!=0) {
        this.plos = response;
      }
    });
  }
}
