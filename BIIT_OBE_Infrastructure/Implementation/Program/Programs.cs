using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Programs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Infrastructure.Implementation.Program
{
    public class Programs : IPrograms
    {
        private IConfiguration Configuration;
        private readonly string connString;
        public Programs(IConfiguration _configuration)
        {
            Configuration = _configuration;
            connString = this.Configuration.GetConnectionString("BIIT_OBEPortal");
        }
        public async Task<List<PrgramModal>> getallprogram()
        {
            try
            {
                List<PrgramModal> list = new List<PrgramModal>();
                PrgramModal obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "ViewAllPrograms";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr =await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new PrgramModal();
                    obj.id = int.Parse(sdr["Program_Id"].ToString());
                    obj.pname = sdr["Program_Name"].ToString();
                    obj.pdesc = sdr["Program_Desc"].ToString();
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
        public async Task<List<PloModal>> GetPLOs(PloModal programName)
        {
            try
            {
                List<PloModal> list = new List<PloModal>();
                PloModal obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetPlos";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("programID", programName.ploname);
                SqlDataReader sdr =await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new PloModal();
                    obj.id = int.Parse(sdr["PLO_Id"].ToString());
                    obj.ploname = sdr["PLO_Name"].ToString();
                    obj.plodesc = sdr["PLO_desc"].ToString();
                    obj.plopass = sdr["PLO_Passing"].ToString();
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
        public async Task<List<PloModal>> GetAllUnassignedPLOS(PloModal programName)
        {
            try
            {
                List<PloModal> list = new List<PloModal>();
                PloModal obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetAllUnassignedPLOS";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("programid", programName.Programid);
                SqlDataReader sdr =await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new PloModal();
                    obj.id = int.Parse(sdr["PLO_Id"].ToString());
                    obj.ploname = sdr["PLO_Name"].ToString();
                    obj.plodesc = sdr["PLO_desc"].ToString();
                    obj.plopass = sdr["PLO_Passing"].ToString();
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
        public async Task<List<PloModal>> getallplos(PloModal programName)
        {
            try
            {
                List<PloModal> list = new List<PloModal>();
                PloModal obj;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetSelectedPlos";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("programid", programName.Programid);
                SqlDataReader sdr =await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    obj = new PloModal();
                    obj.id = int.Parse(sdr["PLO_Id"].ToString());
                    obj.ploname = sdr["PLO_Name"].ToString();
                    obj.plodesc = sdr["PLO_desc"].ToString();
                    obj.plopass = sdr["PLO_Passing"].ToString();
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
        public async Task<int> GetallNotification()
        {
            try
            {
                int x = 0;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "select count(*) count from tbl_TeacherCLO_Assessment where isApprov=1";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader sdr =await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    x = int.Parse(sdr["count"].ToString());
                }
                con.Close();
                x = x + await GetaNotification();
                return x;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetaNotification()
        {
            try
            {
                int x = 0;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "select count(*) count from TeacherCLO_PLO_Mapping where isApprov=1";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader sdr =await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    x = int.Parse(sdr["count"].ToString());
                }
                con.Close();

                return x;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<bool> UpdatePLO(PloModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "UpdatePLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.Parameters.AddWithValue("@programid", obj.Programid);
                com.Parameters.AddWithValue("name", obj.ploHead);
                com.Parameters.AddWithValue("description", obj.plodesc);
                com.Parameters.AddWithValue("plopass", obj.plopass);
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
        public async Task<bool> Updateprogram(PrgramModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "UpdatePrograms";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.Parameters.AddWithValue("name", obj.pname);
                com.Parameters.AddWithValue("description", obj.pdesc);
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
        public async Task<int> getPloId(PloModal obj)
        {
            try
            {
                int id = 0;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "GetPloId";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("PLO", obj.ploHead);
                SqlDataReader sdr =await com.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    id = int.Parse(sdr["PLO_Id"].ToString());
                }
                return id;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<bool> AssignPLO(PloModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query;
                SqlCommand com;
                if (obj.ploHead!=null && obj.plodesc!=null)
                {
                    query = "AddPlo";
                    com = new SqlCommand(query, con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("programid", obj.Programid);
                    com.Parameters.AddWithValue("PLO", obj.plodesc);
                    com.Parameters.AddWithValue("PLOHead", obj.ploHead);
                    com.Parameters.AddWithValue("plopass", obj.plopass);
                    await com.ExecuteNonQueryAsync();
                    con.Close();
                }
                if (obj.list.Count>0)
                {
                    for (int i = 0; i < obj.list.Count; i++)
                    {
                        query = "AddPlo";
                        com = new SqlCommand(query, con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("programid", obj.Programid);
                        com.Parameters.AddWithValue("PLO", obj.list[i].description);
                        com.Parameters.AddWithValue("PLOHead", obj.list[i].heading);
                        com.Parameters.AddWithValue("plopass", obj.plopass);
                        await com.ExecuteNonQueryAsync();
                    }
                }
                
                con.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> addallprogram(PrgramModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "CreatePrograms";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("name", obj.pname);
                com.Parameters.AddWithValue("description", obj.pdesc);
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
        public async Task<bool> Deleteprogram(PrgramModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "Deleteprogram";
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
        public async Task<bool> DeletePLO(PloModal obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = "DeletePLO";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", obj.id);
                com.Parameters.AddWithValue("programid", obj.Programid);
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
