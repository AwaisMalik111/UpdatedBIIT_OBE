using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Core.Entities
{
    public class CLOsModal
    {
        public int id { get; set; }
        public string cloName { get; set; }
        public string Coursename { get; set; }
        public string cloDesc { get; set; }
        public int PLOId { get; set; }
        public int ProgramId { get; set; }
        public int courseID { get; set; }
        public int weightage { get; set; }
        public string createdBy { get; set; }
    }

    public class GetCLO
    {
        public string programname { get; set; }
        public string coursename { get; set; }
        public int ploid { get; set; }
        public string ploName { get; set; }
        public int cloid { get; set; }
        public string cloName { get; set; }
    }
    public class CLO_PLO_Mapping
    {
        public string cloname { get; set; }
        public string clodes{ get; set; }
        public string ploname { get; set; }
        public string plodes { get; set; }
        public string ploweightage { get; set; }
        public string coursename { get; set; }
        public int CLO_Id { get; set; }
        public int Course_Id { get; set; }
        public int Program_Id { get; set; }
        public int weightage { get; set; }
        public List<PLO_List> PLO_Id { get; set; }
        public List<PLO_weightage_List> PLO_weightage { get; set; }
    }
    public class PLO_List {
        public int id { get; set; }
        public int value { get; set; }
    }
    public class PLO_weightage_List
    {
        public int weightage { get; set; }
    }
}
