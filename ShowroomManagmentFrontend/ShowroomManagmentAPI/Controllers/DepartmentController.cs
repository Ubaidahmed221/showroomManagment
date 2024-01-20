using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;


namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment service;

        public DepartmentController(IDepartment _service)
        {
            this.service = _service;
        }

        [HttpGet("GetDepartment")]
        public async Task<string> Getdepartments()
        {
            //return JsonContent.SerializaObject();
            var data = await service.GetDepartment();
            var convertData = JsonConvert.SerializeObject(data);
            return convertData;

        }

        [HttpPost("AddDepartment")]
        public async Task<string> AddDepartment(DepartmentDTO departmentDTO)
        {
            return JsonConvert.SerializeObject(await service.AddDepartment(departmentDTO));

        }
    }
}
