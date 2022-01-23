using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Core.Entities
{
   public class CourseModal
    {
        public int id { get; set; }
        public string cloname { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string coursetype { get; set; }
        public string CreditHours { get; set; }
        public string createdBy { get; set; }
        public List<ProgramList> programs { get; set; }
    }
    public class PLOList
    {
        public List<abstractMappingArray> abstractMappingArray { get; set; }
    }
    public class abstractMappingArray
    {
        public string coursename { get; set; }
        public int ploid { get; set; }
    }
    public class ProgramList {
        public int id { get; set; }
    }
    public class CourseDetail{
        public string name { get; set; }
        public string cloname { get; set; }
        public string clodesc { get; set; }
        public string ploname { get; set; }
        public string plodesc { get; set; }
    }

}
