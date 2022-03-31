using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Core.Entities
{
    public class ExcelAllocation
    {
        public string Course_Title { get; set; }
        public string Course_Code { get; set; }
        public string Teacher { get; set; }
        public string Section { get; set; }
    }
    public class allocation
    {
        public List<ExcelAllocation> ExcelList { get; set; }
    }
}
