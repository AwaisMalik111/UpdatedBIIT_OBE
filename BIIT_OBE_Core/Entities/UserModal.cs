using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Core.Entities
{
   public class UserModal
    {
        public double id { get; set; }
        public string remail { get; set; }
        public string rpassword { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
    public class addNewMember {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname{ get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string createdBy { get; set; }
    }
}
