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
                SqlDataReader sdr = com.ExecuteReader();
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
            catch (Exception ex)
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
                SqlDataReader sdr = com.ExecuteReader();
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
            catch (Exception ex)
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
                SqlDataReader sdr = com.ExecuteReader();
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
            catch (Exception ex)
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
    }
}