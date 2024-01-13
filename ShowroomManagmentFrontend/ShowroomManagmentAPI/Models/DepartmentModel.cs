using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Threading.Tasks;
using ShowroomManagmentAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ShowroomManagmentAPI.Models
{

    public class DepartmentModel : IDepartment
    {
        private readonly ApplicationDbContext db_context;

        public DepartmentModel(ApplicationDbContext dbContext)
        {
            this.db_context = dbContext;
            
        }

        public async Task<ResponseDTO> GetDepartment()
        {
            var response = new ResponseDTO();
            try
            {
              response.Response = await db_context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
