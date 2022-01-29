import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GlobalService } from 'src/app/Admin/services/global.service';
import { UserService } from 'src/app/Admin/services/user.service';
declare const $: any;
@Component({
  selector: 'app-plo-mapping',
  templateUrl: './plo-mapping.component.html',
  styleUrls: ['./plo-mapping.component.css']
})
export class PloMappingComponent implements OnInit {
  allResult: any;
  examPercentage:any;
  cloPercentage:any;
  ploPercentage:any;
  clos:any;
  plos:any;
  reg:any;
  clo:any
  plo:any;
  spinner:boolean;
  constructor(private serv: UserService,
    private rout: Router) {
    if (GlobalService.role != 'HOD') {
      this.rout.navigate(['/']);
    }
    this.spinner=true;
  }
  ngOnInit() {
    this.ViewPlo();
    setTimeout(()=>{ 
      $('#datatable').DataTable() }, 1000); 
  }
  ViewCourse(a,b,x,y){
    this.clo=b+ " : "+a
    this.serv.ViewCLO('api/Result', '/ViewCourse',{
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
    this.spinner=true;
    this.serv.ViewPLO('api/Result', '/ViewPLO',
    ).subscribe(response => {
      if (response!=0) {
        this.plos = response;
        setTimeout(()=>{ 
        this.spinner=false;
    }, 800);       
      }
      else{
        setTimeout(()=>{ 
          this.spinner=false;
    }, 800);    
      }  
    });
  }
}
