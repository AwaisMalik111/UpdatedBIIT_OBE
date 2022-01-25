using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Core.Entities
{
    public class AddExam
    {
        public string Teacher { get; set; }
        public string Course_name { get; set; }
        public string assessmentType { get; set; }
        public int totalMark { get; set; }
        public string totalQuestion { get; set; }
        public string Section { get; set; }
        public string CLO { get; set; }
        public string cloname { get; set; }
        public string clodesc { get; set; }
        public string status { get; set; }
        public int id { get; set; }
        public int examid { get; set; }
        public List<CloList> clo_name { get; set; }
        public List<CloWeightage> CLOWeightage { get; set; }
    }
    public class CloList {
        public string name{ get; set; }
    }
    public class CloWeightage
    {
        public int value { get; set; }
    }
}
