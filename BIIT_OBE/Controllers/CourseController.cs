using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIIT_OBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourse _course;
        public CourseController(ICourse course)
        {
            _course = course;
        }
        [HttpPost("AddNewCourses")]
        public async Task<bool> addcourse([FromBody] CourseModal obj)
        {
            bool flag = await _course.AddNewCourses(obj);
            return flag;
        }
        [HttpPost("UpdateCourses")]
        public async Task<bool> UpdateCourses([FromBody] CourseModal obj)
        {
            bool flag = await _course.UpdateCourses(obj);
            return flag;
        }
        [HttpPost("UpdateCLO")]
        public async Task<bool> UpdateCLO([FromBody] CourseModal obj)
        {
            bool flag = await _course.UpdateCLO(obj);
            return flag;
        }
        [HttpPost("TeacherAssignCLOs")]
        public async Task<bool> TeacherAssignCLOs(CLOsModal obj)
        {
            bool flag = await _course.TeacherAssignCLOs(obj);
            return flag;
        }
        [HttpPost("AssignCLOs")]
        public async Task<bool> AssignCLOs([FromBody] CLOsModal obj)
        {
            bool flag = await _course.AssignCLOs(obj);
            return flag;
        }
        [HttpPost("GetAllCourses")]
        public async Task<List<CourseModal>> GetAllCourses([FromBody] CourseModal obj)
        {
            List<CourseModal> list = await _course.GetAllCourses(obj);
            return list;
        }
        [HttpPost("GetAllCLOs")]
        public async Task<List<CLOsModal>> GetAllCLOs(CLOsModal obj)
        {
            List<CLOsModal> list = await _course.GetAllCLOs(obj);
            return list;
        }
        [HttpPost("TeacherGetAllCLOs")]
        public async Task<List<CLOsModal>> TeacherGetAllCLOs(CLOsModal obj)
        {
            List<CLOsModal> list = await _course.TeacherGetAllCLOs(obj);
            return list;
        }
        [HttpPost("getCourseDetails")]
        public async Task<List<CourseDetail>> getCourseDetails([FromBody] CourseDetail obj)
        {
            List<CourseDetail> list = await _course.GetCourseDetails(obj);
            return list;
        }
        [HttpPost("GetCLOS")]
        public async Task<List<GetCLO>> GetCLOS([FromBody] CLOsModal obj)
        {
            List<GetCLO> list = await _course.GetCLOS(obj);
            return list;
        }
        [HttpPost("DeleteCourse")]
        public async Task<bool> DeleteCourse([FromBody] CourseModal obj)
        {
            bool list = await _course.DeleteCourse(obj);
            return list;
        }
        [HttpPost("DeleteCLO")]
        public async Task<bool> DeleteCLO([FromBody] CourseModal obj)
        {
            bool list = await _course.DeleteCLO(obj);
            return list;
        }
        [HttpPost("TeacherDeleteCLO")]
        public async Task<bool> TeacherDeleteCLO([FromBody] CourseModal obj)
        {
            bool list = await _course.TeacherDeleteCLO(obj);
            return list;
        }

        [HttpPost("ExcelAllocation")]
        public async Task<bool> AssignCourseToTeacher([FromBody] List<ExcelAllocation> ExcelList)
        {
            bool response = await _course.AssignCourseToTeacher(ExcelList);
            return response;
        }
        [HttpPost("GetAllAssignedCourses")]
        public async Task<List<ExcelAllocation>> GetAllAssignedCourses([FromBody] ExcelAllocation obj)
        {
            List<ExcelAllocation> response = await _course.GetAllAssignedCourses(obj);
            return response;
        }
        [HttpPost("GetAllCoursesExcel")]
        public async Task<List<ExcelAllocation>> GetAllCoursesExcel([FromBody] ExcelAllocation obj)
        {
            List<ExcelAllocation> response = await _course.GetAllCoursesExcel(obj);
            return response;
        }
        [HttpPost("saveMapping")]
        public async Task<bool> saveMapping(PLOList obj)
        {
            bool list = await _course.saveMapping(obj);
            return list;
        }
    }
}
