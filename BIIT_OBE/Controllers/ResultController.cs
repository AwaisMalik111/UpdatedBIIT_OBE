using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIIT_OBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        // GET: api/<ResultController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        private readonly IResult _result;
        public ResultController(IResult result)
        {
            _result = result;
        }
        [HttpPost("GetSection")]
        public async Task<List<section>> GetSection([FromBody] section obj)
        {
            List<section> list = await _result.GetSection(obj);
            return list;
        }
        [HttpPost("GetCourses")]
        public async Task<List<section>> GetCourses([FromBody] section obj)
        {
            List<section> list = await _result.GetCourses(obj);
            return list;
        }
        [HttpPost("GetExam")]
        public async Task<List<section>> GetExam([FromBody] section obj)
        {
            List<section> list = await _result.GetExam(obj);
            return list;
        }
        [HttpPost("GetExamType")]
        public async Task<List<section>> GetExamType([FromBody] section obj)
        {
            List<section> list = await _result.GetExamType(obj);
            return list;
        }
        [HttpPost("GetExamMarks")]
        public async Task<List<section>> GetExamMarks([FromBody] section obj)
        {
            List<section> list = await _result.GetExamMarks(obj);
            return list;
        }
        [HttpPost("SaveResult")]
        public async Task<bool> SaveResult([FromBody] StudentResult obj)
        {
            bool response = await _result.SaveResult(obj);
            return response;
        }
        [HttpGet("getAllResult")]
        public async Task<List<ResultDetails>> getAllResult()
        {
            List<ResultDetails> list = await _result.getAllResult();
            return list;
        }
        [HttpPost("getAllStudentResult")]
        public async Task<List<ResultDetails>> getAllStudentResult([FromBody] ResultDetails obj)
        {
            List<ResultDetails> list = await _result.getAllStudentResult(obj);
            return list;
        }
        [HttpPost("ViewCLO")]
        public async Task<List<ResultDetails>> ViewCLO([FromBody] ResultDetails obj)
        {
            List<ResultDetails> list = await _result.ViewCLO(obj);
            return list;
        }
        [HttpPost("ViewCourse")]
        public async Task<List<ResultDetails>> ViewCourse([FromBody] ResultDetails obj)
        {
            List<ResultDetails> list = await _result.ViewCourse(obj);
            return list;
        }
        [HttpGet("ViewPLO")]
        public async Task<List<ResultDetails>> ViewPLO()
        {
            List<ResultDetails> list = await _result.ViewPLO();
            return list;
        }
    }
}
