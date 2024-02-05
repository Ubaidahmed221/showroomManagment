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

        public async Task<ResponseDTO> AddDepartment(DepartmentDTO departmentDTO)
        {
            var response = new ResponseDTO();
            try
            {
                var department = new Department()
                {
                    Name = departmentDTO.Name,
                    Description = departmentDTO.Description
                };

              await  db_context.Departments.AddAsync(department);
                await db_context.SaveChangesAsync();
                response.Response = "Department Created Successfully";

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseDTO> DeleteDepartment(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var data = await db_context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    db_context.Departments.Remove(data);
                    await db_context.SaveChangesAsync();
                    response.Response = "Department Deleted Successfully";

                }
                else
                {
                    response.Response = "Department Not defined ID";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;

            }
            return response;
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

        public async Task<ResponseDTO> GetDepartmentById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var department = await db_context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (department == null)
                {
                    response.StatusCode = 404;
                }
                else
                {
                    response.Response = department;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;

            }
            return response;
        }

        public async Task<ResponseDTO> UpdateDepartment(DepartmentDTO departmentDTO)
        {
            var response = new ResponseDTO();
            try
            {
                var record = await db_context.Departments.Where(x => x.Id == departmentDTO.Id).FirstOrDefaultAsync();
                record.Name = departmentDTO.Name;
                record.Description = departmentDTO.Description;
                db_context.Departments.Update(record);
                await db_context.SaveChangesAsync();
                response.Response = "Department Updated Successfully";
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;

            }
            return response;
        }

       
    }
}
