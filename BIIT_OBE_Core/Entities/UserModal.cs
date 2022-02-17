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
        public float t { get; set; }
        public float o { get; set; }
        public float plo { get; set; }
        public float clo { get; set; }
        public float p { get; set; }
        public string gra { get; set; }
        public string remail { get; set; }
        public string cloname { get; set; }
        public string rpassword { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string a { get; set; }
        public string s { get; set; }
        public string d { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
        public string r { get; set; }
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
