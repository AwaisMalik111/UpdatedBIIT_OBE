using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Result;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BIIT_OBE_Infrastructure.Implementation.Result
{
    public class Result : IResult
    {
        private IConfiguration Configuration;
        private readonly string connString;
        public Result(IConfiguration _configuration)
        {
            Configuration = _configuration;
            connString = this.Configuration.GetConnectionString("BIIT_OBEPortal");
        }
        public async Task<List<section>> GetSection(section name)
        {
            try
            {
                List<section> list = new List<section>();
                section obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetSection";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("TeacherName", name.Teacher);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new section();
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
        public async Task<List<section>> GetCourses(section name)
        {
            try
            {
                List<section> list = new List<section>();
                section obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetCourses";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("TeacherName", name.Teacher);
                com.Parameters.AddWithValue("section", name.Section);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new section();
                    obj.courses = sdr["CourseName"].ToString();
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
        public async Task<List<section>> GetExam(section name)
        {
            try
            {
                List<section> list = new List<section>();
                section obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetExam";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("TeacherName", name.Teacher);
                com.Parameters.AddWithValue("section", name.Section);
                com.Parameters.AddWithValue("course", name.courses);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new section();
                    obj.examtype = sdr["ExamType"].ToString();
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
        public async Task<List<section>> GetExamType(section name)
        {
            try
            {
                List<section> list = new List<section>();
                section obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetExamType";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("TeacherName", name.Teacher);
                com.Parameters.AddWithValue("section", name.Section);
                com.Parameters.AddWithValue("course", name.courses);
                com.Parameters.AddWithValue("examtype", name.examtype);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new section();
                    obj.examtype = sdr["ExamType"].ToString();
                    obj.examid = int.Parse(sdr["Exam_Id"].ToString());
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
        public async Task<List<section>> GetExamMarks(section name)
        {
            try
            {
                List<section> list = new List<section>();
                section obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetExamMarks";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Examid", name.examid);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new section();
                    obj.examid = int.Parse(sdr["TotalMarks"].ToString());
                    obj.assesid = int.Parse(sdr["Exam_Id"].ToString());
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
        public async Task<bool> SaveResult(StudentResult obj){
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                for (int i = 0; i < obj.ListOfMarks.Count; i++)
                {
                    int x = int.Parse(obj.ListOfMarks[i].totalmarks);
                    string query = "SaveResult";
                    SqlCommand com = new SqlCommand(query, con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("assessmentId", obj.assessemntId);
                    com.Parameters.AddWithValue("Marks", x);
                    com.Parameters.AddWithValue("regno", obj.ListOfMarks[i].regno);
                    await com.ExecuteNonQueryAsync();
                }
                con.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<ResultDetails>> getAllResult()
        {
            try
            {
                List<ResultDetails> list = new List<ResultDetails>();
                ResultDetails obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "getAllResult";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new ResultDetails();
                    obj.regno = sdr["Student_Reg"].ToString();
                    obj.ploid = int.Parse(sdr["PLO_Id"].ToString());
                    obj.regno = sdr["PLO_weightage"].ToString();
                    obj.section = sdr["PLO_"].ToString();
                    obj.course = sdr["CourseName"].ToString();
                    obj.tmarks = sdr["TotalMarks"].ToString();
                    obj.omarks = sdr["ObtainedMarks"].ToString();
                    obj.examtype = sdr["ExamType"].ToString();
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
        public async Task<List<ResultDetails>> ViewCLO(ResultDetails obj)
        {
            try
            {
                List<ResultDetails> list = new List<ResultDetails>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "ViewExamCLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Regno", obj.regno);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new ResultDetails();
                    obj.assesid = int.Parse(sdr["Assessment_Id"].ToString());
                    obj.cloid = int.Parse(sdr["CLO_Id"].ToString());
                    obj.regno = sdr["Student_Reg"].ToString();
                    obj.cloname = sdr["CLO_Name"].ToString();
                    obj.clodesc = sdr["CLO_Desc"].ToString();
                    obj.cloweigh = sdr["CLO_Weightage"].ToString();
                    obj.omarks = sdr["ObtainedMarks"].ToString();
                    obj.tmarks = sdr["TotalMarks"].ToString();
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
        public async Task<List<ResultDetails>> ViewCourse(ResultDetails obj)
        {
            try
            {
                List<ResultDetails> list = new List<ResultDetails>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "ViewCourse";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("assesid", obj.assesid);
                com.Parameters.AddWithValue("Regno", obj.regno);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new ResultDetails();
                    obj.examtype = sdr["ExamType"].ToString();
                    obj.course = sdr["CourseName"].ToString();
                    obj.omarks = sdr["ObtainedMarks"].ToString();
                    obj.tmarks = sdr["TotalMarks"].ToString();
                    obj.section = sdr["Section"].ToString();
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
        public async Task<List<ResultDetails>> ViewPLO()
        {
            try
                {
                List<ResultDetails> list = new List<ResultDetails>();
                ResultDetails obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "ResultDetails";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new ResultDetails();
                    obj.regno = sdr["Student_Reg"].ToString();
                    obj.ploid = int.Parse(sdr["PLO_Id"].ToString());
                    obj.ploname= sdr["PLO_Name"].ToString();
                    obj.plodesc= sdr["PLO_desc"].ToString();
                    obj.plopass= sdr["PLO_Passing"].ToString();
                    obj.weigh = sdr["weightage"].ToString();
                    obj.cloweigh = sdr["weight"].ToString();
                    obj.omarks = sdr["ObtainedMarks"].ToString();
                    obj.tmarks = sdr["TotalMarks"].ToString();
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
        public async Task<List<ResultDetails>> getAllStudentResult(ResultDetails obj)
        {
            try
            {
                List<ResultDetails> list = new List<ResultDetails>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "StudentResultDetails";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("regno",obj.regno);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new ResultDetails();
                    obj.regno = sdr["Student_Reg"].ToString();
                    obj.ploid = int.Parse(sdr["PLO_Id"].ToString());
                    obj.ploname = sdr["PLO_Name"].ToString();
                    obj.plodesc = sdr["PLO_desc"].ToString();
                    obj.plopass = sdr["PLO_Passing"].ToString();
                    obj.weigh = sdr["Weightage"].ToString();
                    obj.cloweigh = sdr["weight"].ToString();
                    obj.omarks = sdr["ObtainedMarks"].ToString();
                    obj.tmarks = sdr["TotalMarks"].ToString();
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

    }
}
