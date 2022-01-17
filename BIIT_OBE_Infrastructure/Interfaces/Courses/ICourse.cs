using BIIT_OBE_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Infrastructure.Interfaces.Courses
{
    public interface ICourse
    {
        public Task<bool> TeacherAssignCLOs(CLOsModal obj);
        public Task<bool> AddNewCourses(CourseModal obj);
        public Task<bool> UpdateCourses(CourseModal obj);
        public Task<bool> UpdateCLO(CourseModal obj);
        public Task<List<CourseModal>> GetAllCourses(CourseModal obj);
        public Task<List<CourseDetail>> GetCourseDetails(CourseDetail obj);
        public Task<List<GetCLO>> GetCLOS(CLOsModal obj);
        public Task<bool> AssignCLOs(CLOsModal obj);
        public Task<bool> DeleteCourse(CourseModal obj);
        public Task<bool> DeleteCLO(CourseModal obj);
        public Task<bool> AssignCourseToTeacher(List<ExcelAllocation> ExcelList);
        public Task<List<CLOsModal>> GetAllCLOs(CLOsModal obj);
        public Task<List<CLOsModal>> TeacherGetAllCLOs(CLOsModal obj);
        public Task<List<ExcelAllocation>> GetAllAssignedCourses(ExcelAllocation obj);
        public Task<bool> saveMapping(PLOList obj);
    }
}
