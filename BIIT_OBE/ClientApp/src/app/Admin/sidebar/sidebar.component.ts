import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
declare const $: any;
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  active: any;
  click: number;
  constructor(private route: Router) {

  }
  ngOnInit() {
    if (this.route.url.endsWith('teacher')) this.tech();
    if (this.route.url.endsWith('transcript')) this.Transcripts();
  }

  tech() {
    this.active = "teac";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/teacher"]);
  }
  Transcripts() {
    this.active = "Transcripts";
    $("#" + this.active).addClass('active');
    this.route.navigate(["/transcript"]);
  }
}
