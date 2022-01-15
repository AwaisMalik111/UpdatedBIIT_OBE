import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Admin/services/user.service';
import { GlobalService } from '../../Admin/services/global.service';
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-program',
  templateUrl: './program.component.html',
  styleUrls: ['./program.component.css']
})
export class ProgramComponent implements OnInit {
  pname: string;
  newploDesc: any;
  newploHeading: any;
  id: any;
  ploid: any;
  pdesc: string;
  upname: string;
  upploname: string;
  upplodesc: string;
  updesc: string;
  UnassignedPLOS: any;
  assignedPLOS: any;
  programs: any;
  alreadySelectedProgram: any;
  plos: any;
  ploname: any;
  newploPassign: any;
  unewploPassign: any;
  selectedProgramId: any;
  ShowSelectedPLos: any;
  spinner:boolean;
  constructor(private rout: Router,
    private serv: UserService) {
    this.pname = "";
    this.pdesc = "";
    this.ploname = [];
    if (GlobalService.role != 'HOD') {
      this.rout.navigate(['/']);
      this.spinner=true;
    }
  }
  ngOnInit() {
    this.getAllPrograms();
    setTimeout(function () { $('#datatable').DataTable() }, 500);
  }
  SelectedPLOs(x, index, checkedProp) {
    if (checkedProp) {
      this.ploname.push({ heading: x.ploname, description: x.plodesc, checked: true })
    } else {
      this.ploname.splice(index, 1);
    }

  }
  AddNewProgram() {
    this.spinner=true;
    if (this.pname === '' || this.pdesc === '') {
      alert("Please fill are the required Information....!");
      this.spinner=false;
      return;
    }
    this.serv.AddNewPRogram("api/Program", "/addnewprogram",
      { 'pname': this.pname, 'pdesc': this.pdesc, 'createdBy': GlobalService.uname }).subscribe(response => {
        if (response) {
          alert("Program added successfully.")
          this.pname = "";
          this.pdesc = "";
          setTimeout(()=>{ 
            this.spinner=false;
      }, 400);
          this.getAllPrograms();
        }
      });
  }
  getAllPrograms() {
    this.spinner=true;
    this.serv.GetallPrograms('api/Program', '/GetAllPrograms').subscribe(response => {
      if (response) {
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        this.programs = response;        
      }
    });
  }
  AssignPlos() {
    this.spinner=true;
    if (this.newploDesc === "" || this.newploPassign === "" ||  this.newploHeading === "") {
      alert("Please fill are the required Information....!");
      this.spinner=false;
      return;
    }
    this.serv.AddNewPRogram("api/Program", "/AssignPLO",
      {
        'Programid': this.selectedProgramId,
        'ploHead': this.newploHeading,
        'plopass': this.newploPassign,
        'plodesc': this.newploDesc,
        'list': this.ploname,
        'createdBy': GlobalService.uname
      }).subscribe(response => {
        if (response) {
          alert("PLO Assinged successfully.");
          this.newploHeading = "";
          this.newploPassign = "";
          this.newploDesc = "";
          setTimeout(()=>{ 
            this.spinner=false;
      }, 400);
          this.ShowPlos(this.selectedProgramId);
        }
      });
  }
  getAllPlos() {
    this.serv.GetallPLOs('api/Program', '/GetAllPLOs', { 'Programid': this.selectedProgramId }).subscribe(response => {
      if (response.length>0) {  
        this.plos = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        this.assignedPLOS = response;
    }else{
      this.plos = response;
        this.assignedPLOS = response;
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
    }
    });
  }
  DeleteProgram() {
    if (confirm("Are you sure to delete? ")) {
      this.serv.DeleteUser("api/Program/", "Deleteprogram", { 'id': this.id, 'CreatedBy': GlobalService.uname }).subscribe(response => {
        if (response) {
          alert("Program Deleted Successfully.");
          setTimeout(()=>{ 
            this.spinner=false;
      }, 400);
          this.getAllPrograms();
        }

      });
    }
  }
  ProgramDetails(item) {
    GlobalService.programdetail = item;
    this.rout.navigate(['/viewprograms']);
  }
  UpdateProgramDetail(item) {
    this.id = item.id;
    this.upname = item.pname;
    this.updesc = item.pdesc;
  }
  UpdateProgram() {
    this.spinner=true;
    if (this.upname === "" || this.updesc === "") {
      alert("Please fill are the required Information....!");
      setTimeout(()=>{ 
        this.spinner=false;
  }, 400);
      return;
    }
    this.serv.Updateprogram("api/Program", "/Updateprogram",
      { 'id': this.id, 'pname': this.upname, 'pdesc': this.updesc, 'createdBy': GlobalService.uname }).subscribe(response => {
        if (response) {
          alert("Program updated successfully.")
          this.pname = "";
          this.pdesc = "";
          setTimeout(()=>{ 
            this.spinner=false;
      }, 400);
          this.getAllPrograms();
        }
      });
  }
  ShowPlos(item) {
    this.spinner=false;
    this.selectedProgramId = item;
    this.getAllPlos();
    this.GetAllUnassignedPLOS();
  }
  GetAllUnassignedPLOS() {

    this.serv.GetAllUnassignedPLOS('api/Program', '/GetAllUnassignedPLOS', { 'Programid': this.selectedProgramId }).subscribe(response => {
      if (response) {
        this.UnassignedPLOS = response;
      }
    });
  }
  UpdatePLODetail(item) {
    this.ploid = item.id;
    this.unewploPassign = item.plopass
    this.upploname = item.ploname;
    this.upplodesc = item.plodesc;
  }
  Updateplo() {
    this.spinner=true;
    if (this.upploname === "" || this.upplodesc === ""|| this.unewploPassign === "") {
      alert("Please fill are the required Information....!");
      setTimeout(()=>{ 
        this.spinner=false;
  }, 400);
      return;
    }
    this.serv.UpdatePLO("api/Program", "/UpdatePLO",
      {
        'Programid': this.selectedProgramId, 'id': this.ploid,
        'ploHead': this.upploname,
        'plopass': this.unewploPassign,
        'plodesc': this.upplodesc,
      }).subscribe(response => {
        if (response) {
          alert("PLO Updated successfully.");
          setTimeout(()=>{ 
            this.spinner=false;
      }, 400);
          this.ngOnInit();
        }
      });
  }
  DeletePLO(item) {
    if (confirm("Are you sure to delete? ")) {
      this.serv.DeletePLO("api/Program/", "DeletePLO", { 'id': item, 'Programid': this.selectedProgramId, 'CreatedBy': GlobalService.uname }).subscribe(response => {
        if (response) {
          setTimeout(()=>{ 
            this.spinner=false;
      }, 400);
          alert("PLO Deleted Successfully.");
          this.ShowPlos(this.selectedProgramId);        
        }
      });
    }
  }
}
