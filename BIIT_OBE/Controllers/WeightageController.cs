using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Weightage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BIIT_OBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightageController : ControllerBase
    {
        private IWeightage _weightage;
        public WeightageController(IWeightage weightage)
        {
            _weightage = weightage;
        }
        [HttpPost("AssingMarks")]
        public async Task<bool> AssingMarks([FromBody] AssignWeightage obj)
        {
            bool flag = await _weightage.AssingMarks(obj);
            return flag;
        }
        [HttpPost("ApproveAssessment")]
        public async Task<bool> ApproveAssessment([FromBody] CLO_PLO_Mapping obj)
        {
            bool flag = await _weightage.ApproveAssessment(obj);
            return flag;
        }
        [HttpPost("AssingMarksUpdate")]
        public async Task<bool> AssingMarksUpdate([FromBody] AssignWeightage obj)
        {
            bool flag = await _weightage.AssingMarksUpdate(obj);
            return flag;
        }
        [HttpPost("MapPloWithClo")]
        public async Task<bool> MapPloWithClo([FromBody] CLO_PLO_Mapping obj)
        {
            bool response = await _weightage.MapPloWithClo(obj);
            return response;
        }
        [HttpPost("TeacherMapPloWithClo")]
        public async Task<bool> TeacherMapPloWithClo(CLO_PLO_Mapping obj)
        {
            bool response = await _weightage.TeacherMapPloWithClo(obj);
            return response;
        }
        [HttpPost("GetRemainingPLOWeightage")]
        public async Task<List<CLO_PLO_Mapping>> GetRemainingPLOWeightage([FromBody] CLO_PLO_Mapping obj)
        {
            List<CLO_PLO_Mapping> response = await _weightage.GetRemainingPLOWeightage(obj);
            return response;
        }
        [HttpPost("GetAlreadySetPLOWeightage")]
        public async Task<List<PLO_List>> GetAlreadySetPLOWeightage([FromBody] CLO_PLO_Mapping obj)
        {
            List<PLO_List> response = await _weightage.GetAlreadySetPLOWeightage(obj);
            return response;
        }
        [HttpPost("TeacherGetAlreadySetWeightageOfPLO")]
        public async Task<List<CLO_PLO_Mapping>> TeacherGetAlreadySetWeightageOfPLO([FromBody] CLO_PLO_Mapping obj)
        {
            List<CLO_PLO_Mapping> response = await _weightage.TeacherGetAlreadySetWeightageOfPLO(obj);
            return response;
        }
        [HttpPost("GetCLOSAssessment")]
        public async Task<List<AssignWeightage>> GetCLOSAssessment([FromBody] CLO_PLO_Mapping obj)
        {
            List<AssignWeightage> response = await _weightage.GetCLOSAssessment(obj);
            return response;
        }
        [HttpPost("CLOsAssessmentFCAR")]
        public async Task<List<AssignWeightage>> CLOsAssessmentFCAR([FromBody] CLO_PLO_Mapping obj)
        {
            List<AssignWeightage> response = await _weightage.CLOsAssessmentFCAR(obj);
            return response;
        }
        [HttpPost("GetExamsDetails")]
        public async Task<List<CLO_PLO_Mapping>> GetExamsDetails([FromBody] CLO_PLO_Mapping obj)
        {
            List<CLO_PLO_Mapping> response = await _weightage.GetExamsDetails(obj);
            return response;
        }
        [HttpPost("CLO_Assessment_Check")]
        public async Task<List<AssignWeightage>> CLO_Assessment_Check([FromBody] CLO_PLO_Mapping obj)
        {
            List<AssignWeightage> response = await _weightage.CLO_Assessment_Check(obj);
            return response;
        }
        [HttpPost("Get_PLOS_CLOS")]
        public async Task<List<CLO_PLO_Mapping>> Get_PLOS_CLOS([FromBody] CLO_PLO_Mapping obj)
        {
            List<CLO_PLO_Mapping> response = await _weightage.Get_PLOS_CLOS(obj);
            return response;
        }
        [HttpPost("GetCoursesCLOS")]
        public async Task<List<AssignWeightage>> GetCoursesCLOS([FromBody] CLO_PLO_Mapping obj)
        {
            List<AssignWeightage> response = await _weightage.GetCoursesCLOS(obj);
            return response;
        }
        [HttpGet("GetAlreadySetWeightageOfPLO")]
        public async Task<List<AssignWeightage>> GetAlreadySetWeightageOfPLO()
        {
            List<AssignWeightage> response = await _weightage.GetAlreadySetWeightageOfPLO();
            return response;
        }
        [HttpGet("GetAllPloNotify")]
        public async Task<List<AssignWeightage>> GetAllPloNotify()
        {
            List<AssignWeightage> response = await _weightage.GetAllPloNotify();
            return response;
        }
        [HttpGet("GetAllAssessmentNotify")]
        public async Task<List<AssignWeightage>> GetAllAssessmentNotify()
        {
            List<AssignWeightage> response = await _weightage.GetAllAssessmentNotify();
            return response;
        }
        [HttpPost("AddNewExam")]
        public async Task<bool> AddNewExam([FromBody] AddExam obj)
        {
            bool response = await _weightage.AddNewExam(obj);
            return response;
        }
        [HttpPost("TeacherAssingMarks")]
        public async Task<bool> TeacherAssingMarks([FromBody] AssignWeightage obj)
        {
            bool response = await _weightage.TeacherAssingMarks(obj);
            return response;
        }
        [HttpPost("Approvemapping")]
        public async Task<bool> Approvemapping([FromBody] AssignWeightage obj)
        {
            bool response = await _weightage.Approvemapping(obj);
            return response;
        }
        [HttpGet("getAllExams")]
        public async Task<List<AddExam>> getAllExams()
        {
             List<AddExam> response = await _weightage.getAllExams();
            return response;
        }
        [HttpGet("GetAllPloNotifing")]
        public async Task<List<AddExam>> GetAllPloNotifing()
        {
             List<AddExam> response = await _weightage.GetAllPloNotifing();
            return response;
        }
        [HttpGet("TeachPLOMapNotify")]
        public async Task<List<AddExam>> TeachPLOMapNotify()
        {
             List<AddExam> response = await _weightage.TeachPLOMapNotify();
            return response;
        }
        [HttpGet("GetAllAssignCourses")]
        public async Task<List<AddExam>> GetAllAssignCourses()
        {
             List<AddExam> response = await _weightage.GetAllAssignCourses();
            return response;
        }
    }
}
