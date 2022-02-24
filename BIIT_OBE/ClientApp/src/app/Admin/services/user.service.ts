import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl: any;

  constructor(private http: HttpClient) {
    this.baseUrl='';
   }
  TokenAuth<T>(ControllerName: any, MethodeName: any, data: any) {
    return this.http.post(this.baseUrl + ControllerName + MethodeName, data);
  }
  LoginMethod<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  ViewCourse<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  Approvemapping<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetExamType<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  ViewCLO<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  ViewStudentPlo<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  getAllStudentResult<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  SaveResult<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetExamMarks<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  CLOsAssessmentFCAR<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetExam<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  AddNewMember<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  UpdateUser<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  AddNewPRogram<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  Updateprogram<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  UpdatePLO<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  AddNewCourse<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  UpdateCourses<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  AssignCLOs<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetCLOS<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetAllUnassignedPLOS<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetAllCourses<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetCourses<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetPLOs<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetallPLOs<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  getCourseDetails<T>(ControllerName: any, MethodName: any, data) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  DeleteUser<T>(ControllerName: any, MethodName: any, data) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  ExcelAllocation<T>(ControllerName: any, MethodName: any, data) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  Assign_Marks<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  getTeacherName<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  getSection<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  DeletePLO<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetAllCLOs<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  MapPloWithClo<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetRemainingPLOWeightage<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  AddNewExam<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  ApproveAssessment<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  GetExamsDetails<T>(ControllerName: any, MethodName: any, data: any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName, data);
  }
  DetailsCoursesStudent<T>(ControllerName: any, MethodName: any,data:any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName,data);
  }
  SelectedPLO_GetCLOS<T>(ControllerName: any, MethodName: any,data:any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName,data);
  }
  PLOSCourses<T>(ControllerName: any, MethodName: any,data:any) {
    return this.http.post<any>(this.baseUrl + ControllerName + MethodName,data);
  }
  /////////////////////////////////GET Requestes///////////////////////////////////////////////////////////////////

  GetallTeachers<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  DetailsCourses<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetAllStudents<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetallPrograms<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetAllCLO<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetAlreadySetWeightageOfPLO<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  getAllExams<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  getAllResult<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  ViewPLO<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetAllPloNotify<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetAllPloNotifing<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  TeachPLOMapNotify<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetAllAssessmentNotify<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetAllAssignCourses<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
  GetallNotification<T>(ControllerName: any, MethodName: any) {
    return this.http.get<any>(this.baseUrl + ControllerName + MethodName);
  }
}
