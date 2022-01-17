using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Core.Entities
{
    public class AssignWeightage
    {
        public int Assessment_Id { get; set; }
        public int quiz { get; set; }
        public int assignment { get; set; }
        public int lab { get; set; }
        public int mid { get; set; }
        public int final { get; set; }
        public int project { get; set; }
        public int CLO_Id { get; set; }
        public int Course_Id { get; set; }
        public int Program_Id { get; set; }
        public string CLO_Name{ get; set; }
        public string CLO_Desc{ get; set; }
        public string coursename{ get; set; }
    }
}
