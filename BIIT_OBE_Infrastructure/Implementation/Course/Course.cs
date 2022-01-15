using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Courses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace BIIT_OBE_Infrastructure.Implementation.Course
{
    public class Course : ICourse
    {
        private IConfiguration Configuration;
        private readonly string connString;
        public Course(IConfiguration _configuration)
        {
            Configuration = _configuration;
            connString = this.Configuration.GetConnectionString("BIIT_OBEPortal");
        }
        public async Task<bool> UpdateCourses(CourseModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "UpdateCourses";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.Parameters.AddWithValue("name", obj.name);
                com.Parameters.AddWithValue("credithour", obj.CreditHours);
                com.Parameters.AddWithValue("code", obj.code);
                com.Parameters.AddWithValue("coursetype", obj.coursetype);
                com.Parameters.AddWithValue("createdby", obj.createdBy);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        } 
        public async Task<bool> UpdateCLO(CourseModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "UpdateCLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.Parameters.AddWithValue("name", obj.name);
                com.Parameters.AddWithValue("code", obj.code);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        public async Task<bool> AddNewCourses(CourseModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                for (int i = 0; i < obj.programs.Count; i++)
                {
                    string query = "AddNewCourse";
                    SqlCommand com = new SqlCommand(query, con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("name", obj.name);
                    com.Parameters.AddWithValue("credithour", obj.CreditHours);
                    com.Parameters.AddWithValue("code", obj.code);
                    com.Parameters.AddWithValue("coursetype", obj.coursetype);
                    com.Parameters.AddWithValue("createdby", obj.createdBy);
                    com.Parameters.AddWithValue("programname", obj.programs[i].id);
                    com.ExecuteNonQuery();
                }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }
        public async Task<bool> DeleteCourse(CourseModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "DeleteCourse";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.Parameters.AddWithValue("createdby", obj.createdBy);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteCLO(CourseModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "DeleteCLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<CLOsModal>> GetAllCLOs(CLOsModal clo)
        {
            try
            {
                List<CLOsModal> list = new List<CLOsModal>();
                CLOsModal obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllCLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("ProgramId", clo.id);
                com.Parameters.AddWithValue("CourseId", clo.courseID);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    obj = new CLOsModal();
                    obj.id = int.Parse(sdr["CLO_Id"].ToString());
                    obj.cloName = sdr["CLO_Name"].ToString();
                    obj.cloDesc = sdr["CLO_Desc"].ToString();
                    list.Add(obj);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<CourseModal>> GetAllCourses(CourseModal programname)
        {
            try
            {
                List<CourseModal> list = new List<CourseModal>();
                CourseModal obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllCourse";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("ProgramName", programname.id);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    obj = new CourseModal();
                    obj.id = int.Parse(sdr["Course_Id"].ToString());
                    obj.name = sdr["Course_Name"].ToString();
                    obj.code = sdr["Course_Code"].ToString();
                    obj.CreditHours = sdr["Course_CreditHour"].ToString();
                    list.Add(obj);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<GetCLO>> GetCLOS(CLOsModal obj)
        {
            try
            {
                List<GetCLO> list = new List<GetCLO>();
                GetCLO details;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetCLOS";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("programId", obj.ProgramId);
                com.Parameters.AddWithValue("CourseId", obj.courseID);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    details = new GetCLO();
                    details.programname = sdr["Program_Name"].ToString();
                    details.coursename = sdr["Course_Name"].ToString();
                    details.ploid = int.Parse(sdr["PLO_Id"].ToString());
                    details.ploName = sdr["PLO_Name"].ToString();
                    details.cloid = int.Parse(sdr["CLO_Id"].ToString());
                    details.cloName = sdr["CLO_Name"].ToString();
                    list.Add(details);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<CourseDetail>> GetCourseDetails(CourseDetail obj)
        {
            try
            {
                List<CourseDetail> list = new List<CourseDetail>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "ViewCourseCompleteDetalis";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("name", obj.name);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    obj = new CourseDetail();
                    obj.name = sdr["Course_Name"].ToString();
                    obj.cloname = sdr["CLO_Name"].ToString();
                    obj.clodesc = sdr["CLO_Desc"].ToString();
                    obj.ploname = sdr["PLO_Name"].ToString();
                    obj.plodesc = sdr["PLO_Desc"].ToString();
                    list.Add(obj);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<bool> AssignCLOs(CLOsModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "AssignCLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("courseId", obj.courseID);
                com.Parameters.AddWithValue("ProgramId", obj.ProgramId);
                com.Parameters.AddWithValue("name", obj.cloName);
                com.Parameters.AddWithValue("desc", obj.cloDesc);
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> AddCLOs(CLOsModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "AddNewCLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("name", obj.cloName);
                com.Parameters.AddWithValue("desc", obj.cloDesc);
                com.Parameters.AddWithValue("createdBy", obj.createdBy);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }
        public async Task<bool> AssignCourseToTeacher(List<ExcelAllocation> ExcelList)
        {
            try
            {
                List<CourseModal> list = new List<CourseModal>();
                CourseModal obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "ExelAllocationCourse";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    obj = new CourseModal();
                    obj.name = sdr["Course_Name"].ToString();
                    for (int i = 0; i < ExcelList.Count; i++)
                    {
                        if (obj.name == ExcelList[i].Course_Title)
                        {
                            AllocateCourse(ExcelList[i]);
                        }
                    }
                }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }
        public async Task<bool> AllocateCourse(ExcelAllocation ExcelList)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "AssignCourseToTeacher";
                SqlCommand com1 = new SqlCommand(query, con);
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.AddWithValue("name", ExcelList.Course_Title);
                com1.Parameters.AddWithValue("code", ExcelList.Course_Code);
                com1.Parameters.AddWithValue("teacher", ExcelList.Teacher);
                com1.Parameters.AddWithValue("section", ExcelList.Section);
                com1.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<ExcelAllocation>> GetAllAssignedCourses(ExcelAllocation obj)
        {
            try
            {
                List<ExcelAllocation> list = new List<ExcelAllocation>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllAssignedCourses";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("name", obj.Teacher);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    obj = new ExcelAllocation();
                    obj.Course_Title = sdr["CourseName"].ToString();
                    obj.Course_Code = sdr["CourseCode"].ToString();
                    obj.Section = sdr["Section"].ToString();
                    list.Add(obj);
                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> saveMapping(PLOList obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                for (int i = 0; i < obj.abstractMappingArray.Count; i++)
                {
                    string query = "abstractMappingArray";
                    SqlCommand com = new SqlCommand(query, con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("ploid", obj.abstractMappingArray[i].ploid);
                    com.Parameters.AddWithValue("coursename", obj.abstractMappingArray[i].coursename);
                    com.ExecuteNonQuery();
                }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
