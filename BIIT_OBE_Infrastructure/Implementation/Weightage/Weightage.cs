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
                await com.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> TeacherAssingMarks(AssignWeightage obj)
        {
            int total = obj.quiz + obj.assignment + obj.lab + obj.mid + obj.final + obj.project;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "TeacherCLO_Assessment";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("quiz", obj.quiz);
                com.Parameters.AddWithValue("assignment", obj.assignment);
                com.Parameters.AddWithValue("lab", obj.lab);
                com.Parameters.AddWithValue("mid", obj.mid);
                com.Parameters.AddWithValue("final", obj.final);
                com.Parameters.AddWithValue("project", obj.project);
                com.Parameters.AddWithValue("coursename", obj.coursename);
                com.Parameters.AddWithValue("cloname", obj.CLO_Name);
                com.Parameters.AddWithValue("clodesc", obj.CLO_Desc);
                com.Parameters.AddWithValue("total", total);
                await com.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception)
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
                await com.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Approvemapping(AssignWeightage obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query;
                SqlCommand com;
                int x = await GettotalPLOEvaluation(obj.id);
                if (x > 0)
                {
                    query = "update tbl_PLOTotalCalculation set PLO_Weightage=PLO_Weightage+'" + obj.weightage + "' where PLO_Id='" + obj.id + "'";
                    com = new SqlCommand(query, con);
                    await com.ExecuteNonQueryAsync();
                }
                else
                {
                    query = "insert into tbl_PLOTotalCalculation values('" + obj.id + "','" + obj.weightage + "')";
                    com = new SqlCommand(query, con);
                    await com.ExecuteNonQueryAsync();
                }
                query = "Approvemapping";
                com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("plo", obj.id);
                com.Parameters.AddWithValue("clo", obj.CLO_Name);
                com.Parameters.AddWithValue("course", obj.coursename);
                com.Parameters.AddWithValue("weightage", obj.weightage);
                await com.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception)
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
                    await com1.ExecuteNonQueryAsync();
                    await PLOTotalCalculation(obj.PLO_Id[i].id, obj.PLO_weightage[i].weightage);
                }
                return true;
            }
            catch (Exception)
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
                await com1.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception)
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
                SqlDataReader sdr = await com.ExecuteReaderAsync();
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
            catch (Exception)
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
                SqlDataReader sdr = await com.ExecuteReaderAsync();
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
            catch (Exception)
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
                com.Parameters.AddWithValue("cloname", obj.cloname);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.quiz = int.Parse(sdr["Quiz"].ToString());
                    get.assignment = int.Parse(sdr["Assignment"].ToString());
                    get.lab = int.Parse(sdr["Lab"].ToString());
                    get.project = int.Parse(sdr["Project"].ToString());
                    get.mid = int.Parse(sdr["Mid"].ToString());
                    get.final = int.Parse(sdr["Final"].ToString());
                    get.CLO_Name = sdr["cloname"].ToString();
                    get.CLO_Desc = sdr["clodesc"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
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
                SqlDataReader sdr = await com.ExecuteReaderAsync();
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
            catch (Exception)
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
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new CLO_PLO_Mapping();
                    get.cloname = sdr["cloname"].ToString();
                    get.coursename = sdr["Course"].ToString();
                    get.weightage = int.Parse(sdr["Weightage"].ToString());
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
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
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.quiz = int.Parse(sdr["Quiz"].ToString());
                    get.assignment = int.Parse(sdr["Assignment"].ToString());
                    get.lab = int.Parse(sdr["Lab"].ToString());
                    get.project = int.Parse(sdr["Project"].ToString());
                    get.mid = int.Parse(sdr["Mid"].ToString());
                    get.final = int.Parse(sdr["Final"].ToString());
                    get.CLO_Name = sdr["cloname"].ToString();
                    get.CLO_Desc = sdr["clodesc"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AssignWeightage>> GetAllPloNotify()
        {
            try
            {
                List<AssignWeightage> list = new List<AssignWeightage>();
                AssignWeightage get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllPloNotify";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.quiz = int.Parse(sdr["Quiz"].ToString());
                    get.assignment = int.Parse(sdr["Assignment"].ToString());
                    get.lab = int.Parse(sdr["Lab"].ToString());
                    get.project = int.Parse(sdr["Project"].ToString());
                    get.mid = int.Parse(sdr["Mid"].ToString());
                    get.final = int.Parse(sdr["Final"].ToString());
                    get.CLO_Name = sdr["cloname"].ToString();
                    get.CLO_Desc = sdr["clodesc"].ToString();
                    get.coursename = sdr["coursename"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AssignWeightage>> GetAllAssessmentNotify()
        {
            try
            {
                List<AssignWeightage> list = new List<AssignWeightage>();
                AssignWeightage get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllAssessmentNotify";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.quiz = int.Parse(sdr["Quiz"].ToString());
                    get.assignment = int.Parse(sdr["Assignment"].ToString());
                    get.lab = int.Parse(sdr["Lab"].ToString());
                    get.project = int.Parse(sdr["Project"].ToString());
                    get.mid = int.Parse(sdr["Mid"].ToString());
                    get.final = int.Parse(sdr["Final"].ToString());
                    get.CLO_Name = sdr["cloname"].ToString();
                    get.CLO_Desc = sdr["clodesc"].ToString();
                    get.coursename = sdr["coursename"].ToString();
                    get.status = sdr["isApprov"].ToString();
                    if (get.status == "False")
                    {
                        get.status = "Approved";
                    }
                    else
                    {
                        get.status = "Pending";
                    }
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
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
                SqlDataReader sdr = await com.ExecuteReaderAsync();
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
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<CLO_PLO_Mapping>> TeacherGetAlreadySetWeightageOfPLO(CLO_PLO_Mapping obj)
        {
            try
            {
                List<CLO_PLO_Mapping> list = new List<CLO_PLO_Mapping>();
                CLO_PLO_Mapping get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "TeacherGetAlreadySetWeightageOfPLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("coursename", obj.coursename);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new CLO_PLO_Mapping();
                    get.CLO_Id = int.Parse(sdr["PLO_Id"].ToString());
                    get.ploname = sdr["PLO_Name"].ToString();
                    get.plodes = sdr["PLO_desc"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
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
                for (int i = 0; i < obj.clo_name.Count; i++)
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
                    com1.Parameters.AddWithValue("Cloname", obj.clo_name[i].name);
                    com1.Parameters.AddWithValue("CLO_weightage", obj.CLOWeightage[i].value);
                    await com1.ExecuteNonQueryAsync();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AddExam>> getAllExams()
        {
            try
            {
                List<AddExam> list = new List<AddExam>();
                AddExam get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllExams";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AddExam();
                    get.examid = int.Parse(sdr["ExamId"].ToString());
                    get.Teacher = sdr["teacher"].ToString();
                    get.Course_name = sdr["Coursename"].ToString();
                    get.assessmentType = sdr["examtype"].ToString();
                    get.Section = sdr["Section"].ToString();
                    get.totalQuestion = sdr["totalQues"].ToString();
                    get.totalMark = int.Parse(sdr["totalMarks"].ToString());
                    get.CLO = sdr["weight"].ToString();
                    get.cloname = sdr["cloname"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AddExam>> GetAllPloNotifing()
        {
            try
            {
                List<AddExam> list = new List<AddExam>();
                AddExam get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllPloNotifing";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AddExam();
                    get.Course_name = sdr["Course"].ToString();
                    get.cloname = sdr["cloname"].ToString();
                    get.Teacher = sdr["PLO_Name"].ToString();
                    get.assessmentType = sdr["PLO_desc"].ToString();
                    get.id = int.Parse(sdr["PLO_Id"].ToString());
                    get.totalMark = await GettotalPLOEvaluation(get.id);
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> GettotalPLOEvaluation(int id)
        {
            int total = 0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = "select * from tbl_PLOTotalCalculation where PLO_Id='" + id + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader sdr = await com.ExecuteReaderAsync();
            while (sdr.Read())
            {
                total = int.Parse(sdr["PLO_Weightage"].ToString());
            }
            return total;
        }
        public async Task<List<AddExam>> GetAllAssignCourses()
        {
            try
            {
                List<AddExam> list = new List<AddExam>();
                AddExam get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllAssignCourses";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AddExam();
                    get.Course_name = sdr["CourseName"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AddExam>> TeachPLOMapNotify()
        {
            try
            {
                List<AddExam> list = new List<AddExam>();
                AddExam get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "TeachPLOMapNotify";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AddExam();
                    get.Course_name = sdr["Course"].ToString();
                    get.cloname = sdr["cloname"].ToString();
                    get.Teacher = sdr["PLO_Name"].ToString();
                    get.assessmentType = sdr["PLO_desc"].ToString();
                    get.status = sdr["isApprov"].ToString();
                    if (get.status == "False")
                    {
                        get.status = "Approved";
                    }
                    else
                    {
                        get.status = "Pending";
                    }
                    string x = sdr["Weightage"].ToString();
                    if (x != "")
                    {
                        get.examid = int.Parse(x);
                    }
                    get.id = int.Parse(sdr["PLO_Id"].ToString());
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
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
                    string query = "sp_TeacherCLO_PLO_Mapping";
                    SqlCommand com1 = new SqlCommand(query, con);
                    com1.CommandType = CommandType.StoredProcedure;
                    com1.Parameters.AddWithValue("coursename", obj.coursename);
                    com1.Parameters.AddWithValue("cloname", obj.cloname);
                    com1.Parameters.AddWithValue("PLO_Id", obj.PLO_Id[i].id);
                    await com1.ExecuteNonQueryAsync();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ApproveAssessment(CLO_PLO_Mapping obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "HODAssessmentApproval";
                SqlCommand com1 = new SqlCommand(query, con);
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.AddWithValue("coursename", obj.coursename);
                com1.Parameters.AddWithValue("quiz", obj.quiz);
                com1.Parameters.AddWithValue("lab", obj.lab);
                com1.Parameters.AddWithValue("mid", obj.mid);
                com1.Parameters.AddWithValue("project", obj.project);
                com1.Parameters.AddWithValue("final", obj.final);
                com1.Parameters.AddWithValue("assignment", obj.assignment);
                com1.Parameters.AddWithValue("cloname", obj.cloname);
                await com1.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AssignWeightage>> CLOsAssessmentFCAR(CLO_PLO_Mapping obj)
        {
            try
            {
                List<AssignWeightage> list = new List<AssignWeightage>();
                AssignWeightage get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "CLOsAssessmentFCAR";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("coursename", obj.coursename);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new AssignWeightage();
                    get.coursename = sdr["coursename"].ToString();
                    get.quiz = int.Parse(sdr["Quiz"].ToString());
                    get.assignment = int.Parse(sdr["Assignment"].ToString());
                    get.lab = int.Parse(sdr["Lab"].ToString());
                    get.project = int.Parse(sdr["Project"].ToString());
                    get.mid = int.Parse(sdr["Mid"].ToString());
                    get.final = int.Parse(sdr["Final"].ToString());
                    get.CLO_Name = sdr["cloname"].ToString();
                    get.CLO_Desc = sdr["clodesc"].ToString();
                    list.Add(get);
                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<CLO_PLO_Mapping>> GetExamsDetails(CLO_PLO_Mapping obj)
        {
            try
            {
                List<CLO_PLO_Mapping> list = new List<CLO_PLO_Mapping>();
                CLO_PLO_Mapping get;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetExamsDetails";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("coursename", obj.coursename);
                com.Parameters.AddWithValue("cloname", obj.cloname);
                com.Parameters.AddWithValue("examtype", obj.examtype);
                SqlDataReader sdr = await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    get = new CLO_PLO_Mapping();
                    get.coursename = sdr["ExamId"].ToString();
                    get.clodes = sdr["ExamType"].ToString();
                    get.cloname = sdr["GradeA"].ToString();
                    get.quiz= int.Parse(sdr["GradeB"].ToString());
                    get.lab = int.Parse(sdr["GradeC"].ToString());
                    get.final=int.Parse( sdr["GradeD"].ToString());
                    list.Add(get);
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