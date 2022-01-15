using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Core.Entities
{
    public class PrgramModal
    {
        public int id{ get; set; }
        public string pname{ get; set; }
        public string pdesc{ get; set; }
        public string createdBy{ get; set; }
    }
    public class PloModal
    {
        public int id{ get; set; }
        public int Programid{ get; set; }
        public string ploname{ get; set; }
        public string ploHead{ get; set; }
        public string plodesc { get; set; }
        public string plopass { get; set; }
        public string createdBy { get; set; }
        public List<selectedPLO> list { get; set; }
    }
    public class selectedPLO {
    public string heading { get; set; }
    public string description { get; set; }
    }
}
