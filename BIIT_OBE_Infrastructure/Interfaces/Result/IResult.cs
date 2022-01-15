using BIIT_OBE_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Infrastructure.Interfaces.Result
{
    public interface IResult
    {
        public Task<List<section>> GetSection(section obj);
        public Task<List<section>> GetCourses(section obj);
        public Task<List<section>> GetExam(section obj);
        public Task<List<section>> GetExamType(section obj);
        public Task<List<section>> GetExamMarks(section obj);
        public Task<List<ResultDetails>> getAllResult();
        public Task<List<ResultDetails>> getAllStudentResult(ResultDetails obj);
        public Task<List<ResultDetails>> ViewCLO(ResultDetails obj);
        public Task<List<ResultDetails>> ViewCourse(ResultDetails obj);
        public Task<List<ResultDetails>> ViewPLO();
        public Task<bool> SaveResult(StudentResult obj);
    }
}
