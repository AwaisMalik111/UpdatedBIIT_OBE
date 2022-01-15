using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Core.Entities
{
    public class StudentResult
    {
        public List<ListOfStudent> ListOfMarks { get; set; }
        public int assessemntId { get; set; }
    }
    public class ListOfStudent {
        public string totalmarks { get; set; }
        public string regno { get; set; }
    }
    public class section {
        public int examid { get; set; }
        public int assesid { get; set; }
        public string Section { get; set; }
        public string Teacher { get; set; }
        public string courses { get; set; }
        public string examtype { get; set; }
        
    }
}
