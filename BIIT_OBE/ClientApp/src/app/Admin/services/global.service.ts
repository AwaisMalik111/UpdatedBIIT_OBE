import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export abstract class GlobalService {
  static role:string;
  static uname:string;
  static uemail:string;
  static upass:string;
  static createdBy:string;
  static createdDate:string;
  static modifiedBy:string;
  static modifiedDate:string;
  static programdetail:any;
  static plodetail:any;
  constructor() {
   }
}
export abstract class Courses {
  static courseId:string;
  static coursename:string;
  static coursecode:string;
  static coursecredithours:string;
  constructor() {
   }
}
export abstract class Programs {
  static ProgramId:string;
  static programname:string;
  constructor() {
   }
}
export abstract class Teacher {
  static teachername:string;
  static emailemail:string;
  constructor() {
   }
}