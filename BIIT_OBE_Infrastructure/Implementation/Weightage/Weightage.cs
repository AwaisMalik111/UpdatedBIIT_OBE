using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Weightage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BIIT_OBE_Infrastructure.Implementation.Weightage
{
    public class Weightage : IWeightage
    {
        private IConfiguration Configuration;
        private readonly string connString;
        public Weightage(IConfiguration _configuration)
        {
            Configuration = _configuration;
            connString = this.Configuration.GetConnectionString("BIIT_OBEPortal");
        }
        public async Task<bool> AssingMarks(AssignWeightage obj)
        {
            int total = obj.quiz + obj.assignment + obj.lab + obj.mid + obj.final + obj.project;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "CLO_Assessment";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("quiz", obj.quiz);
                com.Parameters.AddWithValue("assignment", obj.assignment);
                com.Parameters.AddWithValue("lab", obj.lab);
                com.Parameters.AddWithValue("mid", obj.mid);
                com.Parameters.AddWithValue("final", obj.final);
                com.Parameters.AddWithValue("project", obj.project);
                com.Parameters.AddWithValue("Program_Id", obj.Program_Id);
                com.Parameters.AddWithValue("Course_Id", obj.Course_Id);
                com.Parameters.AddWithValue("CLO_Id", obj.CLO_Id);
                com.Parameters.AddWithValue("total", total);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> AssingMarksUpdate(AssignWeightage obj)
        {
            int total = obj.quiz + obj.assignment + obj.lab + obj.mid + obj.final + obj.project;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "CLO_Assessment_Updated";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("quiz", obj.quiz);
                com.Parameters.AddWithValue("assignment", obj.assignment);
                com.Parameters.AddWithValue("lab", obj.lab);
                com.Parameters.AddWithValue("mid", obj.mid);
                com.Parameters.AddWithValue("final", obj.final);
                com.Parameters.AddWithValue("project", obj.project);
                com.Parameters.AddWithValue("Program_Id", obj.Program_Id);
                com.Parameters.AddWithValue("Course_Id", obj.Course_Id);
                com.Parameters.AddWithValue("CLO_Id", obj.CLO_Id);
                com.Parameters.AddWithValue("total", total);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> MapPloWithClo(CLO_PLO_Mapping obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                for (int i = 0; i < obj.PLO_Id.Count; i++)
                {
                    string query = "CLO_PLO_Mapping_with_weightage";
                    SqlCommand com1 = new SqlCommand(query, con);
                    com1.CommandType = CommandType.StoredProcedure;
                    com1.Parameters.AddWithValue("Program_Id", obj.Program_Id);
                    com1.Parameters.AddWithValue("Course_Id", obj.Course_Id);
                    com1.Parameters.AddWithValue("CLO_Id", obj.CLO_Id);
                    com1.Parameters.AddWithValue("PLO_Id", obj.PLO_Id[i].id);
                    com1.Parameters.AddWithValue("PLO_weightage", obj.PLO_weightage[i].weightage);
                    com1.ExecuteNonQuery();
                    PLOTotalCalculation(obj.PLO_Id[i].id, obj.PLO_weightage[i].weightage);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> PLOTotalCalculation(int ploId, int Weightage)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "PLOTotalCalculation";
                SqlCommand com1 = new SqlCommand(query, con);
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.AddWithValue("PLO_Id", ploId);
                com1.Parameters.AddWithValue("PLO_weightage", Weightage);
                com1.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<CLO_PLO_Mapping>> GetRemainingPLOWeightage(CLO_PLO_Mapping obj)
        {
            try
            {
                List<CLO_PLO_Mapping> list = new List<CLO_PLO_Mapping>();
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetRemainingPLOWeightage";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("ProgramId", obj.Program_Id);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    obj = new CLO_PLO_Mapping();
                    obj.Course_Id = int.Parse(sdr["PLO_Id"].ToString());
                    obj.ploname = sdr["PLO_Name"].ToString();
                    obj.plodes = sdr["PLO_desc"].ToString();
                    obj.ploweightage = sdr["PLO_Weightage"].ToString();
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
        public async Task<List<PLO_List>> GetAlreadySetPLOWeightage(CLO_PLO_Mapping obj)
        {
            try
            {
                List<PLO_List> list = new List<PLO_List>();
                PLO_List getId;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAlreadySetPLOWeightage";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("ProgramId", obj.Program_Id);
                com.Parameters.AddWithValue("CourseId", obj.Course_Id);
                com.Parameters.AddWithValue("CLOId", obj.CLO_Id);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    getId = new PLO_List();
                    getId.id = int.Parse(sdr["PLO_Id"].ToString());
                    getId.value = int.Parse(sdr["Weightage"].ToString());
                    list.Add(getId);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<AssignWeightage>> GetCLOSAssessment(CLO_PLO_Mapping obj)
        {
            try
            {
                List<AssignWeightage> list = new List<AssignWeightage>();
                AssignWeightage get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetCLOSAssessment";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("ProgramId", obj.Program_Id);
                com.Parameters.AddWithValue("CourseId", obj.Course_Id);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.quiz = int.Parse(sdr["Quiz"].ToString());
                    get.CLO_Id = int.Parse(sdr["CLO_Id"].ToString());
                    get.assignment = int.Parse(sdr["Assignment"].ToString());
                    get.lab = int.Parse(sdr["Lab"].ToString());
                    get.project = int.Parse(sdr["Project"].ToString());
                    get.mid = int.Parse(sdr["Mid"].ToString());
                    get.final = int.Parse(sdr["Final"].ToString());
                    get.CLO_Name = sdr["CLO_Name"].ToString();
                    get.CLO_Desc = sdr["CLO_Desc"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<AssignWeightage>> CLO_Assessment_Check(CLO_PLO_Mapping obj)
        {

            try
            {
                List<AssignWeightage> list = new List<AssignWeightage>();
                AssignWeightage get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "get_CLO_Assessment";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("CLOId", obj.CLO_Id);
                com.Parameters.AddWithValue("ProgramId", obj.Program_Id);
                com.Parameters.AddWithValue("CourseId", obj.Course_Id);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.quiz = int.Parse(sdr["Quiz"].ToString());
                    get.CLO_Id = int.Parse(sdr["CLO_Id"].ToString());
                    get.assignment = int.Parse(sdr["Assignment"].ToString());
                    get.lab = int.Parse(sdr["Lab"].ToString());
                    get.project = int.Parse(sdr["Project"].ToString());
                    get.mid = int.Parse(sdr["Mid"].ToString());
                    get.final = int.Parse(sdr["Final"].ToString());
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<CLO_PLO_Mapping>> Get_PLOS_CLOS(CLO_PLO_Mapping obj)
        {
            try
            {
                List<CLO_PLO_Mapping> list = new List<CLO_PLO_Mapping>();
                CLO_PLO_Mapping get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "Get_PLOS_CLOS";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("PLO_ID", obj.CLO_Id);
                com.Parameters.AddWithValue("Program_Id", obj.Program_Id);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    get = new CLO_PLO_Mapping();
                    get.CLO_Id = int.Parse(sdr["CLO_Id"].ToString());
                    get.cloname = sdr["CLO_Name"].ToString();
                    get.coursename = sdr["Course_Name"].ToString();
                    get.clodes = sdr["CLO_Desc"].ToString();
                    get.weightage = int.Parse(sdr["Weightage"].ToString());
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<AssignWeightage>> GetCoursesCLOS(CLO_PLO_Mapping obj)
        {
            try
            {
                List<AssignWeightage> list = new List<AssignWeightage>();
                AssignWeightage get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetCoursesCLOS";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("CourseTitle", obj.cloname);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.Assessment_Id = int.Parse(sdr["Assessment_Id"].ToString());
                    get.CLO_Id = int.Parse(sdr["CLO_Id"].ToString());
                    get.quiz = int.Parse(sdr["Quiz"].ToString());
                    get.assignment = int.Parse(sdr["Assignment"].ToString());
                    get.lab = int.Parse(sdr["Lab"].ToString());
                    get.project = int.Parse(sdr["Project"].ToString());
                    get.mid = int.Parse(sdr["Mid"].ToString());
                    get.final = int.Parse(sdr["Final"].ToString());
                    get.CLO_Name = sdr["CLO_Name"].ToString();
                    get.CLO_Desc = sdr["CLO_desc"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<AssignWeightage>> GetAlreadySetWeightageOfPLO()
        {
            try
            {
                List<AssignWeightage> list = new List<AssignWeightage>();
                AssignWeightage get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAlreadySetWeightageOfPLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.CLO_Id = int.Parse(sdr["PLO_Id"].ToString());
                    get.final = int.Parse(sdr["PLO_Weightage"].ToString());
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> AddNewExam(AddExam obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                for (int i = 0; i < obj.assessment_Id.Count; i++)
                {
                    string query = "AddNewExam";
                    SqlCommand com1 = new SqlCommand(query, con);
                    com1.CommandType = CommandType.StoredProcedure;
                    com1.Parameters.AddWithValue("Coursename", obj.Course_name);
                    com1.Parameters.AddWithValue("Section", obj.Section);
                    com1.Parameters.AddWithValue("teachername", obj.Teacher);
                    com1.Parameters.AddWithValue("totalmarks", obj.totalMark);
                    com1.Parameters.AddWithValue("totalQuestions", obj.totalQuestion);
                    com1.Parameters.AddWithValue("assessmenttype", obj.assessmentType);
                    com1.Parameters.AddWithValue("assessment_Id", obj.assessment_Id[i].id);
                    com1.Parameters.AddWithValue("CLO_weightage", obj.CLOWeightage[i].value);
                    com1.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AddExam>> getAllExams() {
            try
            {
                List<AddExam> list = new List<AddExam>();
                AddExam get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllExams";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    get = new AddExam();
                    get.examid = int.Parse(sdr["Exam_Id"].ToString());
                    get.id = int.Parse(sdr["Assessment_Id"].ToString());
                    get.Teacher = sdr["TeacheraName"].ToString();
                    get.Course_name = sdr["CourseName"].ToString();
                    get.assessmentType = sdr["ExamType"].ToString();
                    get.Section = sdr["Section"].ToString();
                    get.totalQuestion = sdr["totalQuestion"].ToString();
                    get.totalMark = sdr["TotalMarks"].ToString();
                    get.CLO = sdr["CLO_Weightage"].ToString();
                    get.cloname = sdr["CLO_Name"].ToString();
                    get.clodesc = sdr["CLO_Desc"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> TeacherMapPloWithClo(CLO_PLO_Mapping obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                for (int i = 0; i < obj.PLO_Id.Count; i++)
                {
                    string query = "CLO_PLO_Mapping";
                    SqlCommand com1 = new SqlCommand(query, con);
                    com1.CommandType = CommandType.StoredProcedure;
                    com1.Parameters.AddWithValue("coursename", obj.coursename);
                    com1.Parameters.AddWithValue("CLO_Id", obj.CLO_Id);
                    com1.Parameters.AddWithValue("PLO_Id", obj.PLO_Id[i].id);
                    com1.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}