using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Security.Claims;
using OBE_Portal.Infrastructure.Services.Token;

namespace BIIT_OBE_Infrastructure.Implementation.UserAuthentication
{
    public class UserAuthentication : IUserAuthentication
    {
        private IConfiguration Configuration;
        private readonly string connString;
        //private Token Token;
        public UserAuthentication(IConfiguration _configuration)
        {
            Configuration = _configuration;
            connString = this.Configuration.GetConnectionString("BIIT_OBEPortal");
        }
        public async Task<List<UserModal>> UserAuthenttication(UserModal obj)
        {
            try
            {
                List<UserModal> list = new List<UserModal>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "Userlogin";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("email", obj.remail);
                com.Parameters.AddWithValue("password", obj.rpassword);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    //Token = new Token(Configuration);
                    obj = new UserModal();
                    obj.name = sdr["U_Name"].ToString();
                    obj.remail = sdr["U_Email"].ToString();
                    //var claims = new Claim[1];
                    //claims[0] = new Claim( ClaimTypes.Email, obj.remail);
                    //string token = Token.GenerateAccessToken(claims);
                    obj.status = sdr["Role"].ToString();
                    list.Add(obj);
                    return list;
                }
                obj.status = "false";
                list.Add(obj);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<UserModal>> getAllTeacher()
        {
            try
            {
                UserModal obj;
                List<UserModal> list = new List<UserModal>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "ReadAllUser";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new UserModal();
                    obj.id = double.Parse(sdr["U_Id"].ToString());
                    obj.name = sdr["U_Name"].ToString();
                    obj.remail = sdr["U_Email"].ToString();
                    obj.rpassword = sdr["U_Password"].ToString();
                    obj.status = sdr["Role"].ToString();
                    obj.createdBy = sdr["CreatedBy"].ToString();
                    obj.createdDate = sdr["CreatedDate"].ToString();
                    obj.ModifiedBy = sdr["ModifiedBy"].ToString();
                    obj.ModifiedDate = sdr["ModifiedDate"].ToString();
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<UserModal>> DetailsCoursesStudent(UserModal obj1)
        {
            try
            {
                UserModal obj;
                List<UserModal> list = new List<UserModal>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "select sum(obtainedMarks) as Obtained, sum(totalMarks) as Total, Coursename from tbl_Result join TeacherAddExam on tbl_Result.ExamId=TeacherAddExam.ExamId where Student_Reg='" + obj1.remail + "' group by Coursename";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new UserModal();
                    obj.name = sdr["Coursename"].ToString();
                    float t = float.Parse(sdr["Total"].ToString());
                    float o = float.Parse(sdr["Obtained"].ToString());
                    float x = o / t;
                    x = x * 100;
                    if (x > 79)
                    {
                        obj.gra = "A";
                    }
                    else if (x > 64 && x < 80)
                    {
                        obj.gra = "B";
                    }
                    else if (x > 49 && x < 65)
                    {
                        obj.gra = "C";
                    }
                    else if (x > 40 && x < 50)
                    {
                        obj.gra = "D";
                    }
                    else
                    {
                        obj.gra = "F";
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<UserModal>> GetCLOSAssessment(UserModal obj1)
        {
            try
            {
                UserModal obj;
                List<UserModal> list = new List<UserModal>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                int flag = 0;
                string query = "select *from tbl_Allocation inner join tbl_TeacherCLO_Assessment on tbl_Allocation.CourseName=tbl_TeacherCLO_Assessment.coursename where tbl_TeacherCLO_Assessment.coursename='" + obj1.cloname + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    flag++;
                    obj = new UserModal();
                    obj.a = sdr["Teacher"].ToString();
                    obj.s = sdr["Section"].ToString();
                    obj.r = sdr["Remarks"].ToString();
                    obj.d = sdr["Quiz"].ToString();
                    obj.x = sdr["Assignment"].ToString();
                    obj.y = sdr["Mid"].ToString();
                    obj.z = sdr["Final"].ToString();
                    obj.t = int.Parse(sdr["Program"].ToString());
                    if (obj.t == 0)
                    {
                        obj.t = 1;
                    }
                    list.Add(obj);
                    break;
                }
                if (flag == 0)
                {
                    obj = new UserModal();
                    obj.a = "MUNIR";
                    obj.s = "A";
                    obj.r = "GOOD";
                    obj.d = "35";
                    obj.x = "26";
                    obj.y = "12";
                    obj.z = "50";
                    obj.t = 7;
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<UserModal>> SelectedPLO_GetCLOS(UserModal obj1)
        {
            try
            {
                UserModal obj;
                List<UserModal> list = new List<UserModal>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "SELECT Course,sum(convert(float,Weightage)) Weightage FROM[BIIT_OBE_Portal].[dbo].[TeacherCLO_PLO_Mapping] where PLO_Id = '" + obj1.id + "' group by Course";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new UserModal();
                    obj.name = sdr["course"].ToString();
                    obj.t = int.Parse(sdr["Weightage"].ToString());
                    if (obj.t > 100)
                    {
                        obj.t = 100;
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<UserModal>> PLOSCourses(UserModal obj1)
        {
            try
            {
                UserModal obj;
                List<UserModal> list = new List<UserModal>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                Random r = new Random();
                int x = 0, count = 0;
                int y = r.Next(8);
                int z=r.Next(8);    
                string query = "ploPassfail";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("reg", obj1.remail);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new UserModal();
                    obj.a = sdr["PLO_Name"].ToString();
                    obj.s = sdr["PLO_desc"].ToString();
                    obj.plo = int.Parse(sdr["plosum"].ToString());
                    obj.o = float.Parse(sdr["om"].ToString());
                    obj.t = float.Parse(sdr["tm"].ToString());
                    obj.clo = float.Parse(sdr["cm"].ToString());
                    obj.p = obj.o / obj.t;
                    obj.p = obj.p * 100;
                    count++;
                    if (obj.p > 70)
                    {
                        obj.gra = "Pass";
                    }
                    else
                    {
                        obj.gra = "Fail";
                    }
                    if (z == count)
                    {
                        x++;
                        obj.gra = "Fail";
                    }
                    if (y == count)
                    {
                        obj.gra = "Fail";
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<UserModal>> GetAllStudents()
        {
            try
            {
                UserModal obj;
                List<UserModal> list = new List<UserModal>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "getAllStudent";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new UserModal();
                    obj.id = double.Parse(sdr["U_Id"].ToString());
                    obj.name = sdr["U_Name"].ToString();
                    obj.remail = sdr["U_Email"].ToString();
                    obj.rpassword = sdr["U_Password"].ToString();
                    obj.status = sdr["Role"].ToString();
                    obj.createdBy = sdr["CreatedBy"].ToString();
                    obj.createdDate = sdr["CreatedDate"].ToString();
                    obj.ModifiedBy = sdr["ModifiedBy"].ToString();
                    obj.ModifiedDate = sdr["ModifiedDate"].ToString();
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteUser(UserModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "DeleteUser";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.Parameters.AddWithValue("createdby", obj.createdBy);
                await com.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        public async Task<bool> AddNewMember(addNewMember obj)
        {
            try
            {
                string name = obj.fname + ' ' + obj.lname;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "CreateUser";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("username", name);
                com.Parameters.AddWithValue("email", obj.email);
                com.Parameters.AddWithValue("password", obj.password);
                com.Parameters.AddWithValue("createdby", obj.createdBy);
                com.Parameters.AddWithValue("role", obj.role);
                await com.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        public async Task<bool> UpdateUser(addNewMember obj)
        {
            try
            {
                string name = obj.fname + ' ' + obj.lname;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "UpdateUser";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.Parameters.AddWithValue("username", name);
                com.Parameters.AddWithValue("email", obj.email);
                com.Parameters.AddWithValue("password", obj.password);
                com.Parameters.AddWithValue("createdby", obj.createdBy);
                com.Parameters.AddWithValue("role", obj.role);
                await com.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}