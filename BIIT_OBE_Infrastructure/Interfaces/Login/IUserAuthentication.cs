using BIIT_OBE_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Infrastructure.Interfaces.Login
{
    public interface IUserAuthentication
    {
       Task<List<UserModal>> UserAuthenttication(UserModal obj);
        Task<bool> AddNewMember(addNewMember obj);
        Task<bool> UpdateUser(addNewMember obj);
        Task<bool> DeleteUser(UserModal obj);
       Task<List<UserModal>> getAllTeacher();
       Task<List<UserModal>> GetAllStudents();
    }
}
