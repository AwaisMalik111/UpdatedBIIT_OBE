using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BIIT_OBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        public readonly IUserAuthentication _user;
        private IConfiguration Configuration;
        public UserAuthController(IUserAuthentication user, IConfiguration _configuration)
        {
            Configuration = _configuration;
            _user = user;
           
        }
        [HttpPost("UserAuthorize")]
        public async Task<List<UserModal>> user([FromBody] UserModal obj)
        {

            List<UserModal> flag = await _user.UserAuthenttication(obj);
            return flag;
        }
        [HttpPost("DetailsCoursesStudent")]
        public async Task<List<UserModal>> DetailsCoursesStudent([FromBody] UserModal obj)
        {
            List<UserModal> flag = await _user.DetailsCoursesStudent(obj);
            return flag;
        }
        [HttpPost("PLOSCourses")]
        public async Task<List<UserModal>> PLOSCourses([FromBody] UserModal obj)
        {
            List<UserModal> flag = await _user.PLOSCourses(obj);
            return flag;
        }
        [HttpGet("GetallTeachers")]
        public async Task<List<UserModal>> teacher()
        {
            List<UserModal> teacher = await _user.getAllTeacher();
            return teacher;
        }
        [HttpGet("GetAllStudents")]
        public async Task<List<UserModal>> GetAllStudents()
        {
            List<UserModal> teacher = await _user.GetAllStudents();
            return teacher;
        }
        [HttpPost("SelectedPLO_GetCLOS")]
        public async Task<List<UserModal>> SelectedPLO_GetCLOS([FromBody] UserModal obj)
        {
            List<UserModal> teacher = await _user.SelectedPLO_GetCLOS(obj);
            return teacher;
        }
        [HttpPost("GetCLOSAssessment")]
        public async Task<List<UserModal>> GetCLOSAssessment([FromBody] UserModal obj)
        {
            List<UserModal> teacher = await _user.GetCLOSAssessment(obj);
            return teacher;
        }
        [HttpPost("AddNewMember")]
        public async Task<bool> addnewmem([FromBody] addNewMember obj)
        {
            bool flag = await _user.AddNewMember(obj);
            return flag;
        }
        [HttpPost("UpdateUser")]
        public async Task<bool> UpdateUser([FromBody] addNewMember obj)
        {
            bool flag = await _user.UpdateUser(obj);
            return flag;
        }
        [HttpPost("DeleteUser")]
        public async Task<bool> DeleteUser([FromBody] UserModal obj)
        {
            bool flag = await _user.DeleteUser(obj);
            return flag;
        }
    }
}
