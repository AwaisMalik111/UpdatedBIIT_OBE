using BIIT_OBE_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Infrastructure.Interfaces.Weightage
{
    public interface IWeightage
    {
        public Task<bool> AssingMarks(AssignWeightage obj);
        public Task<bool> AssingMarksUpdate(AssignWeightage obj);
        public Task<bool> MapPloWithClo(CLO_PLO_Mapping obj);
        public Task<bool> AddNewExam(AddExam obj);
        public Task<bool> TeacherAssingMarks(AssignWeightage obj);
        public Task<List<CLO_PLO_Mapping>> GetRemainingPLOWeightage(CLO_PLO_Mapping obj);
        public Task<List<CLO_PLO_Mapping>> TeacherGetAlreadySetWeightageOfPLO(CLO_PLO_Mapping obj);
        public Task<List<PLO_List>> GetAlreadySetPLOWeightage(CLO_PLO_Mapping obj);
        public Task<List<AssignWeightage>> GetCLOSAssessment(CLO_PLO_Mapping obj);
        public Task<List<AssignWeightage>> CLO_Assessment_Check(CLO_PLO_Mapping obj);
        public Task<List<CLO_PLO_Mapping>> Get_PLOS_CLOS(CLO_PLO_Mapping obj);
        public Task<List<AssignWeightage>> GetCoursesCLOS(CLO_PLO_Mapping obj);
        public Task<List<AssignWeightage>> GetAlreadySetWeightageOfPLO();
        public Task<List<AddExam>> getAllExams();
        public Task<bool> TeacherMapPloWithClo(CLO_PLO_Mapping obj);
    }
}
