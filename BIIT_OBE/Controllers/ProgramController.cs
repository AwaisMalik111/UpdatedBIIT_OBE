using BIIT_OBE_Core.Entities;
using BIIT_OBE_Infrastructure.Interfaces.Programs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIIT_OBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IPrograms _program;
        public ProgramController(IPrograms program)
        {
            _program = program;
        }
        [HttpGet("GetAllPrograms")]
        public async Task<List<PrgramModal>> getallprog() {
            List<PrgramModal> list = await _program.getallprogram();
            return list;
        }
        [HttpGet("GetallNotification")]
        public async Task<int> GetallNotification() {
            int list =await _program.GetallNotification();
            return list;
    }
        [HttpPost("addnewprogram")]
        public async Task<bool> AddNewProgrma([FromBody] PrgramModal obj)
        {
            bool flag= await _program.addallprogram(obj);
            return flag;
        }
        [HttpPost("AssignPLO")]
        public async Task<bool> AssignPLO([FromBody] PloModal obj)
        {
            bool flag= await _program.AssignPLO(obj);
            return flag;
        }
        [HttpPost("GetPLOs")]
        public async Task<List<PloModal>> GetPLOs([FromBody] PloModal obj)
        {
            List<PloModal> flag = await _program.GetPLOs(obj);
            return flag;
        }
        [HttpPost("Updateprogram")]
        public async Task<bool> Updateprogram([FromBody] PrgramModal obj)
        {
            bool flag= await _program.Updateprogram(obj);
            return flag;
        }
        [HttpPost("Deleteprogram")]
        public async Task<bool> Deleteprogram([FromBody] PrgramModal obj)
        {
            bool flag= await _program.Deleteprogram(obj);
            return flag;
        }
        [HttpPost("GetAllPLOs")]
        public async Task<List<PloModal>> getallplos(PloModal programName)
        {
            List<PloModal> list = await _program.getallplos(programName);
            return list;
        }
        [HttpPost("UpdatePLO")]
        public async Task<bool> UpdatePLO(PloModal programName)
        {
            bool list = await _program.UpdatePLO(programName);
            return list;
        }
        [HttpPost("DeletePLO")]
        public async Task<bool> DeletePLO(PloModal programName)
        {
            bool list = await _program.DeletePLO(programName);
            return list;
        }
        [HttpPost("GetAllUnassignedPLOS")]
        public async Task<List<PloModal>> GetAllUnassignedPLOS(PloModal programName)
        {
            List<PloModal> list = await _program.GetAllUnassignedPLOS(programName);
            return list;
        }
    }
}
