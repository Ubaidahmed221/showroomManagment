using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpolyeeController : ControllerBase
    {
        public IEmpolyee service;
        public EmpolyeeController(IEmpolyee empolyee)
        {
            this.service = empolyee;
            
        }
        [HttpPost("AddEmpolyee")]
        public async Task<string> AddEmpolyee([FromForm]EmpolyeeDTO empolyeeDTO)
        {
            return JsonConvert.SerializeObject(await service.AddEmpolyee(empolyeeDTO));

        }
    }
}
