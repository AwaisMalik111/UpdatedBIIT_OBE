using BIIT_OBE_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIIT_OBE_Infrastructure.Interfaces.Programs
{
   public interface IPrograms
    {
        Task<List<PrgramModal>> getallprogram();
        Task<List<PloModal>> getallplos(PloModal programName);
        Task<List<PloModal>> GetPLOs(PloModal obj);
        Task<bool> UpdatePLO(PloModal obj);
        Task<bool> DeletePLO(PloModal obj);
        Task<List<PloModal>> GetAllUnassignedPLOS(PloModal obj);
        Task<bool> addallprogram(PrgramModal obj);
        Task<bool> AssignPLO(PloModal obj);
        Task<bool> Updateprogram(PrgramModal obj);
        Task<bool> Deleteprogram(PrgramModal obj);
    }
}
