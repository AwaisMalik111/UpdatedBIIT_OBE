import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Admin/header/header.component';
import { SidebarComponent } from './Admin/sidebar/sidebar.component';
import { LoginComponent } from './login/login.component';
import { TeacherComponent } from './Admin/teacher/teacher.component';
import { CLOManagementComponent } from './HOD/clo-management/clo-management.component';
import { PloMappingComponent } from './HOD/Result/plo-mapping.component';
import { ProgramComponent } from './HOD/program/program.component';
import { CoursesComponent } from './HOD/course/courses.component';
import { HodNotifyComponent } from './HOD/hod-notify/hod-notify.component';
import { FooterComponent } from './Admin/footer/footer.component';
import { UserDetailsComponent } from './Admin/user-details/user-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { TsidebarComponent } from './Teacher/tsidebar/tsidebar.component';
import { AllocationComponent } from './HOD/allocation/allocation.component';
import { HODSidebarComponent } from './HOD/hod-sidebar/hod-sidebar.component';
import { HclosComponent } from './HOD/CLOsSummary/hclos.component';
import { PlosComponent } from './HOD/PLOsSummary/plos.component';
import { ClosComponent } from './Teacher/Result/clos.component';
import { ExamsComponent } from './Teacher/exams/exams.component';
import { ResultComponent } from './Student/result/result.component';
import { AssignedCoursesComponent } from './Teacher/assigned-courses/assigned-courses.component';
import { TeacherClosComponent } from './Teacher/teacher-clos/teacher-clos.component';
import { TeacherNotifyComponent } from './Teacher/teacher-notify/teacher-notify.component';
import { ApprovedComponent } from './HOD/approved/approved.component';
import { FCARComponent } from './Teacher/fcar/fcar.component';
import { BriefTranscriptComponent } from './Admin/brief-transcript/brief-transcript.component';
import { StudentDetailsComponent } from './Admin/student-details/student-details.component';

@NgModule({
  declarations: [
    BriefTranscriptComponent,
    StudentDetailsComponent,
    TeacherClosComponent,
    HodNotifyComponent,
    ApprovedComponent,
    TeacherNotifyComponent,
    ResultComponent,
    FCARComponent,
    PloMappingComponent,
    CLOManagementComponent,
    HclosComponent,
    PlosComponent,
    AssignedCoursesComponent,
    ExamsComponent,
    ClosComponent,
    HODSidebarComponent,
    AllocationComponent,
    TsidebarComponent,
    AppComponent,
    FooterComponent,
    LoginComponent,
    TeacherComponent,
    ProgramComponent,
    CoursesComponent,
    SidebarComponent,
    HeaderComponent,
    UserDetailsComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'teacher', component: TeacherComponent, }, //for admin
      { path: 'studentDetails', component: StudentDetailsComponent, }, //for admin
      { path: 'transcript', component: BriefTranscriptComponent, }, //for admin
      { path: 'userdetails', component: UserDetailsComponent, }, //for admin
      //for Hod
      { path: 'program', component: ProgramComponent, },
      { path: 'course', component: CoursesComponent, },
      { path: 'allocation', component: AllocationComponent, },
      { path: 'clos', component: HclosComponent, },
      { path: 'plos', component: PlosComponent, },
      { path: 'HodViewResult', component: PloMappingComponent, },
      { path: 'CLOAssessment', component: CLOManagementComponent, },
      { path: 'Notify', component: HodNotifyComponent, },
      { path: 'Approved', component: ApprovedComponent, },
      //for teachers
      { path: 'AssignedCoursesComponent', component: AssignedCoursesComponent, },
      { path: 'TeacherViewResult', component: ClosComponent, },
      { path: 'ExamsComponent', component: ExamsComponent, },
      { path: 'Closmanagement', component: TeacherClosComponent, },
      { path: 'TeacherNotify', component: TeacherNotifyComponent, },
      { path: 'FCARC', component: FCARComponent, },
      {path:'StudentViewResult',component:ResultComponent}
    ]),
    BrowserAnimationsModule,
    // ToastrModule.forRoot({
    //   closeButton:true,
    //   progressBar:true,
    //   progressAnimation:'increasing',
    //   tapToDismiss:true,
    //   onActivateTick:true,
    //   extendedTimeOut:1000,
    //   enableHtml:true
    // }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
