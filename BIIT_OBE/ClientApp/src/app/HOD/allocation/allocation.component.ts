import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../../Admin/services/global.service';
import { Router } from '@angular/router';
import { UserService } from '../../Admin/services/user.service';
declare const $: any;
@Component({
  selector: 'app-allocation',
  templateUrl: './allocation.component.html',
  styleUrls: ['./allocation.component.css']
})
export class AllocationComponent implements OnInit {
  allocation: any;
  spinner:boolean;
  constructor(private serv: UserService,
    private rout: Router) {
      this.spinner=true;
    if (sessionStorage.getItem('role') != 'HOD') {
      this.rout.navigate(['/']);
    }
  }
  ngOnInit() {
    setTimeout(()=>{ 
      this.spinner=false;
}, 400);
  }

  uploadExcel(e) {
    this.spinner=true;
    try {
      const fileName = e.target.files[0].name;
      import('xlsx').then(xlsx => {
        let workBook = null;
        let jsonData = null;
        const reader = new FileReader();
        // const file = ev.target.files[0];
        reader.onload = (event) => {
          const data = reader.result;
          workBook = xlsx.read(data, { type: 'binary' });
          jsonData = workBook.SheetNames.reduce((initial, name) => {
            const sheet = workBook.Sheets[name];
            initial[name] = xlsx.utils.sheet_to_json(sheet);
            return initial;
          }, {});
          this.allocation = jsonData[Object.keys(jsonData)[0]];
          setTimeout(function(){$('#datatable').DataTable()}, 500);
          setTimeout(()=>{ 
            this.spinner=false;
      }, 400);
        };
        reader.readAsBinaryString(e.target.files[0]);
      });
    } catch (e) {
      console.log('error', e);
    }
  }
  Allocation() {
    this.spinner=true;
    this.serv.ExcelAllocation('api/Course', '/ExcelAllocation', this.allocation).subscribe(response => {
      if (response) {
        setTimeout(()=>{ 
          this.spinner=false;
    }, 400);
        alert("Allocation Had Been Done.");
        this.allocation='';
       }
    });
  }
}
