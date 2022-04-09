import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Admin/services/user.service';
import { GlobalService } from '../../Admin/services/global.service';
import { Courses } from '../../Admin/services/global.service';
import { Programs } from '../../Admin/services/global.service';
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-clo-management',
  templateUrl: './clo-management.component.html',
  styleUrls: ['./clo-management.component.css']
})
export class CLOManagementComponent implements OnInit {
  CourseName: any;
  spinner:boolean;
  ProgramName: any;
  Cloname: any;
  ALLplos: any;
  plodetails: any;
  AssignPlos_count: any;
  allCLOs: any;
  Clodesc: any;
  uCloid: any;
  uClodesc: any;
  uCloname: any;
  mark_final: any;
  mark_lab: any;
  mark_mid: any;
  mark_quiz: any;
  mark_project: any;
  mark_assignment:any;
  Alreadysetproject: any;
  Alreadysetfinal: any;
  Alreadysetmid: any;
  Alreadysetlab: any;
  Alreadysetassignment: any;
  Alreadysetquiz: any;
  SetPloWeightage: any;
  SelectedPLO: any;
  Assessment_check:boolean;
  AssignPlos_check:boolean;
  setWeightage:number;
  GetAlreadySetWeightageOfPLOValue:any;
  constructor(private serv: UserService,
    private rout: Router) {
    this.SelectedPLO = [];
    this.SetPloWeightage = [];
    this.Assessment_check=false;
    this.AssignPlos_check=false;
    this.spinner=true;
  }
  ngOnInit() {
    //this.rout.navigate(["/PLOMapping"]);
    this.AllPlos();
    this.GetAllCLOs();
    this.GetAlreadySetWeightageOfPLO();
  }
  GetAllCLOs() {
    this.spinner=true;
    this.ProgramName = Programs.programname;
    this.CourseName = Courses.coursename;
    this.serv.GetAllCLOs('api/Course', '/GetAllCLOs', { 'id': Programs.ProgramId, 'courseID': Courses.courseId }).subscribe(response => {
      if (response.length != 0) {
        this.allCLOs = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
      } else {
        this.allCLOs = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
      }
    });
  }
  UpdateSelectedCLO() {
    this.spinner=true;
    if (this.uCloname === "" || this.uClodesc === "") {
      alert("Please fill are the required Information....!")
      setTimeout(()=>{ 
        this.spinner=false;
  }, 400);
      return;
      
    }
    this.serv.UpdateCourses('api/Course', '/UpdateCLO', {
      'id': this.uCloid, 'name': this.uCloname, 'code': this.uClodesc
    }).subscribe(response => {
      if (response.length != 0) {
        alert("CLO has Updated successfully.");
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        this.ngOnInit();
      }
    });
  }
  DeleteCLO() {
    if (confirm("Are you sure to delete? ")) {
      this.serv.DeleteUser("api/Course/", "DeleteCLO", { 'id': this.uCloid }).subscribe(response => {
        if (response.length != 0) {
          alert("CLO has Deleted Successfully.");
          setTimeout(()=>{ 
            this.spinner=false;
      }, 400);
          this.ngOnInit();
        }
      },
        error => {
          this.spinner=false;
          alert("Server Error");
        });
    }
  }
  AllPlos() {
    this.serv.GetallPLOs('api/Program', '/GetAllPLOs', { 'Programid': Programs.ProgramId }).subscribe(response => {
      if (response.length != 0) {
        this.ALLplos = response;
      }
      else {
        this.ALLplos = response;
      }
    });
  }
  AddNewClos() {this.spinner=true;
    if (this.Cloname === "" || this.Clodesc === "") {
      alert("Please fill are the required Information....!")
      setTimeout(()=>{ 
        this.spinner=false;
  }, 400);
      return;
    }
    this.serv.AssignCLOs('api/Course', '/AssignCLOs', {
      'ProgramId': Programs.ProgramId,
      'courseID': Courses.courseId,
      'cloName': this.Cloname, 'cloDesc': this.Clodesc, 'createdBy': sessionStorage.getItem('uname')
    }).subscribe(response => {
      if (response.length != 0) {
        this.Cloname = "";
        this.Clodesc = "";
        alert("CLO had Assigned.");
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        this.GetAllCLOs();
      } else {
      }
    });
  }
  GotoPLOSummary(){
    this.rout.navigate(["/plos"]);
  }
  GetCLODetail(item, x) {
    this.AssignPlos_check=false;
    this.Assessment_check=false;
    if (x === 'Assessment') {
      this.serv.Assign_Marks('api/Weightage', '/CLO_Assessment_Check', {
        'CLO_Id': item.id,
        'Course_Id': Courses.courseId,
        'Program_Id': Programs.ProgramId
      }).subscribe(response => {
        if (response.length != 0) {
          this.Assessment_check=true;
          this.Alreadysetquiz = response[0].quiz;
          this.Alreadysetassignment = response[0].assignment;
          this.Alreadysetlab = response[0].lab;
          this.Alreadysetmid = response[0].mid;
          this.Alreadysetfinal = response[0].final;
          this.Alreadysetproject = response[0].project;

        }
      });
    }
    if (x === 'PLO weightage') {
      this.serv.GetAlreadySetWeightageOfPLO('api/Weightage', '/GetAlreadySetWeightageOfPLO').subscribe(response => {
        if (response.length != 0) {

          this.GetAlreadySetWeightageOfPLOValue = response;

        }
        else {
          this.GetAlreadySetWeightageOfPLOValue = response;

        }
      });
      this.serv.GetRemainingPLOWeightage('api/Weightage', '/GetAlreadySetPLOWeightage', {
        'CLO_Id': item.id,
        'Course_Id': Courses.courseId,
        'Program_Id': Programs.ProgramId
      }).subscribe(response => {
        if (response.length != 0) {
          for (let i = 0; i < response.length; i++) {
            for (let j = 0; j < response.length; j++) {
              if (response[i].id != this.ALLplos[j].id) {

              }
              else {
                this.ALLplos.splice(j, 1);
              }
            }
          }
          this.AssignPlos_check=true;
          this.plodetails = response;
          this.AssignPlos_count = response.length;

        }
      });
    }
    this.uCloid = item.id;
    this.uClodesc = item.cloDesc;
    this.uCloname = item.cloName;

  }
  GetAlreadySetWeightageOfPLO(){
    this.spinner=true;
    this.serv.GetAlreadySetWeightageOfPLO('api/Weightage', '/GetAlreadySetWeightageOfPLO').subscribe(response => {
      if (response.length != 0) {
        this.GetAlreadySetWeightageOfPLOValue = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
      }
      else {
        this.GetAlreadySetWeightageOfPLOValue = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
      }
    });
  }
  // Clos Assessment 
  quizzes(x) {
    if (x) {
      $("#quizzes").removeAttr('disabled');
    }
    else {
      $("#quizzes").prop('disabled', true);
    }
  }
  assignment(x) {
    if (x) {
      $("#assignment").removeAttr('disabled');
    }
    else {
      $("#assignment").prop('disabled', true);
    }
  }
  lab(x) {
    if (x) {
      $("#lab").removeAttr('disabled');
    }
    else {
      $("#lab").prop('disabled', true);
    }
  }
  mid(x) {
    if (x) {
      $("#mid").removeAttr('disabled');
    }
    else {
      $("#mid").prop('disabled', true);
    }
  }
  final(x) {
    if (x) {
      $("#final").removeAttr('disabled');
    }
    else {
      $("#final").prop('disabled', true);
    }
  }
  project(x) {
    if (x) {
      $("#project").removeAttr('disabled');
    }
    else {
      $("#project").prop('disabled', true);
    }
  }
  SelectedPLOsArray(x, index, checkedProp) {
    if (checkedProp) {
      $("#" + x).removeAttr('disabled');
      this.SelectedPLO.push({ id: x, checked: true })
    } else {
      this.SelectedPLO.splice(x, 1);
      $("#" + x).prop('disabled', true);
    }
  }
  getWeightageArray(x,id) {
    if (x > 100) {
      alert("Weightage range(0-100). Please enter valid weightage....!");
      return;
    }
    this.setWeightage=100-x;
    var value="<h5>"+ this.setWeightage +"%</h5>";
    $("#Remaining" + id).html(value);
    if (x != '0' && x != '') {
      this.SetPloWeightage.push({ weightage: x })
    } else {
      this.SetPloWeightage.splice(x, 1);
    }
  }
  MapPloWithClo() {
    if (this.SetPloWeightage.length === this.SelectedPLO.length) {
      this.serv.MapPloWithClo('api/Weightage', '/MapPloWithClo', {
        'CLO_Id': this.uCloid,
        'Course_Id': Courses.courseId,
        'Program_Id': Programs.ProgramId,
        'PLO_weightage': this.SetPloWeightage,
        'PLO_Id': this.SelectedPLO
      }).subscribe(response => {
        if (response.length != 0) {
          alert("PLO has Assigned successfully.");
          this.SelectedPLO.length = 0;
          this.SetPloWeightage.length = 0;
          this.rout.navigate(["/course"]);
        }
      });
    }
    else {
      alert("Selected PLOs and assign weightage are not matched.");
    }
  }
  CLO_Assessment(x) {
    this.spinner=false;
    var total = this.mark_assignment + this.mark_final + this.mark_lab + this.mark_mid + this.mark_quiz + this.mark_project;
    if (x === 'Addnew') {
      if (total > 100 || total <= 0) {
        alert("Total weightage Range(0-100).Please assign again....!");
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        return;
      }
      else {
        this.serv.Assign_Marks('api/Weightage', '/AssingMarks', {
          'quiz': this.mark_quiz,
          'assignment': this.mark_assignment,
          'lab': this.mark_lab,
          'mid': this.mark_mid,
          'final': this.mark_final,
          'project': this.mark_project,
          'CLO_Id': this.uCloid,
          'Course_Id':Courses.courseId ,
          'Program_Id': Programs.ProgramId,
          'createdBy': sessionStorage.getItem('uname')
        }).subscribe(response => {
          if (response.length != 0) {
            alert("Assessment had done.");
            this.mark_assignment = 0;
            this.mark_final = 0;
            this.mark_lab = 0;
            this.mark_mid = 0;
            this.mark_quiz = 0;
            this.mark_project = 0;
            setTimeout(()=>{ 
              this.spinner=false;
        }, 400);
            this.rout.navigate(["/course"]);
          }
        });
      }
    }
    if (x === 'update') {
      var update = this.Alreadysetassignment + this.Alreadysetfinal + this.Alreadysetlab + this.Alreadysetmid + this.Alreadysetquiz + this.Alreadysetproject;
      if (update > 100 || update <= 0) {
        alert("Total weightage Range(0-100).Please assign again....!");
        this.spinner=false;
        return;
      }
      else {
        this.serv.Assign_Marks('api/Weightage', '/AssingMarksUpdate', {
          'quiz': this.Alreadysetquiz,
          'assignment': this.Alreadysetassignment,
          'lab': this.Alreadysetlab,
          'mid': this.Alreadysetmid,
          'final': this.Alreadysetfinal,
          'project': this.Alreadysetproject,
          'CLO_Id': this.uCloid,
          'Course_Id': Courses.courseId,
          'Program_Id': Programs.ProgramId,
        }).subscribe(response => {
          if (response.length != 0) {
            alert("Assessment had updated.");
            setTimeout(()=>{ 
              this.spinner=false;
        }, 400);
            this.rout.navigate(["/course"]);
          }
        });
      }
    }
  }
}
